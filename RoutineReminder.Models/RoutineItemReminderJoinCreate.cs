using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Models
{
    public class RoutineItemReminderJoinCreate
    {
        [Required]
        public int RoutineItemId { get; set; }
        [Required]
        public int ReminderId { get; set; }

    }
}
