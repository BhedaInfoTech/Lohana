function GetSightSeeingById() {

    var sstViewModel =
		{
		    SightSeeing: {

		        SightSeeingId: $("#drpSightSeeing").val(),		        

		    }		    
		}

    PostAjaxJson("/SightSeeingTariff/GetSightSeeingById", sstViewModel, BindSightSeeing);
}


function BindSightSeeing(data) {

  
    $("[name='SightSeeingTariff.SightSeeing.Description']").val(data.SightSeeing.Description)

    var timefrom = data.SightSeeing.TimeFrom;

    var timeto = data.SightSeeing.TimeTo;

    $("[name='SightSeeingTariff.SightSeeing.TimeFrom']").val(timefrom+" " + "to" +" "+ timeto),

    $("[name='SightSeeingTariff.SightSeeing.VisitTime']").val(data.SightSeeing.VisitTime),

    $("#lblOperationalDays").text(data.SightSeeing.OperationalDays)

}