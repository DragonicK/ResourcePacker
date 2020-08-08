using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using ResourcePacker.Packet;
using ResourcePacker.Common;

namespace ResourcePacker {
    public partial class FormMain : Form {
        /// <summary>
        /// Lista dos arquivos que serão empacotados.
        /// </summary>
        readonly IPackage package = new Package();

        /// <summary>
        /// Métodos de exportação.
        /// </summary>
        private readonly IExportHandler export = new PackageExport();

        /// <summary>
        /// Métodos de armazenamento e carregamento de pacotes.
        /// </summary>
        readonly IPackageHandler manager = new PackageHandler();

        /// <summary>
        /// Índice dos itens selecionados na lista.
        /// </summary>
        private int[] selectedIndex;

        const int ExitSuccess = 0;
        const int InvalidPosition = -1;

        const int MoveUp = -1;
        const int MoveDown = 1;

        public FormMain() {
            InitializeComponent();

            export.ProgressChanged += ChangeStatus;
            manager.ProgressChanged += ChangeStatus;
        }

        private void ChangeStatus(string text) {
            LabelStatus.Text = text;
        }

        #region Menu File
        private async void MenuOpen_Click(object sender, EventArgs e) {
            var dialog = new OpenFileDialog {
                Multiselect = false,
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "Pak Files (*.pak)|*.pak"
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK) {
                var t = await Task.Run(() =>
                     OpenPackage(dialog.FileName)
                );

                // Atualiza a lista depois que os itens forem carregados.
                UpdateListView();
            }
        }

        private async void MenuSave_Click(object sender, EventArgs e) {
            var dialog = new SaveFileDialog {
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "Pak Files (*.pak)|*.pak"
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK) {
                var t = await Task.Run(() =>
                     SavePackage(dialog.FileName)
                );   
            }
        }

        private async void MenuExportSelectedFiles_Click(object sender, EventArgs e) {
            var path = GetExportPath();

            if (path != string.Empty) {
                var t = await Task.Run(() =>
                   ExportSelectedFiles(path)
               );
            }
        }

        private async void MenuExportAllFiles_Click(object sender, EventArgs e) {
            var path = GetExportPath();

            if (path != string.Empty) {
                var t = await Task.Run(() =>
                   ExportAllFiles(path)
               );
            }
        }

        private void MenuExit_Click(object sender, EventArgs e) {
            package.Clear();
            Application.Exit();
        }

        #endregion

        #region Menu Edit
        private void MenuAdd_Click(object sender, EventArgs e) {
            OpenDialogAndSelectFiles();
        }

        private void MenuRemove_Click(object sender, EventArgs e) {
            if (selectedIndex != null) {
                if (selectedIndex.Length > 0) {
                    RemoveSelectedFiles();

                    UpdateListView();
                }
            }
        }

        private void MenuClear_Click(object sender, EventArgs e) {
            Clear();
        }

        #endregion

        #region Context Menu

        private void ContextMenuAdd_Click(object sender, EventArgs e) {
            OpenDialogAndSelectFiles();
        }

        private void ContextMenuRemove_Click(object sender, EventArgs e) {
            if (selectedIndex != null) {         
                if (selectedIndex.Length > 0) {
                    RemoveSelectedFiles();

                    UpdateListView();
                }        
            }
        }

        private void ContextMenuInsert_Click(object sender, EventArgs e) {
            // Se houver algum item selecionado.
            if (ListViewPack.SelectedIndices.Count > 0) {
                var index = ListViewPack.SelectedIndices[0];
                OpenDialogAndSelectFilesAndInsert(index);
            }
        }

        private async void ContextMenuExportAll_Click(object sender, EventArgs e) {
            var path = GetExportPath();

            if (path != string.Empty) {
                var t = await Task.Run(() =>
                    ExportAllFiles(path)
                );
            }
        }

        private async void ContextMenuExportSelected_Click(object sender, EventArgs e) {
            var path = GetExportPath();

            if (path != string.Empty) {
                 var t = await Task.Run(() =>
                    ExportSelectedFiles(path)
                );
            }
        }

