
function SaveContactPerson() {

    $("#frmContactPerson").blur();

    var vViewModel = {

        ContactPerson: {

            ContactPersonId: $("[name='ContactFilter.ContactPersonId']").val(),

            ContactPersonName: $("[name='Vendor.ContactPerson.ContactPersonName']").val(),

            MobileNo: $("[name='Vendor.ContactPerson.MobileNo']").val(),

            PhoneNo: $("[name='Vendor.ContactPerson.PhoneNo']").val(),

            FaxNo: $("[name='Vendor.ContactPerson.FaxNo']").val(),

            EmailId: $("[name='Vendor.ContactPerson.EmailId']").val(),

            DesignationId: $("#drpDesignationId").val(),

            RefId: $("#hdnRefId").val(),

            RefType: $("#hdnRefType").val()

        }
    }
    var url = "";

    if ($("[name='ContactFilter.ContactPersonId']").val() == 0) {

        url = "/Vendor/InsertContactPerson"
    }
    else {
        url = "/Vendor/UpdateContactPerson"

    }
    PostAjaxJson(url, vViewModel, AfterContactPersonSave);
}

function AfterContactPersonSave(data) {

    FriendlyMessage(data);

    $("[name='ContactPerson.RefType']").val(data.ContactPerson.RefType);

    GetContactPerson();

    ResetContactPerson();

}

function ResetContactPerson() {

    $("#hdnSearchContactPersonId").val('');

    $("#txtContactName").val('');

    $("#txtContactPhoneNo").val('');

    $("#txtContactMobileNo").val('');

    $("#txtContactEmail").val('');

    $("#txtContactFaxNo").val('');

    $("#drpDesignationId").val('0');
}

function GetContactPerson() {

    var vViewModel =
		{
		    ContactPerson: {

		        RefId: $("#hdnRefId").val(),

		        RefType: $("#hdnSearchRefType").val()

		    },
		    Pager: {

		        CurrentPage: $('#tblContactPerson').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/Vendor/GetContactPerson", vViewModel, BindContactPerson);
}

function BindContactPerson(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["ContactPersonName","DesignationName", "MobileNo", "EmailId"],
        primayKey: "ContactPersonId",
        hiddenFields: ["ContactPersonId", "ContactPersonName", "DesignationId"],
        headerNames: ["Contact Person Name","Designation", "MobileNo","Email Id"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblContactPerson'));

    BindPagination(list.Pager, $('#tblContactPerson'));

}

function GetContactPersonById() {

    var vViewModel =
      {

          ContactPerson: {

              ContactPersonId: $("[name='ContactFilter.ContactPersonId']").val(),

          },
          Pager: {

              CurrentPage: $('#tblContactPerson').attr("data-current-page"),
          },
      }

    PostAjaxJson("/Vendor/GetContactPersonById", vViewModel, BindContactPersonById);


}

function BindContactPersonById(data) {

    var obj = data;

    $("[name='Vendor.ContactPerson.ContactPersonId']").val(obj.ContactPerson.ContactPersonId),

    $("[name='Vendor.ContactPerson.ContactPersonName']").val(obj.ContactPerson.ContactPersonName),

    $("[name='Vendor.ContactPerson.MobileNo']").val(obj.ContactPerson.MobileNo),

    $("[name='Vendor.ContactPerson.PhoneNo']").val(obj.ContactPerson.PhoneNo),

    $("[name='Vendor.ContactPerson.FaxNo']").val(obj.ContactPerson.FaxNo),

    $("[name='Vendor.ContactPerson.EmailId']").val(obj.ContactPerson.EmailId),

    $("[name='Vendor.ContactPerson.DesignationId']").attr("data-value", obj.ContactPerson.DesignationId);

    GetAutocompleteById("Vendor.ContactPerson.DesignationId");

    $("#hdnRefId").val(obj.ContactPerson.RefId),

    $("#hdnRefType").val(obj.ContactPerson.RefType)

}

function DeleteContactPerson() {

    var vViewModel =
      {

          ContactPerson: {

              ContactPersonId: $("[name='ContactFilter.ContactPersonId']").val(),

              RefId: $("#hdnRefId").val(),


          },
          Pager: {

              CurrentPage: $('#hdnCurrentPage').val()
          },
      }

    PostAjaxJson("/Vendor/DeleteContactPerson", vViewModel, AfterDeleteContactPerson);

    $("#hdnContactPersonId").val('');


}

function AfterDeleteContactPerson(data) {

    FriendlyMessage(data);

    ResetContactPerson();

    GetContactPerson();
}
function Pagination(CurrentPage) {

    $('#tblContactPerson').attr("data-current-page", CurrentPage);

    GetContactPerson();

}

