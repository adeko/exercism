static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        List<string> list = new();
        if (id is { } i) list.Add($"[{i}]");
        list.Add(name);
        list.Add(department?.ToUpper() ?? "OWNER");
        return string.Join(" - ", list);
    }
}
