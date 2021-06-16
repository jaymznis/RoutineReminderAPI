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
    public class ShoppingItemController : ApiController
    {
        private ShoppingItemService CreateShoppingItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var shoppingItemService = new ShoppingItemService(userId);
            return shoppingItemService;
        }

        public IHttpActionResult Post(ShoppingItemCreate shoppingItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShoppingItemService();

            if (!service.CreateShoppingItem(shoppingItem))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult GetByID(int id)
        {
            ShoppingItemService shoppingItemService = CreateShoppingItemService();
            var shoppingItem = shoppingItemService.GetShoppingItemsByShoppingListId(id);
            return Ok(shoppingItem);
        }

        public IHttpActionResult Put(ShoppingItemEdit shoppingItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShoppingItemService();

            if (!service.UpdateShoppingItem(shoppingItem))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult DeleteByID(int id)
        {
            var service = CreateShoppingItemService();

            if (!service.DeleteShoppingItem(id))
                return InternalServerError();

            return Ok();
        }
    }
}
