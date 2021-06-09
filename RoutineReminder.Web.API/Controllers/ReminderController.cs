using RoutineReminder.Models;
using RoutineReminder.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RoutineReminder.Web.API.Controllers
{
    [Authorize]
    public class ReminderController : ApiController
    {
        private ReminderService CreateReminderService()
        {
            var remindService = new ReminderService();
            return remindService;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ReminderService reminderService = CreateReminderService();
            var reminders = reminderService.GetAllReminders();
            return Ok(reminders);
        }

        [HttpPost]
        public IHttpActionResult Post(ReminderCreate reminder)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReminderService();

            if (!service.CreateReminder(reminder))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetByID(int id)
        {
            ReminderService reminderService = CreateReminderService();
            var reminder = reminderService.GetReminderById(id);
            return Ok(reminder);
        }

        [HttpPut]
        public IHttpActionResult Put(ReminderEdit reminder)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReminderService();

            if (!service.UpdateReminder(reminder))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteById(int id)
        {
            var service = CreateReminderService();

            if (!service.DeleteReminder(id))
                return InternalServerError();

            return Ok();
        }
    }
}
