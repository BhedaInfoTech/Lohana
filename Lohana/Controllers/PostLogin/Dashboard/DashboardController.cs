using Lohana.Common;
using Lohana.Models.Dashboard;
using Lohana.Models.Master;
using LohanaRepo.Dashboard;
using LohanaHelper.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LohanaBusinessEntities.Common;

namespace Lohana.Controllers
{
	public class DashboardController:Controller
	{
        public DashboardTaskRepo _dRepo;

        public DashboardController()
        {
            _dRepo = new DashboardTaskRepo();
        }

        public ActionResult Index(DashboardViewModel dViewModel)
        {

            //DashboardViewModel dViewModel = new DashboardViewModel();
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            if (TempData["Message"] != null)
            {
                dViewModel.FriendlyMessage = (List<FriendlyMessage>)TempData["Message"];
            }

            if (Session["SessionInfo"] != null)
            {  
                dViewModel.Task_Grid = _dRepo.GetUserEnquiryTask(((SessionInfo)HttpContext.Session["SessionInfo"]).UserId);
                if (_dRepo.CheckIsUserApproval(((SessionInfo)HttpContext.Session["SessionInfo"]).UserId) > 0)
                {
                    dViewModel.QuotationGrid = _dRepo.GetApprovalQuotationTask();
                    dViewModel.IsApproval = true;
                }
                else
                {
                    dViewModel.QuotationGrid = _dRepo.GetUserQuotationTask(((SessionInfo)HttpContext.Session["SessionInfo"]).UserId); 
                }
            }

            return View("Index", dViewModel);
        }
         
		public ActionResult Dashboard()
		{

			return View();
		}

        public ActionResult ApprovedQBDashboard()
        {
            return View("ApprovedQuotationBookingDashboard");
        }

		public ActionResult About()
		{
			ViewBag.Message = "Your app description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}


        public ActionResult SystemError()
        {
            
            return View("Error");
        }

        public ActionResult UpdateQuotationStatus(DashboardViewModel dViewModel)
        {
            _dRepo.UpdateQuotationStatus(dViewModel.TaskId, dViewModel.QuotationItemId, dViewModel.QuotationStatus, ((SessionInfo)HttpContext.Session["SessionInfo"]).UserId);
            dViewModel.FriendlyMessage.Add(MessageStore.Get("Q07"));
            TempData["Message"] = dViewModel.FriendlyMessage;
            return RedirectToAction("Index");
        }
     
	}
}
