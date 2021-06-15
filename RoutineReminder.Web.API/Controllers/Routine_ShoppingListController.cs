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
    public class Routine_ShoppingListController : ApiController
    {
        private R_SLService CreateR_SLService()
        {
            var rslService = new R_SLService();
            return rslService;
        }
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            R_SLService rslService = CreateR_SLService();
            var rsl = rslService.GetAllR_SL();
            return Ok(rsl);
        }
        [HttpPost]
        public IHttpActionResult Post(R_SLCreate rsl)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); var service = CreateR_SLService(); if (!service.CreateR_SL(rsl))
                return InternalServerError(); return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            R_SLService rslService = CreateR_SLService();
            var rsl = rslService.GetR_SLById(id);
            return Ok(rsl);
        }

        [HttpDelete]
        public IHttpActionResult DeleteByID(int id)
        {
            var service = CreateR_SLService(); if (!service.DeleteR_SL(id))
                return InternalServerError(); return Ok();
        }
    }
}
