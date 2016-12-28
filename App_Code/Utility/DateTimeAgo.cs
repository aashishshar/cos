using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

/// <summary>
/// Summary description for DateTimeAgo
/// </summary>
public class DateTimeAgo
{
    static DateTimeAgo()
    {
    }

    public static string GetFormatDate(string date)
    {
        if (string.IsNullOrEmpty(date))
            return "IN RUNNING RIGHT NOW.";
        DateTime dt = Convert.ToDateTime(date);
        return string.Format(dt.ToString("MMM dd, yyyy", CultureInfo.CreateSpecificCulture("en-US")) + ".");
    }

    public static string TimeAgo(string date)
    {
        try
        {
            DateTime dt = Convert.ToDateTime(date);

            if (dt > DateTime.Now)
            {
                return "sometime from now";
            }
             
            TimeSpan span = DateTime.Now - dt;

            if (span.Days > 1)
            {
                return string.Format(dt.ToString("MMM dd, yyyy",CultureInfo.CreateSpecificCulture("en-US")) + ".");//,CultureInfo.CreateSpecificCulture("en-US")));//"{0:MM/dd/yyyy}", dt);
                //return string.Format(dt.ToString("ddd d MMM",CultureInfo.CreateSpecificCulture("en-US")));//"{0:MM/dd/yyyy}", dt);
            }

            if (span.Days > 365)
            {
                int years = (span.Days / 365);
                if (span.Days % 365 != 0)
                    years += 1;
                return String.Format("{0} {1} ago", years, years == 1 ? "year" : "years");
            }

            if (span.Days > 30)
            {
                int months = (span.Days / 30);
                if (span.Days % 31 != 0)
                    months += 1;
                return String.Format("{0} {1} ago", months, months == 1 ? "month" : "months");
            }

            if (span.Days > 0)
                return String.Format("{0} {1} ago", span.Days, span.Days == 1 ? "day" : "days");

            if (span.Hours > 0)
                return String.Format("{0} {1} ago", span.Hours, span.Hours == 1 ? "hour" : "hours");

            if (span.Minutes > 0)
                return String.Format("{0} {1} ago", span.Minutes, span.Minutes == 1 ? "minute" : "minutes");

            if (span.Seconds > 5)
                return String.Format("{0} seconds ago", span.Seconds);

            if (span.Seconds <= 5)
                return "just now";

            return string.Empty;
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }

    public static List<string> GetTimeIntervals()
    {
        List<string> timeIntervals = new List<string>();
        TimeSpan startTime = new TimeSpan(0, 0, 0);
        DateTime startDate = new DateTime(DateTime.MinValue.Ticks); // Date to be used to get shortTime format.
        for (int i = 0; i < 48; i++)
        {
            int minutesToBeAdded = 60 * i;      // Increasing minutes by 30 minutes interval
            TimeSpan timeToBeAdded = new TimeSpan(0, minutesToBeAdded, 0);
            TimeSpan t = startTime.Add(timeToBeAdded);
            DateTime result = startDate + t;
            timeIntervals.Add(result.ToShortTimeString());      // Use Date.ToShortTimeString() method to get the desired format                
        }
        return timeIntervals;
    }
}