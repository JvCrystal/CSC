﻿using CSC.Core;
using CSC.Core.Service;
using CSC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSC.Web.Areas.Control.Controllers
{
    [AdminAuthorize]
    public class RoleController : BaseController
    {
        private RoleInfoService roleManager = new RoleInfoService();

        // GET: Control/Role
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///  列表【Json】
        /// </summary>
        /// <returns></returns>
        public JsonResult ListJson()
        {
            return Json(roleManager.FindList());
        }

        /// <summary>
        ///  添加
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(RoleInfo role)
        {
            if (ModelState.IsValid)
            {
                if (roleManager.Add(role).Code == 1)
                {
                    return View("Prompt", new Prompt()
                    {
                        Title = "添加角色成功",
                        Message = "你已成功添加了角色【" + role.Name + "】",
                        Buttons = new List<string>() { "<a href=\"" + Url.Action("Index", "Role") + "\" class=\"btn btn-default\">角色管理</a>", "<a href=\"" + Url.Action("Add", "Role") + "\" class=\"btn btn-default\">继续添加</a>" }
                    });
                }
            }
            return View(role);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id">RoleID</param>
        /// <returns></returns>
        public ActionResult Modify(Guid id)
        {
            var _role = roleManager.Find(id);
            if (_role == null) return View("Prompt", new Prompt()
            {
                Title = "错误",
                Message = "ID为【" + id + "】的角色不存在",
                Buttons = new List<string>() { "<a href=\"" + Url.Action("Index", "Role") + "\" class=\"btn btn-default\">角色管理</a>" }
            });
            return View(_role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(RoleInfo role)
        {
            if (ModelState.IsValid)
            {
                var _resp = roleManager.Update(role);
                if (_resp.Code == 1) return View("Prompt", new Prompt()
                {
                    Title = "修改角色成功",
                    Message = "你已成功修改了角色【" + role.Name + "】",
                    Buttons = new List<string>() { "<a href=\"" + Url.Action("Index", "Role") + "\" class=\"btn btn-default\">角色管理</a>", "<a href=\"" + Url.Action("Modify", "Role", new { id = role.ID }) + "\" class=\"btn btn-default\">查看</a>", "<a href=\"" + Url.Action("Add", "Role") + "\" class=\"btn btn-default\">添加</a>" }
                });
                else return View("Prompt", new Prompt()
                {
                    Title = "修改角色失败",
                    Message = "失败原因：" + _resp.Message,
                    Buttons = new List<string>() { "<a href=\"" + Url.Action("Index", "Role") + "\" class=\"btn btn-default\">角色管理</a>", "<a href=\"" + Url.Action("Modify", "Role", new { id = role.ID }) + "\" class=\"btn btn-default\">返回</a>" }
                });
            }
            else return View(role);
        }

        /// <summary>
        /// 删除【Json】
        /// </summary>
        /// <param name="id">RoleID</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteJson(Guid id)
        {
            return Json(roleManager.Delete(id));
        }

    }
}