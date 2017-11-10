using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.Vendor
{
    public class VendorInfo
    {
        

        public int VendorId { get; set; }

        //public bool IsCompany { get; set; }

        public int VendorType { get; set; }

        public string CompanyName { get; set; }

        public string VendorName { get; set; }

        public string MobileNo { get; set; }

        public string PhoneNo { get; set; }

        public string FaxNo { get; set; }

        public string Address { get; set; }

        public int CityId { get; set; }

        public string PINCode { get; set; }

        public string EmailId { get; set; }

        public string WebsiteURL { get; set; }

       // public int PaymentOption { get; set; }

        public string PaymentOptionId { get; set; }

        public string PaymentOptionName { get; set; }

        public bool IsActive { get; set; }

        public string BusinessId { get; set; }

        public string BusinessType { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

       public ContactPerson ContactPerson { get; set; }

       public Bank Bank { get; set; }

       public List<Bank> Banks { get; set; }

       public List<ContactPerson> ContactPersons { get; set; }

        public VendorInfo()
        {
           ContactPerson = new ContactPerson();

           Bank = new Bank();
        }

    }

    public class ContactPerson
    {       

        public int ContactPersonId { get; set; }

        public string ContactPersonName { get; set; }

        public string MobileNo { get; set; }

        public string PhoneNo { get; set; }

        public string EmailId { get; set; }

        public string FaxNo { get; set; }

        public int DesignationId { get; set; }

        public string DesignationName { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int RefId { get; set; }

        public int RefType {get; set; }

    }

    public class Bank
    {
        public int BankId { get; set; }

        public int VendorId { get; set; }

        public string BankName { get; set; }

        public string BranchName { get; set; }

        public string AccountHolderName { get; set; }

        public string AccountNo { get; set; }

        public string IFSCCode { get; set; }

        public string MICRCode { get; set; }

        public string SWIFTCode { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
