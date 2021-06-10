using RoutineReminder.Data;
using RoutineReminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Service
{
   public class RoutineReminderJoinService
    {
        public bool CreateRRJoin(RoutineReminderJoinCreate model)
        {
            var entity =
                new RoutineReminderJoin()
                {
                    RoutineId = model.RoutineId,
                    ReminderId = model.ReminderId

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.RRJoin.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RoutineReminderJoinListItem> GetAllRRJoin()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .RRJoin
                        .Select(
                        e =>
                            new RoutineReminderJoinListItem
                            {
                                RoutineReminderJoinId = e.RoutineReminderJoinId,
                                RoutineId = e.RoutineId,
                                Routine = new RoutineListItem
                                {
                                    RoutineId = e.RoutineId,
                                    RoutineName = e.Routine.RoutineName
                                },
                                ReminderId = e.ReminderId,
                                Reminder = new ReminderListItem
                                {
                                    ReminderId = e.ReminderId,
                                    ReminderName = e.Reminder.ReminderName
                                }

                            });
                return query.ToArray();
            }
        }
        public RoutineReminderJoinDetail GetRRJoinById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .RRJoin
                    .Single(e => e.RoutineReminderJoinId == id);
                return
                    new RoutineReminderJoinDetail
                    {
                        RoutineReminderJoinId = entity.RoutineReminderJoinId,
                        RoutineId = entity.RoutineId,
                        Routine = new RoutineListItem
                        {
                            RoutineId = entity.RoutineId,
                            RoutineName = entity.Routine.RoutineName
                        },
                        ReminderId = entity.ReminderId,
                        Reminder = new ReminderListItem
                        {
                            ReminderId = entity.ReminderId,
                            ReminderName = entity.Reminder.ReminderName
                        }
                    };
            }
        }
        public bool UpdateRoutineReminderJoin(RoutineReminderJoinDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .RRJoin
                    .Single(e => e.RoutineReminderJoinId== model.RoutineReminderJoinId);

                entity.RoutineId= model.RoutineId;
                entity.ReminderId = model.ReminderId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRoutineReminderJoin(int rrjId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RRJoin
                    .Single(e => e.RoutineReminderJoinId == rrjId);
                ctx.RRJoin.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
