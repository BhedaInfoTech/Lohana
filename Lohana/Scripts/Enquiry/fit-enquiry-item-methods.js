// Fit Details Start

function SaveFitEnquiryItem() {

    $("#frmfitdetails").blur();
   
    var enqViewModel = {

        Enquiry: {

            EnquiryItemId: $("[name='Enquiry.EnquiryItemId']").val(),

            EnquiryId: $("#hdnEnquiryId").val(),

            EnquiryType: $("#hdnEnquiryType").val(),

            PackageType: $("[name='Enquiry.packageType']").val(),

            NoOfNights: $("[name='Enquiry.noOfNights']").val(),

            OccupancyId: $("#drpOccupancy").val(),

            AdultCount: $("#txtAdultCount").val(),

            ChildCount: $("#txtChildCount").val(),

            RoomCount: $("#txtroomCount").val(),

            //CXBCount: $("[name='Enquiry.cxbCount']").val(),

            //CXBAge: $("[name='Enquiry.cxbAge']").val(),

            //CNBCount: $("[name='Enquiry.cnbCount']").val(),

            //CNBAge: $("[name='Enquiry.CNBAge']").val(),

            Budget: $("[name='Enquiry.budget']").val(),

            CheckInDate: $("[name='Enquiry.CheckInDate']").val(),

            CheckOutDate: $("[name='Enquiry.CheckOutDate']").val(),

            CountryId: $("#drpCountry").val(),

            StateId: $("[name='EnquiryFit.StateId']").val(),

            CityId: $("[name='EnquiryFit.CityId']").val(),
            

        },

    }

    debugger;

    //alert($("[name='Enquiry.packageType']").val());

    //alert($("[name='Enquiry.destination']").val());

    //alert($("#hdnEnquiryId").val());

    //alert($("#drppackageType").val());

    //alert($("[name='Enquiry.EnquiryItemId']").val());

    var url = "";

    if ($("[name='Enquiry.EnquiryItemId']").val() == 0) {

        url = "/Enquiry/InsertEnquiryItem"
    }
    else {

        url = "/Enquiry/UpdateEnquiryFitDetails"
    }

    //alert(JSON.stringify(enqViewModel));

    PostAjaxWithProcessJson(url, enqViewModel, AfterFitSave, $("body"));
}

function AfterFitSave(data) {

    FriendlyMessage(data);

    $("#hdnEnquiryId").val(data.Enquiry.EnquiryId);

    //alert($("#hdnFitId").val(data.Enquiry.EnquiryItemId));

    $("#hdnFitId").val(data.Enquiry.EnquiryItemId);

    $("#hdnEnquiryTypeFit").val(data.Enquiry.EnquiryType);

    //alert($("#hdnEnquiryTypeFit").val(data.Enquiry.EnquiryType));

    GetEnquiryItemDetailsView();
    $("#modalParent").modal('hide');//To Close/Hide Common Modal
}

function GetFitDetailsView() {

    //alert("fffff");

    $("#divEnquiryItemFit").load("/Enquiry/GetFitDetailsView", { EnquiryId: $("#hdnEnquiryId").val(), EnquiryType: $("#hdnEnquiryType").val() }, null);

    var enumEnqtypeGitId = $("#hdnenumEnqtypeGitId").val();

    var enumEnqtypeFitId = $("#hdnenumEnqtypeFitId").val();

    var hdnEnquiryTypeId = $("#hdnEnquiryTypeId").val();

    //alert('enumEnqtypeFitId' + enumEnqtypeFitId);


    //alert('hdnEnquiryTypeId' + hdnEnquiryTypeId);

    if (enumEnqtypeGitId == hdnEnquiryTypeId) {

        //alert("insidegit");

        $("#divEnquiryItemGit").show();
        //document.getElementById("divEnquiryItemGit").style.display="block";
    }
    else if (enumEnqtypeFitId == hdnEnquiryTypeId) {

        //alert("insidefit");

        $("#divEnquiryItemGit").hide();
        $("#divEnquiryItemFit").show();
    }
}

