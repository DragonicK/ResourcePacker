namespace ResourcePacker {
    partial class FormMain {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.MenuMain = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExportSelectedFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExportAllFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStripMain = new System.Windows.Forms.StatusStrip();
            this.LabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ListViewPack = new System.Windows.Forms.ListView();
            this.ColumnIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContextMenuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuMoveTo = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuExportSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuExportAll = new System.Windows.Forms.ToolStripMenuItem();
            this.LabelFileCount = new System.Windows.Forms.Label();
            this.MenuMain.SuspendLayout();
            this.StatusStripMain.SuspendLayout();
            this.ContextMenuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuMain
            // 
            this.MenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuEdit});
            this.MenuMain.Location = new System.Drawing.Point(0, 0);
            this.MenuMain.Name = "MenuMain";
            this.MenuMain.Size = new System.Drawing.Size(507, 24);
            this.MenuMain.TabIndex = 0;
            this.MenuMain.Text = "menuStrip1";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuOpen,
            this.MenuSave,
            this.exportToolStripMenuItem1,
            this.MenuExit});
            this.MenuFile.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(47, 20);
            this.MenuFile.Text = "File";
            // 
            // MenuOpen
            // 
            this.MenuOpen.Name = "MenuOpen";
            this.MenuOpen.Size = new System.Drawing.Size(116, 22);
            this.MenuOpen.Text = "Open";
            this.MenuOpen.Click += new System.EventHandler(this.MenuOpen_Click);
            // 
            // MenuSave
            // 
            this.MenuSave.Name = "MenuSave";
            this.MenuSave.Size = new System.Drawing.Size(116, 22);
            this.MenuSave.Text = "Save";
            this.MenuSave.Click += new System.EventHandler(this.MenuSave_Click);
            // 
            // exportToolStripMenuItem1
            // 
            this.exportToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuExportSelectedFiles,
            this.MenuExportAllFiles});
            this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            this.exportToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.exportToolStripMenuItem1.Text = "Export";
            // 
            // MenuExportSelectedFiles
            // 
            this.MenuExportSelectedFiles.Name = "MenuExportSelectedFiles";
            this.MenuExportSelectedFiles.Size = new System.Drawing.Size(172, 22);
            this.MenuExportSelectedFiles.Text = "Selected Files";
            this.MenuExportSelectedFiles.Click += new System.EventHandler(this.MenuExportSelectedFiles_Click);
            // 
            // MenuExportAllFiles
            // 
            this.MenuExportAllFiles.Name = "MenuExportAllFiles";
            this.MenuExportAllFiles.Size = new System.Drawing.Size(172, 22);
            this.MenuExportAllFiles.Text = "All Files";
            this.MenuExportAllFiles.Click += new System.EventHandler(this.MenuExportAllFiles_Click);
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(116, 22);
            this.MenuExit.Text = "Exit";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // MenuEdit
            // 
            this.MenuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAdd,
            this.MenuRemove,
            this.MenuClear});
            this.MenuEdit.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuEdit.Name = "MenuEdit";
            this.MenuEdit.Size = new System.Drawing.Size(47, 20);
            this.MenuEdit.Text = "Edit";
            // 
            // MenuAdd
            // 
            this.MenuAdd.Name = "MenuAdd";
            this.MenuAdd.Size = new System.Drawing.Size(116, 22);
            this.MenuAdd.Text = "Add";
            this.MenuAdd.Click += new System.EventHandler(this.MenuAdd_Click);
            // 
            // MenuRemove
            // 
            this.MenuRemove.Name = "MenuRemove";
            this.MenuRemove.Size = new System.Drawing.Size(116, 22);
            this.MenuRemove.Text = "Remove";
            this.MenuRemove.Click += new System.EventHandler(this.MenuRemove_Click);
            // 
            // MenuClear
            // 
            this.MenuClear.Name = "MenuClear";
            this.MenuClear.Size = new System.Drawing.Size(116, 22);
            this.MenuClear.Text = "Clear";
            this.MenuClear.Click += new System.EventHandler(this.MenuClear_Click);
            // 
            // StatusStripMain
            // 
            this.StatusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelStatus});
            this.StatusStripMain.Location = new System.Drawing.Point(0, 539);
            this.StatusStripMain.Name = "StatusStripMain";
            this.StatusStripMain.Size = new System.Drawing.Size(507, 22);
            this.StatusStripMain.TabIndex = 1;
            this.StatusStripMain.Text = "statusStrip1";
            // 
            // LabelStatus
            // 
            this.LabelStatus.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(42, 17);
            this.LabelStatus.Text = "Ready";
            // 
            // ListViewPack
            // 
            this.ListViewPack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewPack.BackColor = System.Drawing.SystemColors.Window;
            this.ListViewPack.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnIndex,
            this.ColumnName,
            this.ColumnType,
            this.ColumnSize});
            this.ListViewPack.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListViewPack.FullRowSelect = true;
            this.ListViewPack.GridLines = true;
            this.ListViewPack.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListViewPack.HideSelection = false;
            this.ListViewPack.Location = new System.Drawing.Point(12, 37);
            this.ListViewPack.Name = "ListViewPack";
            this.ListViewPack.Size = new System.Drawing.Size(483, 474);
            this.ListViewPack.TabIndex = 2;
            this.ListViewPack.UseCompatibleStateImageBehavior = false;
            this.ListViewPack.View = System.Windows.Forms.View.Details;
            this.ListViewPack.SelectedIndexChanged += new System.EventHandler(this.ListViewPack_SelectedIndexChanged);
            this.ListViewPack.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListViewPack_MouseClick);
            this.ListViewPack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListViewPack_MouseDown);
            // 
            // ColumnIndex
            // 
            this.ColumnIndex.Text = "Index";
            this.ColumnIndex.Width = 58;
            // 
            // ColumnName
            // 
            this.ColumnName.Text = "Name";
            this.ColumnName.Width = 231;
            // 
            // ColumnType
            // 
            this.ColumnType.Text = "Type";
            this.ColumnType.Width = 70;
            // 
            // ColumnSize
            // 
            this.ColumnSize.Text = "Size";
            this.ColumnSize.Width = 120;
            // 
            // ContextMenuMain
            // 
            this.ContextMenuMain.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContextMenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuAdd,
            this.ContextMenuMoveUp,
            this.ContextMenuMoveDown,
            this.ContextMenuMoveTo,
            this.ContextMenuInsert,
            this.ContextMenuRemove,
            this.ContextMenuExport});
            this.ContextMenuMain.Name = "ContextMenu";
            this.ContextMenuMain.Size = new System.Drawing.Size(138, 158);
            // 
            // ContextMenuAdd
            // 
            this.ContextMenuAdd.Name = "ContextMenuAdd";
            this.ContextMenuAdd.Size = new System.Drawing.Size(137, 22);
            this.ContextMenuAdd.Text = "Add";
            this.ContextMenuAdd.Click += new System.EventHandler(this.ContextMenuAdd_Click);
            // 
            // ContextMenuMoveUp
            // 
            this.ContextMenuMoveUp.Enabled = false;
            this.ContextMenuMoveUp.Name = "ContextMenuMoveUp";
            this.ContextMenuMoveUp.Size = new System.Drawing.Size(137, 22);
            this.ContextMenuMoveUp.Text = "Move Up";
            this.ContextMenuMoveUp.Click += new System.EventHandler(this.ContextMenuMoveUp_Click);
            // 
            // ContextMenuMoveDown
            // 
            this.ContextMenuMoveDown.Enabled = false;
            this.ContextMenuMoveDown.Name = "ContextMenuMoveDown";
            this.ContextMenuMoveDown.Size = new System.Drawing.Size(137, 22);
            this.ContextMenuMoveDown.Text = "Move Down";
            this.ContextMenuMoveDown.Click += new System.EventHandler(this.ContextMenuMoveDown_Click);
            // 
            // ContextMenuMoveTo
            // 
            this.ContextMenuMoveTo.Enabled = false;
            this.ContextMenuMoveTo.Name = "ContextMenuMoveTo";
            this.ContextMenuMoveTo.Size = new System.Drawing.Size(137, 22);
            this.ContextMenuMoveTo.Text = "Move To";
            this.ContextMenuMoveTo.Click += new System.EventHandler(this.ContextMenuMoveTo_Click);
            // 
            // ContextMenuInsert
            // 
            this.ContextMenuInsert.Enabled = false;
            this.ContextMenuInsert.Name = "ContextMenuInsert";
            this.ContextMenuInsert.Size = new System.Drawing.Size(137, 22);
            this.ContextMenuInsert.Text = "Insert";
            this.ContextMenuInsert.Click += new System.EventHandler(this.ContextMenuInsert_Click);
            // 
            // ContextMenuRemove
            // 
            this.ContextMenuRemove.Enabled = false;
            this.ContextMenuRemove.Name = "ContextMenuRemove";
            this.ContextMenuRemove.Size = new System.Drawing.Size(137, 22);
            this.ContextMenuRemove.Text = "Remove";
            this.ContextMenuRemove.Click += new System.EventHandler(this.ContextMenuRemove_Click);
            // 
            // ContextMenuExport
            // 
            this.ContextMenuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuExportSelected,
            this.ContextMenuExportAll});
            this.ContextMenuExport.Enabled = false;
            this.ContextMenuExport.Name = "ContextMenuExport";
            this.ContextMenuExport.Size = new System.Drawing.Size(137, 22);
            this.ContextMenuExport.Text = "Export";
            // 
            // ContextMenuExportSelected
            // 
            this.ContextMenuExportSelected.Name = "ContextMenuExportSelected";
            this.ContextMenuExportSelected.Size = new System.Drawing.Size(172, 22);
            this.ContextMenuExportSelected.Text = "Selected Files";
            this.ContextMenuExportSelected.Click += new System.EventHandler(this.ContextMenuExportSelected_Click);
            // 
            // ContextMenuExportAll
            // 
            this.ContextMenuExportAll.Name = "ContextMenuExportAll";
            this.ContextMenuExportAll.Size = new System.Drawing.Size(172, 22);
            this.ContextMenuExportAll.Text = "All Files";
            this.ContextMenuExportAll.Click += new System.EventHandler(this.ContextMenuExportAll_Click);
            // 
            // LabelFileCount
            // 
            this.LabelFileCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelFileCount.AutoSize = true;
            this.LabelFileCount.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFileCount.Location = new System.Drawing.Point(12, 514);
            this.LabelFileCount.Name = "LabelFileCount";
            this.LabelFileCount.Size = new System.Drawing.Size(98, 14);
            this.LabelFileCount.TabIndex = 3;
            this.LabelFileCount.Text = "File Count: 0";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 561);
            this.Controls.Add(this.LabelFileCount);
            this.Controls.Add(this.ListViewPack);
            this.Controls.Add(this.StatusStripMain);
            this.Controls.Add(this.MenuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuMain;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resource Packer";
            this.MenuMain.ResumeLayout(false);
            this.MenuMain.PerformLayout();
            this.StatusStripMain.ResumeLayout(false);
            this.StatusStripMain.PerformLayout();
            this.ContextMenuMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuMain;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuSave;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.ToolStripMenuItem MenuEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuAdd;
        private System.Windows.Forms.ToolStripMenuItem MenuClear;
        private System.Windows.Forms.ToolStripMenuItem MenuRemove;
        private System.Windows.Forms.StatusStrip StatusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel LabelStatus;
        private System.Windows.Forms.ListView ListViewPack;
        private System.Windows.Forms.ColumnHeader ColumnName;
        private System.Windows.Forms.ColumnHeader ColumnType;
        private System.Windows.Forms.ContextMenuStrip ContextMenuMain;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuAdd;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuRemove;
        private System.Windows.Forms.ColumnHeader ColumnIndex;
        private System.Windows.Forms.ColumnHeader ColumnSize;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuExport;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuExportSelected;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuExportAll;
        private System.Windows.Forms.Label LabelFileCount;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuExportSelectedFiles;
        private System.Windows.Forms.ToolStripMenuItem MenuExportAllFiles;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuInsert;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuMoveUp;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuMoveDown;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuMoveTo;
    }
}