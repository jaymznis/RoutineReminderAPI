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
    public class Routine_RoutineItemController : ApiController
    {
        private R_RIService CreateR_RIService()
        {
            var rriService = new R_RIService();
            return rriService;
        }
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            R_RIService rriService = CreateR_RIService();
            var rrj = rriService.GetAllR_RI();
            return Ok(rrj);
        }
        [HttpPost]
        public IHttpActionResult Post(R_RICreate rri)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); var service = CreateR_RIService(); if (!service.CreateR_RI(rri))
                return InternalServerError(); return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            R_RIService rriService = CreateR_RIService();
            var rri = rriService.GetR_RIById(id);
            return Ok(rri);
        }

        [HttpDelete]
        public IHttpActionResult DeleteByID(int id)
        {
            var service = CreateR_RIService(); if (!service.DeleteR_RI(id))
                return InternalServerError(); return Ok();
        }
    }
}
