using RoutineReminder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Models
{
    public class ReminderDetail
    {
        public int ReminderId { get; set; }
        public string ReminderName { get; set; }
        public string ReminderDesc { get; set; }
        public DateTime ReminderTime { get; set; }
        public virtual List<RoutineListItem> Routines { get; set; }
    }
}
