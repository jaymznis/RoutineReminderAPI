using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Models
{
    public class ShoppingItemCreate
    {
        [Required]
        public int ShoppingListId { get; set; }

        [Required]
        public string ShoppingItemName { get; set; }

        public string ShoppingItemDesc { get; set; }

        public string StoreLocation { get; set; }
    }
}
