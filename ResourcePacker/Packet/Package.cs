using System.Drawing;
using System.Collections.Generic;
using System.IO;

namespace ResourcePacker.Packet {
    public sealed class Package : IPackage {       
        public int Count {
            get {
                return files.Count;
            }
        }

        public IPackageFile this [int index] {
            get {             
                return files[index];
            }

            set {
                files[index] = value;
            }
        }

        private readonly List<IPackageFile> files;

        public Package() {
            files = new List<IPackageFile>();
        }

        public void Add(string file, string name) {
            var f = new PackageFile {
                Name = GetNameWithoutExtension(name),
                Extension = GetExtension(name),
                Bytes = File.ReadAllBytes(file)
            };

            if (f.Extension == "png") {
                var bitmap = new Bitmap(file);
                f.Width = bitmap.Width;
                f.Height = bitmap.Height;
            }

            f.Length = f.Bytes.Length;

            files.Add(f);
        }

        public void Add(IPackageFile file) {
            files.Add(file);
        }

        public void Clear() {
            files.Clear();
        }

        public void Insert(int index, string file, string name) {
            var f = new PackageFile {
                Name = GetNameWithoutExtension(name),
                Extension = GetExtension(name),
                Bytes = File.ReadAllBytes(file)
            };

            if (f.Extension == "png") {
                var bitmap = new Bitmap(file);
                f.Width = bitmap.Width;
                f.Height = bitmap.Height;
            }

            f.Length = f.Bytes.Length;

            files.Add(f);
        }

        public void Insert(int index, IPackageFile file) {
            files.Insert(index, file);
        }

        public void Remove(int[] selectedIndex) {
            var length = selectedIndex.Length;

            if (length > 0) {
                var array = GetFiles(selectedIndex);

                for (var n = 0; n < length; n++) {
                    files.Remove(array[n]);
                }
            }
        }

        public bool MoveUp(int[] selectedIndex) {
            if (selectedIndex.Length > 0) {
                if (selectedIndex[0] == 0) {
                    return false;
                }

               return MoveTo(selectedIndex[0] - 1, selectedIndex);
            }

            return false;
        }

        public bool MoveDown(int[] selectedIndex) {
            if (selectedIndex.Length > 0) {
                if (selectedIndex[0] == Count - 1) {
                    return false;
                }

                return MoveTo(selectedIndex[0] + 1, selectedIndex);
            }

            return false;
        }

        public bool MoveTo(int index, int[] selectedIndex) {
            if (selectedIndex.Length > 0) {

                if (index + selectedIndex.Length > Count) {
                    return false;
                }

                var copy = GetFiles(selectedIndex);
                var list = new List<IPackageFile>(copy.Length);

                list.AddRange(copy);

                Remove(selectedIndex);

                files.InsertRange(index, list);

                return true;
            }

            return false;
        }

        private IPackageFile[] GetFiles(int[] selectedIndex) {
            var length = selectedIndex.Length;
            var array = new IPackageFile[selectedIndex.Length];

            for (var i = 0; i < length; i++) {
                array[i] = files[selectedIndex[i]];
            }

            return array;
        }

        private string GetNameWithoutExtension(string name) {
            const int NameIndex = 0;

            var names = name.Split('.');
            return names[NameIndex];
        }

        private string GetExtension(string name) {
            // Índice da extensão do arquivo.
            const int ExtensionIndex = 1;

            var parse = name.Split('.');
            var extension = string.Empty;

            // Se algum arquivo estiver com mais pontos.
            // Obtem todas essas extensões.
            // Exemplo: Arquivo.exe.config.
            for (var index = ExtensionIndex; index < parse.Length; index++) {
                extension += parse[index] + ".";
            }

            // Remove o ponto no final.
            return extension.Remove(extension.Length - 1, 1);
        }
    }
}