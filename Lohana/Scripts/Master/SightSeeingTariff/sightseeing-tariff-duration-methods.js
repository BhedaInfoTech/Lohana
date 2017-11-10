

function SaveSightSeeingTariffDuration() {

    $("#frmSightSeeingTariffDuration").blur();

    var start = $("[name='SightSeeingTariff.Duration.FromDate']").datepicker("getDate");

    var end = $("[name='SightSeeingTariff.Duration.ToDate']").datepicker("getDate");

    var DatesBetween = getDates(start, end);

    var Date = [];

    var DayName = [];

    var i;

    for (i = 0; i < DatesBetween.length; i++) {
        Date[i] = (DatesBetween[i].getMonth() + 1) + "/" + (DatesBetween[i].getDate()) + "/" + (DatesBetween[i].getFullYear() + " " + "00:00:00 AM");

        DayName[i] = DatesBetween[i].getDay() + 1;
    }
    var Dates = Date.join();

    var Day = DayName.join();

    var days = [];

    $('input[name="SightSeeingTariff.Duration.OperationalDays"]:checked').each(function (i) {

        days[i] = $(this).val();

    });

    var DaysValue = days.join();

    var sstViewModel = {

        Duration: {

            DurationId: $("[name='DurationFilter.DurationId']").val(),

            SightSeeingTariffId: $("#hdnDurationTariffId").val(),

            FromDate: $("[name='SightSeeingTariff.Duration.FromDate']").val(),

            ToDate: $("[name='SightSeeingTariff.Duration.ToDate']").val(),

            Day: Day,

            OperationalDays: DaysValue,

            Dates: Dates,

        }
    }
    var url = "";

    //if ($("[name='DurationFilter.DurationId']").val() == 0) {


    url = "/SightSeeingTariff/InsertDuration"
    //}
    //else {

    //    url = "/SightSeeingTariff/UpdateDuration"
    //}
    PostAjaxJson(url, sstViewModel, AfterDurationSave);
}

function AfterDurationSave() {

    //ResetDuration();

    GetDuration();

}

function GetDuration() {

    var sstViewModel =
		{
		    Duration: {


		    },
		    Pager: {

		        CurrentPage: $('#tblSightSeeingTariffDurationDetails').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/SightSeeingTariff/GetDuration", sstViewModel, BindDuration);
}

function BindDuration(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["FromDate", "ToDate", "OperationalDays"],
        primayKey: "DurationId",
        hiddenFields: ["DurationId", "FromDate", "ToDate", "OperationalDays"],
        headerNames: ["Duration", " ", "Available Days"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblSightSeeingTariffDurationDetails'));

    BindPagination(list.Pager, $('#tblSightSeeingTariffDurationDetails'), "DurationPagination");

}

function GetSetDurationValues(obj) {

    var id = $(obj).attr("data-durationid");

    var fromdate = $(obj).attr("data-fromdate");

    var todate = $(obj).attr("data-todate");

    var operationaldays = $(obj).attr("data-operationaldays");

    $("[name='SightSeeingTariff.Duration.FromDate']").val(fromdate),

    $("[name='SightSeeingTariff.Duration.ToDate']").val(todate),

    // $("[name='SightSeeingTariff.Duration.OperationalDays']").val(operationaldays),

    $("#lblOperationalDays").text(operationaldays)

    $("#lblFromToDate").text(fromdate + " " + "to" + " " + todate)

    
}

function DurationPagination(CurrentPage) {

    $('#tblSightSeeingTariffDurationDetails').attr("data-current-page", CurrentPage);

    GetDuration();

}

function getDates(start, end) {

    var datesArray = [];

    var startDate = new Date(start);

    while (startDate <= end) {

        datesArray.push(new Date(startDate));

        startDate.setDate(startDate.getDate() + 1);
    }

    return datesArray;


}