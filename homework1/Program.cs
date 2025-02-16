using System.Globalization;

System.Console.Write("Enter the string for conversion: ");
string line = System.Console.ReadLine();
if (line is null)
{
      return -1;
}

string result = Transformation(line);
System.Console.WriteLine("Result: " + result);

string Transformation(string line)
{
      int length = line.Length;
      string[] tmpArray = new string[length];
      for (int i = 0; i < length; ++i)
      {
            tmpArray[i] = line.Substring(i) + line.Substring(0, i);
      }

      Array.Sort(tmpArray);
      foreach (string i in tmpArray)
      {
            System.Console.WriteLine(i);
      }

      string tmpString = string.Empty;
      foreach (string i in tmpArray)
      {
            tmpString += i[i.Length - 1];
      }

      return tmpString;
}

return 0;