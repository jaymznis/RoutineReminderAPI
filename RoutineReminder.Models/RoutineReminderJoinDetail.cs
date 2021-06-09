using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Models
{
    public class RoutineReminderJoinDetail
    {
        public int RoutineReminderJoinId { get; set; }
        public int RoutineId { get; set; }
        public string RoutineName { get; set; }
        public int ReminderId { get; set; }
        public string ReminderName { get; set; }
    }
}
