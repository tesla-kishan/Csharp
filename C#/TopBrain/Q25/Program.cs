using System;

class Program
{
    static string EvaluateExpression(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression))
            return "Error:InvalidExpression";

        string[] parts = expression.Split(' ');

        // Must be exactly: a op b
        if (parts.Length != 3)
            return "Error:InvalidExpression";

        // Parse integers
        if (!int.TryParse(parts[0], out int a) ||
            !int.TryParse(parts[2], out int b))
        {
            return "Error:InvalidNumber";
        }

        string op = parts[1];

        switch (op)
        {
            case "+":
                return (a + b).ToString();

            case "-":
                return (a - b).ToString();

            case "*":
                return (a * b).ToString();

            case "/":
                if (b == 0)
                    return "Error:DivideByZero";
                return (a / b).ToString(); // integer division

            default:
                return "Error:UnknownOperator";
        }
    }

    static void Main()
    {
        string expression = Console.ReadLine();
        string result = EvaluateExpression(expression);
        Console.WriteLine(result);
    }
}