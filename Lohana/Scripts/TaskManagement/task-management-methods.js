function SaveTask() {

    $("#frmTaskEdit").attr("action", "/TaskManagement/UpdateTask/");

    $('#frmTaskEdit').attr("method", "POST");

    $('#frmTaskEdit').submit();

}


function GetTasks() {

    var tViewModel =
		{
		    Task: {

		        CustomerName: $("[name='Task.CustomerName']").val(),

		    },
		    Pager: {


		    },
		}

   // PostAjaxJson("/TaskManagement/GetTasks", tViewModel, function (data) { $("#divTaskListDetails").html(data); });
}