using System.Text;

namespace CodeWars.Challenges;

public static class HumanReadableDurationFormat
{
    private const int MINUTE = 60;
    private const int HOUR = 60 * 60;
    private const int DAY = 60 * 60 * 24;
    private const int YEAR = 60 * 60 * 24 * 365;
    
    public static string FormatDuration(int seconds)
    {
        if (seconds == 0)
        {
            return "now";
        }

        int remainderInSeconds = 0;
        int minutes = 0;
        int hours = 0;
        int days = 0;
        int years = 0;

        while (seconds > 0)
        {
            switch (seconds)
            {
                case >= YEAR:
                    years++;
                    seconds -= YEAR;
                    break;
                case >= DAY:
                    days++;
                    seconds -= DAY;
                    break;
                case >= HOUR:
                    hours++;
                    seconds -= HOUR;
                    break;
                case >= MINUTE:
                    minutes++;
                    seconds -= MINUTE;
                    break;
                default:
                    remainderInSeconds = seconds;
                    seconds = 0;
                    break;
            }
        }
        
        var yearString = years > 1 ? "years" : "year";
        var dayString = days > 1 ? "days" : "day";
        var hourString = hours > 1 ? "hours" : "hour";
        var minutesString = minutes > 1 ? "minutes" : "minute";
        var secondsString = remainderInSeconds > 1 ? "seconds" : "second";

        var yString = $"{(years > 0 ? years + " " + yearString : string.Empty)}";
        var dString = $"{(days > 0 ? days + " " + dayString : string.Empty)}";
        var hString = $"{(hours > 0 ? hours + " " + hourString : string.Empty)}";
        var mString = $"{(minutes > 0 ? minutes + " " + minutesString : string.Empty)}";
        var sString = $"{(remainderInSeconds > 0 ? remainderInSeconds + " " + secondsString : string.Empty)}";

        List<string> arr = [yString, dString, hString, mString, sString];

        var resultString = string.Join(", ", arr.Where(x => x.Length > 0));

        if (resultString.Split(",").Length <= 1) return resultString;
        var splitArray = resultString.Split(",");

        var sb = new StringBuilder();

        for (var i = 0; i < splitArray.Length; i++)
        {
            if (i == splitArray.Length - 2)
            {
                sb.Append(splitArray[i].Trim() + " ");
            }
            else if (i != splitArray.Length - 1)
            {
                sb.Append(splitArray[i].Trim() + ", ");
            }
            else
            {
                sb.Append("and" + splitArray[i]);
            }
        }

        return sb.ToString();
    }
}