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

        [Required]
        public string ReminderName { get; set; }

        public string ReminderDesc { get; set; }

        public DateTime ReminderTime { get; set; }

        public virtual List<RoutineReminderJoin> Routines { get; set; } = new List<RoutineReminderJoin>();

    }
}