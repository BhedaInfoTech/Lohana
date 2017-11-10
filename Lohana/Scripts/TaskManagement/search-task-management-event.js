$(document).ready(function () {

 //   GetTasks();

    $("#SearchCustomerTask").click(function () {

        $("#frmTaskSearch").attr("action", "/TaskManagement/Index/");

        $('#frmTaskSearch').attr("method", "POST");

        $('#frmTaskSearch').submit();

   //     GetTasks();

    });

});