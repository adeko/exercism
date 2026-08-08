static class LogLine
{
    public static string Message(string logLine)
    {
        string[] parts = logLine.Split(":");
        if (parts.Length > 1) return parts[1].Trim();
        throw new NotImplementedException("Invalid Message");
    }

    public static string LogLevel(string logLine)
    {
        string[] parts = logLine.Split(":");
        if (parts.Length > 1) return parts[0].Trim().Trim('[',']').Trim().ToLower();
        throw new NotImplementedException("Invalid Message");
    }

    public static string Reformat(string logLine)
    {
        string[] parts = logLine.Split(":");
        if (parts.Length > 1) return parts[1].Trim() + " (" + parts[0].Trim().Trim('[',']').Trim().ToLower() + ")";
        throw new NotImplementedException("Invalid Message");
    }
}
