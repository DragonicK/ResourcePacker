namespace ResourcePacker.Packet {
    public interface IPackage {
        int Count { get; }
        IPackageFile this[int index] { get; set; }
        void Add(string file, string name);
        void Add(IPackageFile file);
        void Clear();
        void Insert(int index, string file, string name);
        void Insert(int index, IPackageFile file);
        void Remove(int[] selectedIndex);
        bool MoveUp(int[] selectedIndex);
        bool MoveDown(int[] selectedIndex);
        bool MoveTo(int index, int[] selectedIndex);
    }
}