namespace ResourcePacker.Packet {
    public class PackageFile : IPackageFile {
        public string Name { get; set; } 
        public string Extension { get; set; }
        public byte[] Bytes { get; set; }
        public long Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
     
        public PackageFile() {
            Name = string.Empty;
            Extension = string.Empty;
        }
    }
}