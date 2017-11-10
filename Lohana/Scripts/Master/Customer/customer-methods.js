
function SaveCustomer() {

    if ($("[name='Customer.IsActive']").val() == 1 || $("[name='Customer.IsActive']").val() == "true" || $("[name='Customer.IsActive']").val() == "True") {

        activeFlg = true;
    }
    else {
        activeFlg = false;
    }
    
    $("#frmCustomer").blur();

    var cViewModel = {

        Customer: {

            CustomerId: $("[name='Customer.CustomerId']").val(),    

            FirstName: $("[name='Customer.FirstName']").val(),

            MiddleName: $("[name='Customer.MiddleName']").val(),

            LastName: $("[name='Customer.LastName']").val(),

            DOB:$("[name='Customer.DOB']").val(),

            EmailId: $("[name='Customer.EmailId']").val(),

            PhoneNo: $("[name='Customer.PhoneNo']").val(),

            MobileNo: $("[name='Customer.MobileNo']").val(),

            PanNo: $("[name='Customer.PanNo']").val(),

            AadharCardNo: $("[name='Customer.AadharCardNo']").val(),

            PassportNo: $("[name='Customer.PassportNo']").val(),

            Address: $("[name='Customer.Address']").val(),

            Gender: $("#drpGender").val(),

            CustomerCategoryId: $("#drpCustomerCategoryId").val(),
 
            IsActive: activeFlg,

        }
    }

    var url = "";

    if ($("[name='Customer.CustomerId']").val() == 0) {

        url = "/Customer/Insert"
    }
    else {

        url = "/Customer/Update"
    }

    PostAjaxWithProcessJson(url, cViewModel, AfterSave, $("body"));
}

function AfterSave(data) {

    FriendlyMessage(data);

    //ResetCustomer();

    }

function ResetCustomer() {

    $("[name='Customer.CustomerId']").val("");

    $("[name='Customer.FirstName']").val("");

    $("[name='Customer.MiddleName']").val("");

    $("[name='Customer.LastName']").val("");

    $("#drpGender").val("0");

    $("[name='Customer.DOB']").val("");
    
    $("[name='Customer.EmailId']").val("");

    $("[name='Customer.PhoneNo']").val("");

    $("[name='Customer.MobileNo']").val("");

    $("[name='Customer.PanNo']").val("");

    $("[name='Customer.AadharCardNo']").val("");

    $("[name='Customer.PassportNo']").val("");

    $("[name='Customer.Address']").val("");

    $("#drpCustomerCategoryId").val("0");

    if ($("[name='Customer.IsActive']").val() == 0 || $("[name='Customer.IsActive']").val() == "false") {
        $('.switchery').trigger('click');
    }
}
