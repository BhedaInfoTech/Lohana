function GetVendor() {

    var vViewModel =
		{
		    Vendor: {
		       
		        VendorName: $("[name='Vendor.VendorName']").val(),

		        MobileNo: $("[name='Vendor.MobileNo']").val(),

		    },
		    Pager: {

		        CurrentPage: $('#tblVendor').attr("data-current-page"),
		    },
		}
    
    PostAjaxJson("/Vendor/GetVendor", vViewModel, BindVendors);
}

function BindVendors(data) {

    var list = JSON.parse(data);
    var kTable = {
        dataList: ["VendorName", "MobileNo", "Address", "EmailId"],
        primayKey: "VendorId",
        hiddenFields: ["VendorId", "VendorName"],
        headerNames: ["Vendor Name", "Mobile No", "Address", "Email Id"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblVendor'));

    BindPagination(list.Pager, $('#tblVendor'));

   
}

function Pagination(CurrentPage) {
   
    $('#tblVendor').attr("data-current-page", CurrentPage);
  
    GetVendor();

    document.getElementById("btnEditVendor").disabled = true;

    document.getElementById("btnViewContactDetails").disabled = true;

}


// Contact Person

function GetContactPerson() {

    var vViewModel =
		{
		    ContactPerson: {

		        RefId: $("#hdnSearchVendorId").val(),

		        RefType: $("#hdnRefType").val()

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
        dataList: ["ContactPersonName", "MobileNo", "DesignationName"],
        headerNames: ["Contact Person Name", "Mobile No", "Designation"],
        data: list.dt,
    }

    buildHtmlViewTable(kTable, $('#tblContactPerson'));

    BindPagination(list.Pager, $('#tblContactPerson'), "ContactPersonPagination");

}


function ContactPersonPagination(CurrentPage) {

    $('#tblContactPerson').attr("data-current-page", CurrentPage);

    GetContactPerson();

}


