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

        public ShoppingListDetail GetShoppingListById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .ShoppingLists
                    .Single(e => e.ShoppingListId == id);
                return
                    new ShoppingListDetail
                    {
                        ShoppingListId = entity.ShoppingListId,
                        ShoppingListName = entity.ShoppingListName,
                        ShoppingListDesc = entity.ShoppingListDesc,
                        ShoppingItems = entity.ShoppingItems
                        .Select(x => new ShoppingItemListItem()
                        {
                            ShoppingItemId = x.ShoppingItemId,
                            ShoppingItemName = x.ShoppingItemName,
                            ShoppingItemDesc = x.ShoppingItemDesc,
                            StoreLocation = x.StoreLocation
                        }
                        ).ToList(),
                        Routines = entity.Routines
                        .Select(y => new RoutineListItem()
                        {
                            RoutineId = y.Routine.RoutineId,
                            RoutineName = y.Routine.RoutineName
                        }
                        ).ToList()
                    };
            }
        }

        public bool UpdateShoppingList(ShoppingListEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .ShoppingLists
                    .Single(e => e.ShoppingListId == model.ShoppingListId);

                entity.ShoppingListId = model.ShoppingListId;
                entity.ShoppingListName = model.ShoppingListName;
                entity.ShoppingListDesc = model.ShoppingListDesc;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteShoppingList(int shoppingListId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .ShoppingLists
                    .Single(e => e.ShoppingListId == shoppingListId);

                ctx.ShoppingLists.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
