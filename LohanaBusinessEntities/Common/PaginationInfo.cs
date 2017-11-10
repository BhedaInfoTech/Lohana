using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.Common
{
    public class PaginationInfo
    {

        public int TotalItems { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int StartPage { get; set; }

        public int EndPage { get; set; }

        public PaginationInfo() 
        {
            //PageSize = 1;
        }

        public PaginationInfo(int totalItems, int? page, int pageSize = 5)
        {
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);

            var currentPage = page != null ? (int)page : 1;

            var startPage = currentPage - 5;

            var endPage = currentPage + 4;

            if (startPage <= 0)
            {
                endPage -= (startPage - 1);

                startPage = 1;
            }

            if (endPage > totalPages)
            {
                endPage = totalPages;

                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

			if(currentPage == 0)
			{
				currentPage = 1;
			}

            TotalItems = totalItems;

            CurrentPage = currentPage;

            PageSize = pageSize;

            TotalPages = totalPages;

            StartPage = startPage;

            EndPage = endPage;

        }
    }

}
