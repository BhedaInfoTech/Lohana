//Flight Start

function GetEnquiryFlightDetailsById(ele) {

    //alert("add");

    var hdnenquiyitemid = ele.id;

    var cnt = hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1);

    LoadModal("/Quotation/GetEnquiryFlightDetailsById", { EnquiryItemId: $("#hdnFlightEnquiryItemId_" + cnt).val() }, null, "Flight Details", null);

}

//PigeonHoleRefrigerator/GetBranchPigeonHoleRefrigerator?branchId=' + $('#drpBranchId option:selected').val()

//function GetEnquiryGitDetailsById(ele) {

//    alert("add");
//    debugger;

//    var hdnenquiyitemid = ele.id;

//    var cnt = hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1);

//    LoadModal("/Package/GetEnquiryGitDetailsById", { EnquiryItemId: $("#hdnGitEnquiryItemId_" + cnt).val() }, null, "Git Details", null);

//}

function GetQuotationFlightDetailsById(ele) {

    //  alert(ele);

    debugger;

    var hdnquotationitemid = ele.id;

    var cnt = hdnquotationitemid.substring(hdnquotationitemid.indexOf('_') + 1);

    // alert($("#hdnQuotationFlightItemId_" + cnt).val());

    LoadModal("/Quotation/GetQuotationFlightDetailsById", { QuotationItemId: $("#hdnQuotationFlightItemId_" + cnt).val() }, null, "Flight Details", null);

}

function CloneQuotationFlightDetailsById(ele) {

    //alert(ele);

    debugger;

    var hdnquotationitemid = ele.id;

    var cnt = hdnquotationitemid.substring(hdnquotationitemid.indexOf('_') + 1);

    //alert($("#hdnQuotationFlightItemId_" + cnt).val());

    GetAjax("/Quotation/CloneFlightDetails", { QuotationItemId: $("#hdnQuotationFlightItemId_" + cnt).val() }, AfterCloneQuotation);

}

function AfterCloneQuotation() {

    //alert("clone");

    GetEnquiryItemDetailsView();
}

//Flight End


//Train Start

function GetEnquiryTrainDetailsById(ele) {

    //alert("add");

    var hdnenquiytrainitemid = ele.id;

    var cnt = hdnenquiytrainitemid.substring(hdnenquiytrainitemid.indexOf('_') + 1);

    LoadModal("/Quotation/GetEnquiryTrainDetailsById", { EnquiryItemId: $("#hdnTrainEnquiryItemId_" + cnt).val() }, null, "Train Details", null);

}

function GetQuotationTrainTypeDetailsById(ele) {

    //alert(ele);

    debugger;

    var hdnquotationtrainitemid = ele.id;

    var cnt = hdnquotationtrainitemid.substring(hdnquotationtrainitemid.indexOf('_') + 1);

    //alert($("#hdnQuotationTrainItemId_" + cnt).val());

    LoadModal("/Quotation/GetQuotationTrainTypeDetailsById", { QuotationItemId: $("#hdnQuotationTrainItemId_" + cnt).val() }, null, "Train Details", null);

}

function GetQuotationTrainPassDetailsById(ele) {

    //alert(ele);

    debugger;

    var hdnquotationtrainitemid = ele.id;

    var cnt = hdnquotationtrainitemid.substring(hdnquotationtrainitemid.indexOf('_') + 1);

    // alert($("#hdnQuotationTrainItemId_" + cnt).val());

    LoadModal("/Quotation/GetQuotationTrainPassDetailsById", { QuotationItemId: $("#hdnQuotationTrainItemId_" + cnt).val() }, null, "Train Details", null);

}

function CloneQuotationTrainTypeDetailsById(ele) {

    //alert(ele);

    debugger;

    var hdnquotationtrainitemid = ele.id;

    var cnt = hdnquotationtrainitemid.substring(hdnquotationtrainitemid.indexOf('_') + 1);

    // alert($("#hdnQuotationTrainItemId_" + cnt).val());

    GetAjax("/Quotation/CloneTrainTypeDetails", { QuotationItemId: $("#hdnQuotationTrainItemId_" + cnt).val() }, AfterCloneTrainTypeQuotation);

}

function AfterCloneTrainTypeQuotation() {

    // alert("traintypeclone");

    GetEnquiryItemDetailsView();
}

function CloneQuotationTrainPassDetailsById(ele) {

    //alert(ele);

    debugger;

    var hdnquotationtrainpassitemid = ele.id;

    var cnt = hdnquotationtrainpassitemid.substring(hdnquotationtrainpassitemid.indexOf('_') + 1);

    //alert($("#hdnQuotationTrainItemId_" + cnt).val());

    GetAjax("/Quotation/CloneTrainPassDetails", { QuotationItemId: $("#hdnQuotationTrainItemId_" + cnt).val() }, AfterCloneTrainPassQuotation);

}

function AfterCloneTrainPassQuotation() {

    //alert("trainpassclone");

    GetEnquiryItemDetailsView();

}

//Train End


