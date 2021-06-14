using RoutineReminder.Data;
using RoutineReminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Service
{
    public class ShoppingListService
    {
        private readonly Guid _userId;
        public ShoppingListService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateShoppingList(ShoppingListCreate model)
        {
            var entity = new ShoppingList()
            {
                ShoppingListName = model.ShoppingListName,
                ShoppingListDesc = model.ShoppingListDesc
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ShoppingLists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ShoppingListItem> GetShoppingLists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .ShoppingLists
                    .Select
                    (
                        e => new ShoppingListItem
                        {
                            ShoppingListId = e.ShoppingListId,
                            ShoppingListName = e.ShoppingListName
                        }
                    );
                return query.ToArray();
            }
        }


    }
}
