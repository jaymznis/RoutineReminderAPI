using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Data
{
    public class ShoppingList
    {
        [Key]
        public int ShoppingListId { get; set; }

        [Required]
        public string ShoppingListName { get; set; }

        public string ShoppingListDesc { get; set; }

        public List<string> ShoppingListItem { get; set; }
    }
}