//Hotel Start

function GetEnquiryHotelDetailsById(ele) {

    //alert("add");

    $("#modalParent").find('.modal-body').html('');

    var hdnenquiytrainitemid = ele.id;

    var cnt = hdnenquiytrainitemid.substring(hdnenquiytrainitemid.indexOf('_') + 1);

    var hsViewModel =
 {
     HotelSearch: {

         EnquiryItemId: $("#hdnHotelEnquiryItemId_" + cnt).val(),
         //CityId: $("#hdnLocation_" + cnt).val(),
         HotelTypeName: $("#hdnHotelTypeId_" + cnt).val(),
         RoomTypeId: $("#hdnRoomType_" + cnt).val(),
         StarCategory: $("#hdnStarCategory_" + cnt).val(),
         CheckinDate: $("#hdnCheckInDate_" + cnt).val(),
         CheckOutDate: $("#hdnCheckOutDate_" + cnt).val(),
         AdultCount: $("#hdnAdultCount_" + cnt).val(),
         ChildCount: $("#hdnChildCount_" + cnt).val(),
         CityId: $("#hdnCity_" + cnt).val(),
         StateId: $("#hdnState_" + cnt).val(),
         CountryId: $("#hdnCountry_" + cnt).val(),
         IsQuotationHotel: true,
     }
 } 

    if ($("#frmQuotationBasic").valid()) {

        PostAjaxJson("/HotelSearch/GetHotelSearch", hsViewModel, function (data) { $("#modalParent").find('.modal-body').append(data); });

        $("#modalParent").modal('show');
    }

}

// Hotel End


function GetEnquiryGitDetailsById(ele) {

    //alert("add");

    var hdnenquiytrainitemid = ele.id;

    var cnt = hdnenquiytrainitemid.substring(hdnenquiytrainitemid.indexOf('_') + 1);

    var pViewmodel =
 {
     Package: {
         EnquiryItemId: $("#hdnEnquiryItemId_" + cnt).val(),
         FromDate: $("#hdnFromDate" + cnt).val(),
         PackageCost: $("#hdnBudget" + cnt).val(),
         PackageType: $("#hdnPackageType" + cnt).val(),
         AdultCount: $("#hdnadult" + cnt).val(),
         ChildCount: $("#hdnchild" + cnt).val(),
         Cityid: $("#hdncity" + cnt).val(),
         StateId: $("#hdnstate" + cnt).val(),
         CountryId: $("#hdncountry" + cnt).val(),

     }
 }


    //alert(JSON.stringify(pViewmodel));

    if ($("#frmQuotationBasic").valid()) {

        PostAjaxJson("/Package/GetEnquiryGitDetailsById", pViewmodel, function (data) { $("#modalParent").find('.modal-body').append(data); });
        
        $("#modalParent").modal('show');
    }

}

function GetQuotationGitDetailsById(ele) {

    //alert(ele);

    debugger;

    var hdnquotationtrainitemid = ele.id;

    var cnt = hdnquotationtrainitemid.substring(hdnquotationtrainitemid.indexOf('_') + 1);

    //alert($("#hdnQuotationGItId_" + cnt).val());

    LoadModal("/Quotation/GetQuotationGitDetailsById", { QuotationItemId: $("#hdnQuotationGItId_" + cnt).val() }, null, "Git Details", null);

}

function DeleteGitById(ele) {

    //alert("deletegitbyid");

    var hdnQuotationItemid = ele.id;

    var cnt = hdnQuotationItemid.substring(hdnQuotationItemid.indexOf('_') + 1);

    //alert($("#hdnGitEnquiryItemId_" + cnt).val());

    GetAjax("/Quotation/DeleteGitItemById", { QuotationItemId: $("#hdnQuotationGItId_" + cnt).val() }, AfterGitDelete);

}

function AfterGitDelete(data) {

    GetEnquiryItemDetailsView();

}

function GetEnquirySightSeeingDetailsById(ele) {

    var hdnenquiytrainitemid = ele.id;

    var cnt = hdnenquiytrainitemid.substring(hdnenquiytrainitemid.indexOf('_') + 1);
    //alert(cnt);
    //alert($("#hdnSightseeingEnquiryBudget" + cnt).val());
    var sViewmodel =
{
    SightSeeing: {
        EnquiryItemId: $("#hdnSightseeingEnquiryItemId_" + cnt).val(),
        TravelDate: $("#hdnSightseeingEnquiryFromDate" + cnt).val(),
        SightSeeingCost: $("#hdnSightseeingEnquiryBudget" + cnt).val(),
        SightSeeingName: $("#hdnSightSeeingName").val(),
        AdultCount: $("#hdnSightseeingEnquiryAdult" + cnt).val(),
        ChildCount: $("#hdnSightseeingEnquirychild" + cnt).val(),
        Cityid: $("#hdnSightseeingEnquiryCity" + cnt).val(),
        StateId: $("#hdnSightseeingEnquiryState" + cnt).val(),
        CountryId: $("#hdnSightseeingEnquiryCountry" + cnt).val(),
        BtnFlag: true,
        Budget: $("#hdnSightseeingEnquiryBudget" + cnt).val(),
    }
}
    // alert(EnquiryItemId);

    //alert(JSON.stringify(sViewmodel));

    PostAjaxJson("/SightSeeing/GetSearchSightSeeingDetails", sViewmodel, function (data) { $("#modalParent").find('.modal-body').append(data); });

    $("#modalParent").modal('show');

}

