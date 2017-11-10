$(function ()
{

    GetAutocompleteScript("Hotel");

	$("#btnAddHotelRoomType").click(function ()
	{
		if ($("#frmHotelRoomTypeDetails").valid())
		{
			SaveHotelRoomType();
		}
	});

	//$("#btnEditHotelRoomType").click(function ()
	//{
	//	GetHotelRoomTypeById();
	//});

	$(document).on('change', "#tblHotelRoomType [name='c1']", function (event)
	{
		if ($(this).prop('checked'))
		{
			var id = $(this).attr("data-roomtypedetailsid");

			$("#hdnSearchHotelRoomTypeId").val(id);

			GetHotelRoomTypeById();

			$("#btnDeleteHotelRoomType").removeAttr("disabled");


		}
	});

	$("#btnDeleteHotelRoomType").click(function ()
	{
		DeleteHotelRoomType();
	});


});