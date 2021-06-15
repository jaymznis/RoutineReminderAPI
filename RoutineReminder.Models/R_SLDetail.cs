using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Models
{
    public class R_SLDetail
    {
        public int R_SLId { get; set; }
        public int RoutineId { get; set; }
        public RoutineListItem Routine { get; set; }
        public int ShoppingListId { get; set; }
        public ShoppingListItem ShoppingList { get; set; }
    }
}
