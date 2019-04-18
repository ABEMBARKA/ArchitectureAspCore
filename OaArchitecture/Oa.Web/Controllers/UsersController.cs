using Microsoft.AspNetCore.Mvc;

namespace Oa.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Http;
    using Oa.Data;
    using Oa.Service;
    using Oa.Web.Models;

    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserProfileService _userProfileService;
 
        public UsersController(IUserService userService, IUserProfileService userProfileService)
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
 
        //[HttpPost]
        //public ActionResult AddUser(UserViewModel model)
        //{
        //    User userEntity = new User
        //    {
        //        UserName = model.UserName,
        //        Email = model.Email,
        //        Password = model.Password,
        //        AddedDate = DateTime.UtcNow,
        //        ModifiedDate = DateTime.UtcNow,
        //        IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
        //        UserProfile = new UserProfile
        //        {
        //            FirstName = model.FirstName,
        //            LastName = model.LastName,
        //            Address = model.Address,
        //            AddedDate = DateTime.UtcNow,
        //            ModifiedDate = DateTime.UtcNow,
        //            IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString()
        //        }
        //    };
        //    _userService.InsertUser(userEntity);
        //    if (userEntity.Id!=Guid.Empty )
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}
        
        public ActionResult EditUser(Guid? id)
        {
            UserViewModel model = new UserViewModel();
            if (id.HasValue && id != Guid.Empty)
            {
                User userEntity = _userService.GetUser(id.Value);
                UserProfile userProfileEntity = _userProfileService.GetUserProfile(id.Value);
                model.FirstName = userProfileEntity.FirstName;
                model.LastName = userProfileEntity.LastName;
                model.Address = userProfileEntity.Address;
                model.Email = userEntity.Email;
            }
            return PartialView("_EditUser", model);
        }
 
        [HttpPost]
        public ActionResult EditUser(UserViewModel model)
        {
            User userEntity = _userService.GetUser(model.Id);
            userEntity.Email = model.Email;
            userEntity.ModifiedDate = DateTime.UtcNow;
            userEntity.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            UserProfile userProfileEntity = _userProfileService.GetUserProfile(model.Id);
            userProfileEntity.FirstName = model.FirstName;
            userProfileEntity.LastName = model.LastName;
            userProfileEntity.Address = model.Address;
            userProfileEntity.ModifiedDate = DateTime.UtcNow;
            userProfileEntity.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            userEntity.UserProfile = userProfileEntity;
            _userService.UpdateUser(userEntity);
            if (userEntity.Id!=Guid.Empty)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public PartialViewResult DeleteUser(Guid id)
        {
            UserProfile userProfile = _userProfileService.GetUserProfile(id);
            string name = $"{userProfile.FirstName} {userProfile.LastName}";
            return PartialView("_DeleteUser", name);
        }
 
        [HttpPost]
        public ActionResult DeleteUser(Guid id, FormCollection form)
        {
            _userService.DeleteUser(id);         
            return RedirectToAction("Index");
        }
    }
}