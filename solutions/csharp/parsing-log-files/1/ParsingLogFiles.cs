using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text)
    {
        return Regex.IsMatch(text, @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]");
    }

    public string[] SplitLogLine(string text)
    {
        return Regex.Split(text, "<[^>]*>");
    }

    public int CountQuotedPasswords(string lines)
    {
        return Regex.Matches(lines, @"""[^""]*password[^""]*""", RegexOptions.IgnoreCase).Count;
    }

    public string RemoveEndOfLineText(string line)
    {
        return Regex.Replace(line, @"end-of-line[\d]*", "");
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        List<string> result = new List<string>();
        foreach (string line in lines)
        {
            Match match = Regex.Match(line, @"^\[[^]]*\]\s*(?:password\s+|)(password[^\s]+)", RegexOptions.IgnoreCase);
            result.Add((match.Success ? match.Groups[1].Value : "--------") + ": " + line);
        }
        return result.ToArray();
    }
}
