// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ParsingTree;

if (args.Length < 1)
{
    System.Console.WriteLine("Enter the filename!");
    return;
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
var tree = new Tree(inputData);
System.Console.WriteLine($"The parsing tree : {tree.Print()}");
int result = tree.Evaluate();

System.Console.WriteLine($"Result of calculating: {result}");