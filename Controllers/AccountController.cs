﻿using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult DashBoard()
        {
            List<BaseEquipment> list = BaseEquipment.ListEquipmentData();
            ViewBag.list = list;
            return View();
        }
    }
}