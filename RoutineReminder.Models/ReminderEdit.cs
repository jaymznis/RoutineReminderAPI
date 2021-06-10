using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Models
{
    public class ReminderEdit
    {
        public int ReminderId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string ReminderName { get; set; }
        [Required]
        [MaxLength(2000)]
        public string ReminderDesc { get; set; }
        [Required]
        public DateTime ReminderTime { get; set; }
        
    }
}
