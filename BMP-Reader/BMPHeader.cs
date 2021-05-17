namespace BMP_Reader
{
    struct BMPHeader
    {
        public char bfMagicA;//0
        public char bfMagicB;//1
        public uint bfSize;//2
        //public uint bfReserved; //6
        public uint bfImageOffset;//10

        public uint biImageHeaderSize;//14
        public int biWidth;//18
        public int biHeight;//22 Positiv = BottomUp, Negativ = TopDown
        //public ushort biPlanes; //26 immer 1
        public ushort biBitCount; // 28 Bittiefe pro pixel
        public int biCompression; //30
    }

}
