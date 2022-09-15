namespace BMP_and_PNG_resolution_reader
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            const string path = @"C:\Users\simon\source\repos\BMP and PNG resolution reader\SmallImage.png";

            byte[] fileData = GetByteArrayFromFile(path);

            if (SearchForPNGSignature(fileData))
            {
                byte resolution = fileData[19];
                byte overflowValueResolution = fileData[18];

                PrintResolutionOfImageFile(resolution, overflowValueResolution);

                resolution = fileData[23];
                overflowValueResolution = fileData[22];

                PrintResolutionOfImageFile(resolution, overflowValueResolution);
            }
            else if (SearchForBMPSignature(fileData))
            {
                byte resolution = fileData[18];
                byte overflowValueResolution = fileData[19];

                PrintResolutionOfImageFile(resolution, overflowValueResolution);

                resolution = fileData[22];
                overflowValueResolution = fileData[23];

                PrintResolutionOfImageFile(resolution, overflowValueResolution);
            }
            else
            {
                Console.WriteLine("File is invalid.");
            }
        }
        private static byte[] GetByteArrayFromFile(string path)
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

        private static bool SearchForPNGSignature(byte[] fileData)
        {
            byte[] PNGSignature = { 137, 80, 78, 71, 13, 10, 26, 10 };

            for (int i = 0; i < 8; i++)
            {
                if (PNGSignature[i] != fileData[i])
                    return false;
            }
            return true;
        }

        private static bool SearchForBMPSignature(byte[] fileData)
        {
            byte[] BMPSignature = { 77, 66 };

            for (int i = 0; i < BMPSignature.Length; i++)
            {
                if (BMPSignature[i] != fileData[i])
                {
                    return false;
                }                
            }
            return true;
        }

        private static void PrintResolutionOfImageFile(byte resolution, byte overflowValueResolution)
        {
            int length = overflowValueResolution * 256 + resolution;
            Console.Write($"{length} ");
        }
    }
}