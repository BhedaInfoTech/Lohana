function SaveSupplierHotelDetail()
{
    var sViewModel =
        {
            SupplierHotelDetail: {

            	SupplierHotelId: $("[name='SupplierHotelDetail.SupplierHotelId']").val(),

            	SupplierHoteDetaillId: $("[name='SupplierHotelDetail.SupplierHotelDetailId']").val(),

                CityId: $("[name='SupplierHotelDetail.CityId']").val(),

                HotelId: $("[name='SupplierHotelDetail.HotelId']").val(),

                RoomTypeId: $("[name='SupplierHotelDetail.RoomTypeId']").val(),

                MealId: $("[name='SupplierHotelDetail.MealId']").val(),

                TotalNights: $("[name='SupplierHotelDetail.TotalNights']").val(),

                MealInclusions: $("[name='SupplierHotelDetail.MealInclusions']").val(),

            }
        }

    var url = "";


    if ($("[name='SupplierHotelDetail.SupplierHotelDetailId']").val() == 0)
    {

    	url = "/SupplierHotelTariff/InsertSupplierHotelDetail"
    }
    else {
    	url = "/SupplierHotelTariff/UpdateSupplierHotelDetail"
    }

    PostAjaxWithProcessJson(url, sViewModel, AfterSupplerHotelDetailSave, $("body"));
}

function AfterSupplerHotelDetailSave(data)
{
    FriendlyMessage(data);

    ResetSupplierHotelDetail();

    GetSupplierHotelDetail();
}

function GetSupplierHotelDetail() {
    var sViewModel =
		{
		    SupplierHotelDetail: {

		    	SupplierHotelId: $("[name='SupplierHotelDetail.SupplierHotelId']").val(),
		    },
		    Pager: {

		        CurrentPage: $('#tblSupplierHotelDetails').attr("data-current-page"),
		    },
		}

    PostAjaxWithProcessJson("/SupplierHotelTariff/GetSupplierHotelDetail", sViewModel, BindSupplierHotelDetail, $('#tblSupplierHotelDetails'));
}

function BindSupplierHotelDetail(data)
{
    var list = JSON.parse(data);
    var hotelStr = "";
   
    for (var i = 0 ; i < list.dt.length; i++)
    {
    //    var hotelname[i]= list.dt[i].HotelName
        
        //var hotelname[i] = document.getElementById('#lblHotelName').innerHTML

        //var html = "";

        //html += "<tr class='pf-row'>";

        //html += "<td>";
        //html += data.State;
        //html += "<input type='hidden' class='pf-state' name='vendor.AddressList[" + i + "].State' value='" + data.State + "'>";
        //html += "</td>";

        hotelStr += "<label>" + list.dt[i].HotelName + " " + "("+list.dt[i].CityName+")" + "</label><br>";
                                       
           }
    $("#dvHotelDetails").html(hotelStr);

        var kTable = {
        dataList: ["CityName", "HotelName", "TotalNights", "RoomTypeName", "MealName", "MealInclusions"],
        primayKey: "SupplierHotelDetailId",
        hiddenFields: ["SupplierHotelDetailId", "CityId", "HotelId", "TotalNights", "RoomTypeId", "MealId", "MealInclusions"],
        headerNames: ["Location", "Hotel Name", "No. of Nights", "Room Type", "Meal Type", "Meal Inclusions"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblSupplierHotelDetails'));

    BindPagination(list.Pager, $('#tblSupplierHotelDetails'), "SupplierHotelPagination");



}

function SupplierHotelPagination(CurrentPage) {

    $('#tblSupplierHotelDetails').attr("data-current-page", CurrentPage);

    GetSupplierHotelDetail();
}

function ResetSupplierHotelDetail() {

	$("[name='SupplierHotelDetail.CityId']").html("");

	$("[name='SupplierHotelDetail.HotelId']").html("");

	$("[name='SupplierHotelDetail.TotalNights']").val("");

	$("[name='SupplierHotelDetail.RoomTypeId']").html("");

	$("[name='SupplierHotelDetail.MealId']").html("");

	$("[name='SupplierHotelDetail.MealInclusions']").val("");

	$("[name='SupplierHotelDetail.SupplierHotelDetailId']").val(0);

    $("#btnDeleteHotelDetail").attr("disabled",true);
}

function FillHotelDDL(LocationId)
{
    var sViewModel =
		{
		    SupplierHotelDetail: {

		        CityId: LocationId,
		    },
		}

    PostAjaxWithProcessJson("/SupplierHotelTariff/GetHotelByLocation", sViewModel, BindHotelDropdown, $("body"));
}

function BindHotelDropdown(data)
{   
    $('#drpHotel').empty();

    $('#drpHotel').append(new Option("Select Hotel", "0"));

    $.each(data.LstHotel, function (index, item)
    {
        $('#drpHotel').append(new Option(item.HotelName, item.HotelId));
    });

    $('#drpHotel').val($("#hdnDDLHotelId").val());   
}

function SetHotelDetail(obj)
{
    var id = obj.attr("data-supplierhoteldetailid");

    var locationId = obj.attr("data-cityid");

    var hotelId = obj.attr("data-hotelid");

    var noOfNights = obj.attr("data-totalnights");

    var roomTypeId = obj.attr("data-roomtypeid");

    var mealTypeId = obj.attr("data-mealid");

    var mealInclusions = obj.attr("data-mealinclusions");

    $("[name='SupplierHotelDetail.CityId']").attr("data-value", locationId);

    GetAutocompleteById("SupplierHotelDetail.CityId");

    $("[name='SupplierHotelDetail.HotelId']").attr("data-value", hotelId);

    GetAutocompleteById("SupplierHotelDetail.HotelId");

    $("[name='SupplierHotelDetail.TotalNights']").val(noOfNights);

    $("[name='SupplierHotelDetail.RoomTypeId']").attr("data-value", roomTypeId);

    GetAutocompleteById("SupplierHotelDetail.RoomTypeId");

    $("[name='SupplierHotelDetail.MealId']").attr("data-value", mealTypeId);

    GetAutocompleteById("SupplierHotelDetail.MealId");   

    $("[name='SupplierHotelDetail.MealInclusions']").val(mealInclusions);

    $("[name='SupplierHotelDetail.SupplierHoteDetaillId']").val(id);
}

function DeleteSupplierHotelDetail()
{   
	DisplayConformationPopup("Do you want to delete hotel details ? ", null, "Conformation Popup", function ()
	{
		GetAjax("/SupplierHotelTariff/DeleteSupplierHotelDetail", { supplierHoteDetaillId: $("[name='SupplierHotelDetail.SupplierHotelDetailId']").val() }, AfterSupplerHotelDetailSave);
	}, null);
}

