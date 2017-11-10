$(document).ready(function ()
{
   
	GetAutocompleteScript("Supplier Hotel Tariff");

    GetSupplierHotelTariffDetail();

    $('.from-to-date').datepicker({
    	toggleActive: true
    });

    $("#btnAddSupplierHotelTariff").on('click', function ()
    {
        if ($("#frmBasicDetail").valid())
        {
            SaveSupplierHotelTariffDetail();
        }        
    });

    $("#btnResetSupplierHotelTariff").click(function () {
        ResetSupplierHotel();
    });


    $(document).on('change',"#tblSupplierHotelTariffDetails input[type=radio]", function (event)
    {
        debugger;

        if ($(this).prop('checked'))

            //GetSetSupplierHotelTariffValues($(this));
    	{
    		$("[name='SupplierHotelTariff.SupplierHotelId']").val($(this).attr("data-supplierhotelid"));

    		$("[name='SupplierHotelDetail.SupplierHotelId']").val($(this).attr("data-supplierhotelid"));

    		$("[name='SupplierOccupancyDetail.SupplierHotelId']").val($(this).attr("data-supplierhotelid"));

            //$("[name='SupplierHotelPrice.SupplierHotelId']").val($(this).attr("data-supplierhotelid"));

    		//SetSupplierHotelDetail($(this));

    		SetActive($("[name='SupplierHotelTariff.IsActive']"), $(this).attr("data-isactive"));

    		//GetSupplierHotelDetail();
    		
    		GetSupplierHotelTariffDays($(this).attr("data-supplierhotelid"));

    		GetSupplierOccupancyDetail();

    		$("#txtPackageName").val($(this).attr("data-packagename"));

    		var vendorid = $(this).attr("data-supplierid");

    		$("[name='SupplierHotelTariff.SupplierId']").attr("data-value", vendorid);
    
    		GetAutocompleteById("SupplierHotelTariff.SupplierId");

    		$("#lblPackageName").text($(this).attr("data-packagename"));

    		$("#lblSupplier").text($(this).attr("data-vendorname"));

    		$("#txtDayduration").val($(this).attr("data-dayduration"));

    		$("#txtNightduration").val($(this).attr("data-nightduration"));

    		document.getElementById("txtNightduration").readOnly = true;



    		//GetSetSupplierHotelTariffValues($(this));

    		//GetSupplierHotelTariffPrice();
    	}
    });

    

});







