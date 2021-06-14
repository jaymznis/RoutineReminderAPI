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
    public class ShoppingListController : ApiController
    {
        private ShoppingListService CreateShoppingListService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var shoppingListService = new ShoppingListService(userId);
            return shoppingListService;
        }

        public IHttpActionResult Get()
        {
            ShoppingListService shoppingListService = CreateShoppingListService();
            var shoppingLists = shoppingListService.GetShoppingLists();
            return Ok(shoppingLists);
        }

        public IHttpActionResult Post(ShoppingListCreate shoppingList)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); 
            
            var service = CreateShoppingListService(); 
            
            if (!service.CreateShoppingList(shoppingList))
                return InternalServerError(); 
            
            return Ok();
        }
    }
}
