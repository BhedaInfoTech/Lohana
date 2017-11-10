using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.Tax
{
    public class TaxInfo
    {
        public TaxInfo()
        {

        }
        
        public int TaxId { get; set; }

        public string TaxName { get; set; }

        public string TaxCode { get; set; }

        public decimal TaxRate { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}
