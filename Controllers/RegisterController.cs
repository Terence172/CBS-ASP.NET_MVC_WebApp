using Assignment_3_ASP.NET_MVC_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_3_ASP.NET_MVC_CRUD.Controllers
{

    public class RegisterController : Controller
    {

        db_cbsEntities db = new db_cbsEntities();
        
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index([Bind(Include = "u_ic,u_pass,u_name,u_address,u_phone")] tb_user tb_user)
        {
            if (ModelState.IsValid)
            {
                db.tb_user.Add(tb_user);
                db.SaveChanges();
                
                Session["UserIC"] = tb_user.u_ic;
                Session["UserName"] = tb_user.u_name.ToString();
                Session["UserPhoneNo"] = tb_user.u_phone.ToString();
                Session["UserAddress"] = tb_user.u_address.ToString();

                //Return once done :P
                return RedirectToAction("Index", "Home");

            }

            return View(tb_user);
        }


    }
}