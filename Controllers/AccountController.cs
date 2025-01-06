using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            List<BaseEquipment> list = BaseEquipment.ListEquipmentData();
            ViewBag.list = list;
            ViewBag.txtName = "";
            return View();
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
    }
}