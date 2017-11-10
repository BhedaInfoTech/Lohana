
function GetSearchSightSeeingDetails() {

    var sViewModel =
		{
		    SightSeeing: {
		       
		        SightSeeingId: $("[name='SightSeeing.SightSeeingId']").val(),

		        CountryId: $("[name='SightSeeing.CountryId']").val(),

		        StateId: $("[name='SightSeeing.StateId']").val(),

		        CityId: $("[name='SightSeeing.CityId']").val(),

		        FromDate: $("[name='SightSeeing.FromDate']").val(),

		        ToDate: $("[name='SightSeeing.ToDate']").val(),

		        AdultCount: $("[name='SightSeeing.AdultCount']").val(),

		        ChildCount: $("[name='SightSeeing.ChildCount']").val(),

          },
		    Pager: {


		    },
		}


    PostAjaxJson("/SightSeeing/GetSearchSightSeeingDetails", sViewModel, function (data) { $("#divSightSeeingBasicDetails").html(data); });
}

function ViewSightSeeingData(rowId) {

    $("#hdnSearchSightSeeingId").val(rowId);

    $("#frmSearchSightSeeingList").attr("target", "_blank");
    $("#frmSearchSightSeeingList").attr("action", "/SightSeeing/GetSightSeeingView");
    $("#frmSearchSightSeeingList")[0].submit();
    $("#frmSearchSightSeeingList").attr("target", "_self");

}


