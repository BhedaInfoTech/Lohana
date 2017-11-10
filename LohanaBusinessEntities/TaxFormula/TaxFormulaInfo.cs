using LohanaBusinessEntities.HotelTariff;
using LohanaBusinessEntities.SightSeeingTariff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.TaxFormula
{
    public class TaxFormulaInfo
    {

        public List<TaxFormulaChargesInfo> TaxFormulaCharges { get; set; }

        //public List<TaxFormulaCalculatedOnInfo> TaxFormulaCaluclatedOn { get; set; }


        public TaxFormulaInfo()
        {
            TaxFormulaCharges = new List<TaxFormulaChargesInfo>();

            //TaxFormulaCaluclatedOn = new List<TaxFormulaCalculatedOnInfo>();
        }

        public int TaxFormulaId
        {
            get;
            set;
        }

        public string TaxFormulaName
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }

        public DateTime CreatedDate
        {
            get;
            set;
        }

        public int CreatedBy
        {
            get;
            set;
        }

        public DateTime UpdatedDate
        {
            get;
            set;
        }

        public int UpdatedBy
        {
            get;
            set;
        }

        public int TaxFormulaBehaviour { get; set; }

        public int TaxFixPrice { get; set; }

        // Start Drpdown 

        public int ChargesId { get; set; }

        public string ChargesName { get; set; }

        public string Abbreviation { get; set; }

    }


    public class TaxFormulaChargesInfo
    {
        public TaxFormulaChargesInfo()
        {

            TaxFormulaCaluclatedOns = new List<TaxFormulaCalculatedOnInfo>();

            HotelTariffCharge = new HotelTariffChargesDetailsInfo();

            SightSeeingTariffCharge = new SightSeeingTariffChargesInfo();
        }

        public int TaxFormulaChargesId { get; set; }

        public int TaxFormulaId { get; set; }

        public int ChargesId { get; set; }

        public int OldChargesId { get; set; }

        public string ChargesName { get; set; }

        public string ChargeFormula { get; set; }

        public string ChargeFormulaText { get; set; }

        public DateTime CreatedDate
        {
            get;
            set;
        }

        public int CreatedBy
        {
            get;
            set;
        }

        public DateTime UpdatedDate
        {
            get;
            set;
        }

        public int UpdatedBy
        {
            get;
            set;
        }

        public List<TaxFormulaCalculatedOnInfo> TaxFormulaCaluclatedOns { get; set; }

        public HotelTariffChargesDetailsInfo HotelTariffCharge { get; set; }

        public SightSeeingTariffChargesInfo SightSeeingTariffCharge { get; set; }
    }

    public class TaxFormulaCalculatedOnInfo
    {

        public int TaxFormulaChargeId { get; set; }

        public bool IsFixPrice { get; set; }

        public int CalculatedOnId { get; set; }

        public string CalculatedOnName { get; set; }

        public string Behaviour { get; set; }

        public int TaxChargesId { get; set; }

        public string TaxChargesName { get; set; }

        public string ChargesName { get; set; }

        public string BehaviourName { get; set; }

        public string CalOnBehaviour { get; set; }

        public DateTime CreatedDate
        {
            get;
            set;
        }

        public int CreatedBy
        {
            get;
            set;
        }

        public DateTime UpdatedDate
        {
            get;
            set;
        }

        public int UpdatedBy
        {
            get;
            set;
        }

    }

}
