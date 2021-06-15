using RoutineReminder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Models
{
    public class ShoppingListDetail
    {
        public int ShoppingListId { get; set; }
        public string ShoppingListName { get; set; }
        public string ShoppingListDesc { get; set; }
        public virtual List<ShoppingItemListItem> ShoppingItems { get; set; }
    }
}
