// Git Details Strt

function SaveGitEnquiryItem() {


    $("#frmgitdetails").blur();

    var enqViewModel = {

        Enquiry: {

            EnquiryItemId: $("[name='Enquiry.EnquiryItemId']").val(),

            EnquiryId: $("#hdnEnquiryId").val(),

            EnquiryType: $("#hdnEnquiryType").val(),

            CategoryId: $("#drpcategory").val(),

            PackageType: $("[name='Enquiry.packageType']").val(),

            PackageName: $("[name='Enquiry.packagename']").val(),

            NoOfNights: $("[name='Enquiry.noOfNights']").val(),

            Month: $("#drpmonth").val(),

            Year: $("#drpyear").val(),

            AdultCount: $("[name='Enquiry.adultCount']").val(),

            ChildCount: $("[name='Enquiry.chidCount']").val(),

            Budget: $("[name='Enquiry.budget']").val(),

              Location: $("#drpdestination").val(),

              FromDate: $("[name='Enquiry.FromDate']").val(),

              CountryId: $("#drpCountry").val(),

              StateId: $("[name='Enquiry.StateId']").val(),

              Cityid: $("[name='Enquiry.Cityid']").val(),




        }
    }

    //alert($("[name='Enquiry.enquiryAssignedType']").val());

    //alert($("[name='Enquiry.packageType']").val());

    //alert($("#hdnEnquiryId").val());

    //alert($("#hdnEnquiryTypeGit").val());

    //alert($("[name='Enquiry.EnquiryItemId']").val());

    var url = "";

    if ($("[name='Enquiry.EnquiryItemId']").val() == 0) {

        url = "/Enquiry/InsertEnquiryItem"
    }
    else {

        url = "/Enquiry/UpdateEnquiryGitDetails"
    }

    //alert(JSON.stringify(enqViewModel));

    PostAjaxWithProcessJson(url, enqViewModel, AfterGitSave, $("body"));
}

function AfterGitSave(data) {

    //alert(data);

    FriendlyMessage(data);

    //alert("AfterGitSave")

    $("#hdnEnquiryId").val(data.Enquiry.EnquiryId);

    //alert($("#hdnGitId").val(data.Enquiry.EnquiryItemId));

    $("#hdnGitId").val(data.Enquiry.EnquiryItemId);

    $("#hdnEnquiryTypeGit").val(data.Enquiry.EnquiryType);

    //alert(data.Enquiry.EnquiryType);

    GetEnquiryItemDetailsView();

    $("#modalParent").modal('hide');//To Close/Hide Common Modal
}

function GetStateByCountryId(countryId) {

    GetAjax("/City/GetStatesByCountryId", { countryId: countryId }, BindStates);
}

function BindStates(states) {
    $("#drpState").html("");

    var htmltext = "";

    htmltext += "<option value = '0'>Select States</option>";

    if (states.length > 0) {

        for (var i = 0; i < states.length ; i++) {

            htmltext += "<option value='" + states[i].StateId + "' >" + states[i].StateName + "</option>";

        }
    }

    $("#drpState").html(htmltext);
}







































































//function DeleteGitEnquiryItemById(ele) {

//    alert("rrrr");

//    debugger;

//    var hdnenquiyitemid = ele.id;

//    var cnt = hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1);

//    //alert("fadf" + ele.id + hdnenquiyitemid.substring(abc.indexOf('_') + 1));

//    //alert("gsfg " + $("#hdnSightseeingEnquiryItemId_" + hdnenquiyitemid.substring(abc.indexOf('_') + 1)).val());

//    //alert($(ele).closest('div.row').find("input[id^='hdnSightseeingEnquiryItemId_']").val());



//    PostAjaxWithProcessJson("/Enquiry/DeleteEnquiryItemById", { EnquiryId: $("#hdnEnquiryId").val(), EnquiryType: $("#hdnEnquiryType").val(), EnquiryItemId: $("#hdnGitEnquiryItemId_" + cnt).val() }, AfterGitDelete, $("body"));
//}

//function AfterGitDelete(data) {

//    alert(data);

//    FriendlyMessage(data);

//}



