using BMP_and_PNG_resolution_reader;
using System.Globalization;
using System.Runtime.Intrinsics.Arm;

namespace Resolution_Reader.Tests    
{
    public class UnitTest1
    {
        [Fact]
        public void SearchForPNGSignature_TestNormal()
        {
            byte[] PNGSignature = { 137, 80, 78, 71, 13, 10, 26, 10 };

            bool actual = Program.SearchForPNGSignature(PNGSignature);

            Assert.True(actual);
        }
        [Fact]
        public void SearchForPNGSignature_TestNull()
        {
            byte[] PNGSignature = null;
          
            Action nullTest = () => Program.SearchForPNGSignature(PNGSignature);
            Assert.Throws<ArgumentException>(nullTest);
        }
        [Fact]
        public void SearchForPNGSignature_TestEmpty()
        {
            byte[] PNGSignature = { };

            Action emptyTest = () => Program.SearchForPNGSignature(PNGSignature);
            Assert.Throws<ArgumentException>(emptyTest);
        }
        [Fact]
        public void SearchForBMPSignature_TestNormal()
        {
            byte[] BMPSignature = { 66, 77 };

            bool actual = Program.SearchForBMPSignature(BMPSignature);

            Assert.True(actual);
        }
        [Fact]
        public void SearchForBMPSignature_TestNull()
        {
            byte[] BMPSignature = null;

            Action nullTest = () => Program.SearchForBMPSignature(BMPSignature);
            Assert.Throws<ArgumentException>(nullTest);
        }
        [Fact]
        public void SearchForBMPSignature_TestEmpty()
        {
            byte[] BMPSignature = { };

            Action emptyTest = () => Program.SearchForBMPSignature(BMPSignature);
            Assert.Throws<ArgumentException>(emptyTest);
        }
        [Fact]
        public void GetByteArrayFromFile_TestNormal()
        {
            const string path = @"C:\Users\simon\Desktop\test.txt";

            byte[] expected = { 72, 101, 108, 108, 111, 32, 87, 111, 114, 108, 100 };
            byte[] actual = Program.GetByteArrayFromFile(path);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GetByteArrayFromFile_TestNull()
        {
            string path = null;

            Action nullTest = () => Program.GetByteArrayFromFile(path);
            Assert.Throws<ArgumentException>(nullTest);
        }
        [Fact]
        public void GetByteArrayFromFile_TestEmpty()
        {
            string path = string.Empty;

            Action emptyTest = () => Program.GetByteArrayFromFile(path);
            Assert.Throws<ArgumentException>(emptyTest);
        }
    }
}