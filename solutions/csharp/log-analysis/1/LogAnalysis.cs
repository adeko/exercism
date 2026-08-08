public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string input, string delimiter)
    {
        string[] parts = input.Split(delimiter);
        if (parts.Length > 1) return parts[1];
        throw new Exception("Invalid string");
    }

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string input, string delimiter1, string delimiter2)
    {
        if (input.Contains(delimiter1) && input.Contains(delimiter2))
        {
            return input[(input.IndexOf(delimiter1)+delimiter1.Length)..input.IndexOf(delimiter2)];
        }
        throw new Exception("Invalid string");        
    }
    
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string input)
    {
        return input.SubstringAfter(": ");        
    }
    
    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string input)
    {
        return input.SubstringBetween("[", "]"); 
    }
}