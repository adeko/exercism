public static class ResistorColor
{
    static Dictionary<string, int> colors = new()
    {
        ["black"] = 0,
        ["brown"] = 1,
        ["red"] = 2,
        ["orange"] = 3,
        ["yellow"] = 4,
        ["green"] = 5,
        ["blue"] = 6,
        ["violet"] = 7,
        ["grey"] = 8,
        ["white"] = 9
    };
    
    public static int ColorCode(string color) => colors.TryGetValue(color, out int v) ? v : -1;

    public static string[] Colors() => colors.Keys.ToArray();
}