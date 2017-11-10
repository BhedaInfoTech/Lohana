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
    public class TaxFormulaChargesCalOnModel
    {
        public TaxFormulaChargesCalOnModel()
        {
            Charges = new List<ChargesInfo>();
        }

        public List<ChargesInfo> Charges { get; set; }
    }
}