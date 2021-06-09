using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Data
{
     public class RoutineReminderJoin
    {
        [Key]
        public int RoutineReminderJoinId { get; set; }
        public int RoutineId { get; set; }
        public int ReminderId { get; set; }
    }
}
