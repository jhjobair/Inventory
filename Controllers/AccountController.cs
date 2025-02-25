﻿using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Inventory.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult DashBoard()
        {
           if(Session["User"] != null)
            {
                List<BaseEquipment> list = BaseEquipment.ListEquipmentData();
                ViewBag.list = list;
                ViewBag.txtName = "";
                return View();
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
        }
        [HttpPost]
        public ActionResult DashBoard(FormCollection frm, string btnSearch)
        {
            List<BaseEquipment> list = BaseEquipment.ListEquipmentData();
            ViewBag.list = list;
            ViewBag.txtName = "";
            if (btnSearch == "Search")
            {
                 
                string dd = frm["txtName"].ToString();
                ViewBag.list = list.Where(e => e.Name.Contains(dd)).ToList();
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string btnSubmit, string fname, string gmail, int pass)
        { 
            if(btnSubmit == "Login")
            {
                if(fname=="jobair"&& gmail=="jobair@gmail.com" && pass == 123456)
                {
                    Session["User"] = "jobair";
                    return RedirectToAction("DashBoard", "Account");

                }


            }
            return View();
        }
    }
}