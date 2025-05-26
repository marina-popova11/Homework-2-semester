using PrefixTrie;

/// <summary>
/// Tests by trie.
/// </summary>
public class Tests
{
      /// <summary>
      /// Tests.
      /// </summary>
      /// <returns>If all tests passed returns true.</returns>
      public static bool AllTests()
      {
            if (!AddTest())
            {
                  System.Console.WriteLine("AddTest is failed.");
                  return false;
            }

            if (!ContainsTest())
            {
                  System.Console.WriteLine("ContainsTest is failed.");
                  return false;
            }

            if (!RemoveTest())
            {
                  System.Console.WriteLine("RemoveTest is failed.");
                  return false;
            }

            if (!HowManyStartsWithPrefixTest())
            {
                  System.Console.WriteLine("HowManyStartsWithPrefixTest is failed.");
                  return false;
            }

            return true;
      }

      private static bool AddTest()
      {
            Trie trie = new();
            trie.AddElement("dog");
            trie.AddElement("doing");
            return trie.Size == 2;
      }

      private static bool ContainsTest()
      {
            Trie trie = new();
            trie.AddElement("dog");
            trie.AddElement("doing");
            trie.AddElement("milk");
            trie.AddElement("do");
            trie.AddElement("car");
            return trie.Contains("do");
      }

      private static bool RemoveTest()
      {
            Trie trie = new();
            trie.AddElement("dog");
            trie.AddElement("doing");
            trie.AddElement("milk");
            trie.AddElement("do");
            trie.AddElement("car");
            if (trie.Remove("do"))
            {
                  return trie.Size == 4;
            }

            return false;
      }

      private static bool HowManyStartsWithPrefixTest()
      {
            Trie trie = new();
            trie.AddElement("dog");
            trie.AddElement("doing");
            trie.AddElement("milk");
            trie.AddElement("do");
            trie.AddElement("car");
            return trie.HowManyStartsWithPrefix("do") == 3;
      }
}