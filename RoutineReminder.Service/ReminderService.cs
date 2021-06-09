using RoutineReminder.Data;
using RoutineReminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineReminder.Service
{
    public class ReminderService
    {


        public bool CreateReminder(ReminderCreate model)
        {
            var entity =
                new Reminder()
                {
                    
                    ReminderName = model.ReminderName,
                    ReminderDesc = model.ReminderDesc,
                    ReminderTime = model.ReminderTime,
                   
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reminders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReminderListItem> GetAllReminders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Reminders
                    .Select(
                        e =>
                        new ReminderListItem
                        {
                            ReminderId = e.ReminderId,
                            ReminderName = e.ReminderName,
                        }
                        );
                return query.ToArray();
            }
        }
        public ReminderDetail GetReminderById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reminders
                    .Single(e => e.ReminderId == id );
                return
                    new ReminderDetail
                    {
                        ReminderId = entity.ReminderId,
                        ReminderName = entity.ReminderName,
                        ReminderDesc = entity.ReminderDesc,
                        ReminderTime = entity.ReminderTime,
                        Routines = entity.RoutineItemReminderJoin
                        .Select(x => new RoutineListItem()
                        {
                            RoutineId = x.RoutineId,
                            RoutineName = x.RoutineName
                        }
                        ).ToList()
                        
                    };
            }
        }


        public bool UpdateReminder(ReminderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reminders
                    .Single(e => e.ReminderId == model.ReminderId );

                entity.ReminderName = model.ReminderName;
                entity.ReminderDesc = model.ReminderDesc;
                entity.ReminderTime = model.ReminderTime;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReminder(int reminderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reminders
                    .Single(e => e.ReminderId == reminderId);

                ctx.Reminders.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}