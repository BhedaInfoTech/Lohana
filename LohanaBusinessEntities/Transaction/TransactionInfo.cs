using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.Transaction
{
   public class TransactionInfo
    {
       public int TransactionType { get;set;}
       public int TransactionId { get; set; }
       public int TransactionUserId { get; set; }
       public int ModeOfPayment {get;set;}

       public DateTime CreatedDate { get; set; }
       public int CreatedBy { get; set; }
       public DateTime UpdatedDate { get; set; }
       public int UpdatedBy { get; set; }

       
    }
}
