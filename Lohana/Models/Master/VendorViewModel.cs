using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LohanaBusinessEntities;
using LohanaBusinessEntities.City;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Vendor;
using LohanaBusinessEntities.Business;
using LohanaBusinessEntities.Designation;

namespace Lohana.Models.Master
{
    public class VendorViewModel
    {
        public VendorViewModel()
        {
            Vendor = new VendorInfo();

            Vendors = new List<VendorInfo>();

            Cities = new List<CityInfo>();

            Designations = new List<DesignationInfo>();

            Business = new List<BusinessInfo>();

            BusinessList = new List<BusinessInfo>();

            Filter = new VendorFilter();

            ContactFilter = new ContactPersonFilter();

            BankFilter = new BankFilter();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();

            ContactPerson = new ContactPerson();

            ContactPersons = new List<ContactPerson>();

            PaymentOptionList = new List<VendorInfo>();

        }

        public VendorInfo Vendor { get; set; }

        public List<VendorInfo> Vendors { get; set; }

        public List<CityInfo> Cities { get; set; }

        public List<DesignationInfo> Designations { get; set; }

        public List<VendorInfo> PaymentOptionList { get; set; }

        public List<BusinessInfo> BusinessList { get; set; }

        public List<BusinessInfo> Business { get; set; }

        public VendorFilter Filter { get; set; }

        public ContactPerson ContactPerson { get; set; }

        public List<ContactPerson> ContactPersons { get; set; }

        public Bank Bank { get; set; }

        public List<Bank> Banks { get; set; }

        public ContactPersonFilter ContactFilter { get; set; }

        public BankFilter BankFilter { get; set; }

        public PaginationInfo Pager { get; set; }
    
        public List<FriendlyMessage> FriendlyMessage { get; set; }
    
    }

    public class VendorFilter
    {
        public int VendorId { get; set; }
    }

    public class ContactPersonFilter
    {
        public int ContactPersonId { get; set; }     
    }

    public class BankFilter
    {
        public int BankId { get; set; }
    }
}