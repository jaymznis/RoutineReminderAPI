using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Data
{
    public class ShoppingItem
    {
        [Key]
        public int ShoppingItemId { get; set; }

        [ForeignKey(nameof(ShoppingListId))]
        public virtual ShoppingList ShoppingList { get; set; }
        public int ShoppingListId { get; set; }

        [Required]
        public string ShoppingItemName { get; set; }

        public string ShoppingItemDesc { get; set; }

        public string StoreLocation { get; set; }

    }
}
