﻿using CSC.Core;
using CSC.Core.Types;
using CSC.Web.Areas.Control.Models;
using CSC.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CSC.Web.Areas.Control.Controllers
{
    [AdminAuthorize]
    public class UserController : Controller
    {
        private UserInfoManager userManager = new UserInfoManager();

        // GET: Control/User
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 分页列表【json】
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <param name="username">用户名</param>
        /// <param name="name">名称</param>
        /// <param name="sex">性别</param>
        /// <param name="email">Email</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="order">排序</param>
        /// <returns>Json</returns>
        public ActionResult PageListJson(Guid? roleID, string username, string name, int? sex, string email, int? pageNumber, int? pageSize, int? order)
        {
            Paging<UserInfo> _pagingUser = new Paging<UserInfo>();
            if (pageNumber != null && pageNumber > 0) _pagingUser.PageIndex = (int)pageNumber;
            if (pageSize != null && pageSize > 0) _pagingUser.PageSize = (int)pageSize;
            var _paging = userManager.FindPageList(_pagingUser, roleID, username, name, sex, email, null);

            //var userList = new { total = _paging.TotalNumber, rows = _paging.Items };

            //string jsonString = JsonConvert.SerializeObject(userList);

            //return Json(jsonString);
            return Json(new { total = _paging.TotalNumber, rows = _paging.Items });
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            //角色列表
            var _roles = new RoleInfoManager().FindList();
            List<SelectListItem> _listItems = new List<SelectListItem>(_roles.Count());
            foreach (var _role in _roles)
            {
                _listItems.Add(new SelectListItem() { Text = _role.Name, Value = _role.ID.ToString() });
            }
            ViewBag.Roles = _listItems;
            //角色列表结束
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddUserViewModel userViewModel)
        {
            if (userManager.HasUsername(userViewModel.Username)) ModelState.AddModelError("Username", "用户名已存在");
            if (userManager.HasEmail(userViewModel.Email)) ModelState.AddModelError("Email", "Email已存在");
            if (ModelState.IsValid)
            {
                Core.UserInfo _user = new Core.UserInfo();
                _user.ID = Guid.NewGuid();
                _user.RoleId = userViewModel.RoleID;
                _user.UserName = userViewModel.Username;
                _user.DisplayName = userViewModel.Name;
                _user.Password = Core.General.Security.SHA256(userViewModel.Password);
                _user.Email = userViewModel.Email;
                _user.RegistrationTime = System.DateTime.Now;
                _user.IsActive = "1";



                var _response = userManager.Add(_user);
                if (_response.Code == 1)
                {
                    UserProfileInfo _profile = new UserProfileInfo();
                    _profile.UserID = _user.ID;
                    _profile.Sex = userViewModel.Sex;

                    UserProfileInfoManage userProfileManager = new UserProfileInfoManage();
                    _response = userProfileManager.Add(_profile);
                }
                else ModelState.AddModelError("", _response.Message);


                if (_response.Code == 1) return View("Prompt", new Prompt()
                {
                    Title = "添加用户成功",
                    Message = "您已成功添加了用户【" + _response.Data.Username + "（" + _response.Data.Name + "）】",
                    Buttons = new List<string> {"<a href=\"" + Url.Action("Index", "User") + "\" class=\"btn btn-default\">用户管理</a>",
                 "<a href=\"" + Url.Action("Details", "User",new { id= _response.Data.UserID }) + "\" class=\"btn btn-default\">查看用户</a>",
                 "<a href=\"" + Url.Action("Add", "User") + "\" class=\"btn btn-default\">继续添加</a>"}
                });
                else ModelState.AddModelError("", _response.Message);
            }

            //角色列表
            var _roles = new RoleInfoManager().FindList();
            List<SelectListItem> _listItems = new List<SelectListItem>(_roles.Count());
            foreach (var _role in _roles)
            {
                _listItems.Add(new SelectListItem() { Text = _role.Name, Value = _role.ID.ToString() });
            }
            ViewBag.Roles = _listItems;
            //角色列表结束

            return View(userViewModel);
        }

        /// <summary>
        /// 用户名是否可用
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns> 
        [HttpPost]
        public JsonResult CanUsername(string UserName)
        {
            return Json(!userManager.HasUsername(UserName));
        }

        /// <summary>
        /// Email是否存可用
        /// </summary>
        /// <param name="Email">Email</param>
        /// <returns></returns> 
        [HttpPost]
        public JsonResult CanEmail(string Email)
        {
            return Json(!userManager.HasEmail(Email));
        }
    }
}