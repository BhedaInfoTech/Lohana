function AddHotelQuotation(obj) {

    //alert($("[name='Quotation.FollowupDate']").val());

    var qViewModel =
       {
           Quotation: {

               EnquiryItemId: $("#hdnHotelEnquiryItemId").val(),

               EnquiryType: $("#hdnQuotationType").val(),

               HotelId: $(obj).parents(".m-item").find(".room-data").attr("data-hotelid"),

               //HotelTypeId: $(obj).parents(".m-item").find(".room-data").attr("data-hoteltype"),

               //StarCategory: $(obj).parents(".m-item").find(".room-data").attr("data-starcategory"),

               CityId: $(obj).parents(".m-item").find(".room-data").attr("data-cityid"),

               RoomType: $(obj).parents(".m-item").find(".room-data").attr("data-roomtypeid"),

               Cost: $(obj).parents(".m-item").find(".room-price").val(),

               //QuoteRate: $("#txtquoteRate").val(),

               AdultCount: $("#hdnAdultCount").val(),

               ChildCount: $("#hdnChildCount").val(),

               CheckInDate: $("#hdnCheckinDate").val(),

               CheckOutDate: $("#hdnCheckOutDate").val(),

               QuotationId: $("#hdnQuotationId").val(),

               FollowupDate: $("[name='Quotation.FollowupDate']").val(),

               AssigneeToId: $("[name='Quotation.AssigneeToId']").val(),

               EnquiryId: $("[name='Enquiry.EnquiryId']").val(),

               IsApproval: $("[name='IsApproval']").val(),

           }
       }

    alert(JSON.stringify(qViewModel));

    var url = "/Quotation/InsertQuotationItem";

    PostAjaxWithProcessJson(url, qViewModel, AfterQuotationHotelSave, $("body"));

}

function AfterQuotationHotelSave(data) {

    //alert(data);

    FriendlyMessage(data);

    //alert("AfterFlightSave")

    // alert($("#hdnQuotationId").val(data.Quotation.QuotationId));

    $("#hdnQuotationId").val(data.Quotation.QuotationId);

    //alert($("#hdnFlightId").val(data.Enquiry.EnquiryItemId));

    $("#hdnFlightId").val(data.Quotation.QuotationItemId);

    $("#hdnQuotationType").val(data.Quotation.EnquiryType);

    //alert(data.Enquiry.EnquiryType);

    GetEnquiryItemDetailsView();

}

function AddHotelInCart(obj) {

    var QuotationItemA = [];

    //alert();
    var Quotation = {

        VendorId: $(obj).parents(".m-item").find(".room-data").attr("data-vendorid"),
        HotelName: $(obj).parents(".m-item").find(".room-data").attr("data-hotelname"),
        HotelTypeName: $(obj).parents(".m-item").find(".room-data").attr("data-hoteltype"),
        ProductType: $(obj).parents(".m-item").find(".room-data").attr("data-producttype"),

        StarCategoryStr: $(obj).parents(".m-item").find(".room-data").attr("data-starcat"),
        CityName: $(obj).parents(".m-item").find(".room-data").attr("data-city"),
        RoomTypeName: $(obj).parents(".m-item").find(".room-data").attr("data-roomtype"),
        OccupancyCapacity: $(obj).parents(".m-item").find(".room-data").attr("data-capacity"),
        MealName: $(obj).parents(".m-item").find(".room-data").attr("data-meal"),
        HotelDescription: $(obj).parents(".m-item").find(".room-data").attr("data-hoteldesc"), 
        NoOfNight: $(obj).parents(".m-item").find(".room-data").attr("data-noofnight"), 
        NetRatePerNight: $(obj).parents(".m-item").find(".room-data").attr("data-netratepernight"),
        NetRate: $(obj).parents(".m-item").find(".room-data").attr("data-netrate"),
        NoOfRooms: $(obj).parents(".m-item").find(".room-data").attr("data-noofrooms"),
        CheckInTime: $(obj).parents(".m-item").find(".room-data").attr("data-checkintime"),
        CheckOutTime: $(obj).parents(".m-item").find(".room-data").attr("data-checkouttime"),

        OccupancyName: $(obj).parents(".m-item").find(".room-data").attr("data-occupancy"),
        HotelRoomPrice: $(obj).parents(".m-item").find(".room-data").attr("data-roomprice"),
        //NoOfNight: $(obj).parents(".m-item").find(".room-data").attr("data-noofnight"),
    }

    QuotationItemA.push(Quotation);
    //alert(JSON.stringify(QuotationItemA));


    var qViewModel =
       {
           Quotation: {

               QuatationItem: QuotationItemA

           }
       }

    var url = "/HotelSearch/HotelAddToCart"; 

    $.ajax({

        url: url,

        data: JSON.stringify(qViewModel),

        datatype: "json",

        type: "POST",

        contentType: 'application/json',

        success: function (data) {
            //alert("Hotel added in your cart Succesfully.");
        }

    });

}

function CalculatePrice(obj) {  

        var finalPrice = 0;
        var noOccupancy = $(obj).val();
        var HotelRoomPrice = $(obj).parents(".m-item").find(".room-data").attr("data-roomprice");

        finalPrice = noOccupancy * HotelRoomPrice;

        $("[name='" + $(obj).closest('.HotelList').find('.room-price').attr('name') + "']").val(finalPrice);
        //$($(obj).parents(".m-item").find(".room-data").attr("data-roomprice")).val(finalPrice);
}