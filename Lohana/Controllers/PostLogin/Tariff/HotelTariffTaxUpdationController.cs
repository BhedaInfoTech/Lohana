using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Lohana.Common;
using Lohana.Models;
using Lohana.Models.Tariff.HotelTariffTaxUpdation;
using LohanaRepo.HotelTariff;
using LohanaBusinessEntities.Charges;
using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using LohanaHelper.Authorization;
using LohanaHelper.Logging;
using LohanaRepo.HotelTariffTaxUpdation;
using LohanaRepo.Master;
using Newtonsoft.Json;
using LohanaBusinessEntities.HotelTariff;

namespace Lohana.Controllers.PostLogin.Tariff
{
    public class HotelTariffTaxUpdationController : BaseController
    {
        public ChargesInfo charges;

        public HotelTariffTaxUpdationRepo _htuRepo;

        public TaxFormulaRepo _tRepo;

        public ChargesRepo _cRepo;

        public HotelTariffRepo _htRepo;

        public HotelTariffTaxUpdationController()
        {
            charges = new ChargesInfo();

            _htuRepo = new HotelTariffTaxUpdationRepo();

            _tRepo = new TaxFormulaRepo();

            _cRepo = new ChargesRepo();

            _htRepo = new HotelTariffRepo();

        }

        public ActionResult Index(HotelTariffTaxUpdationViewModel htuViewModel)
        {
            if (TempData["htuViewModel"] != null)
            {
                htuViewModel = (HotelTariffTaxUpdationViewModel)TempData["htuViewModel"];
            }

            Set_Date_Session(htuViewModel.HotelTariffTax);

            htuViewModel.Vendors = _htRepo.drpGetVendors();

            htuViewModel.Hotels = _htRepo.drpGetHotels();

            htuViewModel.RoomTypes = _htRepo.drpGetRoomTypes();

            htuViewModel.Meals = _htRepo.drpGetMeals();

            //Price dropdowns

            htuViewModel.LstTaxFormula = _tRepo.drpGetTaxFormula();

            htuViewModel.LstStandardCharges = _cRepo.GetStandardCharges();

            return View("Index", htuViewModel);
        }

        public JsonResult GetHotelTariffTaxUpdation(HotelTariffTaxUpdationViewModel htuViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = htuViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _htuRepo.GetHotelTariffTaxUpdation(htuViewModel.HotelTariffTax, ref pager);

                pViewModel.Pager = pager;

            }

