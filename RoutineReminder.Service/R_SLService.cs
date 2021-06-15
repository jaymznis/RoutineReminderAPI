using RoutineReminder.Data;
using RoutineReminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Service
{
    public class R_SLService
    {
        public bool CreateR_SL(R_SLCreate model)
        {
            var entity =
                new Routine_ShoppingList()
                {
                    RoutineId = model.RoutineId,
                    ShoppingListId = model.ShoppingListId

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.R_SLJoin.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<R_SLListItem> GetAllR_SL()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .R_SLJoin
                        .Select(
                        e =>
                            new R_SLListItem
                            {
                                R_SLId = e.R_SLId,
                                RoutineId = e.RoutineId,
                                ShoppingListId = e.ShoppingListId,
                            });
                return query.ToArray();
            }
        }
        public R_SLDetail GetR_SLById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .R_SLJoin
                    .Single(e => e.R_SLId == id);
                return
                    new R_SLDetail
                    {
                        R_SLId = entity.R_SLId,
                        RoutineId = entity.RoutineId,
                        Routine = new RoutineListItem
                        {
                            RoutineId = entity.RoutineId,
                            RoutineName = entity.Routine.RoutineName
                        },
                        ShoppingListId = entity.ShoppingListId,
                        ShoppingList = new ShoppingListItem
                        {
                            ShoppingListId = entity.ShoppingListId,
                            ShoppingListName = entity.ShoppingList.ShoppingListName
                        }
                    };
            }
        }
        public bool UpdateR_SL(R_SLDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .R_SLJoin
                    .Single(e => e.R_SLId == model.R_SLId);

                entity.RoutineId = model.RoutineId;
                entity.ShoppingListId = model.ShoppingListId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteR_SL(int rslId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .R_SLJoin
                    .Single(e => e.R_SLId == rslId);
                ctx.R_SLJoin.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
