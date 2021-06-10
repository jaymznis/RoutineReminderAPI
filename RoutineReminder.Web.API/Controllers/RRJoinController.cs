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
    public class RRJoinController : ApiController
    {
        private RoutineReminderJoinService CreateRRJoinService()
        { 
            var rrjService = new RoutineReminderJoinService();
            return rrjService;
        }
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            RoutineReminderJoinService rrjService = CreateRRJoinService();
            var rrj = rrjService.GetAllRRJoin();
            return Ok(rrj);
        }
        [HttpPost]
        public IHttpActionResult Post(RoutineReminderJoinCreate rrj)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); var service = CreateRRJoinService(); if (!service.CreateRRJoin(rrj))
                return InternalServerError(); return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            RoutineReminderJoinService rrjService = CreateRRJoinService();
            var rrj = rrjService.GetRRJoinById(id);
            return Ok(rrj);
        }
    
        [HttpDelete]
        public IHttpActionResult DeleteByID(int id)
        {
            var service = CreateRRJoinService(); if (!service.DeleteRoutineReminderJoin(id))
                return InternalServerError(); return Ok();
        }
    }
}
