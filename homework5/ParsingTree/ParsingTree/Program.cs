using ParsingTree;

if (args.Length < 1)
{
      System.Console.WriteLine("Enter the filename!");
}

string input = args[0];
if (string.IsNullOrWhiteSpace(input))
{
      System.Console.WriteLine("File path cannot be null.");
      return;
}

if (!File.Exists(input))
{
      System.Console.WriteLine("File not exists, try again.");
      return;
}

if (new FileInfo(input).Length == 0)
{
      System.Console.WriteLine("File is empty, try again.");
      return;
}

string inputData = File.ReadAllText(input).Trim();
Node root = GetParsingTree(inputData);
var tree = new Tree(root);

Node GetParsingTree(string data)
{
      data = data.Trim('(', ')');
      var parts = data.Split(' ');

}