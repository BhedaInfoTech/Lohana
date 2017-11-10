using Lohana.Models.Master;
using Lohana.Models.TaxFormulaCalDemo;
using LohanaBusinessEntities.Common;
using LohanaRepo.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lohana.Controllers.PostLogin.TaxFormulaCalDemo
{
    public class TaxFormulaCalDemoController : Controller
    {
        TaxFormulaRepo _tRepo;

        ChargesRepo _cRepo;

        public TaxFormulaCalDemoController()
        {
            _tRepo = new TaxFormulaRepo();

            _cRepo = new ChargesRepo();
        }

        public ActionResult Index(TaxFormulaCalDemoViewModel tViewModel)
        {
            // Fill Tax Formula Drop- down
            tViewModel.LstTaxFormula = _tRepo.drpGetTaxFormula();

            tViewModel.LstStandardCharges = _cRepo.GetStandardCharges();

            return View(tViewModel);
        }

        #region PartialViewResult

        public PartialViewResult GetTaxFormulaCharges(int TaxFormulaId)
        {
            TaxFormulaCalDemoViewModel tViewModel = new TaxFormulaCalDemoViewModel();

            PaginationInfo pager = null;

            tViewModel.LstTaxFormulaCharges = _tRepo.GetTaxFormulaCharges(TaxFormulaId, ref pager);

            return PartialView("_TaxFormulaChargesGrid", tViewModel);
        }

        #endregion

    }
}
