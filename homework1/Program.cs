if (!TestTransformation() || !TestReverseConversion())
{
      return -1;
}

System.Console.Write("Enter a string consisting of letters or numbers: ");
string? line = System.Console.ReadLine();
if (line is null)
{
      return -1;
}

var (result, index) = Transformation(line);
System.Console.WriteLine($"Result: {result} index: {index}");
string originLine = ReverseConversion(result, index);
System.Console.WriteLine(originLine);
System.Console.WriteLine(line == originLine);

(string TmpString, int Index) Transformation(string line)
{
      int length = line.Length;
      var rotations = new List<string>(length);
      for (int i = 0; i < length; ++i)
      {
            string rotation = line.Substring(i) + line.Substring(0, i);
            rotations.Add(rotation);
      }

      var sortedRotations = rotations.OrderBy(r => r).ToList();

      var tmpString = new char[length];
      int index = -1;
      for (int i = 0; i < length; ++i)
      {
            tmpString[i] = sortedRotations[i][length - 1];
            if (sortedRotations[i] == line)
            {
                  index = i;
            }
      }

      return (new string(tmpString), index);
}

string ReverseConversion(string modifiedLine, int index)
{
      int length = modifiedLine.Length;
      var result = new char[length];
      var sortedModifiedLine = modifiedLine.ToCharArray();
      Array.Sort(sortedModifiedLine);
      var str = new string(sortedModifiedLine);

      var next = new int[length];
      var count = new Dictionary<char, int>();
      for (int i = 0; i < length; ++i)
      {
            if (!count.ContainsKey(modifiedLine[i]))
            {
                  count[modifiedLine[i]] = 0;
            }

            count[modifiedLine[i]]++;
      }

      var sortedChars = count.Keys.ToList();
      sortedChars.Sort();
      var positions = new int[sortedChars.Count];
      for (int i = 0; i < sortedChars.Count; ++i)
      {
            positions[i] = i == 0 ? 0 : positions[i - 1] + count[sortedChars[i - 1]];
      }

      for (int i = 0; i < length; ++i)
      {
            char symbol = modifiedLine[i];
            int tmpIndex = sortedChars.IndexOf(symbol);
            result[positions[tmpIndex]] = symbol;
            next[positions[tmpIndex]] = i;
            positions[tmpIndex]++;
      }

      var originString = new char[length];
      for (int i = 0; i < length; ++i)
      {
            originString[i] = sortedModifiedLine[index];
            index = next[index];
      }

      return new string(originString);
}

return 0;

bool TestTransformation()
{
      return ("nwekeed", 6) == Transformation("weekend");
}

bool TestReverseConversion()
{
      string str = "psaccuuphh";
      int index = 1;
      return ReverseConversion(str, index) == "chupachups";
}
