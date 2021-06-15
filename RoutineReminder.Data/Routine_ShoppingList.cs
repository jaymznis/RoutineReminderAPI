using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Data
{
   public class Routine_ShoppingList
    {
        [Key]
        public int R_SLId { get; set; }

        public int RoutineId { get; set; }

        public virtual Routine Routine { get; set; }

        public int ShoppingListId { get; set; }

        public virtual ShoppingList ShoppingList { get; set; }

    }
}
