using RoutineReminder.Data;
using RoutineReminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Service
{
    public class RoutineService
    {
        private readonly Guid _userId;
        public RoutineService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRoutine(RoutineCreate model)
        {
            var entity =
                new Routine()
                {
                    OwnerId = _userId,
                    RoutineName = model.RoutineName,
                    RoutineDesc = model.RoutineDesc,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Routines.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RoutineListItem> GetRoutines()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Routines
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new RoutineListItem
                        {
                            RoutineId = e.RoutineId,
                            RoutineName = e.RoutineName,
                        }
                        );
                return query.ToArray();
            }
        }
        public RoutineDetail GetRoutineById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Routines
                    .Single(e => e.RoutineId == id && e.OwnerId == _userId);
                return
                    new RoutineDetail
                    {
                        RoutineId = entity.RoutineId,
                        RoutineName = entity.RoutineName,
                        RoutineDesc = entity.RoutineDesc,
                        StartTime = entity.StartTime,
                        EndTime = entity.EndTime,
                        RoutineItems = entity.RoutineItems
                        .Select(x => new RoutineItemListItem()
                        {
                            RoutineItemId = x.RoutineItem.RoutineItemId,
                            RoutineItemName = x.RoutineItem.RoutineItemName,
                            RoutineItemTimeframe = x.RoutineItem.RoutineItemTimeframe
                        }
                        ).ToList(),
                        Reminders = entity.Reminders
                        .Select(y => new ReminderListItem()
                        {
                            ReminderId = y.Reminder.ReminderId,
                            ReminderName = y.Reminder.ReminderName
                        }
                        ).ToList(),
                        ShoppingLists = entity.ShoppingLists
                      .Select(z => new ShoppingListItem()
                      {
                          ShoppingListId = z.ShoppingList.ShoppingListId,
                          ShoppingListName = z.ShoppingList.ShoppingListName
                      }
                          ).ToList()

                    };
            }
        }


        public bool UpdateRoutine(RoutineEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Routines
                    .Single(e => e.RoutineId == model.RoutineId && e.OwnerId == _userId);

                entity.RoutineName = model.RoutineName;
                entity.RoutineDesc = model.RoutineDesc;
                entity.StartTime = model.StartTime;
                entity.EndTime = model.EndTime;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRoutine(int routineId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Routines
                    .Single(e => e.RoutineId == routineId && e.OwnerId == _userId);

                ctx.Routines.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
