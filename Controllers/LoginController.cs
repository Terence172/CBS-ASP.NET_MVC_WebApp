using Assignment_3_ASP.NET_MVC_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_3_ASP.NET_MVC_CRUD.Controllers
{
    public class LoginController : Controller
    {

        db_cbsEntities db = new db_cbsEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]


        public ActionResult Index(tb_user objchk)
        {
            
            if (ModelState.IsValid) 
            {
                using(db_cbsEntities db = new db_cbsEntities())
                {

                    var obj = db.tb_user.Where(a => a.u_name.Equals(objchk.u_name) && a.u_pass.Equals(objchk.u_pass)).FirstOrDefault();


                    if (obj != null)
                    {
                        Session["UserIC"] = obj.u_ic.ToString();
                        Session["UserName"] = obj.u_name.ToString();
                        Session["UserPhoneNo"] = obj.u_phone.ToString();
                        Session["UserAddress"] = obj.u_address.ToString();
                
                        //Return once done :P
                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        //In Case it is wrong
                        ModelState.AddModelError("", "The Name or Password is Incorrect");
                    }
                }
            }



            return View();
        }

        //Logout Function
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }

    }
}