public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        if (phoneNumber.Length != 12) throw new Exception("Invalid number");
        if (phoneNumber.Split("-").Length != 3) throw new Exception("Invalid number parts");
        string code = phoneNumber[..3];
        string prefix = phoneNumber[4..7];
        string last = phoneNumber[8..];
        bool codeIsNewYork = code == "212";
        bool prefixIsFake = prefix == "555";
        return (codeIsNewYork, prefixIsFake, last);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo) => phoneNumberInfo.IsFake;
}
