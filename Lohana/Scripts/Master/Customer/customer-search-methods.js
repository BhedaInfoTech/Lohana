function GetCustomer() {
   
    var cViewModel =
		{
		    Customer: {                  

		        FirstName: $("[name='Customer.FirstName']").val(),

		        MiddleName: $("[name='Customer.MiddleName']").val(),

		        LastName: $("[name='Customer.LastName']").val(),

		        MobileNo: $("[name='Customer.MobileNo']").val(),
                		      

		    },
		    Pager: {

		        CurrentPage: $('#tblCustomer').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/Customer/GetCustomer", cViewModel, BindCustomers);
}

function BindCustomers(data) {
    
    var list = JSON.parse(data);
    
    var kTable = {
        dataList: ["CustomerName", "MobileNo", "Address", "EmailId"],
        primayKey: "CustomerId",
        hiddenFields: ["CustomerId", "CustomerName"],
        headerNames: ["Customer Name", "MobileNo", "Address", "Email Id"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblCustomer'));

    BindPagination(list.Pager, $('#tblCustomer'));


}

function Pagination(CurrentPage)
{

    $('#tblCustomer').attr("data-current-page", CurrentPage);

    GetCustomer();

    document.getElementById("btnEditCustomer").disabled = true;

}

