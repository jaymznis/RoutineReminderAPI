using Microsoft.AspNet.Identity;
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
    public class RoutineController : ApiController
    {

        private RoutineService CreateRoutineService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var routineService = new RoutineService(userId);
            return routineService;
        }
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            RoutineService routineService = CreateRoutineService();
            var routines = routineService.GetRoutines();
            return Ok(routines);
        }
        [HttpPost]
        public IHttpActionResult Post(RoutineCreate routine)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); var service = CreateRoutineService(); if (!service.CreateRoutine(routine))
                return InternalServerError(); return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetByID(int id)
        {
            RoutineService routineService = CreateRoutineService();
            var routine = routineService.GetRoutineById(id);
            return Ok(routine);
        }
        [HttpPut]
        public IHttpActionResult Put(RoutineEdit routine)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); var service = CreateRoutineService(); if (!service.UpdateRoutine(routine))
                return InternalServerError(); return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteByID(int id)
        {
            var service = CreateRoutineService(); if (!service.DeleteRoutine(id))
                return InternalServerError(); return Ok();
        }
    }
}