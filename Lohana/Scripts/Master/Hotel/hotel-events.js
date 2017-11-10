$(document).ready(function ()
{

    GetAutocompleteScript("Hotel");


	if ($("[name='Hotel.HotelId']").val() == 0)
	{
		$("#link1").hide();
		$("#link2").hide();
		$("#link3").hide();
		$("#link4").hide();
		$("#link5").hide();
	}
	else
	{
		$("#link1").show();
		$("#link2").show();
		$("#link3").show();
		$("#link4").show();
		$("#link5").show();
	}

	GetHotelRoomType();

	GetContactPerson();

	GetHotelBank();

	GetImagesByRefType();


	$("#basicdetails").show();

	$("#btnSaveBasicDetails").click(function ()
	{
		if ($("#frmHotelBasicDetails").valid())
		{
			SaveBasicDetails();

			$(".nav-link").show();
		}
	});

	$("#btnResetBasicDetails").click(function () {

	    document.getElementById("frmHotelBasicDetails").reset();

	    Reset
	});

	$('.file').on('change', function (e)
	{
	    var files = e.target.files;

	    UploadFile($(this), files);
	});
        
	$(".removeimg").on("click", function (e)
	{
	    e.stopImmediatePropagation();

	    removeImg($(this));
	});

	
});