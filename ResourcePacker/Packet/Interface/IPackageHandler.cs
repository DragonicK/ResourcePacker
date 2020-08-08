using System;

namespace ResourcePacker.Packet {
    public interface IPackageHandler {
        Action<string> ProgressChanged { get; set; }
        void OpenPackage(string path, IPackage pack);
        void SavePackage(string path, IPackage pack);
    }
}