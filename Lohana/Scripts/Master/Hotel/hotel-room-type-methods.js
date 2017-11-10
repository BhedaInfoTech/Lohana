

function SaveHotelRoomType()
{
	$("#frmHotelRoomTypeDetails").blur();

	var hViewModel = {

	    HotelRoomType: {

			RoomTypeDetailsId: $("#hdnSearchHotelRoomTypeId").val(),

			RoomTypeId: $("#drpRoom").val(),

			NoOfRooms: $("[name='Hotel.noOfRooms']").val(),

			OccupancyCapacity: $("[name='Hotel.occupancy']").val(),

			HotelId: $("[name='HotelRoomType.HotelId']").val(),
		}
	}
	var url = "";

	if ($("#hdnSearchHotelRoomTypeId").val() == 0)
	{
		url = "/Hotel/InsertHotelRoomType"
	}
	else
	{
		url = "/Hotel/UpdateHotelRoomType"
	}
	PostAjaxJson(url, hViewModel, AfterHotelRoomTypeSave);
}

function AfterHotelRoomTypeSave(data)
{

    var obj = $.parseJSON(data);

    FriendlyMessage(obj);

	$("[name='HotelRoomType.HotelId']").val(obj.HotelRoomType.HotelId);

	$("[name='HotelContactPerson.HotelId']").val(obj.HotelRoomType.HotelId);

	GetHotelRoomType();

	ResetHotelRoomType();
}

function ResetHotelRoomType()
{

    $("#hdnSearchHotelRoomTypeId").val('');

	$("#drpRoom").val("0");

	$("#txtnoOfRooms").val('');

	$("#txtoccupancy").val('');
}

function GetHotelRoomType()
{
	var hViewModel =
		{
			HotelRoomType: {
				HotelId: $("[name='HotelRoomType.HotelId']").val()
			},
			Pager: {
				CurrentPage: $('#tblHotelRoomType').attr("data-current-page"),
			},
		}

	PostAjaxJson("/Hotel/GetHotelRoomType", hViewModel, BindHotelRoomType);
}

function BindHotelRoomType(data)
{
	var list = JSON.parse(data);

	var kTable = {
		dataList: ["RoomTypeName", "NoOfRooms", "OccupancyCapacity"],
		primayKey: "RoomTypeDetailsId",
		hiddenFields: ["RoomTypeDetailsId", "RoomTypeId", "RoomTypeName", "NoOfRooms", "OccupancyCapacity"],
		headerNames: ["Room Type Name", "No Of Rooms", "Occupancy Capacity"],
		data: list.dt,
	}

	buildHtmlTable(kTable, $('#tblHotelRoomType'));

	BindPagination(list.Pager, $('#tblHotelRoomType'), "RoomTypePagination");
}

function RoomTypePagination(CurrentPage)
{
	$('#tblHotelRoomType').attr("data-current-page", CurrentPage);

	GetHotelRoomType();
}

function GetHotelRoomTypeById(data)
{
	var hViewModel =
      {
      	HotelRoomType: {
      		RoomTypeDetailsId: $("[name='HotelRoomTypeFilter.HotelRoomTypeDetailsId']").val(),
      	},
      	Pager: {
      		CurrentPage: $('#hdnCurrentPage').val()
      	},
      }

	PostAjaxJson("/Hotel/GetHotelRoomTypeById", hViewModel, BindHotelRoomTypeById);
}

function BindHotelRoomTypeById(data)
{
	 var obj = data;

	 $("[name='HotelRoomTypeFilter.HotelRoomTypeDetailsId']").val(obj.HotelRoomType.RoomTypeDetailsId),

     //$("#drpRoom").val(obj.HotelRoomType.RoomTypeId),

     $("[name='Hotel.RoomType']").attr("data-value", obj.HotelRoomType.RoomTypeId);

	 GetAutocompleteById("Hotel.RoomType");

     $("[name='Hotel.noOfRooms']").val(obj.HotelRoomType.NoOfRooms),

     $("[name='Hotel.occupancy']").val(obj.HotelRoomType.OccupancyCapacity),

     $("[name='HotelRoomType.HotelId']").val(obj.HotelRoomType.HotelId)
}

function DeleteHotelRoomType()
{
	var hViewModel =
      {
      	HotelRoomType: {
      		RoomTypeDetailsId: $("[name='HotelRoomTypeFilter.HotelRoomTypeDetailsId']").val(),

      		HotelId: $("[name='HotelRoomType.HotelId']").val()
      	},
      	Pager: {
      		CurrentPage: $('#hdnCurrentPage').val()
      	},
      }

	PostAjaxJson("/Hotel/DeleteHotelRoomType", hViewModel, AfterHotelRoomTypeDelete);

	$("[name='HotelRoomTypeFilter.HotelRoomTypeDetailsId']").val('');
}

function AfterHotelRoomTypeDelete(data) {

    FriendlyMessage(data);

    GetHotelRoomType();

    ResetHotelRoomType();
}