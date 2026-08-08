public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum) => shirtNum switch
    {
        1 => "goalie",
        2 => "left back",
        3 or 4 => "center back",
        5 => "right back",
        6 or 7 or 8 => "midfielder",
        9 => "left wing",
        10 => "striker",
        11 => "right wing",
        _ => "UNKNOWN"
    };

    public static string AnalyzeOffField(object report)
    {
        switch (report)
        {
            case int i:
                return i == 1 ? $"There is {i} supporter at the match." : $"There are {i} supporters at the match.";
            case string s:
                return s;
            case Injury injury:
                return $"Oh no! {injury.GetDescription()} Medics are on the field.";
            case Foul foul:
                return foul.GetDescription();
            case Incident incident:
                return incident.GetDescription();
            case Manager { Club: null } manager:
                return manager.Name;
            case Manager manager:
                return $"{manager.Name} ({manager.Club})";
            default:
                return "";
        }
    }
}
