namespace ResourcePacker.Packet {
    public interface IPackageFile {
        string Name { get; set; }
        string Extension { get; set; }
        byte[] Bytes { get; set; }
        long Length { get; set; }
        int Width { get; set; }
        int Height { get; set; }
    }
}