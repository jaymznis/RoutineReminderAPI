using RoutineReminder.Data;
using RoutineReminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Service
{
    public class ShoppingItemService
    {
        private readonly Guid _userId;
        public ShoppingItemService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateShoppingItem(ShoppingItemCreate model)
        {
            var entity = new ShoppingItem()
            {
                ShoppingListId = model.ShoppingListId,
                ShoppingItemName = model.ShoppingItemName,
                ShoppingItemDesc = model.ShoppingItemDesc,
                StoreLocation = model.StoreLocation
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ShoppingItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<ShoppingItemDetail> GetShoppingItemsByShoppingListId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .ShoppingItems
                    .Where(e => e.ShoppingListId == id)
                    .Select
                    (
                            e => new ShoppingItemDetail
                            {
                                ShoppingItemId = e.ShoppingItemId,
                                ShoppingListId = e.ShoppingListId,
                                ShoppingItemName = e.ShoppingItemName,
                                ShoppingItemDesc = e.ShoppingItemDesc,
                                StoreLocation = e.StoreLocation
                            }
                    );

                return query.ToArray();
            }
        }

        public ShoppingItemDetail GetShoppingItemsByShoppingListI(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .ShoppingItems
                    .Single(e => e.ShoppingItemId == id); //NEED SHOPPING LIST ID, NOT ITEM ID
                return
                    new ShoppingItemDetail
                    {
                        ShoppingItemId = entity.ShoppingItemId,
                        ShoppingItemName = entity.ShoppingItemName,
                        ShoppingItemDesc = entity.ShoppingItemDesc,
                        StoreLocation = entity.StoreLocation
                    };
            }
        }

        public bool UpdateShoppingItem(ShoppingItemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .ShoppingItems
                    .Single(e => e.ShoppingItemId == model.ShoppingItemId);

                entity.ShoppingItemId = model.ShoppingItemId;
                entity.ShoppingItemName = model.ShoppingItemName;
                entity.ShoppingItemDesc = model.ShoppingItemDesc;
                entity.StoreLocation = model.StoreLocation;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteShoppingItem(int shoppingItemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .ShoppingItems
                    .Single(e => e.ShoppingItemId == shoppingItemId);

                ctx.ShoppingItems.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
