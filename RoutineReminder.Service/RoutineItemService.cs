using RoutineReminder.Data;
using RoutineReminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Service
{
    public class RoutineItemService
    {
        public bool CreateRoutineItem(RoutineItemCreate model)
        {
            var entity =
                new RoutineItem()
                {
                    RoutineItemName = model.RoutineItemName,
                    RoutineItemDescription = model.RoutineItemDescription,
                    RoutineItemTimeframe = model.RoutineItemTimeframe
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.RoutineItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RoutineItemListItem> GetRoutineItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .RoutineItems
                    .Select(
                        e =>
                        new RoutineItemListItem
                        {
                            RoutineItemId = e.RoutineItemId,
                            RoutineItemName = e.RoutineItemName,
                            RoutineItemTimeframe = e.RoutineItemTimeframe,
                           
                        }
                        );
                return query.ToArray();
            }
        }

        public RoutineItemDetail GetRoutineItemById(int id) 
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RoutineItems
                    .Single(e => e.RoutineItemId == id);
                return
                    new RoutineItemDetail
                    {
                        RoutineItemId = entity.RoutineItemId,
                        RoutineItemName = entity.RoutineItemName,
                        RoutineItemDescription = entity.RoutineItemDescription,
                        RoutineItemTimeframe = entity.RoutineItemTimeframe,
                        Routines = entity.Routines
                        .Select(x => new RoutineListItem()
                        {
                            RoutineId = x.RoutineId,
                            RoutineName = x.Routine.RoutineName
                        }
                        ).ToList()
                    };
            }
        }

        public bool UpdateRoutineItem(RoutineItemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RoutineItems
                    .Single(e => e.RoutineItemId == model.RoutineItemId);

                entity.RoutineItemName = model.RoutineItemName;
                entity.RoutineItemDescription = model.RoutineItemDescription;
                entity.RoutineItemTimeframe = model.RoutineItemTimeframe;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRoutineItem(int routineItemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                   ctx
                   .RoutineItems
                   .Single(e => e.RoutineItemId == routineItemId);

                ctx.RoutineItems.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
