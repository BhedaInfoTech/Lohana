function SaveRole() {

    if ($("[name='Role.IsActive']").val() == 1 || $("[name='Role.IsActive']").val() == "true") {
        activeFlg = true;
    }
    else {
        activeFlg = false;
    }

    $("#frmRole").blur();

    var rViewModel = {

        Role: {

            RoleId: $("[name='Role.RoleId']").val(),

            RoleName: $("[name='Role.RoleName']").val(),
                     
            IsActive: $("[name='Role.activeFlg']").val(),
                     
            Modules: ModuleAccess(),
        },
          
    }
    
    if ($("[name='Role.RoleId']").val() == 0) {

        url = "/Role/Insert"
    }
    else {
        
        url = "/Role/Update"
    }

    PostAjaxWithProcessJson(url, rViewModel, AfterSave, $("body"));

}

function AfterSave(data) {

    FriendlyMessage(data);

    ResetRole();

    //GetRoles();
}

function ResetRole() {

    $("[name='Roles.RoleId']").val("");

    $("[name='Roles.RoleName']").val("");

    if ($("[name='Roles.IsActive']").val() == 0 || $("[name='Roles.IsActive']").val() == "false") {
        $('.switchery').trigger('click');
    }
}

function ModuleAccess() {
    var functionList = [];
   
    $('.access-function').each(function () {
        
        var Access = false;
        var Create = false;		
        var Edit = false;
        var View = false;
        var Delete= false;
        
        if ($(this).find(".has-access").val() == "true") {
            Access = true;
            
        }
        if ($(this).find(".has-create").val() == "true") {
            Create = true;
        }
        if ($(this).find(".has-edit").val() == "true") {
            Edit = true;
        }
        if ($(this).find(".has-view").val() == "true") {
            View = true;
        }
        if ($(this).find(".has-delete").val() == "true") {
            Delete = true;
        }

        functionList.push({
            ModuleId: $(this).find(".module-id").val(),
           
            HasAccess: Access,
            IsCreate: Create,
            IsEdit: Edit,
            IsView: View,
            IsDelete: Delete,
        });

});

return functionList;
}