using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Models
{
    public class ShoppingItemDetail
    {
        public int ShoppingItemId { get; set; }
        public int ShoppingListId { get; set; }
        public string ShoppingItemName { get; set; }
        public string ShoppingItemDesc { get; set; }
        public string StoreLocation { get; set; }
    }
}
