using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Data
{
    internal class Event
    {
        public int EventId { get; private set; }
        public string Name { get; private set; }
        public int HallId { get; private set; }
        public string StartTime { get; private set; }
        public string EndTime { get; private set; }

        public Event(int eventId, string name, int hallId, string startTime, string endTime)
        {
            EventId = eventId;
            Name = name;
            HallId = hallId;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
