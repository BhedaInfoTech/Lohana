
function SaveVendor() {

    if ($("[name='Vendor.IsActive']").val() == 1 || $("[name='Vendor.IsActive']").val().toLowerCase() == "true")
    {
        activeFlg = true;
    }
    else
    {
        activeFlg = false;
    }
    
    $("#frmVendor").blur();
    
    var vViewModel = {

        Vendor: {

            VendorId: $("[name='Vendor.VendorId']").val(),
            
            VendorType: $('input[name="Vendor.VendorType"]:checked').val(),

            CompanyName: $("[name='Vendor.CompanyName']").val(),

            VendorName: $("[name='Vendor.VendorName']").val(),

            MobileNo: $("[name='Vendor.MobileNo']").val(),

            PhoneNo: $("[name='Vendor.PhoneNo']").val(),

            FaxNo: $("[name='Vendor.FaxNo']").val(),

            Address: $("[name='Vendor.Address']").val(),

            CityId: $("#drpCity").val(),

            BusinessId: $("#hdnBusinessType").val(),

            PINCode: $("[name='Vendor.PINCode']").val(),

            EmailId: $("[name='Vendor.EmailId']").val(),

            WebsiteURL: $("[name='Vendor.WebsiteURL']").val(),

           // PaymentOption: $("[name='Vendor.PaymentOption']").val(),
            PaymentOptionId: $("#hdnPaymentOption").val(),

            IsActive: activeFlg,

        }
    }


    alert($("#hdnPaymentOption").val());

    var url = "";

    if ($("[name='Vendor.VendorId']").val() == 0) {

        url = "/Vendor/Insert"
    }
    else {     

        url = "/Vendor/UpdateVendor"
    }
    
    PostAjaxWithProcessJson(url, vViewModel, AfterSave, $("body"));
}

function AfterSave(data) {

    FriendlyMessage(data);

    $("[name='ContactPerson.VendorId']").val(data.Vendor.VendorId),

    $("[name='Vendor.Bank.VendorId']").val(data.Vendor.VendorId)
  
    $("#link1").show();

    $("#link2").show();
  
  //  ResetVendor();
}

function ResetVendor() {

    $("[name='Vendor.IsCompany']").val(""),

    $("[name='Vendor.VendorName']").val(""),

    $("[name='Vendor.CompanyName']").val(""),

    $("[name='Vendor.MobileNo']").val(""),

    $("[name='Vendor.PhoneNo']").val(""),

    $("[name='Vendor.FaxNo']").val(""),

    $("[name='Vendor.Address']").val(""),

    $("#drpCity").val("0"),

    $("#drpBusinessType").val("0"),

    $("[name='Vendor.PINCode']").val(""),

    $("[name='Vendor.EmailId']").val(""),

    $("[name='Vendor.WebsiteURL']").val(""),

    // $("[name='Vendor.PaymentOption']").val("0"),

    $("#drpPaymentOption").val("0");

    $("[name='Vendor.IsActive']").val(false)

    if ($("[name='Vendor.IsActive']").val() == 0 || $("[name='Vendor.IsActive']").val() == "false") {

        $('.switchery').trigger('click');
    }

    $("[name='Vendor.IsCompany']").prop("checked", false)

}

function Set_BusinessType() {

    var hexvalues = [];

    var labelvalues = [];

    var BusinessType = "";

    var BusinessName = "";

    $('.BusinessType :selected').each(function (i, selectedElement) {

        hexvalues[i] = $(selectedElement).val();

        labelvalues[i] = $(selectedElement).text();

        debugger;

        BusinessType = hexvalues[i] + "," + BusinessType;

        BusinessName = labelvalues[i] + ", " + BusinessName;

    });

    $('#hdnBusinessType').val(BusinessType);

}


function Set_PaymentOption() {

    var hexvalues = [];

    var labelvalues = [];

    var PaymentOption = "";

    var PaymentName = "";

    $('.PaymentOption :selected').each(function (i, selectedElement) {

        hexvalues[i] = $(selectedElement).val();

        labelvalues[i] = $(selectedElement).text();

        debugger;

        PaymentOption = hexvalues[i] + "," + PaymentOption;

        PaymentName = labelvalues[i] + ", " + PaymentName;

    });

    $('#hdnPaymentOption').val(PaymentOption);

}















//function SaveContactPerson() {

//    $("#frmContactPerson").blur();

//    var vViewModel = {

//        ContactPerson: {

//            ContactPersonId:$("[name='ContactFilter.ContactPersonId']").val(),

