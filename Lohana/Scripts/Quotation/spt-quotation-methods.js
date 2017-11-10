
function AddSptQuotation(PackageName, Cost, Duration) {

    var qViewModel =
        {
            Quotation:
                {
                    PackageName: PackageName,
                    PackageType: $("#hdnPackageTypeId").val(),
                    Cost: Cost,
                    EnquiryItemId: $("#hdnSptid").val(),
                    CheckInDate: $("#hdnSptCheckInDate").val(),
                    CheckOutDate: $("#hdnSptCheckOutDate").val(),
                    EnquiryType: $("#hdnSptQuotationType").val(),
                    PackageDuration: Duration,
                    RoomTypeId: $("#hdnSptRoomTypeId").val(),
                    AdultCount: $("#hdnSptAdultCount").val(),
                    ChildCount: $("#hdnSptChildCount").val(),
                    CountryId: $("#hdnSptCountryId").val(),
                    StateId: $("#hdnSptStateId").val(),
                    Cityid: $("#hdnSptCityId").val(),
                    QuotationId: $("#hdnQuotationId").val()

                }

        }
    var url = "/Quotation/InsertQuotationItem"

    //alert(JSON.stringify(qViewModel));

    PostAjaxWithProcessJson(url, qViewModel, SptQuotation, $("body"));
}

function SptQuotation(Data) {

    FriendlyMessage(Data);

    GetEnquiryItemDetailsView();
}