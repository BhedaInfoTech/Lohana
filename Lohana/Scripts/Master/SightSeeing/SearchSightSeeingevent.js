$(document).ready(function () {
  
    // GetAutocompleteScript("SearchSightSeeing");

    GetAutocompleteScript("SightSeeingSearch");

    //GetAutocompleteById("SightSeeing.StatId");

    $('#txtFromDate').datepicker('setDate', new Date());

    $('#txtToDate').datepicker('setDate', new Date());


   GetSearchSightSeeingDetails();

    $("#btnSearchSightSeeing").click(function () {
      
        GetSearchSightSeeingDetails();
    })

    $("#hdnSearchSightSeeingId").val();
                                               
    $("#btnResetSightSeeing").click(function () {
        $("#frmSearchSightSeeingList").valid();
        $("#frmSearchSightSeeingList").attr("action", "/SightSeeing/SearchSightSeeing");
        $("#frmSearchSightSeeingList").submit();
    });

})