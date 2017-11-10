using LohanaBusinessEntities.RoomType;
using LohanaBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using LohanaBusinessEntities;
using LohanaRepo.Utilities;
using LohanaBusinessLogic.Utilities;
using LohanaHelper.Logging;

namespace LohanaRepo.Master
{
    public class RoomTypeRepo
    {

        SQLHelperRepo _sqlHelper = null;

        public RoomTypeRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        public int Insert(RoomTypeInfo roomtype)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInRoomType(roomtype), Storeprocedures.spInsertRoomType.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInRoomType(RoomTypeInfo roomtype)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (roomtype.RoomTypeId != 0)
            {
                sqlParam.Add(new SqlParameter("RoomTypeId", roomtype.RoomTypeId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", roomtype.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", roomtype.CreatedBy));
            }
            sqlParam.Add(new SqlParameter("RoomTypeName", roomtype.RoomTypeName));

            Logger.Debug("RoomType Controller RoomTypeName:" + roomtype.RoomTypeName);

            sqlParam.Add(new SqlParameter("@IsActive", roomtype.IsActive));

            Logger.Debug("RoomType Controller IsActive:" + roomtype.IsActive);

            sqlParam.Add(new SqlParameter("UpdatedBy", roomtype.UpdatedBy));

            sqlParam.Add(new SqlParameter("UpdatedDate", roomtype.UpdatedDate));

            return sqlParam;
        }

        public DataTable GetRoomTypes(string roomtypeName,ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@RoomTypeName", roomtypeName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetRoomTypes.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);

        }

        public void Update(RoomTypeInfo roomtype)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInRoomType(roomtype), Storeprocedures.spUpdateRoomType.ToString(), CommandType.StoredProcedure);
        }

        public bool CheckRoomTypeNameExist(string roomtypeName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@RoomTypeName", roomtypeName));

            Logger.Debug("RoomType Controller RoomTypeName" +roomtypeName);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckRoomTypeNameExist.ToString(), CommandType.StoredProcedure));

        }

    }
}
