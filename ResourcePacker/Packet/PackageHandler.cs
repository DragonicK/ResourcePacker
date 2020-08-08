using System;
using System.IO;
using ResourcePacker.Common;

namespace ResourcePacker.Packet {
    public class PackageHandler : IPackageHandler {
        public Action<string> ProgressChanged { get; set; }

        public void OpenPackage(string path, IPackage package) {

            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read)) {
                using (BinaryReader reader = new BinaryReader(file)) {
                    var fileCount = reader.ReadInt32();
     
                    for (var i = 0; i < fileCount; i++) {
                        package.Add(ReadFile(reader));
                        UpdateProgress($"Processed {Util.GetProgressPercentage(i + 1, fileCount)}% Total {i + 1}");
                    }

                    reader.Close();
                }
            }
        }

        public void SavePackage(string path, IPackage package) {
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write)) {
                using (BinaryWriter writer = new BinaryWriter(file)) {
                    writer.Write(package.Count);

                    for(var i = 0; i < package.Count; i++) {
                        WriteFile(writer, package[i]);
                        UpdateProgress($"Processed {Util.GetProgressPercentage(i + 1, package.Count)}% Total {i + 1}");
                    }
                }
            }
        }

        private void WriteFile(BinaryWriter writer, IPackageFile f) {
            writer.Write(f.Name);
            writer.Write(f.Extension);
            writer.Write(f.Width);
            writer.Write(f.Height);
            writer.Write(f.Length);
            writer.Write(f.Bytes);
        }

        private IPackageFile ReadFile(BinaryReader reader) {
            var f = new PackageFile {
                Name = reader.ReadString(),
                Extension = reader.ReadString(),
                Width = reader.ReadInt32(),
                Height = reader.ReadInt32(),
                Length = reader.ReadInt32()
            };

            f.Bytes = reader.ReadBytes((int)f.Length);

            return f;
        }

        private void UpdateProgress(string text) {
            ProgressChanged?.Invoke(text);
        }
    }
}