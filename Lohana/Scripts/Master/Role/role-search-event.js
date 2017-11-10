$(document).ready(function () {
    
    GetRoles();

    $('.switchery').trigger('click');

    document.getElementById("btnEditRole").disabled = true;
    
    $(document).on('change', "[name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetRoleValues($(this));

            document.getElementById("btnEditRole").disabled = false;

        }
    
    });


    $("#btnSearchRole").click(function ()
    {
        GetRoles();
    });
   

    $("#btnEditRole").click(function () {
       
        $("#frmSearchRole").attr("action", "/Role/GetRoleById");

        $("#frmSearchRole").submit();
        
    });


    $("#btnResetRole").click(function () {
        
        document.getElementById("frmSearchRole").reset();

        $("#hdnSearchRoleId").val("");
    });


});
