public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        string operationString = operation switch
        {
            "+" or "*" or "/" => operation,
            "" => throw new ArgumentException("The operation argument is an empty string.", nameof(operation)),
            null => throw new ArgumentNullException(nameof(operation), "The operation argument is null."),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, "Unsupported math operation.")
        };
        
        if (operationString == "/" && operand2 == 0)
        {
            return "Division by zero is not allowed.";
        }
    
        List<object> output = new();
        output.Add(operand1);
        output.Add(operationString);
        output.Add(operand2);
        
        var result = operationString switch
        {
            "+" => SimpleOperation.Addition(operand1, operand2),
            "*" => SimpleOperation.Multiplication(operand1, operand2),
            "/" => SimpleOperation.Division(operand1, operand2),
            _ => throw new Exception("Unknown operation error.")
        };
    
        output.Add(result);
        return string.Format("{0} {1} {2} = {3}", output.ToArray());
    }
}
