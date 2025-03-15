using LZW.Algorithm;
using NUnit.Framework.Constraints;

namespace LZW.Algorithm.Tests;

public class Tests
{
    private LZWCompression lzw = new(); 
    [SetUp]
    public void SetUp()
    {
        var lzw = new LZWCompression();
    }
    [Test]
    public void Test_CompressEmptySet()
    {
        var filePath = Path.GetTempFileName();
        File.WriteAllBytes(filePath, Array.Empty<byte>());
        (var compressed, var cRatio) = lzw.Compress(filePath);
        Assert.That(compressed, Is.Empty);
        File.Delete(filePath);
    }

    [Test]
    public void Test_CompressTwoElement()
    {
        byte[] array = [99, 3];
        var filePath = Path.GetTempFileName();
        File.WriteAllBytes(filePath, array);
        (var compressed, var cRatio) = lzw.Compress(filePath);
        Assert.That(compressed, Is.Not.Empty);
        File.Delete(filePath);
    }

    [Test]
    public void Test_CompressTenElements()
    {
        var filePath = Path.GetTempFileName();
        File.WriteAllText(filePath, "AAAAA");
        (var compressed, var cRatio) = lzw.Compress(filePath);
        Assert.That(compressed, Is.Not.Empty);
        Assert.That(cRatio, Is.GreaterThan(0));
        File.Delete(filePath);   
    }
    
    [Test]
    public void Compress_InvalidFilePathThrowsException()
        {
            var invalidFilePath = "invalid_path.txt";
            Assert.Throws<FileNotFoundException>(() => lzw.Compress(invalidFilePath));
        }
}
