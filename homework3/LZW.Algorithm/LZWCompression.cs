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
      /// <param name="compressedFilePath">The path to the compressed file with the extension .zipped.</param>
      public void Compress(string filePath, string compressedFilePath)
      {
            var trie = new Trie();
            int nextCode = 0;

            for (int i = 0; i < 256; ++i)
            {
                  trie.AddElement(new byte[] { (byte)i }, nextCode); // new byte[] { ... } — создаёт новый массив байтов, содержащий один элемент: (byte)i.
                  ++nextCode;
            }

            using (FileStream sourceStream = new FileStream(filePath, FileMode.Open))
            using (FileStream targetStream = File.Create(compressedFilePath))
            using (BinaryWriter writer = new BinaryWriter(targetStream))
            {
                  byte[] currentStr = new byte[1000];
                  int length = 0;
                  int el;
                  while ((el = sourceStream.ReadByte()) != -1)
                  {
                        currentStr[length] = (byte)el;
                        ++length;
                        var code = trie.Contains(currentStr.Take(length).ToArray());
                        if (code == -1)
                        {
                              trie.AddElement(currentStr.Take(length).ToArray(), nextCode);
                              ++nextCode;
                              writer.Write(trie.Contains(currentStr.Take(length - 1).ToArray()));
                              length = 0;
                              currentStr[length] = (byte)el;
                              ++length;
                        }
                  }

                  if (length > 0)
                  {
                        writer.Write(trie.Contains(currentStr.Take(length).ToArray()));
                  }
            }
      }
}