﻿using RoutineReminder.Data;
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
                        .select(e => new RoutineItemListItem()
                        {RoutineItemId = e.RoutineItemId,
                        RoutineId = e.RoutineId,
                        RoutineItemName = e.RoutineItemName,
                        RoutineItemTimeFrame = e.RoutineItemTimeFrame
                        }
                        ).ToList(),
                        RoutineReminders = entity.RoutineReminders
                        .select(e => new RoutineReminderListItem()
                        {
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