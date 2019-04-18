using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oa.Data;
using Oa.Service;
using Oa.Web.Models;

namespace Oa.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserProfileService _userProfileService;

        public UserController(IUserService userService, IUserProfileService userProfileService)
        {
            this._userService = userService;
            this._userProfileService = userProfileService;
        }

        // GET
        [HttpGet]
        public IActionResult Index()
        {
            List<UserViewModel> model = new List<UserViewModel>();
            _userService.GetUsers().ToList().ForEach(u =>
            {
                UserProfile userProfile = _userProfileService.GetUserProfile(u.Id);
                UserViewModel user = new UserViewModel
                {
                    Id = u.Id,
                    Name = $"{userProfile.FirstName} {userProfile.LastName}",
                    Email = u.Email,
                    Address = userProfile.Address
                };
                model.Add(user);
            });

            return View(model);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            UserViewModel model = new UserViewModel();

            return PartialView("_AddUser", model);
        }

    }
}