using Routers;

System.Console.WriteLine("Enter the filename: ");
string? filename = System.Console.ReadLine();
if (string.IsNullOrWhiteSpace(filename))
{
      System.Console.WriteLine("File path cannot be null.");
      return;
}

if (!File.Exists(filename))
{
      System.Console.WriteLine("File not exists, try again.");
      return;
}

if (new FileInfo(filename).Length == 0)
{
      System.Console.WriteLine("File is empty, try again.");
      return;
}

var network = ReadFromFile(filename);
var newNet = network.PrimAlgorithm();
WriteToFile(newNet);

Network ReadFromFile(string filename)
{
      var network = new Network();
      using (StreamReader reader = new StreamReader(filename))
      {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                  var parts = line.Split(":");
                  int vertex1 = int.Parse(parts[0].Trim());
                  var neighbors = parts[1].Split(',');
                  foreach (var el in neighbors)
                  {
                        var neighborsParts = el.Trim().Split(new[] { '(', ')' },  StringSplitOptions.RemoveEmptyEntries);
                        int vertex2 = int.Parse(neighborsParts[0].Trim());
                        int bandwidth = int.Parse(neighborsParts[1].Trim());
                        network.AddEdge(vertex1, vertex2, bandwidth);
                  }
            }
      }

      return network;
}

void WriteToFile(List<Edge> network)
{
      var grouped = network.GroupBy(e => e.FirstVertex).OrderBy(g => g.Key);
      using (var writer = new StreamWriter("newFile.txt"))
      {
            foreach (var el in grouped)
            {
                  writer.Write($"{el.Key}: ");
                  var edges = el.Select(e => $"{e.SecondVertex}({e.Bandwidth})");
                  writer.WriteLine(string.Join(", ", edges));
            }
      }
}