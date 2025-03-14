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
            var result = new List<int>();
            for (int i = 0; i < array.Length; i += 4)
            {
                  if (i + 4 <= array.Length)
                  {
                        int code = BitConverter.ToInt32(array, i);
                        result.Add(code);
                  }
            }

            return result;
      }
}