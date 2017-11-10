
$(function ()
{
	$("#btnSaveHotelFacilityDetails").click(function ()
	{
		if ($("#frmHotelFacilityDetails").valid())
		{
			SaveHotelFacilityDetails();
		}
	});

	$(".facility-status").on("change",function ()
	{
		if (this.checked)
		{
			$(this).val(true);
		}
		else
		{
			$(this).val(false);
		}
	});

});