$(document).ready(function () {
     
    $('.datepicker-autoclose').datepicker({
        autoclose: true,
        todayHighlight: true
    });

    $("#btnSaveTask").click(function () {

        if($("#frmTaskEdit").valid())
        {
            SaveTask();
        }

    });

});