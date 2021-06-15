using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public virtual List<ShoppingItem> ShoppingItems { get; set; }

        public virtual List<Routine_ShoppingList> Routines { get; set; }

    }
}
