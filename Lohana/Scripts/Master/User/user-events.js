$(document).ready(function () {
 
    $("#btnSaveUser").click(function ()
    {
        if ($("#frmUser").valid())
        {

            SaveUser();
        }

    });

});