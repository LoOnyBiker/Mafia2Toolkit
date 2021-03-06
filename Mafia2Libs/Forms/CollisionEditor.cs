﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Gibbed.Illusion.FileFormats.Hashing;
using Mafia2;
using static Mafia2.M2TStructure;

namespace Mafia2Tool
{
    public partial class CollisionEditor : Form
    {
        private FileInfo collisionFile;

        public CollisionEditor(FileInfo file)
        {
            InitializeComponent();
            Localise();
            collisionFile = file;
            CheckCollision();
            ShowDialog();
            ToolkitSettings.UpdateRichPresence("Using the Collision editor.");
        }

        private void Localise()
        {
            ContextDelete.Text = Language.GetString("$COLLISION_DELETE");
            deletePlacementToolStripMenuItem.Text = Language.GetString("$PLACEMENT_DELETE");
            openM2T.FileName = Language.GetString("$SELECT_MODEL_FILE");
            fileToolButton.Text = Language.GetString("$FILE");
            saveToolStripMenuItem.Text = Language.GetString("$SAVE");
            reloadToolStripMenuItem.Text = Language.GetString("$RELOAD");
            exitToolStripMenuItem.Text = Language.GetString("$EXIT");
            toolsButton.Text = Language.GetString("$TOOLS");
            addButton.Text = Language.GetString("$COLLISION_ADD");
            addNewPlacementToolStripMenuItem.Text = Language.GetString("$PLACEMENT_ADD");
            Text = Language.GetString("$COLLISION_EDITOR_TITLE");
        }

        /// <summary>
        /// make sure collisions can load; and then proceed.
        /// </summary>
        public void CheckCollision()
        {
            SceneData.Collisions = new Collision(collisionFile.FullName);
            LoadInCollision();
        }

        /// <summary>
        /// Insert all collisions into the editor.
        /// </summary>
        public void LoadInCollision()
        {
            treeView1.Nodes.Clear();
            for (int i = 0; i != SceneData.Collisions.NXSData.Count; i++)
            {
                Collision.NXSStruct nxsData = SceneData.Collisions.NXSData.ElementAt(i).Value;

                TreeNode node = new TreeNode(nxsData.Hash.ToString());
                node.Tag = nxsData;
                node.Name = nxsData.Hash.ToString();


                M2TStructure model = new M2TStructure();
                model.Lods = new Lod[1];
                model.Lods[0] = new Lod();

                ;
                model.Lods[0].Vertices = new Vertex[nxsData.Data.Vertices.Length];

                for (int x = 0; x != model.Lods[0].Vertices.Length; x++)
                {
                    model.Lods[0].Vertices[x] = new Vertex();
                    model.Lods[0].Vertices[x].Position = nxsData.Data.Vertices[x];
                }

                List<CollisionMaterials> typeList = new List<CollisionMaterials>();
                List<List<Short3>> values = new List<List<Short3>>();

                for (int x = 0; x != nxsData.Data.Materials.Length; x++)
                {
                    CollisionMaterials[] mats = nxsData.Data.Materials;
                    Int3[] triangles = nxsData.Data.Triangles;

                    if (!typeList.Contains(mats[x]))
                    {
                        typeList.Add(mats[x]);
                        values.Add(new List<Short3>());
                        values[typeList.Count-1].Add(new Short3(triangles[x]));
                    }
                    else
                    {
                        for(int y = 0; y != typeList.Count; y++)
                        {
                            if(typeList[y] == mats[x])
                                values[y].Add(new Short3(triangles[x]));
                        }
                    }
                }

                model.Lods[0].Parts = new ModelPart[typeList.Count];

                for(int x = 0; x != typeList.Count; x++)
                {
                    model.Lods[0].Parts[x] = new ModelPart();
                    model.Lods[0].Parts[x].Indices = values[x].ToArray();
                    model.Lods[0].Parts[x].Material = typeList[x].ToString();
                }

                model.ExportCollisionToM2T(node.Name);
                treeView1.Nodes.Add(node);
            }

            CustomEDD frame = new CustomEDD();
            for (int i = 0; i != SceneData.Collisions.Placements.Count; i++)
            {
                Collision.Placement data = SceneData.Collisions.Placements[i];
                CustomEDD.Entry entry = new CustomEDD.Entry();

                entry.LodCount = 1;
                entry.LODNames = new string[1];
                entry.LODNames[0] = data.Hash.ToString();
                entry.Position = data.Position;
                entry.Rotation = new Matrix33();

                for (int x = 0; x != treeView1.Nodes.Count; x++)
                {
                    if (data.Hash.ToString() == treeView1.Nodes[x].Name)
                    {
                        TreeNode node = new TreeNode(treeView1.Nodes[x].Nodes.Count + 1.ToString());
                        node.Tag = data;
                        node.Name = treeView1.Nodes[x].Nodes.Count + 1.ToString();

                        treeView1.Nodes[x].Nodes.Add(node);
                    }
                }
                frame.Entries.Add(entry);
            }
            frame.EntryCount = frame.Entries.Count;
            using (BinaryWriter writer = new BinaryWriter(File.Create("collisions/frame.edd")))
            {
                frame.WriteToFile(writer);
            }
        }

