function AddQuotation(PackageName, PackageCategoryId, FinalCost, PackageDuration) {
    var qViewModel = {
        Quotation: {
            PackageName: PackageName,
            CategoryId: PackageCategoryId,
            PackageType: $("#hdntype").val(),
            Cost: FinalCost,
            EnquiryItemId: $("#hdnGitid").val(),
            FromDate: $("#hdnDate").val(),
            EnquiryType: $("#hdnQuotationType").val(),
            PackageDuration: PackageDuration,
            AdultCount: $("#hdnadult").val(),
            ChildCount: $("#hdnchild").val(),
            countryId: $("#hdnCountryId").val(),
            stateId: $("#hdnStateId").val(),
            cityid: $("#hdnCityId").val(),
            QuotationId: $("#hdnQuotationId").val(),

        }
        
    }
    var url = "/Quotation/InsertQuotationItem"
    //alert(JSON.stringify(qViewModel));
    PostAjaxWithProcessJson(url, qViewModel,GitQuotation,$("body"));
}

function GitQuotation(Data){
    FriendlyMessage(Data);
   
    GetEnquiryItemDetailsView();
}