            catch (Exception ex)
            {
                htuViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelTariffTaxUpdation Controller - GetHotelTariffTax" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

		//public JsonResult GetHotelTariffPrice(HotelTariffTaxUpdationViewModel htuViewModel)
		//{
		//	try
		//	{
		//		htuViewModel.HotelTariffPrice = _htRepo.GetHotelTariffPrice(htuViewModel.HotelTariffPrice.HotelTariffId, htuViewModel.HotelTariffPrice.HotelTariffDurationDetailsId, htuViewModel.HotelTariffPrice.HotelTariffRoomDetailsId);
		//	}
		//	catch (Exception ex)
		//	{
		//		htuViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

		//		Logger.Error("HotelTariff Controller - GetPrice" + ex.ToString());
		//	}

		//	TempData["htViewModel"] = htuViewModel;

		//	return Json(htuViewModel, JsonRequestBehavior.AllowGet);
		//}

        public PartialViewResult GetTaxFormulaCharges(int TaxFormulaId, int HotelTriffPriceDetailsId)
        {
            HotelTariffTaxUpdationViewModel htuViewModel = new HotelTariffTaxUpdationViewModel();

            PaginationInfo pager = null;

            if (HotelTriffPriceDetailsId != 0)
            {
                htuViewModel.LstTaxFormulaCharges = _htRepo.GetTaxFormulaChargesByPriceId(TaxFormulaId, HotelTriffPriceDetailsId, ref pager);

                if (htuViewModel.LstTaxFormulaCharges.Count > 0)
                {
                    htuViewModel.HotelTariffPrice.TotalTaxPrice = htuViewModel.LstTaxFormulaCharges[0].HotelTariffCharge.TotalTaxPrice;
                }
                else
                {
                    htuViewModel.LstTaxFormulaCharges = _tRepo.GetTaxFormulaCharges(TaxFormulaId, ref pager);
                }
            }
            else
            {
                htuViewModel.LstTaxFormulaCharges = _tRepo.GetTaxFormulaCharges(TaxFormulaId, ref pager);

            }

            return PartialView("_PriceTaxFormulaCharges", htuViewModel);
        }

        public PartialViewResult GetTaxFormulaChargesUpdate(int TaxFormulaId)
        {
            HotelTariffTaxUpdationViewModel htuViewModel = new HotelTariffTaxUpdationViewModel();

            PaginationInfo pager = null;

            htuViewModel.LstTaxFormulaCharges = _tRepo.GetTaxFormulaCharges(TaxFormulaId, ref pager);

            return PartialView("_UpdatePriceTaxFormulaCharges", htuViewModel);
        }

        public JsonResult UpdateHotelTariffTaxFormula(HotelTariffTaxUpdationViewModel htuViewModel)
        {
            List<HotelTariffChargesDetailsInfo> charges = new List<HotelTariffChargesDetailsInfo>();

            try
            {
                decimal? totalTax = 0;

                decimal? netRatePerNight = 0;

                foreach (var item in htuViewModel.HotelTariffPrices)
                {
                    Set_Date_Session(item);

                    //_htRepo.DeletHotelTariffCharges(item.HotelTariffPriceDetailsId);

                    foreach (var item1 in htuViewModel.HotelTariffPrice.HotelTariffCharges)
                    {
                        HotelTariffChargesDetailsInfo charge = new HotelTariffChargesDetailsInfo();

                        string[] calonstr = item1.HotelTariffCalOn.Split(',');

                        decimal? amount = 0;

                        decimal? chargeTotal = 0;

                        //decimal? calculatedPrice = 0;

                        for (int i = 0; i < calonstr.Length; i++)
                        {
                            if (calonstr[i] == "+" || calonstr[i] == "-")
                            {

                            }
                            else
                            {
                                int chargeId = Convert.ToInt32(calonstr[i]);

                                htuViewModel.Charges = _cRepo.GetChargesById(chargeId);

                                if (htuViewModel.Charges.IsStandardPrice == true)
                                {
                                    if (htuViewModel.Charges.ChargesName == "Publish Price")
                                    {
                                        amount = item.PublishPrice;
                                    }
                                    else if (htuViewModel.Charges.ChargesName == "Commission Price")
                                    {
                                        amount = item.CommissionPrice;
                                    }
                                    else if (htuViewModel.Charges.ChargesName == "Special price")
                                    {
                                        amount = item.SpecialPrice;
                                    }
                                }
                                else
                                {
                                    amount = charges.Where(a => a.ChargesId == chargeId).Select(a => a.CalculatedPrice).FirstOrDefault();
                                }
                                if (calonstr.Length == (i + 1))
                                {
                                    if (i == 0)
                                    {
                                        chargeTotal = amount;
                                    }
                                    else
                                    {
                                        if (calonstr[i - 1] == "+")
                                        {
                                            chargeTotal = chargeTotal + amount;
                                        }
                                        else if (calonstr[i - 1] == "-")
                                        {
                                            chargeTotal = chargeTotal - amount;
                                        }
                                    }
                                }

                                else
                                {
                                    if (i == 0)
                                    {
                                        chargeTotal = amount;
                                    }
                                    else
                                    {
                                        if (calonstr[i - 1] == "+")
                                        {
                                            chargeTotal = chargeTotal + amount;
                                        }
                                        else if (calonstr[i - 1] == "-")
                                        {
                                            chargeTotal = chargeTotal - amount;
                                        }
                                    }
                                }

                            }
                        }

                        decimal calculatedAmt = Convert.ToDecimal(chargeTotal * (item1.Percentage / 100));

                        totalTax = totalTax + calculatedAmt;

                        charge.ChargesId = item1.ChargesId;

                        item1.CalculatedPrice = calculatedAmt;

                        item1.HotelTariffPriceDetailsId = item.HotelTariffPriceDetailsId;

                        charge.CalculatedPrice = calculatedAmt;

                        charges.Add(charge);
                    }

                    item.TotalTaxPrice = Convert.ToDecimal(totalTax);

                    item.NetRate = item.SpecialPrice + item.TotalTaxPrice;

                    netRatePerNight = item.NetRate / item.NoOfNight;

                    item.NetRatePerNight = Convert.ToDecimal(netRatePerNight);

                    _htuRepo.DeletHotelTariffCharges(htuViewModel.HotelTariffPrice);

                    _htuRepo.InsertPriceChargesDetails(htuViewModel.HotelTariffPrice);
  
                }

                _htuRepo.UpdateHotelTariffPriceDetails(htuViewModel.HotelTariffPrices, htuViewModel.HotelTariffPrice, htuViewModel.HotelTariffTax);

                _htuRepo.InsertHotelTariffDateDetails(htuViewModel.HotelTariffPrices);

                htuViewModel.FriendlyMessage.Add(MessageStore.Get("HTTU01"));

                Logger.Debug("HotelTariffTTaxUpdation Controller UpdateHotelTariffTaxFormula");
            }
            catch (Exception ex)
            {
                htuViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelTariffTTaxUpdation Controller - UpdateHotelTariffTaxFormula" + ex.ToString());
            }

            return Json(htuViewModel);
        }

    }
}
