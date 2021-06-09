using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Data
{
    public class Reminder
    {
        [Key]
        public int ReminderId { get; set; }

        [ForeignKey(nameof(Routine))]
        public int? RoutineId { get; set; }
        public virtual Routine Routine { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string ReminderName { get; set; }

        public string ReminderDesc { get; set; }

        public DateTime ReminderTime { get; set; }

        public virtual List<Reminder> Reminders { get; set; }

    }
}