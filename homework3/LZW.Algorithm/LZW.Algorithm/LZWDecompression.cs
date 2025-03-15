namespace LZW.Algorithm;

/// <summary>
/// Data decompression class.
/// </summary>
public class LZWDecompression
{
      /// <summary>
      /// A function for decompressing data.
      /// </summary>
      /// <param name="filePath">The path to the compressed file with the extension .zipped.</param>
      /// <returns>A sequence of bytes.</returns>
      public byte[] Decompress(string filePath)
      {
            var input = File.ReadAllBytes(filePath);
            var dictionary = new Dictionary<int, byte[]>();
            for (int i = 0; i < 256; ++i)
            {
                  dictionary[i] = new byte[] { (byte)i };
            }

            var compressed = this.FromByteArray(input);
            var output = new List<byte>();
            var current = dictionary[compressed[0]];
            output.AddRange(current);

            for (int i = 1; i < compressed.Count; ++i)
            {
                  var code = compressed[i];
                  byte[] element;
                  if (dictionary.ContainsKey(code))
                  {
                        element = dictionary[code];
                  }
                  else
                  {
                        element = current.Concat(new[] { current[0] }).ToArray();
                  }

                  output.AddRange(element);
                  var entry = current.Concat(new[] { element[0] }).ToArray();
                  dictionary[dictionary.Count] = entry;
                  current = element;
            }

            return output.ToArray();
      }

      private List<int> FromByteArray(byte[] array)
      {
            var intList = new List<int>();
            int i = 0;

            while (i < array.Length)
            {
                  byte firstByte = array[i];

                  if (firstByte < 0x80) // Однобайтовое число
                  {
                        intList.Add(firstByte);
                        i += 1;
                  }
                  else if ((firstByte & 0xC0) == 0x80) // Двухбайтовое число
                  {
                        if (i + 1 >= array.Length)
                        {
                              throw new InvalidOperationException("Invalid byte array format");
                        }

                        int value = ((firstByte & 0x3F) << 8) | array[i + 1];
                        intList.Add(value);
                        i += 2;
                  }
                  else if ((firstByte & 0xE0) == 0xC0) // Трехбайтовое число
                  {
                        if (i + 2 >= array.Length)
                        {
                              throw new InvalidOperationException("Invalid byte array format");
                        }

                        int value = ((firstByte & 0x1F) << 16) | (array[i + 1] << 8) | array[i + 2];
                        intList.Add(value);
                        i += 3;
                  }
                  else
                  {
                        throw new InvalidOperationException("Invalid byte array format");
                  }
            }

            return intList;
      }
}