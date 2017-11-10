

function SaveHotelFacilityDetails()
{
	var HotelFacilityList = [];

	$(".facility-status").each(function ()
	{
		var demo =
                {
                	FacilityId: $(this).parent().find(".facility-id").val(),

                	FacilityStatus: $(this).val(),

                	HotelId: $("[name='Facility.HotelId']").val(),
                }

			HotelFacilityList.push(demo);
	});

	var hViewModel = {

		HotelFacilityDetails: HotelFacilityList,

		Hotel: {
			HotelId: $("[name='Facility.HotelId']").val(),
		}
	}

	var url = "";

	url = "/Hotel/InsertHotelFacilityDetails"

	//PostAjaxJson(url, hViewModel, AfterSave);

	PostAjaxWithProcessJson(url, hViewModel, HotelFacilitiesave, $("#frmHotelFacilityDetails"));
}

function HotelFacilitiesave(data)
{
    FriendlyMessage(data);

}





































//for (var i = 0 ; i < 14  ; i++)
//{
//	if ($("#chkHotelFacilityStatus_" + i).val().toLocaleLowerCase() == "true")
//	{
//		activeFlg = true;
//	}
//	else
//	{
//		activeFlg = false;
//	}

//	if ($("#chkHotelFacilityStatus_" + i))
//	{
//		var demo =
//            {
//            	FacilityId: $("#hdnfacilityId_" + i).val(),

//            	FacilityStatus: activeFlg,

//            	HotelId: $("[name='Facility.HotelId']").val(),
//            }

//		HotelFacilityList.push(demo);
//	}
//}

