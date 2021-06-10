using RoutineReminder.Data;
using RoutineReminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Service
{
    public class R_RIService
    {
        public bool CreateR_RI(R_RICreate model)
        {
            var entity =
                new Routine_RoutineItem()
                {
                    RoutineId = model.RoutineId,
                    RoutineItemId = model.RoutineItemId

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.R_RIJoin.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<R_RIListItem> GetAllR_RI()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .R_RIJoin
                        .Select(
                        e =>
                            new R_RIListItem
                            {
                               R_RI_Id= e.R_RI_Id,
                                RoutineId = e.RoutineId,
                               RoutineItemId = e.RoutineItemId,
                            });
                return query.ToArray();
            }
        }
        public R_RIDetail GetR_RIById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .R_RIJoin
                    .Single(e => e.R_RI_Id == id);
                return
                    new R_RIDetail
                    {
                        R_RI_Id = entity.R_RI_Id,
                        RoutineId = entity.RoutineId,
                        Routine = new RoutineListItem
                        {
                            RoutineId = entity.RoutineId,
                            RoutineName = entity.Routine.RoutineName
                        },
                        RoutineItemId = entity.RoutineItemId,
                        RotuineItem = new RoutineItemListItem
                        {
                            RoutineItemId = entity.RoutineItemId,
                            RoutineItemName = entity.RoutineItem.RoutineItemName,
                            RoutineItemTimeframe = entity.RoutineItem.RoutineItemTimeframe
                        }
                    };
            }
        }
        public bool UpdateR_RI(R_RIDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .R_RIJoin
                    .Single(e => e.R_RI_Id == model.R_RI_Id);

                entity.RoutineId = model.RoutineId;
                entity.RoutineItemId = model.RoutineItemId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRoutineReminderJoin(int rriId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .R_RIJoin
                    .Single(e => e.R_RI_Id == rriId);
                ctx.R_RIJoin.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
