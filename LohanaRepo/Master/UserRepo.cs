using LohanaBusinessEntities;
using LohanaBusinessEntities.City;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Enquiry;
using LohanaBusinessEntities.Role;
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
    public class UserRepo
    {
        SQLHelperRepo _sqlHelper = null;

        public UserRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        public int Insert(UserInfo user)
        {

            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInUser(user), Storeprocedures.spInsertUser.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInUser(UserInfo user)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (user.UserId != 0)
            {
                sqlParam.Add(new SqlParameter("UserId", user.UserId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", user.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", user.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("@FirstName", user.FirstName));

            Logger.Debug("User Controller FirstName:" + user.FirstName);

            sqlParam.Add(new SqlParameter("@MiddleName", user.MiddleName));

            Logger.Debug("User Controller MiddleName:" + user.MiddleName);

            sqlParam.Add(new SqlParameter("@LastName", user.LastName));

            Logger.Debug("User Controller LastName:" + user.LastName);

            //sqlParam.Add(new SqlParameter("@CityId", user.CityId));

            //Logger.Debug("User Controller CityId:" + user.CityId);

            sqlParam.Add(new SqlParameter("@MobileNo", user.MobileNo));

            Logger.Debug("User Controller MobileNo:" + user.MobileNo);

            sqlParam.Add(new SqlParameter("@PhoneNo", user.PhoneNo));

            Logger.Debug("User Controller PhoneNo:" + user.PhoneNo);

            sqlParam.Add(new SqlParameter("@EmailId", user.EmailId));

            Logger.Debug("User Controller EmailId:" + user.EmailId);

            sqlParam.Add(new SqlParameter("@PermanentAddress", user.PermanentAddress));

            Logger.Debug("User Controller PermanentAddress:" + user.PermanentAddress);

            sqlParam.Add(new SqlParameter("@ResidenceAddress", user.ResidenceAddress));

            Logger.Debug("User Controller ResidenceAddress:" + user.ResidenceAddress);

            sqlParam.Add(new SqlParameter("@RoleId", user.RoleId));

            Logger.Debug("User Controller RoleId:" + user.RoleId);

            sqlParam.Add(new SqlParameter("@UserName", user.UserName));

            Logger.Debug("User Controller UserName:" + user.UserName);

            sqlParam.Add(new SqlParameter("@Password", user.Password));

            Logger.Debug("User Controller Password:" + user.Password);

            sqlParam.Add(new SqlParameter("@IsActive", user.IsActive));

            Logger.Debug("User Controller IsActive:" + user.IsActive);

            sqlParam.Add(new SqlParameter("@UpdatedBy", user.UpdatedBy));

            sqlParam.Add(new SqlParameter("@UpdatedDate", user.UpdatedDate));

            return sqlParam;

        }

        public DataTable GetUser(string username, int roleid, ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();


            sqlParam.Add(new SqlParameter("@UserName", username));

            sqlParam.Add(new SqlParameter("@RoleId", roleid));


            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetUser.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }

        private UserInfo GetUserValues(DataRow dr)
        {

            UserInfo User = new UserInfo();

            User.UserId = Convert.ToInt32(dr["UserId"]);

            if (!dr.IsNull("FirstName"))
                User.FirstName = Convert.ToString(dr["FirstName"]);

            if (!dr.IsNull("MiddleName"))
                User.MiddleName = Convert.ToString(dr["MiddleName"]);

            if (!dr.IsNull("LastName"))
                User.LastName = Convert.ToString(dr["LastName"]);

            //if (!dr.IsNull("CityId"))
            //    User.CityId = Convert.ToInt32(dr["CityId"]);

            if (!dr.IsNull("RoleId"))
                User.RoleId = Convert.ToInt32(dr["RoleId"]);

            if (!dr.IsNull("PermanentAddress"))
                User.PermanentAddress = Convert.ToString(dr["PermanentAddress"]);

            if (!dr.IsNull("ResidenceAddress"))
                User.ResidenceAddress = Convert.ToString(dr["ResidenceAddress"]);

            if (!dr.IsNull("UserName"))
                User.UserName = Convert.ToString(dr["UserName"]);

            if (!dr.IsNull("Password"))
                User.Password = Convert.ToString(dr["Password"]);

            if (!dr.IsNull("IsActive"))
                User.IsActive = Convert.ToBoolean(dr["IsActive"]);

            if (!dr.IsNull("EmailId"))
                User.EmailId = Convert.ToString(dr["EmailId"]);

            if (!dr.IsNull("PhoneNo"))
                User.PhoneNo = Convert.ToString(dr["PhoneNo"]);

            if (!dr.IsNull("MobileNo"))
                User.MobileNo = Convert.ToString(dr["MobileNo"]);

            if (!dr.IsNull("LocationId"))
                User.Locations = Convert.ToString(dr["LocationId"]);

            if (!dr.IsNull("TeamLeadId"))
                User.Teamleads = Convert.ToString(dr["TeamLeadId"]);

            if (!dr.IsNull("specialID"))
                User.SpecializationType = Convert.ToString(dr["specialID"]);


            

            return User;


        }

        public UserInfo GetUserById(int userid)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            UserInfo User = new UserInfo();

            sqlParam.Add(new SqlParameter("@UserId", userid));

            Logger.Debug("User Controller GetUserId:" + userid);

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetUserById.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    User = GetUserValues(dr);
                }
            }
            return User;
        }

        public void UpdateUser(UserInfo user)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInUser(user), Storeprocedures.spUpdateUser.ToString(), CommandType.StoredProcedure);
        }

        public List<CityInfo> drpGetCountryStateCity()
        {
            List<CityInfo> cities = new List<CityInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spdrpGetCountryStateCity.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cities.Add(GetCountryStateCityValues(dr));
                }
            }
            return cities;
        }

        public List<RoleInfo> drpGetRole()
        {
            List<RoleInfo> role = new List<RoleInfo>();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spdrpGetRole_Id.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    role.Add(GetRoleValues(dr));
                }
            }

            return role;
        }


        public List<SpecializationInfo> GetSpecialization()
        {
            List<SpecializationInfo> SpecializationList = new List<SpecializationInfo>();

            DataTable dt = _sqlHelper.ExecuteDataTable(null, Storeprocedures.spdrpSpecialization.ToString(), CommandType.StoredProcedure);


            foreach (DataRow dr in dt.Rows)
            {
                SpecializationInfo specialization = new SpecializationInfo();

                if (!dr.IsNull("SpecializationId"))
                    specialization.SpecializationId = Convert.ToInt32(dr["SpecializationId"]);

                if (!dr.IsNull("Specializationname"))
                    specialization.Specializationname = Convert.ToString(dr["Specializationname"]);

                SpecializationList.Add(specialization);
            }


            return SpecializationList;
        }


        public RoleInfo GetRoleValues(DataRow dr)
        {
            RoleInfo Val = new RoleInfo();

            Val.RoleId = Convert.ToInt32(dr["RoleId"]);

            Val.RoleName = Convert.ToString(dr["RoleName"]);

            return Val;
        }

        public CityInfo GetCountryStateCityValues(DataRow dr)
        {
            CityInfo retVal = new CityInfo();

            retVal.CityId = Convert.ToInt32(dr["CityId"]);

            retVal.CityName = Convert.ToString(dr["Name"]);

            return retVal;
        }

        public bool CheckUserNameExist(string userid)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@UserId", userid));

            Logger.Debug("User Controller UserId:" + userid);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckUserNameExist.ToString(), CommandType.StoredProcedure));

        }


        public List<UserInfo> GetUsers()
        {
            List<UserInfo> Users = new List<UserInfo>();

            DataTable dt = _sqlHelper.ExecuteDataTable(null, Storeprocedures.spGetUsers.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Users.Add(GetUserValue(dr));
                }
            }

            return Users;
        }

        private UserInfo GetUserValue(DataRow dr)
        {
            UserInfo User = new UserInfo();

            User.UserId = Convert.ToInt32(dr["UserId"]);

            if (!dr.IsNull("FirstName"))
                User.FirstName = Convert.ToString(dr["FirstName"]);

            if (!dr.IsNull("LastName"))
                User.LastName = Convert.ToString(dr["LastName"]);

            return User;
        }


        public void InsertUserLocations(UserInfo user)
        {
            var Location = user.Locations.TrimEnd(',');
            string[] Locations = Location.Split(',');

            List<SqlParameter> sqlParam = new List<SqlParameter>(); 

            sqlParam.Add(new SqlParameter("@UserId", user.UserId));

            _sqlHelper.ExecuteScalerObj(sqlParam, Storeprocedures.spDeleteUserLocations.ToString(), CommandType.StoredProcedure);

            foreach (var itm in Locations)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@UserId", user.UserId));

                sqlParams.Add(new SqlParameter("@LocationId", itm));

                sqlParams.Add(new SqlParameter("@CreatedDate", user.CreatedDate));

                sqlParams.Add(new SqlParameter("@CreatedBy", user.CreatedBy));

                sqlParams.Add(new SqlParameter("@UpdatedBy", user.UpdatedBy));

                sqlParams.Add(new SqlParameter("@UpdatedDate", user.UpdatedDate));

                _sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spInsertUserLocations.ToString(), CommandType.StoredProcedure);
            }
        }

        public void InsertUserTeamLead(UserInfo user)
        {
            //var TeamLeads = user.TeamLeadId.TrimEnd(',');
            //string[] TeamLead = TeamLeads.Split(',');

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@UserId", user.UserId));

            _sqlHelper.ExecuteScalerObj(sqlParam, Storeprocedures.spDeleteUserTeamLead.ToString(), CommandType.StoredProcedure);

            //foreach (var itm in TeamLead)
            //{
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@UserId", user.UserId));

                sqlParams.Add(new SqlParameter("@TeamLeadId", user.TeamLeadId));

                sqlParams.Add(new SqlParameter("@CreatedDate", user.CreatedDate));

                sqlParams.Add(new SqlParameter("@CreatedBy", user.CreatedBy));

                sqlParams.Add(new SqlParameter("@UpdatedBy", user.UpdatedBy));

                sqlParams.Add(new SqlParameter("@UpdatedDate", user.UpdatedDate));

                _sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spInsertUserTeamLead.ToString(), CommandType.StoredProcedure);
            //}
        }



        public void InsertUserSpecialization(UserInfo user)
        {
            var Specialization = user.SpecializationType.TrimEnd(',');
            string[] Specializationes = Specialization.Split(',');

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@UserId", user.UserId));

            _sqlHelper.ExecuteScalerObj(sqlParam, Storeprocedures.spDeleteUserSpecializationes.ToString(), CommandType.StoredProcedure);

            foreach (var itm in Specializationes)
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("@UserId", user.UserId));

                sqlParams.Add(new SqlParameter("@SpecializationId", itm));

                sqlParams.Add(new SqlParameter("@CreatedDate", user.CreatedDate));

                sqlParams.Add(new SqlParameter("@CreatedBy", user.CreatedBy));

                sqlParams.Add(new SqlParameter("@UpdatedBy", user.UpdatedBy));

                sqlParams.Add(new SqlParameter("@UpdatedDate", user.UpdatedDate));

                _sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spInsertUserSpecialization.ToString(), CommandType.StoredProcedure);
            }
        }
         
    }
}
