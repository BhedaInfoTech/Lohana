using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.Charges
{
    public class ChargesInfo
    {
        public ChargesInfo()
        {
        }

        public int ChargesId { get; set; }

        public string ChargesName { get; set; }

        public string Abbreviation { get; set; }

        public int ChargesBehaviour { get; set; }

        public bool IsStandardPrice { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

    }
}
