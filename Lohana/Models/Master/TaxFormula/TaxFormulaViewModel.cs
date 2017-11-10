using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LohanaBusinessEntities.TaxFormula;
using LohanaBusinessEntities.Charges;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Business;

namespace Lohana.Models.Master
{
    public class TaxFormulaViewModel
    {

        public TaxFormulaViewModel()
        {
            TaxFormula = new TaxFormulaInfo();

            TaxFormulas = new List<TaxFormulaInfo>();

            Filter = new TaxFormulaFilter();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();

            Charges = new List<ChargesInfo>();

            TaxFormulaCharges = new List<TaxFormulaChargesInfo>();
        }

        public TaxFormulaInfo TaxFormula
        {
            get;
            set;
        }

        public List<TaxFormulaInfo> TaxFormulas
        {
            get;
            set;
        }

        public TaxFormulaFilter Filter
        {
            get;
            set;
        }

        public PaginationInfo Pager
        {
            get;
            set;
        }

        public List<FriendlyMessage> FriendlyMessage
        {
            get;
            set;
        }

        public List<ChargesInfo> Charges { get; set; }

        public List<ChargesInfo> DynamicCharges { get; set; }

        public List<TaxFormulaChargesInfo> TaxFormulaCharges { get; set; }

    }

    public class TaxFormulaFilter
    {

        public int TaxFormulaChargesId { get; set; }

        public string TaxFormulaName
        {
            get;
            set;
        }

        public int TaxFormulaId
        {
            get;
            set;
        }
    }
}