
function GetFitDetailsById(ele) {

    //alert("fitei");

    var hdnenquiyitemid = ele.id;

    var cnt = hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1);

    //alert(cnt);

    //alert("fadf" + ele.id + hdnenquiyitemid.substring(abc.indexOf('_') + 1));

    //alert("gsfg " + $("#hdnFitEnquiryItemId_" + hdnenquiyitemid.substring(abc.indexOf('_') + 1)).val());

    //alert($(ele).closest('div.row').find("input[id^='hdnFitEnquiryItemId_']").val());

    LoadModal("/Enquiry/GetFitDetailsById", { EnquiryItemId: $("#hdnFitEnquiryItemId_" + cnt).val() }, null, "Fit Details", null);
}

function DeleteFitDetailsById(ele) {

    //alert("deletefitbyid");

    var hdnenquiyitemid = ele.id;

    var cnt = hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1);

    //alert($("#hdnFitEnquiryItemId_" + cnt).val());

    GetAjax("/Enquiry/DeleteEnquiryItemById", { EnquiryId: $("#hdnEnquiryId").val(), EnquiryType: $("#hdnEnquiryType").val(), EnquiryItemId: $("#hdnFitEnquiryItemId_" + cnt).val() }, AfterFitDelete);

}

function AfterFitDelete(data) {

    GetEnquiryItemDetailsView();

}


function GetFlightDetailsById(ele) {

    //alert("getflightbyid");

    var hdnenquiyitemid = ele.id;

    var cnt = hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1);

    //alert($("#hdnEnquiryId").val());

    //alert($("#hdnEnquiryType").val());

    //alert($("#hdnFlightEnquiryItemId_" + cnt).val());

    //alert("fadf" + ele.id + hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1));

    //alert("gsfg " + $("#hdnGitEnquiryItemId_" + hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1)).val());

    //alert($(ele).closest('div.row').find("input[id^='hdnGitEnquiryItemId_']").val());

    // LoadModal("/Enquiry/GetGitDetailsById", { EnquiryId: $("#hdnEnquiryId").val(), EnquiryType: $("#hdnEnquiryType").val(), EnquiryItemId: $("#hdnGitEnquiryItemId_" + cnt).val() }, null, "Git Details", null);

    LoadModal("/Enquiry/GetFlightDetailsById", { EnquiryItemId: $("#hdnFlightEnquiryItemId_" + cnt).val() }, null, "Flight Details", null);

}

function DeleteFlightDetailsById(ele) {

    //alert("deleteflightbyid");

    var hdnenquiyitemid = ele.id;

    var cnt = hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1);

    //alert($("#hdnFlightEnquiryItemId_" + cnt).val());

    GetAjax("/Enquiry/DeleteEnquiryItemById", { EnquiryId: $("#hdnEnquiryId").val(), EnquiryType: $("#hdnEnquiryType").val(), EnquiryItemId: $("#hdnFlightEnquiryItemId_" + cnt).val() }, AfterFlightDelete);

}

function AfterFlightDelete(data) {

    GetEnquiryItemDetailsView();

}


function GetGitDetailsById(ele) {

    //alert("getgitbyid");

    var hdnenquiyitemid = ele.id;

    var cnt = hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1);

    //alert($("#hdnEnquiryId").val());

    //alert($("#hdnEnquiryType").val());

    //alert($("#hdnGitEnquiryItemId_" + cnt).val());

    //alert("fadf" + ele.id + hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1));

    //alert("gsfg " + $("#hdnGitEnquiryItemId_" + hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1)).val());

    //alert($(ele).closest('div.row').find("input[id^='hdnGitEnquiryItemId_']").val());

    // LoadModal("/Enquiry/GetGitDetailsById", { EnquiryId: $("#hdnEnquiryId").val(), EnquiryType: $("#hdnEnquiryType").val(), EnquiryItemId: $("#hdnGitEnquiryItemId_" + cnt).val() }, null, "Git Details", null);

    LoadModal("/Enquiry/GetGitDetailsById", { EnquiryId: $("#hdnEnquiryId").val(), EnquiryType: $("#hdnEnquiryType").val(), EnquiryItemId: $("#hdnGitEnquiryItemId_" + cnt).val() }, null, "Git Details", null);

}

function DeleteGitDetailsById(ele) {

    //alert("deletegitbyid");

    var hdnenquiyitemid = ele.id;

    var cnt = hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1);

    //alert($("#hdnGitEnquiryItemId_" + cnt).val());

    GetAjax("/Enquiry/DeleteEnquiryItemById", { EnquiryId: $("#hdnEnquiryId").val(), EnquiryType: $("#hdnEnquiryType").val(), EnquiryItemId: $("#hdnGitEnquiryItemId_" + cnt).val() }, AfterGitDelete);

}

function AfterGitDelete(data) {

    GetEnquiryItemDetailsView();

}


function GetHotelDetailsById(ele) {

    var hdnenquiyitemid = ele.id;

    var cnt = hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1);

    //alert("fadf" + ele.id + hdnenquiyitemid.substring(abc.indexOf('_') + 1));

    //alert("gsfg " + $("#hdnHotelEnquiryItemId_" + hdnenquiyitemid.substring(abc.indexOf('_') + 1)).val());

    //alert($(ele).closest('div.row').find("input[id^='hdnHotelEnquiryItemId_']").val());

    LoadModal("/Enquiry/GetHotelDetailsById", { EnquiryItemId: $("#hdnHotelEnquiryItemId_" + cnt).val() }, null, "Hotel Details", null);
}

