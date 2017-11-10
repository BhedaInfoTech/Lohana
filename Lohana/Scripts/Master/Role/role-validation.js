$(document).ready(function () {

    $("#frmRole").validate({

        rules: {

            "Role.RoleName":
             {
                 required: true,
                 CheckRoleNameExist: true
             }

        },
        messages: {

            "Role.RoleName":
                {
                    required: "Role name is required."
                }
        }

    });

    jQuery.validator.addMethod("CheckRoleNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/Role/CheckRoleNameExist', { RoleName: value }, $("#txtRoleName"), $("#hdnRoleName"));

    }, "Role name already exist.")

});