using Lohana.Common;
using Lohana.Models.TaskManagement;
using LohanaBusinessEntities.Common;
using LohanaHelper.Logging;
using LohanaRepo.Master;
using LohanaRepo.TaskManagementRepo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lohana.Controllers.PostLogin
{
    public class TaskManagementController : Controller
    {
        public TaskManagementRepo _tRepo;
        public UserRepo _uRepo;

        public TaskManagementController()
        {
            _tRepo = new TaskManagementRepo();
            _uRepo = new UserRepo();
        }

        public ActionResult Index(TaskViewModel tViewModel)
        {

            if (Session["SessionInfo"] != null)
            {
              //  tViewModel.Tasks = _tRepo.GetTasks(((SessionInfo)HttpContext.Session["SessionInfo"]).UserId);
               GetTasks(tViewModel);
            }

            return View("Index",tViewModel);
        }

        public ActionResult Quotation()
        {
            return View("~/Views/PostLogin/Quotation/Index.cshtml");
        }

        public JsonResult GetTasks(TaskViewModel tViewModel)
        {
            try
            {
                if (Session["SessionInfo"] != null)
                {
                    tViewModel.Task.UserId=(((SessionInfo)HttpContext.Session["SessionInfo"]).UserId);
                    tViewModel.Tasks = _tRepo.GetTasks(tViewModel.Task);
                }
            }
            catch
            {

            }

            return Json(JsonConvert.SerializeObject(tViewModel), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTaskByTaskId(int TaskNo)
        {            
            TaskViewModel tViewModel = new TaskViewModel(); 
            try
            {    
                tViewModel.Users = _uRepo.GetUsers();

                tViewModel.Task = _tRepo.GetTaskByTaskId(TaskNo);
            }
            catch (Exception ex)
            {
                tViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Task Controller - GetTaskByTaskId " + ex.Message);
            } 

            return View("_EditTask", tViewModel);
        }

        public ActionResult UpdateTask(TaskViewModel tViewModel)
        {
            try
            {
                  if (Session["SessionInfo"] != null)
                 {
                     tViewModel.Task.UpdatedBy = ((SessionInfo)HttpContext.Session["SessionInfo"]).UserId; 
                 }
               
                _tRepo.UpdateTask(tViewModel.Task);

                tViewModel.FriendlyMessage.Add(MessageStore.Get("Task1"));
            }
            catch (Exception ex)
            {
                tViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Task Controller - Insert " + ex.Message);
            }

            TempData["tViewModel"] = tViewModel;

            return Index(tViewModel);
        }

    }
}
