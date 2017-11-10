$(document).ready(function () {
   
    if ($("[name='Role.IsActive']").val() == 0 || $("[name='Role.IsActive']").val() == "false") {
        $('.switchery').trigger('click');
    }

    else if ($("[name='Role.IsActive']").val() == 1 || $("[name='Role.IsActive']").val() == "true") {
        $('.switchery').trigger('click');
    }

   
    $(document).on('change', ".has-access", function (event) {
        
        if ($(this).prop('checked')) {

            $(this).closest("tr").find(".access").removeAttr("disabled");
            $(this).closest("tr").find(".has-view").prop("checked", true);
            $(this).closest("tr").find(".has-view").val(true);          
        }
        else
        {
            $(this).closest("tr").find(".access").attr("disabled", "disabled");
            $(this).closest("tr").find(".access").prop("checked", false);
            $(this).closest("tr").find(".access").val(false);          
        }
        
    });
   
    
    var html = "";
    
    $('.has-access').each(function (i) {
    
        html += i + " : " + $(this).val() + "\n"
                  + "Create:" + $(this).closest("tr").find(".has-create").val() + "\n"
                  + "Edit:" + $(this).closest("tr").find(".has-edit").val() + "\n"
                  + "View:" + $(this).closest("tr").find(".has-view").val() + "\n"
                  + "Delete:" + $(this).closest("tr").find(".has-delete").val() + "\n";
        
    });
   

    $("#btnSaveRole").click(function () {

        if ($("#frmRole").valid()) {

            SaveRole();
        }

    });


    $("#btnResetRole").click(function () {

        document.getElementById("frmRole").reset();

        $("#hdnRoleId").val("");
    });

 
$(document).on("change", "input[type='checkbox']", function () {
    if ($(this).prop("checked")) {

        $(this).val(true);
    }
    else {

        $(this).val(false);
    }
});
});