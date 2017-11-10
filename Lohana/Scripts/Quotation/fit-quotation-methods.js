function AddFitQuotation(PackageName, Cost, LPTDuration, CountryId, StateId, CityId, PackageTypeId, cnt) {

    debugger;

    var qViewModel =
        {
            Quotation:
                {
                    PackageName: PackageName,
                    PackageType: PackageTypeId,
                    Cost: Cost,
                    EnquiryItemId: $("#hdnFitid").val(),
                    CheckInDate: $("#hdnCheckInDate").val(),
                    CheckOutDate: $("#hdnCheckOutDate").val(),
                    EnquiryType: $("#hdnQuotationType").val(),
                    PackageDuration: LPTDuration,
                    RoomTypeId: $("#hdnRoomTypeId").val(),
                    AdultCount: $("#hdnAdultCount").val(),
                    ChildCount: $("#hdnChildCount").val(),
                    CountryId: CountryId,
                    StateId: StateId,
                    Cityid: CityId,
                    RoomCount: $("#txtNoOfRooms_"+ cnt).val(),
                    FinalCost: $("#lblLPTFinalCost_" + cnt).text(),
                    QuotationId: $("#hdnQuotationId").val(),
                }

        }
    var url = "/Quotation/InsertQuotationItem"

    //alert(JSON.stringify(qViewModel));

    PostAjaxWithProcessJson(url, qViewModel, FitQuotation, $("body"));
}

function FitQuotation(Data) {

    FriendlyMessage(Data);

    GetEnquiryItemDetailsView();
  
}