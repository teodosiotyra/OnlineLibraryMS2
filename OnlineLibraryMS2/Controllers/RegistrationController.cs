using OnlineLibraryMS2.Models.Context;
using OnlineLibraryMS2.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineLibraryMS2.Controllers
{
    public class RegistrationController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult RegistrationPage()
        {
            return View("Registration");
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult AdminDashboard()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RegisterUser(tbl_users_model user)
        {
            try
            {
                using (var db = new LibraryContext())
                {
                    if (db.tbl_users.Any(x => x.Username == user.Username))
                    {
                        return Json(new
                        {
                            success = false,
                            message = "Username already exists"
                        });
                    }

                    user.Role = "User";
                    user.DateRegistered = DateTime.Now;

                    db.tbl_users.Add(user);
                    db.SaveChanges();
                }

                return Json(new
                {
                    success = true,
                    message = "Registered Successfully"
                });
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.InnerException?.Message ?? ex.Message;
                return Json(new
                {
                    success = false,
                    message = "Error: " + innerMessage
                });
            }
        }

        [HttpPost]
        public JsonResult RegUser2(tbl_users_model user)
        {
            return RegisterUser(user);
        }

        [HttpPost]
        public JsonResult LoginUser(tbl_users_model login)
        {
            try
            {
                using (var db = new LibraryContext())
                {
                    if (login.Username == "admin" && login.Password == "admin123")
                    {
                        return Json(new
                        {
                            status = "Success",
                            role = "Admin"
                        });
                    }
                    var user = db.tbl_users.FirstOrDefault(x =>
                        x.Username == login.Username &&
                        x.Password == login.Password);

                    if (user != null)
                    {
                        return Json(new
                        {
                            status = "Success",
                            role = user.Role,
                            fullName = user.FullName,
                            UserID = user.UserID
                        });
                    }
                }

                return Json(new
                {
                    status = "Failed",
                    message = "Invalid Username or Password"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = "Error",
                    message = ex.Message
                });
            }
        }
    }
}