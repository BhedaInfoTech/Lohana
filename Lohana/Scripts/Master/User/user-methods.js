
function SaveUser() {

    if ($("[name='User.IsActive']").val() == 1 || $("[name='User.IsActive']").val() == "true" || $("[name='User.IsActive']").val() == "True") {

        activeFlg = true;
    }
    else {
        activeFlg = false;
    }

    $("#frmUser").blur();

    var uViewModel = {

        User: {

            UserId: $("[name='User.UserId']").val(),

            FirstName: $("[name='User.FirstName']").val(),

            MiddleName: $("[name='User.MiddleName']").val(),

            LastName: $("[name='User.LastName']").val(),          

            EmailId: $("[name='User.EmailId']").val(),

            UserName: $("[name='User.UserName']").val(),

            Password:$("[name='User.Password']").val(),

            PhoneNo: $("[name='User.PhoneNo']").val(),

            MobileNo: $("[name='User.MobileNo']").val(),

            ResidenceAddress: $("[name='User.ResidenceAddress']").val(),

            PermanentAddress: $("[name='User.PermanentAddress']").val(),

            CityId:$("#drpCity").val(),

            RoleId: $("#drpUserRole").val(),

            Locations: $("#hdnLocation").val(),

            TeamLeadId: $("#drpTeamlead").val(),

            SpecializationType: $("#hdnSpecialization").val(),
          
            IsActive: activeFlg,

        }
    }

    var url = "";

    if ($("[name='User.UserId']").val() == 0) {

        url = "/User/Insert"
    }
    else {

        url = "/User/Update"
    }

    PostAjaxWithProcessJson(url, uViewModel, AfterSave, $("body"));
}

function AfterSave(data) {

    FriendlyMessage(data);

    $("#hdnUserId").val(data.User.UserId);

    $("[name='Accessories.RefId']").val(data.User.UserId);

    $("#divImage").show();

    //ResetUser();
}

function ResetUser() {

    $("[name='User.FirstName']").val(" "),

    $("[name='User.MiddleName']").val(" "),

    $("[name='User.LastName']").val(" "),

    $("[name='User.UserName']").val(" "),

    $("[name='User.Password']").val(" "),

    $("[name='User.EmailId']").val(" "),

    $("[name='User.PhoneNo']").val(" "),

    $("[name='User.MobileNo']").val(" "),

    $("[name='User.ResidenceAddress']").val(" "),

    $("[name='User.PermanentAddress']").val(" "),

    $("#drpCity").val("0"),

    $("#drpUserRole").val("0"),

    $("[name='User.IsActive']").val(false)

    if ($("[name='User.IsActive']").val() == 0 || $("[name='User.IsActive']").val() == "false") {

        $('.switchery').trigger('click');
    }

}