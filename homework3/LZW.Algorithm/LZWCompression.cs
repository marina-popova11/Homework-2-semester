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

            for (int i = 0; i < 256; ++i)
            {
                  trie.AddElement(new byte[] { (byte)i }, trie.NextCode); // (byte)i — это приведение значения переменной i к типу byte.\
                  //  Поскольку i является целым числом (int), оно преобразуется в байт. Это необходимо, потому что Trie работает с байтами, \
                  // а не с целыми числами. new byte[] { ... } — создаёт новый массив байтов, содержащий один элемент: (byte)i.
                  ++trie.NextCode;
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
                        var code = trie.Contains(currentStr.Take(length).ToArray()); // ищем массив в боре по длине
                        if (code == -1)
                        {
                              trie.AddElement(currentStr.Take(length).ToArray(), trie.NextCode);
                              ++trie.NextCode;
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