using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Models
{
   public class R_SLCreate
    {
        [Required]
        public int RoutineId { get; set; }
        [Required]
        public int ShoppingListId { get; set; }
    }
}
