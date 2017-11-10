using LohanaBusinessEntities.Charges;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.TaxFormula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lohana.Models.TaxFormulaCalDemo
{
    public class TaxFormulaCalDemoViewModel
    {
        public TaxFormulaCalDemoViewModel()
        {
            LstStandardCharges = new List<ChargesInfo>();
            
            LstTaxFormula = new List<TaxFormulaInfo>();

            LstTaxFormulaCharges = new List<TaxFormulaChargesInfo>();

            FriendlyMessage = new List<FriendlyMessage>();
        }

        public List<ChargesInfo> LstStandardCharges { get; set; }

        public List<TaxFormulaInfo> LstTaxFormula { get; set; }

        public List<TaxFormulaChargesInfo> LstTaxFormulaCharges { get; set; }       

        public List<FriendlyMessage> FriendlyMessage { get; set; } 
    }
}