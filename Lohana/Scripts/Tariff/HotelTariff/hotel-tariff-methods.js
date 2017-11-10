
function SaveHotelTariffBasic() {

   
    $("#frmHotelTariffBasic").blur();

    var htViewModel = {

        HotelTariff: {

            HotelTariffId: $("[name='Filter.HotelTariffId']").val(),

            VendorId: $("#drpVendor").val(),

            HotelId: $("#drpHotel").val(),

            CityId: $("#drpCity").val(),

        }
    }
    var url = "";

    if ($("[name='Filter.HotelTariffId']").val() == 0) {

        url = "/HotelTariff/InsertHotelTariff"
    }
    else {

        url = "/HotelTariff/UpdateHotelTariff"
    }
    PostAjaxJson(url, htViewModel, AfterBasicSave);
}

function AfterBasicSave(data) {

    FriendlyMessage(data);

    ResetBasic();

    GetHotelTariffBasic();


}

function ResetBasic() {

    $("#drpHotel").html("");

    $("#drpVendor").html("");

    $("#drpCity").html("");

    $("#hdnSearchHotelTariffId").val('');

    $("#tblHotelTariff [name='c1']").removeAttr("checked");

}

function GetHotelTariffBasic() {

    var htViewModel =
		{
		    HotelTariff: {

		        VendorId: $("#drpVendor").val(),

		        HotelId: $("#drpHotel").val(),

		        CityId: $("#drpCity").val(),
		    },
		    Pager: {

		        CurrentPage: $('#tblHotelTariff').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/HotelTariff/GetHotelTariff", htViewModel, BindHotelTariffBasic);
}

function BindHotelTariffBasic(data) {
    //alert(JSON.stringify(data));
    //alert(data);

    var list = JSON.parse(data);

    //alert(JSON.stringify(list));
    
   
    //for (var i = 0 ; i < list.dt.length; i++) {
    //    ìf(list.dt[i].VendorName == null)
    //    {
    //        var  = $("VendorName").text(list.dt[i].HotelName);
    //    }
    //}
       

    var kTable = {
        dataList: ["VendorName", "CityName", "HotelName"],
      
        primayKey: ["HotelTariffId","VendorId","HotelId","CityId"],
        hiddenFields: ["HotelTariffId", "VendorId", "HotelId","CityId","VendorName","HotelName","CityName"],
        headerNames: ["Vendor Name","City Name", "Hotel Name"],
        data: list.dt,
    }
    //alert(JSON.stringify(kTable));
    //for (var i = 0; i < data.length; i++)
    //{
    //    if(data[i].VendorName==null){
    //        $("data[i].VendorName").val(data[i].HotelName);
    //    }
    //}
    
    buildHtmlTable(kTable, $('#tblHotelTariff'));

    BindPagination(list.Pager, $('#tblHotelTariff'), "HotelTariffBasicPagination");

}

function GetSetHotelTariffValues(obj) {
    

    var id = $(obj).attr("data-hoteltariffid");

    var vendorid = $(obj).attr("data-vendorid");
    
    var hotelid = $(obj).attr("data-hotelid");

    var cityid = $(obj).attr("data-cityid");

    //if ($(obj).attr("data-hoteltariffid") == null) {
    //    $("VendorName").text(list.HotelName);
    //}

    var vendorname = $(obj).attr("data-vendorname");

    //if (vendorname == "")
    //{
    //    var vendorname = $(obj).attr("data-hotelname");
    //}
    
    var hotelname = $(obj).attr("data-hotelname");

    $("#drpVendor").attr("data-value",vendorid);

    $("#drpCity").attr("data-value", cityid);

    $("#drpHotel").attr("data-value", hotelid);

    $("#lblSupplier").text(vendorname);
    

    $("#lblHotel").text(hotelname);

    GetAutocompleteById("HotelTariff.CityId");

    GetAutocompleteById("HotelTariff.HotelId");

    GetAutocompleteById("HotelTariff.VendorId");

    $("[name='HotelTariffRoom.HotelTariffId']").val(id);

    ResetRoom();

    GetHotelTariffRoom();
}

function HotelTariffBasicPagination(CurrentPage) {

    $('#tblHotelTariff').attr("data-current-page", CurrentPage);

    GetHotelTariffBasic();

}

