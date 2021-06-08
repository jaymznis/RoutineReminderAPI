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
    public class RoutineItemController : ApiController
    {
        private RoutineItemService CreateRoutineItemService()
        {
            var noteService = new RoutineItemService();
            return noteService;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
           RoutineItemService routineItemService = CreateRoutineItemService();
            var routineItems = routineItemService.GetRoutineItems();
            return Ok(routineItems);
        }

        [HttpPost]
        public IHttpActionResult Post(RoutineItemCreate routineItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRoutineItemService();

            if (!service.CreateRoutineItem(routineItem))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetByID(int id)
        {
            RoutineItemService routineItemService = CreateRoutineItemService();
            var routineItem = routineItemService.GetRoutineItemById(id);
            return Ok(routineItem);
        }

        [HttpPut]
        public IHttpActionResult Put(RoutineItemEdit routineItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRoutineItemService();

            if (!service.UpdateRoutineItem(routineItem))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteByID(int id)
        {
            var service = CreateRoutineItemService();

            if (!service.DeleteRoutineItem(id))
                return InternalServerError();

            return Ok();
        }
    }
}
