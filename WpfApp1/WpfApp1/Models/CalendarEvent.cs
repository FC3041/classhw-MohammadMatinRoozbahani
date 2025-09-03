using System;

namespace PersonalCalendar.Models
{
    public class CalendarEvent
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public int DurationMinutes { get; set; }
        public DateTime EndTime => Date.Add(StartTime).AddMinutes(DurationMinutes);
        public string Color { get; set; } = "#E6E6FA";
    }
} 