        private void ContextMenuMoveUp_Click(object sender, EventArgs e) {
            if (ListViewPack.SelectedIndices.Count > 0) {
                if (package.MoveUp(selectedIndex)) {
                    UpdateListView();

                    ListViewPack.EnsureVisible(selectedIndex[0] - 1);

                    SelectItem(IncrementIndexPosition(MoveUp));
                }
            }
        }

        private void ContextMenuMoveDown_Click(object sender, EventArgs e) {
            if (ListViewPack.SelectedIndices.Count > 0) {
                if (package.MoveDown(selectedIndex)) {
                    UpdateListView();

                    ListViewPack.EnsureVisible(selectedIndex[0] + 1);

                    SelectItem(IncrementIndexPosition(MoveDown));
                }
            }
        }

        private void ContextMenuMoveTo_Click(object sender, EventArgs e) {
            var index = InputBox();

            if (index > InvalidPosition) {
                if (package.MoveTo(index, selectedIndex)) {
                    UpdateListView();

                    ListViewPack.EnsureVisible(index);

                    SelectItem(CreateNewIndexPositionFrom(index));
                }
            }
        }


        #endregion

        #region Open & Save Package

        private int OpenPackage(string path) {
            manager.OpenPackage(path, package);
     
            return ExitSuccess;
        }

        private int SavePackage(string path) {
            manager.SavePackage(path, package);

            return ExitSuccess;
        }

        #endregion

        #region Add

        /// <summary>
        /// Abre a caixa de dialogo para a selação dos arquivos. 
        /// </summary>
        private async void OpenDialogAndSelectFiles() {
            var dialog = new OpenFileDialog {
                Multiselect = true,
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "All Files (*.*)|*.*"
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK) {

                var t = await Task.Run(() =>
                    ParseFileNames(dialog.FileNames, dialog.SafeFileNames)
                );
                
                // Atualiza a lista depois que os items forem carregados.
                UpdateListView();
            }
        }

        private async void OpenDialogAndSelectFilesAndInsert(int index) {
            var dialog = new OpenFileDialog {
                Multiselect = true,
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "All Files (*.*)|*.*"
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK) {

                var t = await Task.Run(() =>
                    ParseAndInsertFileNames(index, dialog.FileNames, dialog.SafeFileNames)
                );

                // Atualiza a lista depois que os items forem carregados.
                UpdateListView();
            }
        }

        private int ParseAndInsertFileNames(int index, string[] fileNames, string[] safeNames) {
            var length = fileNames.Length;
 
            if (length > 0) {

                // Adiciona cada arquivo selecionado.
                for (var i = length - 1; i >= 0; i--) {
                    package.Insert(index, fileNames[i], safeNames[i]);

                    // Atualiza o progresso.
                    ChangeStatus($"Loaded {Util.GetProgressPercentage((i - length) + 1, length)}% Total {(i - length) + 1}");
                }
            }

            return ExitSuccess;
        }

        /// <summary>
        /// Percorre a lista de nomes e adiciona na lista.
        /// </summary>
        /// <param name="fileNames"></param>
        /// <param name="safeNames"></param>
        private int ParseFileNames(string[] fileNames, string[] safeNames) {
            var length = fileNames.Length;
  
            if (length > 0) {

                // Adiciona cada arquivo selecionado.
                for (var i = 0; i < length; i++) {
                    package.Add(fileNames[i], safeNames[i]);

                    // Atualiza o progresso.
                    ChangeStatus($"Loaded {Util.GetProgressPercentage(i + 1, length)}% Total {i + 1}");
                }
            }

            return ExitSuccess;
        }

        #endregion

        #region Export    

        private string GetExportPath() {
            var path = string.Empty;

            if (package.Count > 0) {

                var dialog = new FolderBrowserDialog() {
                    ShowNewFolderButton = true,
                    RootFolder = Environment.SpecialFolder.MyComputer
                };

                var result = dialog.ShowDialog();

                if (result == DialogResult.OK) {
                    path = dialog.SelectedPath;
                }
            }

            return path;
        }

        private int ExportSelectedFiles(string path) {
            if (selectedIndex != null) {
                var length = selectedIndex.Length;

                if (length > 0) {
                    export.ExportSelectedFiles(path, selectedIndex, package);
                }
            }

            return ExitSuccess;
        }

