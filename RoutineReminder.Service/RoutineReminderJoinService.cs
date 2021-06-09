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
                                Reminder = new Models.Cohort.CohortListItem
                                {
                                    Name = e.Cohort.Name,
                                    Id = e.Cohort.Id
                                }

                            });
                return query.ToArray();
            }
        }
        public EnrollmentDetail GetEnrollmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Enrollments
                    .Single(e => e.Id == id);
                return
                    new EnrollmentDetail
                    {
                        Id = entity.Id,
                        StudentId = entity.StudentId,
                        Student = new StudentListItem
                        {
                            Name = entity.Student.FullName(),
                            Id = entity.Student.Id
                        },
                        CohortId = entity.CohortId,
                        Cohort = new Models.Cohort.CohortListItem
                        {
                            Name = entity.Cohort.Name,
                            Id = entity.Cohort.Id
                        }
                    };
            }
        }
        public bool UpdateEnrollment(EnrollmentDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Enrollments
                    .Single(e => e.Id == model.Id);

                entity.CohortId = model.CohortId;
                entity.StudentId = model.StudentId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEnrollment(int enrollmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Enrollments
                    .Single(e => e.Id == enrollmentId);
                ctx.Enrollments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
