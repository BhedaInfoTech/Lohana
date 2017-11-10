
using Lohana.Models.Master;
using Newtonsoft.Json;
using Lohana.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using LohanaBusinessEntities.Common;
using LohanaHelper;
using LohanaHelper.Logging;
using LohanaRepo.Accessories;
using Lohana.Models.Lookup;
using LohanaBusinessEntities;
using LohanaRepo.AutoLookupRepo;
using System.Data;

namespace Lohana.Controllers.PostLogin
{
    public class AutocompleteLookupController : BaseController
    {
        AutocompleteLookupRepo _autoLookupRepo;

        public AutocompleteLookupController()
        {
            _autoLookupRepo = new AutocompleteLookupRepo();
        }

        public PartialViewResult Load_Modal_Data(string table_Name, string columns, string headerNames, string editValue, string fieldValue, string fieldName, int currentPage)
        {
            LookupViewModel LookupVM = new LookupViewModel();

            string[] cols;

            string[] headerNamesArr;

            cols = columns.Split(',');

            if (headerNames != null)
            {
                headerNamesArr = headerNames.Split(',');

                LookupVM.HeaderNames = headerNamesArr;

                Logger.Debug("AutoCompleteLookup Controller Load_Modal_Data");
            }

            try
            {

                LookupVM.Pager.CurrentPage = currentPage;

                DataTable dt = _autoLookupRepo.Get_Lookup_Data(table_Name, cols, fieldValue, fieldName, 1);

                LookupVM.Pager = new PaginationInfo(LookupVM.PartialDt.Rows.Count, LookupVM.Pager.CurrentPage);

                LookupVM.PartialDt = dt.AsEnumerable().Skip((LookupVM.Pager.CurrentPage - 1) * LookupVM.Pager.PageSize).Take(LookupVM.Pager.PageSize).CopyToDataTable();

                LookupVM.EditLookupValue = editValue;

            }
            catch (Exception ex)
            {
                Logger.Error("AutoCompleteLookup Controller - Load_Modal_Data" + ex.Message);
            }

            return PartialView("_Lookup", LookupVM);
        }

        public JsonResult Get_Lookup_Data_By_Id(string field_Value, string table_Name, string columns, string headerNames)        
        
       {
            LookupViewModel LookupVM = new LookupViewModel();

            try

            {
                string[] cols;

                string[] headerNamesArr;

                cols = columns.Split(',');

                if (headerNames != null)
                {
                    headerNamesArr = headerNames.Split(',');

                    LookupVM.HeaderNames = headerNamesArr;
                }

                if (table_Name == "Country")
                {
 
                    if (field_Value != null)
                    {
                        LookupVM.Value = _autoLookupRepo.Get_Lookup_Data_Country(field_Value, table_Name, cols);
                    }
                }

                Logger.Debug("AutoCompleteLookup Controller Get_Lookup_Data_By_Id");

            }
            catch (Exception ex)
            {
                Logger.Error("AutoCompleteLookup Controller- Get_Lookup_Data_By_Id" + ex.Message);
            }

            return Json(LookupVM.Value, JsonRequestBehavior.AllowGet);
        }

    }

    
}
