using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Data
{
     public class RoutineReminderJoin
    {
        [Key]
        public int RoutineReminderJoinId { get; set; }


        [ForeignKey(nameof(Routine))]
        public int RoutineId { get; set; }
        public virtual Routine Routine { get; set; }


        [ForeignKey(nameof(Reminder))]
        public int ReminderId { get; set; }
        public virtual Reminder Reminder { get; set; }
    }
}
