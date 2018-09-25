using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace TodoListApp.Models
{
    class CalendarModel
    {
        public string Id { get; set; }
        // Must use System.Globalization with Calendar
        public Calendar Calendar { get; set;  }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Sync { get; set; }
    }
}
