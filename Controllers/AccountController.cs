using Inventory.Models;
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
            if (Session["User"] != null)
            {
                List<BaseEquipment> list = BaseEquipment.ListEquipmentData();
                ViewBag.list = list;
                ViewBag.txtName = "";
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        public ActionResult DashBoard(FormCollection frm, string btnSearch)
        {
            if(btnSearch== "Add Equipment")
            {
            BaseEquipment baseEquipment =new BaseEquipment();
                baseEquipment.Name = frm["ddlEquipmentName"].ToString();
                baseEquipment.EcCount = Convert.ToInt16(frm["txtQuantity"].ToString());
                DateTime parsedDate;
                if (DateTime.TryParse(frm["txtEntryDate"], out parsedDate) && parsedDate >= (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                {
                    baseEquipment.DateEntry = parsedDate;
                }
                else
                {
                    baseEquipment.DateEntry = DateTime.Now; // or use a nullable field if the DB allows it
                }
                int result = baseEquipment.SaveEquipment();
                if (result > 0) 
                {
                    ViewBag.Operation = "Save Successfully😍";
                }

            }


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
            BaseAccount baseAccount = new BaseAccount();
            return View(baseAccount);
        }
        [HttpPost]
        public ActionResult Login(string btnSubmit,BaseAccount @base)
        {
            string LoginMsg = "";
            bool varifyStatus = @base.VarifyLogin();
            if(btnSubmit == "Login")
            {
                if(varifyStatus)
                {
                    Session["User"] = @base.Username;
                    LoginMsg = "Login Success";
                    //return RedirectToAction("DashBoard", "Account");
                }
                else
                {
                   LoginMsg = "Failed, Username / gmail / passward is incorrect";
                }
            }
            BaseAccount baseAccount = new BaseAccount();
            ViewBag.LoginMsg = LoginMsg;
            return View(baseAccount); 
        }
        [HttpPost]
        public ActionResult LogOut()
        {
            if (Session["User"] != null)
            {
                Session.Remove("User");
                return RedirectToAction("Login");
            }
            return RedirectToAction("Login");
        }
    }
}