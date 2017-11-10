
using Lohana.Common;
using System;
using System.Web.Mvc;
using System.IO;
using LohanaHelper.Logging;
using LohanaRepo.Accessories;
using Lohana.Models.Accessories;
using LohanaBusinessEntities;
using System.Net;

namespace Lohana.Controllers.PostLogin
{
    public class AccessoriesController : BaseController
    {
        public AccessoriesRepo _aRepo;

        public AccessoriesController()
        {
        _aRepo=new AccessoriesRepo();
        }

        public ActionResult Index()
        {
            return View("Accessories");
        }

        public JsonResult Upload()
        {
            AccessoriesViewModel aViewModel = new AccessoriesViewModel();
            
            string newFileName = string.Empty;

            string fileName = string.Empty;

            string dt = DateTime.Now.ToString("ddMMyyyy_HHmmss");

            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    fileName = Path.GetFileName(file.FileName);

                    newFileName = string.Concat(new string[] {Guid.NewGuid().ToString(),"_" + dt, Path.GetExtension(file.FileName)});

                    var path = Path.Combine(Server.MapPath("~/Upload/"), newFileName);

                    file.SaveAs(path);

                    aViewModel.FileName = fileName;

                    aViewModel.NewFileName = newFileName;
                }

                aViewModel.FriendlyMessage.Add(MessageStore.Get("ACCESSORIES01"));

                Logger.Debug("Accessories Controller Upload");
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

                aViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Accessories Controller - Upload " + ex.Message);
            }

            return Json(aViewModel);
        }

        public JsonResult Insert(AccessoriesViewModel aViewModel)
        {
            try
            {
                
                Set_Date_Session(aViewModel.Accessories);

                if (aViewModel.Accessories.RefTypeName == "Package")
                {
                    aViewModel.Accessories.RefType = (int)Attachment.Package;
                }
                if (aViewModel.Accessories.RefTypeName == "User")
                {
                    aViewModel.Accessories.RefType = (int)Attachment.User;
                }
                if (aViewModel.Accessories.RefTypeName == "SightSeeing")
                {
                    aViewModel.Accessories.RefType = (int)Attachment.SightSeeing;
                }
                if (aViewModel.Accessories.RefTypeName == "Hotel")
                {
                    aViewModel.Accessories.RefType = (int)Attachment.Hotel;
                }
                aViewModel.Accessories.AttachmentId = _aRepo.Insert(aViewModel.Accessories);

                Logger.Debug("Accessories Controller Insert");

            }
            catch (Exception ex)
            {
                aViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Accessories Controller - Insert " + ex.Message);
            }

          TempData["aViewModel"] = (AccessoriesViewModel)aViewModel;

          return Json(aViewModel);          

        }

        public JsonResult GetImages(AccessoriesViewModel aViewModel)
        {
            try
            {

                aViewModel.Images = _aRepo.GetImages(aViewModel.Accessories.AttachmentId,aViewModel.Accessories.RefId, aViewModel.Accessories.RefType, aViewModel.Accessories.RefCategory);

                Logger.Debug("Accessories Controller GetImages");
            }

            catch (Exception ex)
            {
                aViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Accessories Controller - GetImages" + ex.ToString());
            }

            return Json(aViewModel, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetImagesByRefType(AccessoriesViewModel aViewModel)
        {
            try
            {
                if (aViewModel.Accessories.RefTypeName == "Package")
                {
                    aViewModel.Accessories.RefType = (int)Attachment.Package;
                }
                if (aViewModel.Accessories.RefTypeName == "User")
                {
                    aViewModel.Accessories.RefType = (int)Attachment.User;
                }
                if (aViewModel.Accessories.RefTypeName == "SightSeeing")
                {
                    aViewModel.Accessories.RefType = (int)Attachment.SightSeeing;
                }
                if (aViewModel.Accessories.RefTypeName == "Hotel")
                {
                    aViewModel.Accessories.RefType = (int)Attachment.Hotel;
                }

                aViewModel.Images = _aRepo.GetImagesByRefType(aViewModel.Accessories.RefId, aViewModel.Accessories.RefType);

                Logger.Debug("Accessories Controller GetImagesByRefType");
            }

            catch (Exception ex)
            {
                aViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Accessories Controller - GetImagesByRefType" + ex.ToString());
            }

            return Json(aViewModel, JsonRequestBehavior.AllowGet);

        }

        public JsonResult RemoveImage(AccessoriesViewModel aViewModel)
        {
            try
            {  
                if (aViewModel.Accessories.RefTypeName == "Package")
                {
                    aViewModel.Accessories.RefType = (int)Attachment.Package;
                }
                if (aViewModel.Accessories.RefTypeName == "User")
                {
                    aViewModel.Accessories.RefType = (int)Attachment.User;
                }
                if (aViewModel.Accessories.RefTypeName == "SightSeeing")
                {
                    aViewModel.Accessories.RefType = (int)Attachment.SightSeeing;
                }
                if (aViewModel.Accessories.RefTypeName == "Hotel")
                {
                    aViewModel.Accessories.RefType = (int)Attachment.Hotel;
                }

                // Delete file physicaly.
                string filePath = Server.MapPath("~/Upload/" + aViewModel.Accessories.UniqueAttachmentId);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                // Delete record from database.

                int deletedRows = _aRepo.DeleteAttachment(aViewModel.Accessories.RefId, aViewModel.Accessories.RefType, aViewModel.Accessories.UniqueAttachmentId);
                
                aViewModel.FriendlyMessage.Add(MessageStore.Get("ACCESSORIES02"));

                Logger.Debug("Accessories Controller RemoveImage");
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

                aViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Accessories Controller - RemoveImage " + ex.Message);
            }
            
            return Json(aViewModel);

        }
    
    }
}
