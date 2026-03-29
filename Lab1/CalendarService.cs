using System;

namespace Lab_1
{
    public class CalendarService
    {
        private static CalendarService _instance;
        public static CalendarService Instance => _instance ??= new CalendarService();

        public DateTime CurrentTime { get; private set; }

        private CalendarService()
        {
            CurrentTime = DateTime.Now;
        }

        public void AdvanceTime(TimeSpan span)
        {
            CurrentTime = CurrentTime.Add(span);
        }
    }
}