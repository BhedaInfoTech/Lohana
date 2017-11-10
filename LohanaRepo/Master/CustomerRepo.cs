using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Customer;
using LohanaBusinessEntities.CustomerCategory;
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
    public class CustomerRepo
    {
        SQLHelperRepo _sqlHelper = null;

        public CustomerRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        public int Insert(CustomerInfo customer)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInCustomer(customer), Storeprocedures.spInsertCustomer.ToString(), CommandType.StoredProcedure));            
        }

        public List<SqlParameter> SetValuesInCustomer(CustomerInfo customer)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (customer.CustomerId != 0)
            {
                sqlParam.Add(new SqlParameter("CustomerId", customer.CustomerId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", customer.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", customer.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@FirstName", customer.FirstName));

            Logger.Debug("Customer Controller FirstName:" + customer.FirstName);

            sqlParam.Add(new SqlParameter("@MiddleName", customer.MiddleName));

            Logger.Debug("Customer Controller MiddleName:" +customer.MiddleName);

            sqlParam.Add(new SqlParameter("@LastName", customer.LastName));

            Logger.Debug("Customer Controller LastName:" + customer.LastName);

            sqlParam.Add(new SqlParameter("@IsActive", customer.IsActive));

            Logger.Debug("Customer Controller IsActive:" + customer.IsActive);

            sqlParam.Add(new SqlParameter("@DOB", customer.DOB));

            Logger.Debug("Customer Controller DOB:" + customer.DOB);

            sqlParam.Add(new SqlParameter("@EmailId", customer.EmailId));
           
            Logger.Debug("Customer Controller EmailId:" + customer.EmailId);

            sqlParam.Add(new SqlParameter("@PhoneNo", customer.PhoneNo));

            Logger.Debug("Customer Controller PhoneNo:" + customer.PhoneNo);

            sqlParam.Add(new SqlParameter("@MobileNo", customer.MobileNo));

            Logger.Debug("Customer Controller MobileNo:" + customer.MobileNo);

            sqlParam.Add(new SqlParameter("@PanNo", customer.PanNo));

            Logger.Debug("Customer Controller PanNo:" + customer.PanNo);

            sqlParam.Add(new SqlParameter("@AadharCardNo", customer.AadharCardNo));

            Logger.Debug("Customer Controller AadharCardNo:" + customer.AadharCardNo);

            sqlParam.Add(new SqlParameter("@PassportNo", customer.PassportNo));

            Logger.Debug("Customer Controller PassportNo:" + customer.PassportNo);

            sqlParam.Add(new SqlParameter("@Address", customer.Address));

            Logger.Debug("Customer Controller Address:" + customer.Address);

            sqlParam.Add(new SqlParameter("@CustomerCategoryId", customer.CustomerCategoryId));

            Logger.Debug("Customer Controller CustomerCategoryId:" + customer.CustomerCategoryId);

            sqlParam.Add(new SqlParameter("@UpdatedDate", customer.UpdatedDate));

            sqlParam.Add(new SqlParameter("@UpdatedBy", customer.UpdatedBy));

            sqlParam.Add(new SqlParameter("@Gender", customer.Gender));

            Logger.Debug("Customer Controller Gender");

            //StringBuilder body = new StringBuilder();

            //body.Append("<b>Dear Customer,</b>");
            //body.Append("<p>");
            //body.Append("<b>");
            //body.Append("Mr/Mrs/Ms." + customer.FirstName + ",");
            //body.Append("</b>");
            //body.Append("your booking is done. Please check booking detalis in below:");            
            ////body.Append(".You stay in " + "+"); // Hotel Name 
            //body.Append("</p>");
            //body.Append("<p>");
            //body.Append("<div> ");
            //body.Append("<span class='a' style='left:399px;top:302px'>"+ "+</span>");//hotel name
            //body.Append("</div>");
            //body.Append("<div> ");
            //body.Append("<span class='a' style='left:399px;top:473px;word-spacing:11px;letter-spacing:-2px'>Booking ID -"+ "+</span>");//booking id
            //body.Append("</div>");
            //body.Append("<div> ");
            //body.Append("<span class='a' style='left:399px;top:473px;word-spacing:11px;letter-spacing:-2px'>Booking Date -" + "+</span>");//booking date
            //body.Append("</div>");            
            //body.Append("</p>");
            //body.Append("<div class='image_layer' style='z-index: 1'>");
            //body.Append("<div class='ie_fix'>");
            //body.Append("<img class='absimg' style='left: -1px; top: -1px; width: 904px; height: 1173px; clip: rect(1px 903px 1168px 1px); display: block;' src='https://html2-f.scribdassets.com/6xwvuu3k8w4xatrn/images/1-b8ec98ac9a.jpg'>");//add path in src
            //body.Append("</div>");
            //body.Append("</div>");
            //body.Append("<div class='management m-b-1'>");
            //body.Append("<div class='m-item'>");
            //body.Append("<div class='mi-checkbox'>");
            //body.Append("</div>");
            //body.Append("<div class=''>");
            //body.Append("<div class='table-responsive'>");
            //body.Append("<table class='table m-md-b-0' id='tblGitDetails'>");
            //body.Append("<thead class='thead-inverse'>");
            //body.Append("<tr>");
            //body.Append("<th>Category</th> <th>Packagetype</th><th>Package Name</th><th>Duration</th><th>Net Rate</th><th>Quote Rate</th>");
            //body.Append("</tr>");
            //body.Append("<tr>");
            //body.Append("<td><div class=''> <label>Domestic </label> </div> </td>");
            //body.Append("<td><div class=''> <label>Honeymoon </label> </div> </td>");
            //body.Append("<td><div class=''> <label>Mumbai-Pune </label> </div> </td>");
            //body.Append("<td><div class=''> <label>5D/6N </label> </div> </td>");
            //body.Append("<td><div class=''> <label>12000/- </label> </div> </td>");
            //body.Append("<td><div class=''> <label>12000/- </label> </div> </td>");
            //body.Append("</tr>");
            //body.Append("</thead>");
            //body.Append("</table>");
            //body.Append("</div>");
            //body.Append("</div>");                   
         
         
            //CommonMethods.SendMail(customer.EmailId, "", "demo lohana", body.ToString());                      

            return sqlParam;

        }

        public DataTable GetCustomer(string firstname, string middlename, string lastname, string mobileno,ref PaginationInfo pager)
        {
            
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@FirstName", firstname));

            sqlParam.Add(new SqlParameter("@MiddleName", middlename));

            sqlParam.Add(new SqlParameter("@LastName", lastname));

            sqlParam.Add(new SqlParameter("@MobileNo", mobileno));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetCustomer.ToString(), CommandType.StoredProcedure);
                
            return CommonMethods.GetPaginatedTable(dt,ref pager);

        }

        private CustomerInfo GetCustomerValues(DataRow dr)
        {

            CustomerInfo Customer = new CustomerInfo();

            Customer.CustomerId = Convert.ToInt32(dr["CustomerId"]);

            if (!dr.IsNull("FirstName"))
                Customer.FirstName = Convert.ToString(dr["FirstName"]);

            if (!dr.IsNull("MiddleName"))
                Customer.MiddleName = Convert.ToString(dr["MiddleName"]);

            if (!dr.IsNull("LastName"))
                Customer.LastName = Convert.ToString(dr["LastName"]);

            if (!dr.IsNull("IsActive"))
                Customer.IsActive = Convert.ToBoolean(dr["IsActive"]);

            if (!dr.IsNull("DOB"))
                Customer.DOB = Convert.ToDateTime(dr["DOB"]);

            if (!dr.IsNull("EmailId"))
                Customer.EmailId = Convert.ToString(dr["EmailId"]);

            if (!dr.IsNull("PhoneNo"))
                Customer.PhoneNo = Convert.ToString(dr["PhoneNo"]);

            if (!dr.IsNull("MobileNo"))
                Customer.MobileNo = Convert.ToString(dr["MobileNo"]);

            if (!dr.IsNull("PanNo"))
                Customer.PanNo = Convert.ToString(dr["PanNo"]);

            if (!dr.IsNull("AadharCardNo"))
                Customer.AadharCardNo = Convert.ToString(dr["AadharCardNo"]);

            if (!dr.IsNull("PassportNo"))
                Customer.PassportNo = Convert.ToString(dr["PassportNo"]);

            if (!dr.IsNull("Address"))
                Customer.Address = Convert.ToString(dr["Address"]);

            if (!dr.IsNull("Gender"))
                Customer.Gender = Convert.ToInt32(dr["Gender"]);

            if (!dr.IsNull("CustomerCategoryId"))
                Customer.CustomerCategoryId = Convert.ToInt32(dr["CustomerCategoryId"]);
            
            return Customer;

        }

        public CustomerInfo GetCustomerById(int customerid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            CustomerInfo Customer = new CustomerInfo();

            sqlParam.Add(new SqlParameter("@CustomerId", customerid));

            Logger.Debug("Customer Controller CustomerId:" + customerid);

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetCustomerById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Customer = GetCustomerValues(dr);
                }
            }
            return Customer;
        }

        public void UpdateCustomer(CustomerInfo customer)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInCustomer(customer), Storeprocedures.spUpdateCustomer.ToString(), CommandType.StoredProcedure);
        }

        public bool CheckEmailIdExist(string emailid)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@EmailId", emailid));

            Logger.Debug("Customer Controller EmailId:" + emailid);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckCustomerEmailIdExist.ToString(), CommandType.StoredProcedure));

        }

        public List<CustomerCategoryInfo> drpGetCustomerCategory()
        {
            List<CustomerCategoryInfo> customercategory = new List<CustomerCategoryInfo>();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spdrpGetCust_Category.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    customercategory.Add(GetCustomerCategoryValues(dr));
                }
            }

            return customercategory;

        }

        public CustomerCategoryInfo GetCustomerCategoryValues(DataRow dr)
        {
            CustomerCategoryInfo Val = new CustomerCategoryInfo();

            Val.CustomerCategoryId = Convert.ToInt32(dr["CustomerCategoryId"]);

            Val.CustomerCategoryName = Convert.ToString(dr["CustomerCategoryName"]);
            return Val;
        }
    }
}













     
