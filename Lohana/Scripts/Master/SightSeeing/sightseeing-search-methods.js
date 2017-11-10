function GetSightSeeing() {  

    var sViewModel =
		{
		    SightSeeing: {

		        SightSeeingName: $("[name='SightSeeing.SightSeeingName']").val(),

		        CityId: $("#drpCity").val(),

		    },
		    Pager: {

		        CurrentPage: $('#tblSightSeeing').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/SightSeeing/GetSightSeeing", sViewModel, BindSightSeeing);
}

function BindSightSeeing(data) {

    var list = JSON.parse(data);   

    var kTable = {
        dataList: ["SightSeeingName", "CityName", "OperationalTime", "OperationalDays"],
        primayKey: "SightSeeingId",
        hiddenFields: ["SightSeeingId", "SightSeeingName","CityId","VendorId"],
        headerNames: ["Sight Seeing Name", "Location", "Operational Time" ,"Operational Days"],
        data: list.dt,      
    }

    buildHtmlTable(kTable, $('#tblSightSeeing'));

    BindPagination(list.Pager, $('#tblSightSeeing'));

}

function Pagination(CurrentPage) {

    $('#tblSightSeeing').attr("data-current-page", CurrentPage);

    GetSightSeeing();

}