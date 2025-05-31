// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Routers;

if (args.Length < 2)
{
      System.Console.WriteLine("Enter <input_file> <output_file>");
      return;
}

string inputFileName = args[0];
string outputFileName = args[1];

if (string.IsNullOrWhiteSpace(inputFileName))
{
      System.Console.WriteLine("File path cannot be null.");
      return;
}

if (!File.Exists(inputFileName))
{
      System.Console.WriteLine("File not exists, try again.");
      return;
}

if (new FileInfo(inputFileName).Length == 0)
{
      System.Console.WriteLine("File is empty, try again.");
      return;
}

var network = ReadFromFile(inputFileName);
if (!network.IsNetworkConnected())
{
      System.Console.WriteLine("Graph should be connected!");
      return;
}

var newNet = network.PrimAlgorithm();
WriteToFile(newNet, outputFileName);

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

void WriteToFile(List<Edge> network, string filename)
{
      var grouped = network.GroupBy(e => e.FirstVertex).OrderBy(g => g.Key);
      using (var writer = new StreamWriter(filename))
      {
            foreach (var el in grouped)
            {
                  writer.Write($"{el.Key}: ");
                  var edges = el.Select(e => $"{e.SecondVertex}({e.Bandwidth})");
                  writer.WriteLine(string.Join(", ", edges));
            }
      }
}