function BindPagination(Pager, tblObj, method) {

    if (method == "" || method == undefined)
    {
        method = "Pagination";
    }
 

    var html = "";

    //Remove the pagination which gets binded again and again..

    // $('nav.nav').remove();

    if ($(tblObj).next().hasClass("nav")) {
        $(tblObj).next().remove();
    }

    $(tblObj).attr("data-current-page", Pager.CurrentPage);

    // $('ul.pagination-sm m-a-0').remove();

    if (Pager.EndPage > 1)
    {
    	html += "<nav class='nav'>";

    	html += "<ul class='pagination-sm m-a-0'>";

    	if (Pager.CurrentPage > 1)
    	{
                
    		var currentPage = Pager.CurrentPage - 1;

    		html += "<li class='page-item'>";
    		html += "<a class='page-link' href='#' onclick='" + method + "(1)'>First</a>";
    		html += "</li>";
    		html += "<li class='page-item'>";
    		html += " <a class='page-link' href='#'  onclick='" + method + "(" + currentPage + ")'>Pre</a>";
    		html += "</li>";
    	}

    	for (var page = Pager.StartPage; page <= Pager.EndPage; page++)
    	{

    		html += "<li class='page-item" + (page == Pager.CurrentPage ? " active" : "") + "'>";
    		html += "<a class='page-link' href= '#' onclick='" + method + "(" + page + ")'>" + page + "</a>";
    		html += "</li>";
    	}

    	if (Pager.CurrentPage < Pager.TotalPages)
    	{

    		var currentPage = Pager.CurrentPage + 1;

    		html += "<li class='page-item'>";
    		html += "<a  class='page-link'  href= '#' onclick='" + method + "(" + currentPage + ")'>Nxt</a>";
    		html += "</li>";
    		html += "<li class='page-item'>";
    		html += "<a class='page-link' href= '#' onclick='" + method + "(" + Pager.TotalPages + ")'>Lst</a>";
    		html += "</li>";
    	}

    	html += "</ul>";

    	html += "</nav>";

    	// Binding of Pagination after Table Gets Binded.
  

    	$(tblObj).after(html);

    	
    }

}




