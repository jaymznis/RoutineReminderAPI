using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Data
{
    public class ShoppingList_ShoppingItem
    {
        [Key]
        public int ListItemJoinId { get; set; }

        public int ShoppingListId { get; set; }
        public virtual ShoppingList ShoppingList { get; set; }

        public int ShoppingItemId { get; set; }
        public virtual ShoppingItem ShoppingItem { get; set; }

        public string StoreLocation { get; set; }
    }
}
