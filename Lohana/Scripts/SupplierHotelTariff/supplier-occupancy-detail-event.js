$(document).ready(function ()
{
    

    $("#btnAddSupplierOccupancyDetail").on('click', function ()
    {
        if ($("#frmOccupancyDetail").valid())
        {
            SaveSupplierOccupancyDetail();
        }        
    });

    $("#btnResetOccupancyDetail").on('click', function ()
    {
        ResetSupplierOccupancyDetail();

        $("#hdnSupplierOccupancyDetailId").val('');
    });

    $(document).on('change', "#tblSupplierOccupancyDetails input[type=radio]", function (event) {
        if ($(this).prop('checked')) {

            $("[name='SupplierHotelPrice.OccupancyDetailId']").val($(this).attr("data-OccupancyDetailId"));

            SetOccupancyDetail($(this));

            GetSupplierHotelTariffPrice();

            GetHotelTariffDuration($("#dvcalendar"));

            //var ocuupencyType = GetAutocompleteExtraParamValue("OccupancyType", $(this));

            ////alert(ocuupencyType);
            //if (ocuupencyType == 1) {

            //    $("#divAgeFromTo").hide();
            //}
            //else {
            //    $("#divAgeFromTo").show();
            //}

        }
    });

    $(document).on('change', "#drpLocation", function (event) {

        var ocuupencyType = GetAutocompleteExtraParamValue("OccupancyType", $(this));
        if (ocuupencyType == 1)

        {

           $("#divAgeFromTo").hide();
        }
        else {
            $("#divAgeFromTo").show();
        }

    });



});