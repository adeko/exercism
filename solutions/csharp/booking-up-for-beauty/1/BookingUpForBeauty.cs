static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        if (DateTime.TryParse(appointmentDateDescription, out DateTime dt)) return dt;
        throw new FormatException($"'{appointmentDateDescription}' is not a valid date format.");
    }

    public static bool HasPassed(DateTime appointmentDate) => appointmentDate < DateTime.Now;

    public static bool IsAfternoonAppointment(DateTime appointmentDate) => appointmentDate.TimeOfDay >= TimeSpan.FromHours(12) && appointmentDate.TimeOfDay < TimeSpan.FromHours(18);

    public static string Description(DateTime appointmentDate) => string.Format("You have an appointment on {0}.", appointmentDate.ToString("G"));

    public static DateTime AnniversaryDate()
    {
        var dtAnniversaryDate = new DateTime(2019, 9, 15, 0, 0, 0);
        var dtNext = dtAnniversaryDate.AddYears(DateTime.Today.Year - dtAnniversaryDate.Year);        
        if (dtNext < DateTime.Today) dtNext = dtNext.AddYears(1);
        return dtNext;
    }
}
