using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Models
{
    public class ShoppingListCreate
    {
        [Required]
        public string ShoppingListName { get; set; }

        public string ShoppingListDesc { get; set; }
    }
}
