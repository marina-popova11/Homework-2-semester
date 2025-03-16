using LZW.Algorithm;
using NUnit.Framework.Constraints;

namespace LZW.Algorithm.Tests;

public class TestForDecompression
{
      private LZWDecompression lzw = new();
      [SetUp]
      public void SetUp()
      {
            var lzw = new LZWDecompression();
      }

      [Test]
      public void Test_DecompressEmptySet()
      {
            var filePath = Path.GetTempFileName();
            File.WriteAllBytes(filePath, Array.Empty<byte>());
            var decompressed = lzw.Decompress(filePath);
            Assert.That(decompressed, Is.Empty);
            File.Delete(filePath);
      }

      [Test]
      public void Test_DecompressOneElement()
      {
            var filePath = Path.GetTempFileName();
            var compressed = new byte[] { 0x41 };
            File.WriteAllBytes(filePath, compressed);
            var decompressed = lzw.Decompress(filePath);
            Assert.That(decompressed, Is.EqualTo(new byte[] { (byte)'A' }));
            File.Delete(filePath);
      }

      [Test]
      public void Test_DecompressRepeatedElements()
      {
            var filePath = Path.GetTempFileName();
            var compressed = new byte[] { (byte)'A', (byte)'A', (byte)'A' };
            File.WriteAllBytes(filePath, compressed);
            var decompressedData = lzw.Decompress(filePath);
            Assert.That(decompressedData, Is.EqualTo(new byte[] { (byte)'A', (byte)'A', (byte)'A' }));
            File.Delete(filePath);
      }

      [Test]
      public void Test_DecompressInvalidByteArrayThrowsException()
      {
            var filePath = Path.GetTempFileName();
            var compressed = new byte[] {0xC0};
            File.WriteAllBytes(filePath, compressed);
            Assert.That(() => lzw.Decompress(filePath), Throws.TypeOf<InvalidOperationException>());
      }

      [Test]
      public void Test_DecompressInvalidFilePathThrowsException()
      {
            var invalidFilePath = "invalid_path.zipped";
            Assert.That(() => lzw.Decompress(invalidFilePath), Throws.TypeOf<FileNotFoundException>());
      }
}