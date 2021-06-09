using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Data
{
    public class RoutineItemReminderJoin
    {
        [Key]
        public int RoutineItemReminderJoinId { get; set; }
        public int RoutineItemId { get; set; }
        public int ReminderId { get; set; }
    }
}
