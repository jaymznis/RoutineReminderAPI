using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Models
{
    public class RoutineDetail
    {
        public int RoutineId { get; set; }
        public string RoutineName { get; set; }
        public string RoutineDesc { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Timeframe
        {
            get
            {
                TimeSpan timeframe = EndTime - StartTime;
                return timeframe;
            }
        }
        public virtual List<RoutineItemListItem> RoutineItems { get; set; }
        public virtual List<ReminderListItem> Reminders { get; set; }
        public virtual List<ShoppingListItem> ShoppingLists { get; set; }

    }
}
