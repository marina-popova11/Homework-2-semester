namespace LZW.Algorithm;

/// <summary>
/// Data decompression class.
/// </summary>
public class LZWDecompression
{
      /// <summary>
      /// A function for decompressing data.
      /// </summary>
      /// <param name="compressedFilePath">The path to the compressed file with the extension .zipped.</param>
      /// <param name="targetFilePath">The path to the source file.</param>
      public void Decompress(string compressedFilePath, string targetFilePath)
      {
            var dict = new Dictionary<int, byte[]>();
            int nextCode = 0;
            for (int i = 0; i < 256; ++i)
            {
                  dict[nextCode] = new byte[] { (byte)i };
                  ++nextCode;
            }

            using (FileStream compressedStream = new FileStream(compressedFilePath, FileMode.Open))
            using (FileStream targetStream = new FileStream(targetFilePath, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(targetStream))
            using (BinaryReader reader = new BinaryReader(compressedStream))
            {
                  int previousCode = reader.ReadInt32();
                  writer.Write(dict[previousCode]);
                  while (compressedStream.Position < compressedStream.Length)
                  {
                        int currentCode = reader.ReadInt32();
                        byte[] currentStr = new byte[1000];
                        if (dict.ContainsKey(currentCode))
                        {
                              currentStr = dict[currentCode];
                        }
                        else
                        {
                              currentStr = dict[previousCode].Concat(new byte[] { dict[previousCode][0] }).ToArray();
                        }

                        writer.Write(currentStr);
                        byte[] newStr = dict[previousCode].Concat(new byte[] { currentStr[0] }).ToArray();
                        dict[nextCode] = newStr;
                        ++nextCode;
                        previousCode = currentCode;
                        dict[previousCode] = currentStr;
                  }
            }
      }
}