        private int ExportAllFiles(string path) {
            if (package.Count > 0) {
                export.ExportAllFiles(path, package);
            }

            return ExitSuccess;
        }
       
        #endregion

        #region Remove

        private void RemoveSelectedFiles() {
            if (selectedIndex != null) {
                var length = selectedIndex.Length;

                if (length > 0) {
                    package.Remove(selectedIndex);
                }

                selectedIndex = null;
            }
        }
        
        private void Clear() {
            selectedIndex = null;

            package.Clear();

            UpdateListView();
        }

        #endregion

        #region ListView

        private void SelectItem(int[] selected) {
            ListViewPack.Focus();

            if (ListViewPack.Items.Count > 0) {
                for (var i = 0; i < selected.Length; i++) {
                    ListViewPack.Items[selected[i]].Selected = true;
                    ListViewPack.Select();
                }
            }
        }

        private void UpdateListView() {
            ListViewPack.BeginUpdate();
            ListViewPack.Items.Clear();

            ListViewItem viewItem;

            for (var i = 0; i < package.Count; i++) {
                viewItem = new ListViewItem(i.ToString());

                viewItem.SubItems.Add(package[i].Name);
                viewItem.SubItems.Add(package[i].Extension);
                viewItem.SubItems.Add(Util.GetFileSize(package[i].Length));
                
                ListViewPack.Items.Add(viewItem);
            }

            ListViewPack.EndUpdate();
            LabelFileCount.Text = $"File Count: {package.Count}";
        }

        private void ListViewPack_SelectedIndexChanged(object sender, EventArgs e) {
           
            var count = ListViewPack.SelectedIndices.Count;

            selectedIndex = new int[count];
            ListViewPack.SelectedIndices.CopyTo(selectedIndex, 0);  
        }

        private void ListViewPack_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                
                // Os botões remove e export são habilitados quando somente o clique é feito em algum item da lista.
                ContextMenuRemove.Enabled = false;
                ContextMenuExport.Enabled = false;

                ContextMenuMoveUp.Enabled = false;
                ContextMenuMoveDown.Enabled = false;
                ContextMenuMoveTo.Enabled = false;
                ContextMenuInsert.Enabled = false;

                ContextMenuMain.Show(ListViewPack, e.Location);
            }
        }

        private void ListViewPack_MouseClick(object sender, MouseEventArgs e) {   
            if (ListViewPack.Items.Count == 0) {
                selectedIndex = null;
            }

            // Habilita os botões quando clicado em algum item da lista.
            ContextMenuRemove.Enabled = CanEnableButton();
            ContextMenuExport.Enabled = CanEnableButton();
            ContextMenuMoveUp.Enabled = CanEnableButton();
            ContextMenuMoveDown.Enabled = CanEnableButton();
            ContextMenuMoveTo.Enabled = CanEnableButton();
                  
            if (selectedIndex != null && selectedIndex.Length == 1 && ListViewPack.Items.Count > 0) {
                ContextMenuInsert.Enabled = true; 
            }
            else {
                ContextMenuInsert.Enabled = false;
            }
        }

        private bool CanEnableButton() {
            // Se houver algum item selecionado.
            if (selectedIndex != null && selectedIndex.Length > 0 && ListViewPack.Items.Count > 0) {
                return true;
            }

            return false;
        }

        #endregion

        public int InputBox() {
            var input = new InputBoxDialog {
                Caption = "Move To Position ... ",
                Text = "Resource Packer",
                Input = "0"
            };

            input.ShowDialog();

            var response = input.Response;

            input.Close();

            var success = int.TryParse(response, out var result);

            if (success) {
                return result;
            }

            return InvalidPosition;
        }

        private int[] IncrementIndexPosition(int increment) {
            var positions = new int[selectedIndex.Length];

            for (var i = 0; i < positions.Length; i++) {
                positions[i] = selectedIndex[i] + increment;
            }

            return positions;
        }

        private int[] CreateNewIndexPositionFrom(int index) {
            var positions = new int[selectedIndex.Length];

            for (var i = 0; i < positions.Length; i++) {
                positions[i] = index++;
            }

            return positions;
        }
    }
}