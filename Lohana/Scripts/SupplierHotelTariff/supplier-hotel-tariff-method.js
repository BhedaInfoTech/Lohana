
function SaveSupplierHotelTariffDetail()
{
    var activeFlg = true;

    if ($("[name='SupplierHotelTariff.IsActive']").val() == 1 || $("[name='SupplierHotelTariff.IsActive']").val() == "true")
    {
        activeFlg = true;
    }
    else
    {
        activeFlg = false;
    }

    var sViewModel = {

        SupplierHotelTariff: {

        	SupplierHotelId: $("[name='SupplierHotelTariff.SupplierHotelId']").val(),

        	SupplierId: $("[name='SupplierHotelTariff.SupplierId']").val(),

            PackageName: $("[name='SupplierHotelTariff.PackageName']").val(),

            IsActive: activeFlg,

            DayDuration: $("[name='SupplierHotelTariff.DayDuration']").val(),

            NightDuration: $("[name='SupplierHotelTariff.NightDuration']").val(),
        }
    }

    var url = "";


    if ($("#hdnSupplierHotelId").val() == 0)
    {

    	url = "/SupplierHotelTariff/InsertSupplierHotel"
    }
    else {
        url = "/SupplierHotelTariff/UpdateSupplierHotel"
    }

    PostAjaxWithProcessJson(url, sViewModel, AfterSave, $("body"));
}

function AfterSave(data)
{
    FriendlyMessage(data);

    ResetSupplierHotel();

    GetSupplierHotelTariffDetail();
}

function GetSupplierHotelTariffDetail()
{
    var sViewModel =
		{  
		    Pager: {

		        CurrentPage: $('#tblSupplierHotelTariffDetails').attr("data-current-page"),
		    },
		}

    PostAjaxWithProcessJson("/SupplierHotelTariff/GetSupplierHotel", sViewModel, BindSupplierHotelTariffDetail, $("#frmSupplierHotelTariff"));
}

function BindSupplierHotelTariffDetail(data)
{
    var list = JSON.parse(data);

    var kTable = {
        dataList: ["VendorName", "PackageName", "IsActiveStr"],
        primayKey: "SupplierHotelId",
        hiddenFields: ["SupplierHotelId", "PackageName", "IsActiveStr", "SupplierId", "VendorName", "IsActive","DayDuration","NightDuration"],
        headerNames: ["Supplier", "Package",  "Is Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblSupplierHotelTariffDetails'));

    BindPagination(list.Pager, $('#tblSupplierHotelTariffDetails'));
}

//function GetSetHotelTariffValues(obj) {

//    var id = $(obj).attr("data-hoteltariffid");

//    var vendorid = $(obj).attr("data-vendorid");

//    var hotelid = $(obj).attr("data-hotelid");

//    var cityid = $(obj).attr("data-cityid");

//    var vendorname = $(obj).attr("data-vendorname");

//    $("#lblSupplier").text(vendorname);

//    $("#lblHotel").text(hotelname);

function ResetSupplierHotel() {

    $("#drpVendor").html("");

    $("[name='SupplierHotelTariff.SupplierId']").html("");

    $("#txtPackageName").val("");

    $("#txtNightduration").removeAttr("disabled");

    if ($("[name='SupplierHotelTariff.IsActive']").val() == 0 || $("[name='SupplierHotelTariff.IsActive']").val() == "false")
    {
        $("[name='SupplierHotelTariff.IsActive']").trigger('click');
    }

    $("#dvBasicDetail input[type='radio']").attr("checked", false);

    $('#hdnOldVendorId').val("0");

    $("#hdnSupplierHotelId").val("0");

    $("#txtDayduration").val("");

    $("#txtNightduration").val("");

    document.getElementById("txtNightduration").readOnly = false;
    
    
}

function Pagination(CurrentPage)
{
	$('#tblSupplierHotelTariffDetails').attr("data-current-page", CurrentPage);

	GetSupplierHotelTariffDetail();
}

//function SetSupplierHotelDetail(obj)
//{
//    var vendorId = obj.attr("data-supplierid");

//    //var supplier = obj.attr("data-supplier")

//    var packageName = obj.attr("data-packagename");

//    var vendorName = obj.attr("data-vendorname");

//	$("[name='SupplierHotelTariff.SupplierId']").attr("data-value", vendorId);

//	GetAutocompleteById("SupplierHotelTariff.SupplierId");

//	$("#txtPackageName").val(packageName);

//	//$("#lblSupplier").text(vendorId);

//	$("#lblPackageName").text(packageName);

//	$("#lblSupplier").text(vendorName);

//	ResetSupplierHotel();
//}

//GetSetSupplierHotelTariffValues(obj)
//{
//    var suppliername = $(obj).attr("data-suppliername");

//    var packagename = $(obj).attr("data-packagename");

//    $("#lblSupplier").text(suppliername);

//    $("#lblPackageName").text(packagename);

//}
