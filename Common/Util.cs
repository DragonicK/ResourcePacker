using System.Globalization;

namespace ResourcePacker.Common {
    public static class Util {
        private static NumberFormatInfo numberFormat = NumberFormatInfo.InvariantInfo;

        public const long Bytes = 1024;
        public const long KiloBytes = 1048576; // KiloBytes = (Bytes * 1024) 
        public const long MegaBytes = 1073741824; // MegaBytes = (KiloBytes * 1024) 

        public static string GetFileSize(long fileSize) {
            var kByte = (double)fileSize / 1024D;
            var mByte = kByte / 1024D;
            var gByte = mByte / 1024D;

            if (fileSize < Bytes) {
                return string.Format(numberFormat, "{0} Bytes", fileSize);
            }
            else if (fileSize < KiloBytes) {
                return string.Format(numberFormat, "{0:0.00} KB", kByte);
            }
            else if (fileSize < MegaBytes) {
                return string.Format(numberFormat, "{0:0.00} MB", mByte);
            }
            else {
                return string.Format(numberFormat, "{0:0.00} GB", gByte);
            }
        }

        public static int GetProgressPercentage(int minValue, int maxValue) {
            // Não permite uma divisão por 0.
            if (minValue <= 0) {
                minValue = 1;
            }

            if (maxValue <= 0) {
                maxValue = 1;
            }

            float result = ((float)minValue / (float)maxValue);

            return (int)(result * 100);
        }
    }
}