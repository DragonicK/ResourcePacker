using System;
using System.IO;
using ResourcePacker.Common;

namespace ResourcePacker.Packet {
    public class PackageExport : IExportHandler {
        public Action<string> ProgressChanged { get; set; }

        public void ExportSelectedFiles(string path, int[] selectedIndex, IPackage package) {
            var length = selectedIndex.Length;

            for (var i = 0; i < length; i++) {
                ExportFile(path, package[selectedIndex[i]]);
                UpdateProgress($"Processed {Util.GetProgressPercentage(i + 1, length)}% Total {i + 1}");
            }
        }

        public void ExportAllFiles(string path, IPackage package) {
            for (var i = 0; i < package.Count; i++) {
                ExportFile(path, package[i]);
                UpdateProgress($"Processed {Util.GetProgressPercentage(i + 1, package.Count)}% Total {i + 1}");
            }
        }

        public void ExportFile(string path, IPackageFile packageFile) {
            //var name = packageFile.Name;
            //var extension = packageFile.Extension;

            //using (FileStream file = new FileStream($"{path}/{name}.{extension}", FileMode.Create, FileAccess.Write)) {
            //    using (BinaryWriter writer = new BinaryWriter(file)) {
            //        writer.Write(packageFile.Bytes);
            //    }
            //}
        }

        private void UpdateProgress(string text) {
            ProgressChanged?.Invoke(text);
        }
    }
}