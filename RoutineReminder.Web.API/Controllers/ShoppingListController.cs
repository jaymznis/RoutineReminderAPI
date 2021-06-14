using Microsoft.AspNet.Identity;
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
    }
}