        /// <summary>
        /// Insert new mesh into the collision data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCollisionModel(object sender, System.EventArgs e)
        {
            //make sure an actual model has been selected.
            if (openM2T.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Failed to select an M2T model.", "Toolkit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            M2TStructure colModel = new M2TStructure();

            if (openM2T.FileName.ToLower().EndsWith(".m2t"))
                colModel.ReadFromM2T(new BinaryReader(File.Open(openM2T.FileName, FileMode.Open)));
            else if (openM2T.FileName.ToLower().EndsWith(".fbx"))
                colModel.ReadFromFbx(openM2T.FileName);

            //crash happened/
            if (colModel.Lods[0] == null)
                return;

            Collision.NXSStruct nxsData = new Collision.NXSStruct();
            nxsData.Hash = FNV64.Hash(colModel.Name);
            nxsData.Data.BuildBasicCollision(colModel.Lods[0]);
            nxsData.Sections = new Collision.Section[colModel.Lods[0].Parts.Length];

            int curEdges = 0;
            for (int i = 0; i != nxsData.Sections.Length; i++)
            {
                nxsData.Sections[i] = new Collision.Section();
                nxsData.Sections[i].Unk1 = (int)Enum.Parse(typeof(CollisionMaterials), colModel.Lods[0].Parts[i].Material)-2;
                nxsData.Sections[i].Start = curEdges;
                nxsData.Sections[i].NumEdges = colModel.Lods[0].Parts[i].Indices.Length*3;
                curEdges += colModel.Lods[0].Parts[i].Indices.Length * 3;
            }

            Collision.Placement placement = new Collision.Placement();
            placement.Hash = nxsData.Hash;
            placement.Unk5 = 128;
            placement.Unk4 = -1;
            placement.Position = new Vector3(0, 0, 0);
            placement.Rotation = new Vector3(0);


            SceneData.Collisions.NXSData.Add(nxsData.Hash, nxsData);
            SceneData.Collisions.Placements.Add(placement);
            treeView1.Nodes.Clear();
            LoadInCollision();
        }

        private void CollisionMaterialTest(object sender, System.EventArgs e)
        {
            if (treeView1.SelectedNode.Tag == null)
                return;

            if (treeView1.SelectedNode.Tag.GetType() != typeof(Collision.NXSStruct))
                return;

            Collision.NXSStruct data = (Collision.NXSStruct)treeView1.SelectedNode.Tag;
            CollisionMaterials[] mats = data.Data.Materials;
            List<CollisionMaterials> typeList = new List<CollisionMaterials>();
            List<int> values = new List<int>();

            for (int x = 0; x != mats.Length; x++)
            {
                if (!typeList.Contains(mats[x]))
                {
                    typeList.Add(mats[x]);
                    values.Add(3);
                }
                else
                {
                    values[typeList.IndexOf(mats[x])] += 3;
                }
            }
        }

        /// <summary>
        /// Close and clean data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClose(object sender, FormClosingEventArgs e)
        {
            SceneData.CleanData();
        }

        /// <summary>
        /// Save collision file to system.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Create(SceneData.Collisions.name)))
            {
                SceneData.Collisions.WriteToFile(writer);
            }
        }

        /// <summary>
        /// Reload collision file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reloadToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            CheckCollision();
        }


        /// <summary>
        /// Exit editor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Delete collision and placements.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDeleteCollision(object sender, System.EventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;

            Collision.NXSStruct col = treeView1.SelectedNode.Tag as Collision.NXSStruct;
            SceneData.Collisions.NXSData.Remove(col.Hash);

            for(int i = 0; i != SceneData.Collisions.Placements.Count; i++)
            {
                Collision.Placement placement = SceneData.Collisions.Placements[i];
                if(placement.Hash == col.Hash)
                {
                    SceneData.Collisions.Placements.Remove(placement);

                    TreeNode[] nodes = treeView1.Nodes.Find(placement.Hash.ToString(), true);

                    if (nodes.Length != 0)
                    {
                        for(int x = 0; x != nodes.Length; x++)
                        {
                            nodes[x].Remove();
                        }
                    }
                    i--;
                }
            }
        }

        /// <summary>
        /// Sort our context. TODO: NEED TO REDO. DOESN'T WORK VERY WELL..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpening(object sender, CancelEventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                e.Cancel = true;
                return;
            }

            CollisionContext.Items[0].Visible = false;
            CollisionContext.Items[1].Visible = false;

            if (treeView1.SelectedNode.Tag.GetType() == typeof(Collision.NXSStruct))
            {
                CollisionContext.Items[0].Visible = true;
            }
            else if (treeView1.SelectedNode.Tag.GetType() == typeof(Collision.Placement))
            {
                CollisionContext.Items[1].Visible = true;
            }
        }

        private void OnNodeSelectSelect(object sender, TreeViewEventArgs e)
        {
            //treeView1.SelectedNode = e.Node;
            FrameResourceGrid.SelectedObject = e.Node.Tag;
        }
    }
}