// Fit Details Start

function GetEnquiryFitDetailsById(ele) {

    //alert("add");

    $("#modalParent").find('.modal-body').empty();

    debugger;

    var hdnenquiytrainitemid = ele.id;

    var cnt = hdnenquiytrainitemid.substring(hdnenquiytrainitemid.indexOf('_') + 1);

    var lptsViewModel =
 {
     LohanaPackageTariffSearch: {

         EnquiryItemId: $("#hdnFitEnquiryItemId_" + cnt).val(),
         PackageTypeId: $("#hdnPackageType" + cnt).val(),
         CountryId: $("#hdnCountryId" + cnt).val(),
         StateId: $("#hdnStateId" + cnt).val(),
         CityId: $("#hdnCityId" + cnt).val(),
         NightDuration: $("#hdnNoOfNights" + cnt).val(),
         OccupancyId: $("#hdnOccupancyId" + cnt).val(),
         StarCategory: $("#hdnStarCategory" + cnt).val(),
         CheckInDate: $("#hdnCheckInDate" + cnt).val(),
         CheckOutDate: $("#hdnCheckOutDate" + cnt).val(),
         AdultCount: $("#hdnAdultCount" + cnt).val(),
         ChildCount: $("#hdnChildCount" + cnt).val(),
         Cost: $("#hdnBudget" + cnt).val(),
         //IsHotel: true,
     },
     IsPackage: true,
 }

    //alert(JSON.stringify(lptsViewModel));

    PostAjaxJson("/LohanaPackageTariffSearch/GetLohanaPackageTariffSearch", lptsViewModel, function (data) { $("#modalParent").find('.modal-body').append(data); });

    $("#modalParent").modal('show');

}

function GetEnquirySptDetailsById(ele) {
    debugger;
    $("#modalParent").find('.modal-body').empty();
    var hdnenquiytrainitemid = ele.id;
    var cnt = hdnenquiytrainitemid.substring(hdnenquiytrainitemid.indexOf('_') + 1);

    var ssViewModel =
        {
            SupplierSearch: {
                EnquiryItemId: $("#hdnSptEnquiryItemId_" + cnt).val(),
                CityId: $("#hdnSptCityId" + cnt).val(),
                StateId: $("#hdnSptStateId" + cnt).val(),
                CountryId: $("#hdnSptCountryId" + cnt).val(),
                CheckinDate: $("#hdnSptCheckInDate" + cnt).val(),
                NoOfDays: 0,//$('#txtNoOfDays').val(),
                NoOfNights: $("#hdnSptNoOfNights" + cnt).val(),
                //ChildAge: $('#txtChildAge').val(),
                AdultCount: $("#hdnSptAdultCount" + cnt).val(),
                ChildCount: $("#hdnSptChildCount" + cnt).val(),
                Cost: $("#hdnSptBudget" + cnt).val(),
            },
            IsAddToQuotation: true,
        }

    PostAjaxJson("/SupplierSearch/GetSupplierSearch", ssViewModel, function (data) { $("#modalParent").find('.modal-body').append(data); });
    $("#modalParent").modal('show');
}


function DeleteFitById(ele) {

    //alert("deletefitbyid");

    var hdnQuotationItemid = ele.id;

    var cnt = hdnQuotationItemid.substring(hdnQuotationItemid.indexOf('_') + 1);

    GetAjax("/Quotation/DeleteGitItemById", { QuotationItemId: $("#hdnQuotationFitId_" + cnt).val() }, AfterFitDelete);

}

function DeleteSptById(ele) {
    var hdnQuotationItemid = ele.id;
    var cnt = hdnQuotationItemid.substring(hdnQuotationItemid.indexOf('_') + 1);
    GetAjax("/Quotation/DeleteGitItemById", { QuotationItemId: $("#hdnQuotationSptId_" + cnt).val() }, AfterFitDelete);
}

function AfterFitDelete(data) {

    GetEnquiryItemDetailsView();

}

// Fit Details End
function DeleteSightSeeingById(ele) {
    //alert();
    var hdnQuotationItemid = ele.id;

    var cnt = hdnQuotationItemid.substring(hdnQuotationItemid.indexOf('_') + 1);

    //alert($("#hdnQuotationSightSeeingId_" + cnt).val());

    GetAjax("/Quotation/DeleteSightSeeingItemById", { QuotationItemId: $("#hdnQuotationSightSeeingId_" + cnt).val() }, AfterSightSeeingDelete);

}

function AfterSightSeeingDelete(data) {
    GetEnquiryItemDetailsView();
}
