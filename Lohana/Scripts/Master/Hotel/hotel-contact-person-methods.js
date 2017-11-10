function SaveContactPerson() {
 
    $("#frmContactPerson").blur();

    var hViewModel = {
        ContactPerson: {
            ContactPersonId: $("#hdnSearchHotelContactPersonId").val(),

            ContactPersonName: $("[name='Hotel.ContactPerson.ContactPersonName']").val(),

            MobileNo: $("[name='Hotel.ContactPerson.MobileNo']").val(),

            PhoneNo: $("[name='Hotel.ContactPerson.PhoneNo']").val(),

            FaxNo: $("[name='Hotel.ContactPerson.FaxNo']").val(),

            EmailId: $("[name='Hotel.ContactPerson.EmailId']").val(),

            DesignationId: $("#drpDesignation").val(),

            RefId: $("#hdnRefId").val(),

            RefType: $("#hdnRefType").val()
        }
    }
    var url = "";

    if ($("#hdnSearchHotelContactPersonId").val() == 0) {
        url = "/Hotel/InsertContactPerson"
    }
    else {
        url = "/Hotel/UpdateContactPerson"
    }
    PostAjaxJson(url, hViewModel, AfterContactPersonSave);
}

function AfterContactPersonSave(data)
{
    var obj = $.parseJSON(data);

    FriendlyMessage(obj);

    $("[name='ContactPerson.RefType']").val(obj.ContactPerson.RefType)

    ResetContactPerson();

    GetContactPerson();
}

function ResetContactPerson() {

    $("#hdnSearchHotelContactPersonId").val('');

    $("#txtContactName").val('');

    $("#drpDesignation").val("0");

    $("#txtContactPhoneNo").val('');

    $("#txtContactMobileNo").val('');

    $("#txtContactEmail").val('');

    $("#txtContactFaxNo").val('');

    $("#hdnIsEditContactPerson").val(false);
}

function GetContactPerson() {
    var hViewModel =
		{
		    ContactPerson: {
		        RefId: $("#hdnRefId").val(),

		        //RefId: $("[name='HotelContactPerson.HotelId']"),

		        RefType: $("#hdnRefType").val()
		    },

		    Pager: {
		        CurrentPage: $('#tblContactPerson').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/Hotel/GetContactPerson", hViewModel, BindContactPerson);
}

function BindContactPerson(data) {
    var list = JSON.parse(data);

    var kTable = {
        dataList: ["ContactPersonName",  "DesignationName","MobileNo","EmailId"],
        primayKey: "ContactPersonId",
        hiddenFields: ["ContactPersonId", "ContactPersonName", "DesignationId"],
        headerNames: ["Contact Person Name", "Designation", "Mobile No", "Email Id" ],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblContactPerson'));

    BindPagination(list.Pager, $('#tblContactPerson'));
}

function GetContactPersonById(data) {
    var hViewModel =
      {
          ContactPerson: {
              ContactPersonId: $("#hdnSearchHotelContactPersonId").val(),
          },
          Pager:
              {
                  CurrentPage: $('#hdnCurrentPage').val()
              },
      }

    PostAjaxJson("/Hotel/GetContactPersonById", hViewModel, BindContactPersonById);
}

function BindContactPersonById(data) {

    var obj = data;

    $("[name='Hotel.ContactPerson.ContactPersonId']").val(obj.ContactPerson.ContactPersonId),

    $("[name='Hotel.ContactPerson.ContactPersonName']").val(obj.ContactPerson.ContactPersonName),

    $("[name='Hotel.ContactPerson.MobileNo']").val(obj.ContactPerson.MobileNo),

    $("[name='Hotel.ContactPerson.PhoneNo']").val(obj.ContactPerson.PhoneNo),

    $("[name='Hotel.ContactPerson.FaxNo']").val(obj.ContactPerson.FaxNo),

    $("[name='Hotel.ContactPerson.EmailId']").val(obj.ContactPerson.EmailId),

    $("[name='Hotel.ContactPerson.Designation']").attr("data-value", obj.ContactPerson.DesignationId);

    GetAutocompleteById("Hotel.ContactPerson.Designation");

    $("#hdnRefId").val(obj.ContactPerson.RefId),

    $("#hdnRefType").val(obj.ContactPerson.RefType)
}

function DeleteHotelContactPerson() {
    var hViewModel =
      {
          ContactPerson: {
              ContactPersonId: $("[name='ContactPerson.ContactPersonId']").val(),

              RefId: $("#hdnRefId").val(),
          },
          Pager: {
              CurrentPage: $('#hdnCurrentPage').val()
          },
      }

    PostAjaxJson("/Hotel/DeleteContactPerson", hViewModel, AfterContactPersonDelete);

    $("[name='ContactPerson.ContactPersonId']").val('');
}


function AfterContactPersonDelete(data) {

    FriendlyMessage(data);

    $("[name='ContactPerson.RefType']").val(data.ContactPerson.RefType)

    ResetContactPerson();

    GetContactPerson();
}


function Pagination(CurrentPage) {
    $('#tblContactPerson').attr("data-current-page", CurrentPage);

    GetContactPerson();
}
