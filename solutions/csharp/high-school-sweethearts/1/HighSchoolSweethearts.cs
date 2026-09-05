public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        studentA = studentA.Trim();
        studentB = studentB.Trim();
        return ("".PadLeft(31 - studentA.Length - 2) + $"{studentA} ♡ {studentB}").PadRight(61);
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        List<string> heart = new() {
"     ******       ******",
"   **      **   **      **",
" **         ** **         **",
"**            *            **",
"**                         **",
" **                       **",
"   **                   **",
"     **               **",
"       **           **",
"         **       **",
"           **   **",
"             ***",
"              *"
        };
        studentA = studentA.Trim();
        studentB = studentB.Trim();
        string line = ("".PadLeft(15 - studentA.Length - 3 - 2) + $"{studentA}  +  {studentB}").PadRight(29 - 4);
        line = $"**{line}**";
        heart.Insert(5, line);
        return string.Join("\n", heart);
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        string date = start.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
        string time = hours.ToString("N2", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
        return $"{studentA} and {studentB} have been dating since {date} - that's {time} hours";
    }
}
