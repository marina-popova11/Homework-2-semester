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
int result = tree.Evaluate();
System.Console.WriteLine($"Result of calculating: {result}");

Node GetParsingTree(string data)
{
      data = data.Trim();
      if (int.TryParse(data, out int number))
      {
            return new NumberNode(number);
      }

      if (!data.StartsWith("(") || !data.EndsWith(")"))
      {
            throw new FormatException("Expression must be enclosed in parentheses");
      }

      string inner = data.Substring(1, data.Length - 2).Trim();
      int firstSpace = inner.IndexOf(' ');
      if (firstSpace <= 0)
      {
            throw new FormatException("Invalid expression format");
      }

      string operation = inner.Substring(0, firstSpace);
      string operands = inner.Substring(firstSpace + 1).Trim();
      int splitPos = FindOperandSplitPos(operands);
      if (splitPos < 0)
      {
            throw new FormatException("Could not split operands");
      }

      // data = data.Trim().TrimStart('(').TrimEnd(')').Trim();
      // var parts = data.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      // if (parts.Length == 1)
      // {
      //       if (int.TryParse(parts[0], out int number))
      //       {
      //             return new NumberNode(number);
      //       }
      //       else
      //       {
      //             throw new FormatException($"Invalid operand {parts[0]}");
      //       }
      // }

      // if (parts.Length != 3)
      // {
      //       throw new FormatException("Expression must contain operator and exactly 2 operands");
      // }

      // var operation = parts[0];
      // var leftPart = parts[1];
      // var rightPart = parts[2];
      string leftPart = operands.Substring(0, splitPos).Trim();
      string rightPart = operands.Substring(splitPos).Trim();
      Node leftNode = GetParsingTree(leftPart);
      Node rightNode = GetParsingTree(rightPart);
      return operation switch
      {
            "+" => new OperatorNode("+", leftNode, rightNode),
            "-" => new OperatorNode("-", leftNode, rightNode),
            "*" => new OperatorNode("*", leftNode, rightNode),
            "/" => new OperatorNode("/", leftNode, rightNode),
            _ => throw new InvalidOperationException($"Unknown operator!"),
      };
}

int FindOperandSplitPos(string operands)
{
      int balance = 0;
      for (int i = 0; i < operands.Length; ++i)
      {
            char c = operands[i];
            if (c == '(')
            {
                  ++balance;
            }
            else if (c == ')')
            {
                  --balance;
            }

            if (c == ' ' && balance == 0)
            {
                  return i;
            }
      }

      return -1;
}