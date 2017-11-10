using LohanaBusinessEntities;
using LohanaBusinessEntities.Business;
using LohanaBusinessEntities.City;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Designation;
using LohanaBusinessEntities.Vendor;
using LohanaBusinessLogic.Utilities;
using LohanaHelper.Logging;
using LohanaRepo.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaRepo.Master
{
    public class VendorRepo
    {
        SQLHelperRepo _sqlHelper = null;

        public VendorRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        //vendor

        public int Insert(VendorInfo vendor)
        {

            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInVendor(vendor), Storeprocedures.spInsertVendor.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInVendor(VendorInfo vendor)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (vendor.VendorId != 0)
            {
                sqlParam.Add(new SqlParameter("VendorId", vendor.VendorId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", vendor.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", vendor.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@VendorType", vendor.VendorType));

            Logger.Debug("Vendor Controller VendorType:" + vendor.VendorType);

            sqlParam.Add(new SqlParameter("@CompanyName", vendor.CompanyName));

            Logger.Debug("Vendor Controller CompanyName:" + vendor.CompanyName);

            sqlParam.Add(new SqlParameter("@VendorName", vendor.VendorName));

            Logger.Debug("Vendor Controller VendorName:" + vendor.VendorName);

            sqlParam.Add(new SqlParameter("@MobileNo", vendor.MobileNo));

            Logger.Debug("Vendor Controller MobileNo:" + vendor.MobileNo);

            sqlParam.Add(new SqlParameter("@PhoneNo", vendor.PhoneNo));

            Logger.Debug("Vendor Controller PhoneNo:" + vendor.PhoneNo);

            sqlParam.Add(new SqlParameter("@FaxNo", vendor.FaxNo));

            Logger.Debug("Vendor Controller FaxNo:" + vendor.FaxNo);

            sqlParam.Add(new SqlParameter("@Address", vendor.Address));

            Logger.Debug("Vendor Controller Address:" + vendor.Address);

            sqlParam.Add(new SqlParameter("@CityId", vendor.CityId));

            Logger.Debug("Vendor Controller CityId:" + vendor.CityId);

            sqlParam.Add(new SqlParameter("@BusinessId", vendor.BusinessId));

            Logger.Debug("Vendor Controller BusinessId:" + vendor.BusinessId);

            sqlParam.Add(new SqlParameter("@PINCode", vendor.PINCode));

            Logger.Debug("Vendor Controller PINCode:" + vendor.PINCode);

            sqlParam.Add(new SqlParameter("@EmailId", vendor.EmailId));

            Logger.Debug("Vendor Controller EmailId:" + vendor.EmailId);

            sqlParam.Add(new SqlParameter("@WebsiteURL", vendor.WebsiteURL));

            Logger.Debug("Vendor Controller WebsiteURL:" + vendor.WebsiteURL);

            sqlParam.Add(new SqlParameter("@PaymentOption", vendor.PaymentOptionId));

            Logger.Debug("Vendor Controller PaymentOption:" + vendor.PaymentOptionId);

            sqlParam.Add(new SqlParameter("@IsActive", vendor.IsActive));

            Logger.Debug("Vendor Controller IsActive:" + vendor.IsActive);

            sqlParam.Add(new SqlParameter("@UpdatedDate", vendor.UpdatedDate));

            sqlParam.Add(new SqlParameter("@UpdatedBy", vendor.UpdatedBy));

            return sqlParam;

        }

        public DataTable GetVendor(string vendorname, string mobileno,ref PaginationInfo pager)
        {
           
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@VendorName", vendorname));
            
            sqlParam.Add(new SqlParameter("@MobileNo", mobileno));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetVendor.ToString(), CommandType.StoredProcedure);          

            return CommonMethods.GetPaginatedTable(dt,ref pager);

        }

        public VendorInfo GetVendorById(int vendorid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            VendorInfo Vendor = new VendorInfo();

            sqlParam.Add(new SqlParameter("@VendorId", vendorid));

            Logger.Debug("Vendor Controller VendorId:" + vendorid);

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetVendorById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Vendor = GetVendorValues(dr);
                }

            }           
            
            return Vendor;
        }

        private VendorInfo GetVendorValues(DataRow dr)
        {

            VendorInfo Vendor = new VendorInfo();

            Vendor.VendorId = Convert.ToInt32(dr["VendorId"]);

            if (!dr.IsNull("VendorType"))
                Vendor.VendorType = Convert.ToInt32(dr["VendorType"]);

            if (!dr.IsNull("VendorName"))
                Vendor.VendorName = Convert.ToString(dr["VendorName"]);

            if (!dr.IsNull("CompanyName"))
                Vendor.CompanyName = Convert.ToString(dr["CompanyName"]);

            if (!dr.IsNull("MobileNo"))
                Vendor.MobileNo = Convert.ToString(dr["MobileNo"]);

            if (!dr.IsNull("Address"))
                Vendor.Address = Convert.ToString(dr["Address"]);

            if (!dr.IsNull("PhoneNo"))
                Vendor.PhoneNo = Convert.ToString(dr["PhoneNo"]);

            if (!dr.IsNull("EmailId"))
                Vendor.EmailId = Convert.ToString(dr["EmailId"]);

            if (!dr.IsNull("FaxNo"))
                Vendor.FaxNo = Convert.ToString(dr["FaxNo"]);

            if (!dr.IsNull("CityId"))
                Vendor.CityId = Convert.ToInt32(dr["CityId"]);

            if (!dr.IsNull("PINCode"))
                Vendor.PINCode = Convert.ToString(dr["PINCode"]);

            if (!dr.IsNull("WebsiteURL"))
                Vendor.WebsiteURL = Convert.ToString(dr["WebsiteURL"]);

            //if (!dr.IsNull("PaymentOption"))
            //    Vendor.PaymentOption = Convert.ToInt32(dr["PaymentOption"]);

            if (!dr.IsNull("PaymentOption"))
                Vendor.PaymentOptionId = Convert.ToString(dr["PaymentOption"]);

            if (!dr.IsNull("IsActive"))
                Vendor.IsActive = Convert.ToBoolean(dr["IsActive"]);

            if (!dr.IsNull("BusinessId"))
                Vendor.BusinessId = Convert.ToString(dr["BusinessId"]);

            return Vendor;

        }

        public void UpdateVendor(VendorInfo vendor)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInVendor(vendor), Storeprocedures.spUpdateVendor.ToString(), CommandType.StoredProcedure);
        }

        public List<CityInfo> drpGetCities()
        {
            List<CityInfo> cities = new List<CityInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetCountryStateCity.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cities.Add(GetCityValues(dr));
                }
            }
            return cities;
        }
       
        public CityInfo GetCityValues(DataRow dr)
        {
            CityInfo retVal = new CityInfo();

            retVal.CityId = Convert.ToInt32(dr["CityId"]);

            retVal.CityName = Convert.ToString(dr["Name"]);

            return retVal;
        }

        public List<DesignationInfo> drpGetDesignations()
        {
            List<DesignationInfo> designations = new List<DesignationInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetDesignation.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    designations.Add(GetDesignationValues(dr));
                }
            }
            return designations;
        }

        public DesignationInfo GetDesignationValues(DataRow dr)
        {
            DesignationInfo retVal = new DesignationInfo();

            retVal.DesignationId = Convert.ToInt32(dr["DesignationId"]);

            retVal.DesignationName = Convert.ToString(dr["DesignationName"]);

            return retVal;
        }

        public List<BusinessInfo> drpGetBusiness()
        {
            List<BusinessInfo> business = new List<BusinessInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetBusiness.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    business.Add(GetBusinessValues(dr));
                }
            }
            return business;
        }

        public BusinessInfo GetBusinessValues(DataRow dr)
        {
            BusinessInfo retVal = new BusinessInfo();

            retVal.BusinessId = Convert.ToString(dr["BusinessId"]);

            retVal.BusinessName = Convert.ToString(dr["BusinessName"]);

            return retVal;
        }


        //contact person

        public int InsertContactPerson(ContactPerson contactperson)
        {

            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInContactPerson(contactperson), Storeprocedures.spInsertContactPerson.ToString(), CommandType.StoredProcedure));

        }

        public List<SqlParameter> SetValuesInContactPerson(ContactPerson contactperson)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            VendorInfo vendor = new VendorInfo();

            if (contactperson.ContactPersonId != 0)
            {
                sqlParam.Add(new SqlParameter("ContactPersonId", contactperson.ContactPersonId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", contactperson.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", contactperson.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@ContactPersonName", contactperson.ContactPersonName));

            Logger.Debug("Vendor Controller ContactPersonName:" + contactperson.ContactPersonName);

            sqlParam.Add(new SqlParameter("@MobileNo", contactperson.MobileNo));

            Logger.Debug("Vendor Controller MobileNo:" + contactperson.MobileNo);

            sqlParam.Add(new SqlParameter("@PhoneNo", contactperson.PhoneNo));

            Logger.Debug("Vendor Controller PhoneNo:" + contactperson.PhoneNo);

            sqlParam.Add(new SqlParameter("@EmailId", contactperson.EmailId));

            Logger.Debug("Vendor Controller EmailId:" + contactperson.EmailId);

            sqlParam.Add(new SqlParameter("@FaxNo", contactperson.FaxNo));

            Logger.Debug("Vendor Controller FaxNo:" + contactperson.FaxNo);

            sqlParam.Add(new SqlParameter("@DesignationId", contactperson.DesignationId));

            Logger.Debug("Vendor Controller DesignationId:" + contactperson.DesignationId);

            sqlParam.Add(new SqlParameter("@UpdatedBy", contactperson.UpdatedBy));

            sqlParam.Add(new SqlParameter("@UpdatedDate", contactperson.UpdatedDate));

            sqlParam.Add(new SqlParameter("@RefType", ContactType.Vendor));

            Logger.Debug("Vendor Controller RefType:" + ContactType.Vendor);

            sqlParam.Add(new SqlParameter("@RefId", contactperson.RefId));

            Logger.Debug("Vendor Controller RefId:" + contactperson.RefId);

            return sqlParam;
        }

        public DataTable GetContactPerson(int refid, int reftype,ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@RefId", refid));

            sqlParam.Add(new SqlParameter("@RefType", reftype));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetContactPerson.ToString(), CommandType.StoredProcedure);          

            return CommonMethods.GetPaginatedTable(dt,ref pager);

        }

        private ContactPerson GetContactPersonValues(DataRow dr)
        {

            ContactPerson ContactPerson = new ContactPerson();

            ContactPerson.ContactPersonId = Convert.ToInt32(dr["ContactPersonId"]);

            ContactPerson.RefId = Convert.ToInt32(dr["RefId"]);

            ContactPerson.RefType = Convert.ToInt32(dr["RefType"]);

            if (!dr.IsNull("ContactPersonName"))
                ContactPerson.ContactPersonName = Convert.ToString(dr["ContactPersonName"]);

            if (!dr.IsNull("MobileNo"))
                ContactPerson.MobileNo = Convert.ToString(dr["MobileNo"]);

            if (!dr.IsNull("PhoneNo"))
                ContactPerson.PhoneNo = Convert.ToString(dr["PhoneNo"]);

            if (!dr.IsNull("EmailId"))
                ContactPerson.EmailId = Convert.ToString(dr["EmailId"]);

            if (!dr.IsNull("FaxNo"))
                ContactPerson.FaxNo = Convert.ToString(dr["FaxNo"]);

            if (!dr.IsNull("DesignationId"))
                ContactPerson.DesignationId = Convert.ToInt32(dr["DesignationId"]);


            return ContactPerson;

        }

        public ContactPerson GetContactPersonById(int contactpersonid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            ContactPerson ContactPerson = new ContactPerson();

            sqlParam.Add(new SqlParameter("@ContactPersonId", contactpersonid));

            Logger.Debug("Vendor Controller ContactPersonId: " + contactpersonid);

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetContactPersonById.ToString(), CommandType.StoredProcedure);


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ContactPerson = GetContactPersonValues(dr);
                }
            }
            return ContactPerson;
        }

        public void UpdateContactPerson(ContactPerson contactperson)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInContactPerson(contactperson), Storeprocedures.spUpdateContactPerson.ToString(), CommandType.StoredProcedure);
        }

        public void DeleteContactPerson(int contactpersonid, int refid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            ContactPerson ContactPerson = new ContactPerson();

            sqlParam.Add(new SqlParameter("ContactPersonId", contactpersonid));

            Logger.Debug("Vendor Controller ContactPersonId: " + contactpersonid);

            sqlParam.Add(new SqlParameter("RefId", refid));

            Logger.Debug("Vendor Controller RefId: " + refid);

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteContactPerson.ToString(), CommandType.StoredProcedure);


        }

        //Vendor bank

        public int InsertVendorBank(Bank bank)
        {

            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInVendorBank(bank), Storeprocedures.spInsertVendorBank.ToString(), CommandType.StoredProcedure));

        }

        public List<SqlParameter> SetValuesInVendorBank(Bank bank)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            VendorInfo vendor = new VendorInfo();

            if (bank.BankId != 0)
            {
                sqlParam.Add(new SqlParameter("BankId", bank.BankId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", bank.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", bank.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@BankName", bank.BankName));

            Logger.Debug("Vendor Controller BankName:" + bank.BankName);

            sqlParam.Add(new SqlParameter("@VendorId", bank.VendorId));

            Logger.Debug("Vendor Controller VendorId:" + bank.VendorId);

            sqlParam.Add(new SqlParameter("@BranchName", bank.BranchName));

            Logger.Debug("Vendor Controller BranchName:" + bank.BranchName);

            sqlParam.Add(new SqlParameter("@AccountNo", bank.AccountNo));

            Logger.Debug("Vendor Controller AccountNo:" + bank.AccountNo);

            sqlParam.Add(new SqlParameter("@AccountHolderName", bank.AccountHolderName));

            Logger.Debug("Vendor Controller AccountHolderName:" + bank.AccountHolderName);

            sqlParam.Add(new SqlParameter("@IFSCCode", bank.IFSCCode));

            Logger.Debug("Vendor Controller IFSCCode:" + bank.IFSCCode);

            sqlParam.Add(new SqlParameter("@MICRCode", bank.MICRCode));

            Logger.Debug("Vendor Controller MICRCode:" + bank.MICRCode);

            sqlParam.Add(new SqlParameter("@SWIFTCode", bank.SWIFTCode));

            Logger.Debug("Vendor Controller SWIFTCode:" + bank.SWIFTCode);

            sqlParam.Add(new SqlParameter("@UpdatedBy", bank.UpdatedBy));

            sqlParam.Add(new SqlParameter("@UpdatedDate", bank.UpdatedDate));           

            return sqlParam;
        }

        public DataTable GetVendorBank(int vendorid,ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@VendorId", vendorid));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetVendorBank.ToString(), CommandType.StoredProcedure);

            List<DataRow> drList = new List<DataRow>();

            return CommonMethods.GetPaginatedTable(dt, ref pager);


        }

        private Bank GetVendorBankValues(DataRow dr)
        {

            Bank Bank = new Bank();

            Bank.BankId = Convert.ToInt32(dr["BankId"]);

            Bank.VendorId = Convert.ToInt32(dr["VendorId"]);

            if (!dr.IsNull("BankName"))
                Bank.BankName = Convert.ToString(dr["BankName"]);

            if (!dr.IsNull("BranchName"))
                Bank.BranchName = Convert.ToString(dr["BranchName"]);

            if (!dr.IsNull("AccountNo"))
                Bank.AccountNo = Convert.ToString(dr["AccountNo"]);

            if (!dr.IsNull("AccountHolderName"))
                Bank.AccountHolderName = Convert.ToString(dr["AccountHolderName"]);

            if (!dr.IsNull("IFSCCode"))
                Bank.IFSCCode = Convert.ToString(dr["IFSCCode"]);

            if (!dr.IsNull("MICRCode"))
                Bank.MICRCode = Convert.ToString(dr["MICRCode"]);

            if (!dr.IsNull("SWIFTCode"))
                Bank.SWIFTCode = Convert.ToString(dr["SWIFTCode"]);

            
            return Bank;

        }

        public Bank GetVendorBankById(int bankid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            Bank Bank = new Bank();

            sqlParam.Add(new SqlParameter("@BankId", bankid));

            Logger.Debug("Vendor Controller BankId:" + bankid);

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetVendorBankById.ToString(), CommandType.StoredProcedure);


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Bank = GetVendorBankValues(dr);
                }
            }
            return Bank;
        }

        public void UpdateVendorBank(Bank bank)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInVendorBank(bank), Storeprocedures.spUpdateVendorbank.ToString(), CommandType.StoredProcedure);
        }  

        public void DeleteVendorBank(int bankid, int vendorid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("BankId", bankid));

            Logger.Debug("Vendor Controller BankId:" + bankid);

            sqlParam.Add(new SqlParameter("VendorId", vendorid));

            Logger.Debug("Vendor Controller VendorId:" + vendorid);

            _sqlHelper.ExecuteNonQuery(sqlParam, Storeprocedures.spDeleteVendorBank.ToString(), CommandType.StoredProcedure);          

        }


        //

        public bool CheckVendorNameExist(string vendorName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@VendorName", vendorName));

            Logger.Debug("Vendor Controller VendorName:" + vendorName);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckVendorNameExist.ToString(), CommandType.StoredProcedure));

        }

        public bool CheckEmailIdExist(string emailid)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@EmailId", emailid));

            Logger.Debug("Vendor Controller EmailId:" + emailid);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckVendorEmailIdExist.ToString(), CommandType.StoredProcedure));

        }
    }
}
