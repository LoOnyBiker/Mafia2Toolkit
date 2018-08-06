﻿using System.Windows.Forms;

namespace Mafia2Tool
{
    partial class GameExplorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameExplorer));
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.folderView = new System.Windows.Forms.TreeView();
            this.imageBank = new System.Windows.Forms.ImageList(this.components);
            this.fileListView = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLastModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.topContainer = new System.Windows.Forms.ToolStripContainer();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.buttonFile = new System.Windows.Forms.ToolStripButton();
            this.buttonEdit = new System.Windows.Forms.ToolStripButton();
            this.buttonTools = new System.Windows.Forms.ToolStripButton();
            this.bottomContainer = new System.Windows.Forms.ToolStripContainer();
            this.status = new System.Windows.Forms.StatusStrip();
            this.infoText = new System.Windows.Forms.ToolStripStatusLabel();
            this.SDSContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextSDSUnpack = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSDSPack = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.topContainer.ContentPanel.SuspendLayout();
            this.topContainer.SuspendLayout();
            this.tools.SuspendLayout();
            this.bottomContainer.ContentPanel.SuspendLayout();
            this.bottomContainer.SuspendLayout();
            this.status.SuspendLayout();
            this.SDSContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(0, 23);
            this.mainContainer.Name = "mainContainer";
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.folderView);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.Controls.Add(this.fileListView);
            this.mainContainer.Size = new System.Drawing.Size(800, 401);
            this.mainContainer.SplitterDistance = 266;
            this.mainContainer.TabIndex = 0;
            // 
            // folderView
            // 
            this.folderView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderView.ImageIndex = 0;
            this.folderView.ImageList = this.imageBank;
            this.folderView.Location = new System.Drawing.Point(0, 0);
            this.folderView.Name = "folderView";
            this.folderView.SelectedImageIndex = 0;
            this.folderView.Size = new System.Drawing.Size(266, 401);
            this.folderView.TabIndex = 0;
            this.folderView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // imageBank
            // 
            this.imageBank.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageBank.ImageStream")));
            this.imageBank.TransparentColor = System.Drawing.Color.Transparent;
            this.imageBank.Images.SetKeyName(0, "folderIcon");
            this.imageBank.Images.SetKeyName(1, "defaultIcon");
            this.imageBank.Images.SetKeyName(2, "dllIcon");
            this.imageBank.Images.SetKeyName(3, "exeIcon");
            // 
            // fileListView
            // 
            this.fileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnType,
            this.columnSize,
            this.columnLastModified});
            this.fileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileListView.Location = new System.Drawing.Point(0, 0);
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(530, 401);
            this.fileListView.SmallImageList = this.imageBank;
            this.fileListView.TabIndex = 0;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.Details;
            this.fileListView.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.fileListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 157;
            // 
            // columnType
            // 
            this.columnType.Text = "Type";
            this.columnType.Width = 143;
            // 
            // columnSize
            // 
            this.columnSize.Text = "Size";
            // 
            // columnLastModified
            // 
            this.columnLastModified.Text = "Last Modified";
            this.columnLastModified.Width = 281;
            // 
            // topContainer
            // 
            this.topContainer.BottomToolStripPanelVisible = false;
            // 
            // topContainer.ContentPanel
            // 
            this.topContainer.ContentPanel.Controls.Add(this.tools);
            this.topContainer.ContentPanel.Size = new System.Drawing.Size(800, 23);
            this.topContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.topContainer.LeftToolStripPanelVisible = false;
            this.topContainer.Location = new System.Drawing.Point(0, 0);
            this.topContainer.Name = "topContainer";
            this.topContainer.RightToolStripPanelVisible = false;
            this.topContainer.Size = new System.Drawing.Size(800, 23);
            this.topContainer.TabIndex = 1;
            this.topContainer.Text = "topContainer";
            this.topContainer.TopToolStripPanelVisible = false;
            // 
            // tools
            // 
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonFile,
            this.buttonEdit,
            this.buttonTools});
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(800, 25);
            this.tools.TabIndex = 1;
            this.tools.Text = "toolStrip1";
            // 
            // buttonFile
            // 
            this.buttonFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonFile.Image = ((System.Drawing.Image)(resources.GetObject("buttonFile.Image")));
            this.buttonFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(29, 22);
            this.buttonFile.Text = "File";
            // 
            // buttonEdit
            // 
            this.buttonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonEdit.Image = ((System.Drawing.Image)(resources.GetObject("buttonEdit.Image")));
            this.buttonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(31, 22);
            this.buttonEdit.Text = "Edit";
            // 
            // buttonTools
            // 
            this.buttonTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonTools.Image = ((System.Drawing.Image)(resources.GetObject("buttonTools.Image")));
            this.buttonTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonTools.Name = "buttonTools";
            this.buttonTools.Size = new System.Drawing.Size(39, 22);
            this.buttonTools.Text = "Tools";
            // 
            // bottomContainer
            // 
            this.bottomContainer.BottomToolStripPanelVisible = false;
            // 
            // bottomContainer.ContentPanel
            // 
            this.bottomContainer.ContentPanel.Controls.Add(this.status);
            this.bottomContainer.ContentPanel.Size = new System.Drawing.Size(800, 26);
            this.bottomContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomContainer.LeftToolStripPanelVisible = false;
            this.bottomContainer.Location = new System.Drawing.Point(0, 424);
            this.bottomContainer.Name = "bottomContainer";
            this.bottomContainer.RightToolStripPanelVisible = false;
            this.bottomContainer.Size = new System.Drawing.Size(800, 26);
            this.bottomContainer.TabIndex = 1;
            this.bottomContainer.Text = "bottomContainer";
            this.bottomContainer.TopToolStripPanelVisible = false;
            // 
            // status
            // 
            this.status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoText});
            this.status.Location = new System.Drawing.Point(0, 0);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(800, 26);
            this.status.TabIndex = 0;
            this.status.Text = "statusStrip1";
            // 
            // infoText
            // 
            this.infoText.Name = "infoText";
            this.infoText.Size = new System.Drawing.Size(0, 21);
            // 
            // SDSContext
            // 
            this.SDSContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextSDSUnpack,
            this.ContextSDSPack});
            this.SDSContext.Name = "SDSContext";
            this.SDSContext.Size = new System.Drawing.Size(115, 48);
            // 
            // ContextSDSUnpack
            // 
            this.ContextSDSUnpack.Name = "ContextSDSUnpack";
            this.ContextSDSUnpack.Size = new System.Drawing.Size(114, 22);
            this.ContextSDSUnpack.Text = "Unpack";
            this.ContextSDSUnpack.Click += new System.EventHandler(this.ContextSDSUnpack_Click);
            // 
            // ContextSDSPack
            // 
            this.ContextSDSPack.Name = "ContextSDSPack";
            this.ContextSDSPack.Size = new System.Drawing.Size(114, 22);
            this.ContextSDSPack.Text = "Pack";
            this.ContextSDSPack.Click += new System.EventHandler(this.ContextSDSPack_Click);
            // 
            // GameExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.bottomContainer);
            this.Controls.Add(this.topContainer);
            this.Name = "GameExplorer";
            this.Text = "GameExplorer";
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            this.topContainer.ContentPanel.ResumeLayout(false);
            this.topContainer.ContentPanel.PerformLayout();
            this.topContainer.ResumeLayout(false);
            this.topContainer.PerformLayout();
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.bottomContainer.ContentPanel.ResumeLayout(false);
            this.bottomContainer.ContentPanel.PerformLayout();
            this.bottomContainer.ResumeLayout(false);
            this.bottomContainer.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.SDSContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainContainer;
        private System.Windows.Forms.TreeView folderView;
        private System.Windows.Forms.ImageList imageBank;
        private System.Windows.Forms.ListView fileListView;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnType;
        private System.Windows.Forms.ColumnHeader columnLastModified;
        private System.Windows.Forms.ColumnHeader columnSize;
        private ToolStripContainer topContainer;
        private ToolStrip tools;
        private ToolStripButton buttonFile;
        private ToolStripButton buttonEdit;
        private ToolStripContainer bottomContainer;
        private StatusStrip status;
        private ToolStripStatusLabel infoText;
        private ToolStripButton buttonTools;
        private ContextMenuStrip SDSContext;
        private ToolStripMenuItem ContextSDSUnpack;
        private ToolStripMenuItem ContextSDSPack;
    }
}