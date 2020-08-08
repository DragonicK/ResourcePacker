using System;
namespace ResourcePacker.Packet {
    public interface IExportHandler {
        Action<string> ProgressChanged { get; set; }
        void ExportSelectedFiles(string path, int[] selectedIndex, IPackage package);
        void ExportAllFiles(string path, IPackage package);
        void ExportFile(string path, IPackageFile packageFile);
    }
}