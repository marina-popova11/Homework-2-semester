// <copyright file="Tree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParsingTree;

/// <summary>
/// This parsing tree.
/// </summary>
public class Tree
{
    private Node? root;

    /// <summary>
    /// Initializes a new instance of the <see cref="Tree"/> class.
    /// </summary>
    /// <param name="data">The input string.</param>
    public Tree(string data)
    {
        this.root = this.GetParsingTree(data);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Tree"/> class.
    /// </summary>
    /// <param name="root">The tree root.</param>
    public Tree(Node root)
    {
        this.root = root;
    }

    /// <summary>
    /// The function for calculating the value.
    /// </summary>
    /// <returns>The result of calculating.</returns>
    public int Evaluate()
    {
        if (this.root == null)
        {
            System.Console.WriteLine("The tree must not be empty.");
            return -1;
        }

        return this.root.Evaluate();
    }

    /// <summary>
    /// The function for output to the console.
    /// </summary>
    /// <returns>String.</returns>
    public string Print()
    {
        if (this.root == null)
        {
            throw new ArgumentNullException();
        }

        return this.root.Print();
    }

    /// <summary>
    /// Looking for a balance of brackets.
    /// </summary>
    /// <param name="operands">The expression.</param>
    /// <returns>Position of split space.</returns>
    public int FindOperandSplitPos(string operands)
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

    /// <summary>
    /// Builds a parse tree.
    /// </summary>
    /// <param name="data">Started expression.</param>
    /// <returns>The root of tree.</returns>
    /// <exception cref="FormatException">If expression must be enclosed in parentheses.</exception>
    /// <exception cref="InvalidOperationException">If you select an operation that does not exist.</exception>
    public Node GetParsingTree(string data)
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
        int splitPos = this.FindOperandSplitPos(operands);
        if (splitPos < 0)
        {
            throw new FormatException("Could not split operands");
        }

        string leftPart = operands.Substring(0, splitPos).Trim();
        string rightPart = operands.Substring(splitPos).Trim();
        Node leftNode = this.GetParsingTree(leftPart);
        Node rightNode = this.GetParsingTree(rightPart);
        return operation switch
        {
            "+" => new OperatorNode("+", leftNode, rightNode),
            "-" => new OperatorNode("-", leftNode, rightNode),
            "*" => new OperatorNode("*", leftNode, rightNode),
            "/" => new OperatorNode("/", leftNode, rightNode),
            _ => throw new InvalidOperationException($"Unknown operator!"),
        };
    }
}