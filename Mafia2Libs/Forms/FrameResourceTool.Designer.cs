﻿namespace Mafia2Tool {
    partial class FrameResourceTool {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrameResourceTool));
            this.FrameResourceGrid = new System.Windows.Forms.PropertyGrid();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.m2tBrowser = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.fileToolButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.modifyHeaderButton = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAllSubButton = new System.Windows.Forms.ToolStripMenuItem();
            this.farLodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overwriteBufferSubButton = new System.Windows.Forms.ToolStripMenuItem();
            this.addButton = new System.Windows.Forms.ToolStripMenuItem();
            this.importFrameEDDButton = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.switchViewSubButton = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextExtract3D = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextUpdateParents = new System.Windows.Forms.ToolStripMenuItem();
            this.eddBrowser = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // FrameResourceGrid
            // 
            this.FrameResourceGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FrameResourceGrid.Location = new System.Drawing.Point(387, 28);
            this.FrameResourceGrid.Name = "FrameResourceGrid";
            this.FrameResourceGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.FrameResourceGrid.Size = new System.Drawing.Size(386, 393);
            this.FrameResourceGrid.TabIndex = 6;
            this.FrameResourceGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.OnPropertyChanged);
            // 
            // folderBrowser
            // 
            this.folderBrowser.ShowNewFolderButton = false;
            // 
            // m2tBrowser
            // 
            this.m2tBrowser.FileName = "m2tBrowser";
            this.m2tBrowser.Filter = "Meshes|*.m2t|FBX|*.fbx";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolButton,
            this.toolsButton,
            this.viewToolButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(785, 25);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // fileToolButton
            // 
            this.fileToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.reloadToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolButton.Image = ((System.Drawing.Image)(resources.GetObject("fileToolButton.Image")));
            this.fileToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileToolButton.Name = "fileToolButton";
            this.fileToolButton.Size = new System.Drawing.Size(38, 22);
            this.fileToolButton.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveClick);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.ReloadClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitClick);
            // 
            // toolsButton
            // 
            this.toolsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolsButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAllSubButton,
            this.overwriteBufferSubButton,
            this.modifyHeaderButton,
            this.addButton,
            this.importFrameEDDButton});
            this.toolsButton.Image = ((System.Drawing.Image)(resources.GetObject("toolsButton.Image")));
            this.toolsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsButton.Name = "toolsButton";
            this.toolsButton.Size = new System.Drawing.Size(48, 22);
            this.toolsButton.Text = "Tools";
            // 
            // modifyHeaderButton
            // 
            this.modifyHeaderButton.Name = "modifyHeaderButton";
            this.modifyHeaderButton.Size = new System.Drawing.Size(198, 22);
            this.modifyHeaderButton.Text = "$MODIFY_HEADER";
            this.modifyHeaderButton.Click += new System.EventHandler(this.modifyHeaderDataToolStripMenuItem_Click);
            // 
            // exportAllSubButton
            // 
            this.exportAllSubButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.farLodsToolStripMenuItem,
            this.modelsToolStripMenuItem,
            this.allToolStripMenuItem});
            this.exportAllSubButton.Name = "exportAllSubButton";
            this.exportAllSubButton.Size = new System.Drawing.Size(198, 22);
            this.exportAllSubButton.Text = "Export All";
            // 
            // farLodsToolStripMenuItem
            // 
            this.farLodsToolStripMenuItem.Name = "farLodsToolStripMenuItem";
            this.farLodsToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.farLodsToolStripMenuItem.Text = "Far Lods";
            this.farLodsToolStripMenuItem.Click += new System.EventHandler(this.OnExportFarLods);
            // 
            // modelsToolStripMenuItem
            // 
            this.modelsToolStripMenuItem.Name = "modelsToolStripMenuItem";
            this.modelsToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.modelsToolStripMenuItem.Text = "Models";
            this.modelsToolStripMenuItem.Click += new System.EventHandler(this.OnExportModels);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.OnExportAll);
            // 
            // overwriteBufferSubButton
            // 
            this.overwriteBufferSubButton.Name = "overwriteBufferSubButton";
            this.overwriteBufferSubButton.Size = new System.Drawing.Size(198, 22);
            this.overwriteBufferSubButton.Text = "Overwrite Buffer";
            this.overwriteBufferSubButton.Click += new System.EventHandler(this.OverwriteBuffer_Click);
            // 
            // addButton
            // 
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(198, 22);
            this.addButton.Text = "$FRADD_ADDBUTTON";
            this.addButton.Click += new System.EventHandler(this.AddFrameSingleMesh_Click);
            // 
            // importFrameEDDButton
            // 
            this.importFrameEDDButton.Name = "importFrameEDDButton";
            this.importFrameEDDButton.Size = new System.Drawing.Size(198, 22);
            this.importFrameEDDButton.Text = "D_ Import Frame (.EDD)";
            this.importFrameEDDButton.Click += new System.EventHandler(this.importFrameEDDButton_Click);
            // 
            // viewToolButton
            // 
            this.viewToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.viewToolButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchViewSubButton});
            this.viewToolButton.Image = ((System.Drawing.Image)(resources.GetObject("viewToolButton.Image")));
            this.viewToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewToolButton.Name = "viewToolButton";
            this.viewToolButton.Size = new System.Drawing.Size(45, 22);
            this.viewToolButton.Text = "View";
            // 
            // switchViewSubButton
            // 
            this.switchViewSubButton.Name = "switchViewSubButton";
            this.switchViewSubButton.Size = new System.Drawing.Size(137, 22);
            this.switchViewSubButton.Text = "Switch View";
            this.switchViewSubButton.Click += new System.EventHandler(this.SwitchView);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(12, 27);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(368, 394);
            this.treeView1.TabIndex = 15;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnSelect);
            // 
            // contextExtract3D
            // 
            this.contextExtract3D.Name = "contextExtract3D";
            this.contextExtract3D.Size = new System.Drawing.Size(129, 22);
            this.contextExtract3D.Text = "Extract 3D";
            // 
            // contextDelete
            // 
            this.contextDelete.Name = "contextDelete";
            this.contextDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.contextDelete.Size = new System.Drawing.Size(129, 22);
            this.contextDelete.Text = "Delete";
            this.contextDelete.Click += new System.EventHandler(this.OnDelete);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextExtract3D,
            this.contextDelete,
            this.contextUpdateParents});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.ShowImageMargin = false;
            this.contextMenu.Size = new System.Drawing.Size(130, 70);
            this.contextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ItemClicked);
            // 
            // contextUpdateParents
            // 
            this.contextUpdateParents.Name = "contextUpdateParents";
            this.contextUpdateParents.Size = new System.Drawing.Size(129, 22);
            this.contextUpdateParents.Text = "Update Parents";
            this.contextUpdateParents.ToolTipText = "Add a scene as a parent.";
            // 
            // eddBrowser
            // 
            this.eddBrowser.FileName = "m2tBrowser";
            this.eddBrowser.Filter = "Scene|*.edd|Scene FBX|*.fbx";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.EntryName});
            this.dataGridView1.Location = new System.Drawing.Point(13, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(367, 393);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.Visible = false;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnSelectedChanged);
            // 
            // Index
            // 
            this.Index.HeaderText = "$INDEX";
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            // 
            // EntryName
            // 
            this.EntryName.HeaderText = "$ENTRYNAME";
            this.EntryName.Name = "EntryName";
            this.EntryName.ReadOnly = true;
            // 
            // FrameResourceTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 431);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.FrameResourceGrid);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrameResourceTool";
            this.Text = "Frame Resource Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnExit);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PropertyGrid FrameResourceGrid;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.OpenFileDialog m2tBrowser;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton fileToolButton;
        private System.Windows.Forms.ToolStripDropDownButton viewToolButton;
        private System.Windows.Forms.ToolStripMenuItem switchViewSubButton;
        private System.Windows.Forms.ToolStripDropDownButton toolsButton;
        private System.Windows.Forms.ToolStripMenuItem exportAllSubButton;
        private System.Windows.Forms.ToolStripMenuItem overwriteBufferSubButton;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem farLodsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contextExtract3D;
        private System.Windows.Forms.ToolStripMenuItem contextDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem addButton;
        private System.Windows.Forms.ToolStripMenuItem contextUpdateParents;
        private System.Windows.Forms.ToolStripMenuItem importFrameEDDButton;
        private System.Windows.Forms.OpenFileDialog eddBrowser;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryName;
        private System.Windows.Forms.ToolStripMenuItem modifyHeaderButton;
    }
}