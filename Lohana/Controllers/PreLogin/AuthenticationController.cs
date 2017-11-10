using Lohana.Common;
using Lohana.Models.Master;
using Lohana.Models.Quotation;
using LohanaBusinessEntities.Common;
using LohanaHelper.Logging;
//using LohanaHelper.Utilities;
using LohanaRepo.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Lohana.Controllers.PreLogin
{
    public class AuthenticationController : Controller
    {


        AuthenticationRepo _authRepo;

        public AuthenticationController()
        {
            _authRepo = new AuthenticationRepo();
        }

        public ActionResult AuthenticateUser( AuthenticationViewModel authViewModel)
         {
            UserViewModel homeViewModel = new UserViewModel(); 

            try
            {
                Logger.Debug("Authentication Controller AuthenticateUser");

               // authViewModel.Session.Password = Encrypter.Encrypt(authViewModel.Session.Password);             

                SessionInfo session = _authRepo.AuthernticateLogin(authViewModel.Session);  
            
                
                if (session.UserName == authViewModel.Session.UserName && session.IsActive == true)
                {
                    //HttpCookie cookieObj = new HttpCookie("Booking"); 

                    SetUsersSession(session);

                    SetCookies(session);

                    if (session.RoleId == 0)
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {

                        return RedirectToAction("Index", "Dashboard");
                    }    
                                       
                }
                else
                {
                    if (session.UserName == authViewModel.Session.UserName && session.IsActive == false)
                    {
                        homeViewModel.FriendlyMessage.Add(MessageStore.Get("UM007"));

                    }
                    else
                    {
                        homeViewModel.FriendlyMessage.Add(MessageStore.Get("UM001"));
                    }

                    TempData["homeViewModel"] = homeViewModel;

                                       
                }

            }
            catch (Exception ex)
            {
                Logger.Error("Authentication Controller - AuthenticateUser " + ex.Message);

                homeViewModel.FriendlyMessage.Add(MessageStore.Get("UM004"));

                TempData["homeViewModel"] = homeViewModel;

                HttpContext.Session.Clear();

                return RedirectToAction("Index", "Login");

            }
            return RedirectToAction("Index", "Login");

           
        }

        private void SetUsersSession(SessionInfo session)
        {
            QuotationViewModel qsViewModel = new QuotationViewModel();
            try
            {
                Logger.Debug("Authentication Controller SetUserSession");
                 
                if (HttpContext.Session["SessionInfo"] == null)
                {
                    HttpContext.Session.Add("SessionInfo", session);
                    HttpContext.Session.Add("BookingCart", qsViewModel.Quotation.QuatationItem);
                }
                else
                {
                    HttpContext.Session["SessionInfo"] = session;
                }
            }
            catch (Exception ex)
            {              

                UserViewModel homeViewModel = new UserViewModel();

                homeViewModel.FriendlyMessage.Add(MessageStore.Get("UM004"));

                Logger.Error("Authentication Controller - Set Session " + ex.Message);

                TempData["homeViewModel"] = homeViewModel;

                HttpContext.Session.Clear();

            }
        }

        //private void SetCookies(SessionInfo session)
        //{
            

        //    try
        //    {
        //        if (Request.Cookies["Bookings"] == null)
        //        {
        //            HttpCookie userCookie = new HttpCookie("Bookings");

        //            userCookie.Expires.AddDays(365);

        //            HttpContext.Response.Cookies.Add(userCookie);

        //            HttpContext.Response.Cookies.Remove("ASP.Net_SessionId");
        //        }
        //        else
        //        {
        //            HttpCookie cookies = (HttpCookie)Session["Bookings"];

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error("Authentication Controller - Set Session " + ex.Message);
        //        HttpContext.Request.Cookies.Clear();
        //    }
        //}

        private void SetCookies(SessionInfo session)
        {
            var userCookie = new HttpCookie("Bookings");

            try
            {
                userCookie.Expires.AddDays(365);

                HttpContext.Response.Cookies.Add(userCookie);

                HttpContext.Response.Cookies.Remove("ASP.Net_SessionId");
            }
            catch (Exception ex)
            {
                Logger.Error("Authentication Controller - Set Session " + ex.Message);

                userCookie.Expires = DateTime.Now.AddDays(-10);

                userCookie.Value = null;
            }
        }

        public ActionResult Logout(string timeOut)
        {
            AuthenticationViewModel authViewModel = new AuthenticationViewModel();

            var RoleId = 0;

            try
            {
                Logger.Debug("Authentication Controller Logout");

                RoleId = ((SessionInfo)Session["SessionInfo"]).RoleId;

                LogoutUser();

                FormsAuthentication.SignOut();

                if (timeOut == "Timeout")
                {

                }
            }
            catch (Exception ex)
            {
                authViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Authentication Controller - Logout " + ex.Message);
            }

            return RedirectToAction("Index", "Login");
           

        }

        //private void LogoutUser()
        //{
        //    try
        //    {
        //        Logger.Debug("Authentication Controller LogoutUser");

        //        HttpCookie cookies = System.Web.HttpContext.Current.Request.Cookies["Bookings"];
                


        //        Session["SessionInfo"] = null;
              
        //        FormsAuthentication.SignOut();

        //        Session["Bookings"] = cookies;

        //        Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddYears(-1);

        //        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);

        //        Response.Expires = -1500;

        //        Response.CacheControl = "no-cache";

        //        Response.AddHeader("Cache-Control", "no-cache");

        //        Response.Cache.SetNoStore();

        //        Response.AddHeader("Pragma", "no-cache");

        //        cookies = (HttpCookie)Session["Bookings"];
        //        Response.Cookies["Bookings"].Expires = DateTime.Now.AddDays(10);
                
        //        cookies.Expires.AddDays(365);

        //        //HttpContext.Response.Cookies.Add(userCookie);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error("Authentication Controller - LogoutUser " + ex.Message);

        //    }

        //}

        private void LogoutUser()
        {
            try
            {
                Logger.Debug("Authentication Controller LogoutUser");

                Session["SessionInfo"] = null;
                Session["BookingCart"] = null;

                FormsAuthentication.SignOut();

                Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddYears(-1);

                Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);

                Response.Expires = -1500;

                Response.CacheControl = "no-cache";

                Response.AddHeader("Cache-Control", "no-cache");

                Response.Cache.SetNoStore();

                Response.AddHeader("Pragma", "no-cache");
            }
            catch (Exception ex)
            {
                Logger.Error("Authentication Controller - LogoutUser " + ex.Message);

            }

        }

        public ActionResult UnAuthorizedAccess(string returnURL)
        {
            AuthenticationViewModel authViewModel = new AuthenticationViewModel();
            
            try
            {
                Logger.Debug("Authentication Controller UnAuthorizedAccess");

                authViewModel.FriendlyMessage.Add(MessageStore.Get("SYS03"));

                Session["ReturnURL"] = returnURL;
            }
            catch (Exception ex)
            {
                // clear session.
                HttpContext.Session.Clear();

                Logger.Error("Authentication Controller - UnAuthorizedAccess: " + ex.ToString());

                authViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("UnAuthorizeAccess");
        }

    }
}
