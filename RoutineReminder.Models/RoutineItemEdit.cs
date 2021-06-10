using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Models
{
    public class RoutineItemEdit
    {
        public int RoutineItemId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string RoutineItemName { get; set; }

        [MaxLength(1200)]
        public string RoutineItemDescription { get; set; }

        public TimeSpan RoutineItemTimeframe { get; set; }

    }
}
