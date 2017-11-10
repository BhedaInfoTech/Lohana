function AddQuotation(SightSeeingName,Location, NetRate, Duration) {
    var qViewModel = {
        Quotation: {
            SightSeeingName: SightSeeingName,
            Location: Location,
            Cost: NetRate,
            EnquiryItemId: $("#hdnSightSeeingid").val(),
            FromDate: $("#hdnDate").val(),
            TravelDate: $("#hdnTravelDate").val(),
            EnquiryType: $("#hdnQuotationType").val(),
            PackageDuration: Duration,
            AdultCount: $("#hdnadult").val(),
            ChildCount: $("#hdnchild").val(),
            countryId: $("#hdnCountryId").val(),
            stateId: $("#hdnStateId").val(),
            cityid: $("#hdnCityId").val(),
            BtnFlag: true,
            QuotationId: $("#hdnQuotationId").val(),
        }

    }
    var url = "/Quotation/InsertQuotationItem"
    //alert(JSON.stringify(qViewModel));
    PostAjaxWithProcessJson(url, qViewModel, SightSeeingQuotation, $("body"));
}


function SightSeeingQuotation(Data) {
    FriendlyMessage(Data);

    GetEnquiryItemDetailsView();
}

//function AddToQuotation()
//{
//    var SightSeeingId = $("#hdnSightSeeingId").val();
//    var SightSeeingName = $("#lblSightSeeingName").text();
//   // var PackageLocation = $("#lblLocation").text();
//    // var Duration = $("#lblDuration").text();
//    var Location = $("#hdnLocation").val();
//    var Duration = $("#hdnDuration").val();    
//    var NetRate = $("#lblTotalCost").val();
//    var TravelDate = $("#hdnDate").val();

//    var trrow = $("#tblSightSeeingDetails").find('tr').size() - 1;   
//    if(SightSeeingId !=0)
//    {
//        var tr = "<tr id='tr" + trrow + "'>";
//        tr += "<td>";
//        tr += "<input type='hidden' id=(hdnQuotationSightSeeingId_+ counter)" + SightSeeingId + "/>";
//        tr += "</td>";
//        tr +="<td>";
//        tr += "<span id='trCategory'>" + SightSeeingName + "</span>";
//        tr +="</td>";
//        tr +="<td>";
//        tr += "<span id='trCategory'>" + Location + "</span>";
//        tr +="</td>";
//        tr +="<td>";
//        tr += "<span id='trCategory'>" + Duration + "</span>";
//        tr +="</td>";
//        tr +="<td>";
//        tr += "<span id='trCategory'>" + NetRate + "</span>";
//        tr +="</td>";
//        tr +="<td>";
//        tr +="<span id='trCategory'>"+ TravelDate+"</span>";
//        tr +="</td>";       
//        tr +="<td>";
//        tr +=" <button type='button' class='btn btn-danger btn-rounded waves-effect waves-light btn-model-times' style='font-size: 15px;' value='1'><i class='fa fa-times'></i></button>";
//        tr +="</td>";                                            
                                        
//        $("#tblSightSeeingDetails").append(tr);
                                  
//    }
    
//}