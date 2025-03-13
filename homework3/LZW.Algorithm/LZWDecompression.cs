using System.Linq.Expressions;

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
      /// <exception cref="InvalidDataException">Invalid data.</exception>
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
                  if (dictionary.ContainsKey(code))
                  {
                        var element = dictionary[code];
                        output.AddRange(element);
                        var entry = current.Concat(new[] { element[0] }).ToArray();
                        dictionary[dictionary.Count] = entry;
                        current = element;
                  }
                  else
                  {
                        var entry = current.Concat(new byte[] { current[0] }).ToArray();
                        output.AddRange(entry);
                        dictionary[dictionary.Count] = entry;
                        current = entry;
                  }
            }

            return output.ToArray();
      }

      // private List<int> FromByteArray(byte[] array)
      // {
      // }
}