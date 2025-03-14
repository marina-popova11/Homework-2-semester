using System.Runtime.Intrinsics.Arm;
using LZW.Algorithm;

System.Console.WriteLine("Usage: lzw <file>");
string? filePath = System.Console.ReadLine();
System.Console.WriteLine("Enter [-c|-u]");
string? mode = System.Console.ReadLine();
if (filePath == null)
{
      System.Console.WriteLine("File path cannot be null.");
      return;
}

if (mode == "-c")
{
      CompressedFile(filePath);
}
else if (mode == "-u")
{
      DecompressedFile(filePath);
}
else
{
      System.Console.WriteLine("Use -c for compression or -u for decompression.");
}

static void CompressedFile(string filePath)
{
      var compress = new LZWCompression();
      (var compressed, var compressionRatio) = compress.Compress(filePath);
      var outputPath = filePath + ".zipped";
      File.WriteAllBytes(outputPath, compressed);

      System.Console.WriteLine($"Compression completed. Compression ratio: {compressionRatio:P}");
}

static void DecompressedFile(string filePath)
{
      if (!filePath.EndsWith(".zipped"))
      {
            System.Console.WriteLine("File must have .zipped extension for decompressing.");
      }

      var decompress = new LZWDecompression();
      var decompressed = decompress.Decompress(filePath);
      var outputPath = filePath.Replace(".zipped", "");
      File.WriteAllBytes(outputPath, decompressed);
      System.Console.WriteLine($"Decompressing completed.");
}
