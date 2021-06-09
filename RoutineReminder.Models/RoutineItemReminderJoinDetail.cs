using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Models
{
    public class RoutineItemReminderJoinDetail
    {
        public int RoutineItemReminderJoinId { get; set; }
        public int RoutineItemId { get; set; }
        public RoutineItemListItem RoutineItems { get; set; }
        public int ReminderId { get; set; }
        public ReminderListItem Reminders { get; set; }
    }
}
