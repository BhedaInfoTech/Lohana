function GetUser() {

    var uViewModel =
		{
		    User: {

		        UserName:$("[name='User.UserName']").val(),

		        RoleId: $("#drpUserRole").val(),		        

		    },
		    Pager: {

		        CurrentPage: $('#tblUser').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/User/GetUser", uViewModel, BindUsers);
}

function BindUsers(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["UserName", "MobileNo", "ResidenceAddress", "EmailId"],
        primayKey: "UserId",
        hiddenFields: ["UserId", "UserName"],
        headerNames: ["User Name", "MobileNo", "Residence Address", "Email Id"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblUser'));

    BindPagination(list.Pager, $('#tblUser'));

   
}

function Pagination(CurrentPage) {

    $('#tblUser').attr("data-current-page", CurrentPage);

    GetUser();

    document.getElementById("btnEditUser").disabled = true;
}