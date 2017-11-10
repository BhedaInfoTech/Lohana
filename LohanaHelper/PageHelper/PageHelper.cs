using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace LohanaHelper.PageHelper
{
    public static class PageHelper
    {
        public static DataTable Skip_Take_Records(DataTable dt, int currentPage, int pageSize)
        {
            if (currentPage > 1)
            {
                return dt.AsEnumerable().Skip((currentPage - 1) * pageSize).Take(pageSize).CopyToDataTable<DataRow>();
            }
            else
            {
                return dt.AsEnumerable().Take(pageSize).CopyToDataTable<DataRow>();
            }


        }

    }
}