function DeleteHotelDetailsById(ele) {

    //alert("deletehotelbyid");

    var hdnenquiyitemid = ele.id;

    var cnt = hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1);

    //alert($("#hdnHotelEnquiryItemId_" + cnt).val());

    GetAjax("/Enquiry/DeleteEnquiryItemById", { EnquiryId: $("#hdnEnquiryId").val(), EnquiryType: $("#hdnEnquiryType").val(), EnquiryItemId: $("#hdnHotelEnquiryItemId_" + cnt).val() }, AfterHotelDelete);

}

function AfterHotelDelete(data) {

    GetEnquiryItemDetailsView();

}


function GetSightseeingDetailsById(ele) {

    var hdnenquiyitemid = ele.id;

    var cnt = hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1);

    //alert($("#hdnEnquiryId").val());

    //alert($("#hdnEnquiryType").val());

    //alert($("#hdnGitEnquiryItemId_" + cnt).val());

    //alert("fadf" + ele.id + hdnenquiyitemid.substring(abc.indexOf('_') + 1));

    //alert("gsfg " + $("#hdnSightseeingEnquiryItemId_" + hdnenquiyitemid.substring(abc.indexOf('_') + 1)).val());

    //alert($(ele).closest('div.row').find("input[id^='hdnSightseeingEnquiryItemId_']").val());

    LoadModal("/Enquiry/GetSightseeingDetailsById", { EnquiryItemId: $("#hdnSightseeingEnquiryItemId_" + cnt).val() }, null, "Sightseeing Details", null);
}

function DeleteSightseeingDetailsById(ele) {

    //alert("deletesightseeingbyid");

    var hdnenquiyitemid = ele.id;

    var cnt = hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1);

    //alert($("#hdnSightseeingEnquiryItemId_" + cnt).val());

    GetAjax("/Enquiry/DeleteEnquiryItemById", { EnquiryId: $("#hdnEnquiryId").val(), EnquiryType: $("#hdnEnquiryType").val(), EnquiryItemId: $("#hdnSightseeingEnquiryItemId_" + cnt).val() }, AfterSightseeingDelete);

}

function AfterSightseeingDelete(data) {

    GetEnquiryItemDetailsView();

}


function GetTrainDetailsById(ele) {

    //alert("gettrainbyid");

    var hdnenquiyitemid = ele.id;

    var cnt = hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1);

    //alert($("#hdnEnquiryId").val());

    //alert($("#hdnEnquiryType").val());

    //alert($("#hdnTrainEnquiryItemId_" + cnt).val());

    //alert("fadf" + ele.id + hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1));

    //alert("gsfg " + $("#hdnGitEnquiryItemId_" + hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1)).val());

    //alert($(ele).closest('div.row').find("input[id^='hdnGitEnquiryItemId_']").val());

    // LoadModal("/Enquiry/GetGitDetailsById", { EnquiryId: $("#hdnEnquiryId").val(), EnquiryType: $("#hdnEnquiryType").val(), EnquiryItemId: $("#hdnGitEnquiryItemId_" + cnt).val() }, null, "Git Details", null);

    LoadModal("/Enquiry/GetTrainDetailsById", { EnquiryItemId: $("#hdnTrainEnquiryItemId_" + cnt).val() }, null, "Train Details", null);

}

function DeleteTrainDetailsById(ele) {

    //alert("deletetrainbyid");

    var hdnenquiyitemid = ele.id;

    var cnt = hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1);

    //alert($("#hdnTrainEnquiryItemId_" + cnt).val());

    GetAjax("/Enquiry/DeleteEnquiryItemById", { EnquiryId: $("#hdnEnquiryId").val(), EnquiryType: $("#hdnEnquiryType").val(), EnquiryItemId: $("#hdnTrainEnquiryItemId_" + cnt).val() }, AfterTrainDelete);

}

function AfterTrainDelete(data) {

    GetEnquiryItemDetailsView();

}


function GetTransferDetailsById(ele) {

    //alert("gettransferbyid");

    var hdnenquiyitemid = ele.id;

    var cnt = hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1);

    //alert($("#hdnEnquiryId").val());

    //alert($("#hdnEnquiryType").val());

    //alert($("#hdnTansferEnquiryItemId_" + cnt).val());

    LoadModal("/Enquiry/GetFlightDetailsById", { EnquiryItemId: $("#hdnTansferEnquiryItemId_" + cnt).val() }, null, "Transfer Details", null);

}

function DeleteTransferDetailsById(ele) {

    //alert("deletetransferbyid");

    var hdnenquiyitemid = ele.id;

    var cnt = hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1);

    //alert($("#hdnTransferEnquiryItemId_" + cnt).val());

    GetAjax("/Enquiry/DeleteEnquiryItemById", { EnquiryId: $("#hdnEnquiryId").val(), EnquiryType: $("#hdnEnquiryType").val(), EnquiryItemId: $("#hdnTransferEnquiryItemId_" + cnt).val() }, AfterTransferDelete);

}

function AfterTransferDelete(data) {

    GetEnquiryItemDetailsView();

}
