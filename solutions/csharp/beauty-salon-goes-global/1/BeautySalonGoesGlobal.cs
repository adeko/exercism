using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    private static readonly Dictionary<Location, string> WindowsZones = new()
    {
        [Location.NewYork] = "Eastern Standard Time",
        [Location.London] = "GMT Standard Time",
        [Location.Paris] = "W. Europe Standard Time"
    };
    
    private static readonly Dictionary<Location, string> IanaZones = new()
    {
        [Location.NewYork] = "America/New_York",
        [Location.London] = "Europe/London",
        [Location.Paris] = "Europe/Paris"
    };

    private static readonly Dictionary<Location, string> Cultures = new()
    {
        [Location.NewYork] = "en-US",
        [Location.London] = "en-GB",
        [Location.Paris] = "fr-FR"
    };

    private static TimeZoneInfo GetZoneInfo(Location location)
    {
        var zoneId = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) 
            ? WindowsZones[location] 
            : IanaZones[location];
        return TimeZoneInfo.FindSystemTimeZoneById(zoneId);
    }

    private static CultureInfo GetCultureInfo(Location location)
    {
        return new CultureInfo(Cultures[location]);
    }
    
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return TimeZoneInfo.ConvertTimeFromUtc(dtUtc, TimeZoneInfo.Local);
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        TimeZoneInfo destinationZone = GetZoneInfo(location);
        DateTime appointmentDate = DateTime.Parse(appointmentDateDescription);
        return TimeZoneInfo.ConvertTime(appointmentDate, destinationZone, TimeZoneInfo.Local);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        TimeSpan duration = alertLevel switch {
            AlertLevel.Early => new TimeSpan(24, 0, 0),
            AlertLevel.Standard => new TimeSpan(1, 45, 0),
            AlertLevel.Late => new TimeSpan(0, 30, 0),
        };
        return appointment - duration;
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        TimeZoneInfo zoneInfo = GetZoneInfo(location);
        DateTime originalUtc = TimeZoneInfo.ConvertTimeToUtc(dt, zoneInfo);
        DateTime earlyUtc = originalUtc.AddDays(-7);
        DateTime earlyDt = TimeZoneInfo.ConvertTimeFromUtc(earlyUtc, zoneInfo);
        return zoneInfo.IsDaylightSavingTime(dt) != zoneInfo.IsDaylightSavingTime(earlyDt);
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        CultureInfo cultureInfo = GetCultureInfo(location);
        if (!DateTime.TryParse(dtStr, cultureInfo, DateTimeStyles.None, out DateTime parsedDateTime)) 
        {
            return new DateTime(1, 1, 1, 0, 0, 0);
        }
        return parsedDateTime; 
    }
}
