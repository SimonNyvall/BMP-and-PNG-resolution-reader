namespace BMP_and_PNG_resolution_reader
{
    public class Program
    {        
        static void Main(string[] args)
        {
            const string path = @"C:\Users\simon\source\repos\BMP and PNG resolution reader\SmallImage.png";

            byte[] fileData = GetByteArrayFromFile(path);

            if (SearchForPNGSignature(fileData))
            {
                byte resolutionWidth = fileData[19];
                byte overflowValueResolutionWidth = fileData[18];     

                byte resolutionHeigth = fileData[23];
                byte overflowValueResolutionHeigth = fileData[22];

                int width = overflowValueResolutionWidth * 256 + resolutionWidth;
                int heigth = overflowValueResolutionHeigth * 256 + resolutionHeigth;

                PrintResolutionOfImageFile(width, heigth);
            }
            else if (SearchForBMPSignature(fileData))
            {
                byte resolutionWidth = fileData[18];
                byte overflowValueResolutionWidth = fileData[19];
               
                byte resolutionHeigth = fileData[22];
                byte overflowValueResolutionHeigth = fileData[23];

                int width = overflowValueResolutionWidth * 256 + resolutionWidth;
                int heigth = overflowValueResolutionHeigth * 256 + resolutionHeigth;

                PrintResolutionOfImageFile(width, heigth);
            }
            else
            {
                Console.WriteLine("File is invalid.");
            }
        }
        public static byte[] GetByteArrayFromFile(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Null or empty", path);
            using (var dataStream = new FileStream(path, FileMode.Open))
            {
                var fileSize = (int)dataStream.Length;

                byte[] data = new byte[fileSize];

                dataStream.Read(data, 0, fileSize);

                return data;
            }            
        }

        public static bool SearchForPNGSignature(byte[] fileData)
        {
            if (fileData == null) throw new ArgumentException("No data");
            if (fileData.Length <= 1) throw new ArgumentException("No data");

            byte[] PNGSignature = { 137, 80, 78, 71, 13, 10, 26, 10 };

            for (int i = 0; i < 8; i++)
            {
                if (PNGSignature[i] != fileData[i])
                    return false;
            }
            return true;
        }

        public static bool SearchForBMPSignature(byte[] fileData)
        {
            if (fileData == null) throw new ArgumentException("No data");
            if (fileData.Length <= 1) throw new ArgumentException("No data");

            byte[] BMPSignature = { 66, 77 };

            for (int i = 0; i < BMPSignature.Length; i++)
            {
                if (BMPSignature[i] != fileData[i])
                {
                    return false;
                }                
            }
            return true;
        }

        private static void PrintResolutionOfImageFile(int pixelWidth, int pixelHeight)
        {            
            Console.Write($"{pixelWidth}x{pixelHeight}");
        }
    }
}