//            ContactPersonName:$("[name='Vendor.ContactPerson.ContactPersonName']").val(),

//            MobileNo:$("[name='Vendor.ContactPerson.MobileNo']").val(),

//            PhoneNo:$("[name='Vendor.ContactPerson.PhoneNo']").val(),

//            FaxNo:$("[name='Vendor.ContactPerson.FaxNo']").val(),

//            EmailId:$("[name='Vendor.ContactPerson.EmailId']").val(),           

//            DesignationId: $("#drpDesignationId").val(),

//            RefId:$("#hdnRefId").val(),

//            RefType:$("#hdnRefType").val()

//        }
//    }
//    var url = "";

//    if ($("[name='ContactFilter.ContactPersonId']").val() == 0) {

//        url = "/Vendor/InsertContactPerson"
//    }
//        else {
//        url = "/Vendor/UpdateContactPerson"

//    }
//    PostAjaxJson(url, vViewModel, AfterContactPersonSave);
//}
 
//function AfterContactPersonSave(data) {

//    var obj = $.parseJSON(data);

//    $("[name='ContactPerson.RefType']").val(obj.ContactPerson.RefType); 

//    GetContactPerson();
    
//    ResetContactPerson();
    


//}
  
//function ResetContactPerson() {

//    $("#hdnSearchContactPersonId").val('');

//    $("#txtContactName").val('');

//    $("#txtContactPhoneNo").val('');

//    $("#txtContactMobileNo").val('');

//    $("#txtContactEmail").val('');

//    $("#txtContactFaxNo").val('');

//    $("#drpDesignationId").val('');
//}

//function GetContactPerson() {

//    var vViewModel =
//		{
//		    ContactPerson: {

//		        RefId: $("#hdnRefId").val(),

//		        RefType:$("#hdnSearchRefType").val()

//		    },
//		    Pager: {

//		        CurrentPage: $('#tblContactPerson').attr("data-current-page"),
//		    },
//		}

//    PostAjaxJson("/Vendor/GetContactPerson", vViewModel, BindContactPerson);
//}

//function BindContactPerson(data) {

//    var list = JSON.parse(data);

//    var kTable = {
//        dataList: ["ContactPersonName", "MobileNo", "DesignationName"],
//        primayKey: "ContactPersonId",
//        hiddenFields: ["ContactPersonId", "ContactPersonName", "DesignationId"],
//        headerNames: ["Contact Person Name", "MobileNo", "Designation"],
//        data: list.dt,
//    }

//    buildHtmlTable(kTable, $('#tblContactPerson'));

//    BindPagination(list.Pager, $('#tblContactPerson'));

//}

//function GetContactPersonById() {

//    var vViewModel =
//      {

//          ContactPerson: {
            
//              ContactPersonId: $("[name='ContactFilter.ContactPersonId']").val(),

//          },          
//      }

//    PostAjaxJson("/Vendor/GetContactPersonById", vViewModel, BindContactPersonById);


//}

//function BindContactPersonById(data) {

//    var obj = data;

//    $("[name='Vendor.ContactPerson.ContactPersonId']").val(obj.ContactPerson.ContactPersonId),

//    $("[name='Vendor.ContactPerson.ContactPersonName']").val(obj.ContactPerson.ContactPersonName),

//    $("[name='Vendor.ContactPerson.MobileNo']").val(obj.ContactPerson.MobileNo),

//    $("[name='Vendor.ContactPerson.PhoneNo']").val(obj.ContactPerson.PhoneNo),

//    $("[name='Vendor.ContactPerson.FaxNo']").val(obj.ContactPerson.FaxNo),

//    $("[name='Vendor.ContactPerson.EmailId']").val(obj.ContactPerson.EmailId),

//    $("#drpDesignationId").val(obj.ContactPerson.DesignationId),

//    $("#hdnRefId").val(obj.ContactPerson.RefId),

//    $("#hdnRefType").val(obj.ContactPerson.RefType)

//}

//function DeleteContactPerson() {

//    var vViewModel =
//      {

//          ContactPerson: {

//              ContactPersonId: $("[name='ContactFilter.ContactPersonId']").val(),

//              RefId: $("#hdnRefId").val(),


//          },
//          Pager: {

//              CurrentPage: $('#hdnCurrentPage').val()
//          },
//}

//    PostAjaxJson("/Vendor/DeleteContactPerson", vViewModel,GetContactPerson);

//    $("#hdnContactPersonId").val('');


//}

//function Pagination(CurrentPage) {

//    $('#tblContactPerson').attr("data-current-page", CurrentPage);

//    GetContactPerson();

//}







