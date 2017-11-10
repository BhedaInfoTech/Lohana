$(document).ready(function ()
{  
    $("#btnAddSupplierHotelDetail").on('click', function ()
    {
        if ($("#frmHotelDetail").valid())
        {
            SaveSupplierHotelDetail();
        }        
    });

    $("#btnResetHotelDetail").on('click', function ()
    {
        ResetSupplierHotelDetail();

        $("#hdnSupplierHotelDetailId").val('');
    });

    $("#btnDeleteHotelDetail").on('click', function ()
    {
        DeleteSupplierHotelDetail();
    });

    $(document).on('change',"#tblSupplierHotelDetails input[type=radio]", function (event)
    {
    	if ($(this).prop('checked'))
    	{
    	    $("[name='SupplierHotelDetail.SupplierHotelDetailId']").val($(this).attr("data-supplierhoteldetailid"));

    		$("#btnDeleteHotelDetail").removeAttr("disabled");

    		SetHotelDetail($(this));
    	}
    });
    
   
});