function GetEnquiry() {

    var enqViewModel =
		{
		    Enquiry: {

		        CustomerType: $("#drpCustomerType").val(),

		        EnquiryStatus: $("#drpStatus").val(),

		        EnquirySource: $("#drpSourceEnquiry").val()

		    },
		    Pager: {

		        CurrentPage: $('#tblEnquiry').attr("data-current-page"),

		    },
		}

    //alert($("#drpCustomerType").val());

    //alert($("#drpStatus").val());

    //alert($("#drpSourceEnquiry").val());

    PostAjaxJson("/Enquiry/GetEnquiry", enqViewModel, BindEnquiries);
}

function BindEnquiries(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["CustomerTypeStr", "EnquiryStatusStr", "EnquirySourceStr", "Created"],
        primayKey: "EnquiryId",
        hiddenFields: ["EnquiryId", "CustomerType", "EnquiryStatus", "EnquirySource","CreatedBy"],
        headerNames: ["Customer Type", "Enquiry Status", "Enquiry Source","Created"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblEnquiry'));

    BindPagination(list.Pager, $('#tblEnquiry'), "EnquiryPagination");

}


function EnquiryPagination(CurrentPage) {

    $('#tblEnquiry').attr("data-current-page", CurrentPage);

    GetEnquiry();

    document.getElementById("btnEditEnquiry").disabled = true;

}


