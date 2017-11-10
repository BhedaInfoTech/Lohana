using LohanaBusinessEntities;
using LohanaBusinessEntities.Accessories;
using LohanaBusinessEntities.Common;
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



namespace LohanaRepo.Accessories
{
   public class AccessoriesRepo
    {
       
       SQLHelperRepo _sqlHelper = null;

       public AccessoriesRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }
       
       public int Insert(AccessoriesInfo accessories)
       {
           return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInAccessories(accessories), Storeprocedures.spInsertAttachment.ToString(), CommandType.StoredProcedure));
       }

       public List<SqlParameter> SetValuesInAccessories(AccessoriesInfo accessories)
       {      
                         
           List<SqlParameter> sqlParam = new List<SqlParameter>();          

           if (accessories.AttachmentId != 0)
           {
               sqlParam.Add(new SqlParameter("AttachmentId", accessories.AttachmentId));
           }
           else
           {
               sqlParam.Add(new SqlParameter("CreatedDate", accessories.CreatedDate));

               sqlParam.Add(new SqlParameter("CreatedBy", accessories.CreatedBy));
           }

           sqlParam.Add(new SqlParameter("RefId",accessories.RefId));

           Logger.Debug("Accessories Controller RefId:" + accessories.RefId);

           sqlParam.Add(new SqlParameter("AttachmentName", accessories.AttachmentName));

           Logger.Debug("Accessories Controller AttachmentName:" + accessories.AttachmentName);

           sqlParam.Add(new SqlParameter("UniqueAttachmentId", accessories.UniqueAttachmentId.Replace("/Upload/",string.Empty)));

           if (accessories.RefTypeName == "Hotel")
           {
               sqlParam.Add(new SqlParameter("@RefType", Attachment.Hotel));
           }
           if (accessories.RefTypeName == "User")
           {
               sqlParam.Add(new SqlParameter("@RefType", Attachment.User));
           }
           if (accessories.RefTypeName == "SightSeeing")
           {
               sqlParam.Add(new SqlParameter("@RefType", Attachment.SightSeeing));
           }
           if (accessories.RefTypeName == "Package")
           {
               sqlParam.Add(new SqlParameter("@RefType", Attachment.Package));
           }

           sqlParam.Add(new SqlParameter("RefCategory", accessories.RefCategory));

           Logger.Debug("Accessories Controller RefCategory:" + accessories.RefCategory);

           sqlParam.Add(new SqlParameter("UpdatedBy", accessories.UpdatedBy));

           sqlParam.Add(new SqlParameter("UpdatedDate", accessories.UpdatedDate));

           
           return sqlParam;
       }

       public List<AccessoriesInfo> GetImages(int attachmentid,int refid, int reftype,string refcategory)
       {
           List<AccessoriesInfo> Images = new List<AccessoriesInfo>();

           List<SqlParameter> sqlParam = new List<SqlParameter>();

           sqlParam.Add(new SqlParameter("@AttachmentId", attachmentid));

           sqlParam.Add(new SqlParameter("@RefId", refid));

           sqlParam.Add(new SqlParameter("@RefType", reftype));

           sqlParam.Add(new SqlParameter("@RefCategory", refcategory));

           DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetImages.ToString(), CommandType.StoredProcedure);

           List<DataRow> drList = new List<DataRow>();

           drList = dt.AsEnumerable().ToList();

           foreach (DataRow dr in drList)
           {
               Images.Add(GetImagesValues(dr));
           }

           return Images;

       }

       private AccessoriesInfo GetImagesValues(DataRow dr)
       {

           AccessoriesInfo Accessories = new AccessoriesInfo();

           Accessories.AttachmentId = Convert.ToInt32(dr["AttachmentId"]);

           if (!dr.IsNull("RefId"))
               Accessories.RefId = Convert.ToInt32(dr["RefId"]);
           
           if (!dr.IsNull("RefType"))
               Accessories.RefType = Convert.ToInt32(dr["RefType"]);

           if (!dr.IsNull("RefCategory"))
               Accessories.RefCategory = Convert.ToString(dr["RefCategory"]);

           if (!dr.IsNull("AttachmentName"))
               Accessories.AttachmentName = Convert.ToString(dr["AttachmentName"]);

           if (!dr.IsNull("UniqueAttachmentId"))
               Accessories.UniqueAttachmentId = Convert.ToString(dr["UniqueAttachmentId"]);

           return Accessories;

       }

       public List<AccessoriesInfo> GetImagesByRefType( int refid, int reftype)
       {
           List<AccessoriesInfo> Images = new List<AccessoriesInfo>();

           List<SqlParameter> sqlParam = new List<SqlParameter>();
          
           sqlParam.Add(new SqlParameter("@RefId", refid));

           Logger.Debug("Accessories Controller RefId:" + refid);

           sqlParam.Add(new SqlParameter("@RefType", reftype));

           Logger.Debug("Accessories Controller RefType:" + reftype);

           DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetImagesByRefType.ToString(), CommandType.StoredProcedure);

           List<DataRow> drList = new List<DataRow>();

           drList = dt.AsEnumerable().ToList();

           foreach (DataRow dr in drList)
           {
               Images.Add(GetImagesValues(dr));
           }

           return Images;

       }

       public int DeleteAttachment(int refid, int reftype, string uniqueAttachmentId)
       {
           int effectedRows = 0;
           
           List<AccessoriesInfo> Images = new List<AccessoriesInfo>();

           List<SqlParameter> sqlParam = new List<SqlParameter>();

           sqlParam.Add(new SqlParameter("@RefId", refid));

           Logger.Debug("Accessories Controller RefId:" + refid);

           sqlParam.Add(new SqlParameter("@RefType", reftype));

           Logger.Debug("Accessories Controller RefTye:" + reftype);

           sqlParam.Add(new SqlParameter("@UniqueAttachmentId", uniqueAttachmentId));

           Logger.Debug("Accessories Controller UniqueAttachmentId:" + uniqueAttachmentId);

           effectedRows = Convert.ToInt32(_sqlHelper.ExecuteScalerObj(sqlParam, Storeprocedures.spDeleteAttachment.ToString(), CommandType.StoredProcedure));

           return effectedRows;
       }
   }
}
