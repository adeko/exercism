using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        if (string.IsNullOrWhiteSpace(identifier)) return identifier;
        
        StringBuilder sb = new StringBuilder();
        bool makeUppercase = false;

        foreach (char c in identifier)
        {
            if (c == ' ')
            {
                sb.Append('_');
            }
            else if (char.IsControl(c))
            {
                sb.Append("CTRL");
            }
            else if (c == '-')
            {
                makeUppercase = true;
                continue;
            }
            else if (c >= 'α' && c <= 'ω')
            {
                continue;
            }
            else if (!char.IsLetter(c))
            {
                continue;
            }
            else
            {
                sb.Append(makeUppercase ? char.ToUpper(c) : c);
                makeUppercase = false;
            }
        }
        
        return sb.ToString();
    }
}
