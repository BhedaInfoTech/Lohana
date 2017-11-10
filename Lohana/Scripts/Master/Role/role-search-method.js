function GetRoles() {
    
    var rViewModel =
		{
		    Filter: {
		        
		         RoleName: $("[name='Filter.RoleName']").val(),
                                                                            		                                  
		    },
            
		    Pager:
                {
                    CurrentPage: $('#tblRole').attr("data-current-page"),
                },
		}
    
    PostAjaxJson("/Role/GetRoles", rViewModel, BindRoles, $("#frmSearchRole"));
}

function BindRoles(data) {
    
    var list = JSON.parse(data);

    var kTable = {
        dataList: ["RoleName", "IsActiveStr"],
        primayKey: "RoleId",
        hiddenFields: ["RoleId", "RoleName"],
        headerNames: ["Role Name", "Is Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblRole'));

    BindPagination(list.Pager, $('#tblRole'));
}

function ResetRole() {

    $("[name='Filter.RoleName']").val("");
     
    }

function Pagination(CurrentPage) {

    $('#tblRole').attr("data-current-page", CurrentPage);

    GetRoles();

}   

function GetSetRoleValues(obj) {

    var id = $(obj).attr("data-roleid");

    var roleName = $(obj).attr("data-rolename");

    $("#hdnSearchRoleId").val(id);

    $("[name='Filter.RoleName']").val(roleName);

}