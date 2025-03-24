using Routers;

System.Console.WriteLine("Enter the filename: ");
string? filename = System.Console.ReadLine();
if (filename == null)
{
      System.Console.WriteLine("File path cannot be null.");
}

var network = ReadFromFile(filename);
var newNet = network.PrimAlgorithm();

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