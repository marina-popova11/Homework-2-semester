namespace LZW.Algorithm;

/// <summary>
/// Data compression class.
/// </summary>
public class LZWCompression
{
      /// <summary>
      /// A function for compressing data and moving character codes to a compressed file.
      /// </summary>
      /// <param name="filePath">The path to the source file.</param>
      /// <returns>A sequence of bytes.</returns>
      public (byte[] Array, double CompressionRatio) Compress(string filePath)
      {
            var input = File.ReadAllBytes(filePath);
            var trie = new Trie();
            for (int i = 0; i < 256; ++i)
            {
                  trie.AddElement(new byte[] { (byte)i });
            }

            var output = new List<int>();
            var current = new List<byte>();

            foreach (var el in input)
            {
                  var next = new List<byte>(current) { el };
                  if (trie.Contains(next.ToArray()) != -1)
                  {
                        current = next;
                  }
                  else
                  {
                        output.Add(trie.Contains(current.ToArray()));
                        trie.AddElement(next.ToArray());
                        current = new List<byte> { el };
                  }
            }

            if (output.Count > 0)
            {
                  output.Add(trie.Contains(current.ToArray()));
            }

            byte[] outputFile = this.ToByteArray(output.ToArray());
            return (outputFile, (double)outputFile.Length / input.Length);
      }

      private byte[] ToByteArray(int[] list)
      {
            var byteList = new List<byte>();
            foreach (var code in list)
            {
                  if (code < 128)
                  {
                        byteList.Add((byte)code);
                  }
                  else if (code < 16384)
                  {
                        byteList.Add((byte)(0x80 | (code >> 8)));
                        byteList.Add((byte)(code & 0xFF));
                  }
                  else
                  {
                        byteList.Add((byte)(0xC0 | (code >> 16)));
                        byteList.Add((byte)((code >> 8) & 0xFF));
                        byteList.Add((byte)(code & 0xFF));
                  }
            }

            return byteList.ToArray();
      }

      // {
      //       var byteList = new List<byte>();
      //       byte currentByte = 0;
      //       int bitPosition = 0;
      //       foreach (int code in list)
      //       {
      //             int bitCount = this.GetBitCount(code);
      //             for (int i = bitCount - 1; i >= 0; --i)
      //             {
      //                   currentByte |= (byte)(((code >> i) & 1) << (7 - bitPosition));
      //                   bitPosition++;
      //                   if (bitPosition == 8)
      //                   {
      //                         byteList.Add(currentByte);
      //                         bitPosition = 0;
      //                         currentByte = 0;
      //                   }
      //             }
      //       }
      //       if (bitPosition > 0)
      //       {
      //             byteList.Add(currentByte);
      //       }
      //       return byteList.ToArray();
      // }

      // private int GetBitCount(int value)
      // {
      //       if (value == 0)
      //       {
      //             return 1;
      //       }
      //       int bitCount = 0;
      //       while (value > 0)
      //       {
      //             value >>= 1;
      //             ++bitCount;
      //       }
      //       return bitCount;
      // }
}
