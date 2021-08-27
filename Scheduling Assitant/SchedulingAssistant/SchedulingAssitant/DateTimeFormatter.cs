using System;
using System.Globalization;

namespace SchedulingAssistant
{
    public class DateTimeFormatter
    {
        public string DateTimeFormat(string date, string time)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string dateTime = ($"{date} {time}");
            string format = "dd/MM/yyyy HH:mm";
            DateTime formattedDateTime = DateTime.ParseExact(dateTime, format, provider);
            return $"{formattedDateTime.ToString("yyyy-MM-ddTHH:mm")}";
        }
    }
}
