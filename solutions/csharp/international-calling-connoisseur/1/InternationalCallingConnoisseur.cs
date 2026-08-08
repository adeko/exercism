public static class DialingCodes
{
    static Dictionary<int, string> _dictionary { get; } = new() { 
        {1, "United States of America"}, 
        {55, "Brazil"}, 
        {91, "India"}, 
    };
    
    public static Dictionary<int, string> GetEmptyDictionary() => new();

    public static Dictionary<int, string> GetExistingDictionary() => new(_dictionary);

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName) {
        var dict = GetEmptyDictionary();
        dict.Add(countryCode, countryName);
        return dict;
    }

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        existingDictionary.Add(countryCode, countryName);
        return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        if (existingDictionary.ContainsKey(countryCode)) return existingDictionary[countryCode];
        return string.Empty;
    }

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode) => existingDictionary.ContainsKey(countryCode);

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if (existingDictionary.ContainsKey(countryCode)) existingDictionary[countryCode] = countryName;
        return existingDictionary;
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        if (existingDictionary.ContainsKey(countryCode)) existingDictionary.Remove(countryCode);
        return existingDictionary;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        int key = -1;
        int len = -1;
        foreach(var country in existingDictionary)
        {
            if ((country.Value.Length) > len)
            {
                len = country.Value.Length;
                key = country.Key;
            }            
        }
        if (key > -1) return existingDictionary[key];
        return string.Empty;
    }
}