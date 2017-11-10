$(document).ready(function () {

    GetAutocompleteScript("Package Hotel");
    
    GetPackageItineraryHotel();

    $(document).on('click', '#btnAddPackageItineraryHotels', function (event) {
        if ($("#frmPackageItineraryHotels").valid()) {
                    SavePackageItineraryHotels();
        }
    });

    $(document).on('change', "#tblPackageItineraryHotels [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            debugger

            var id = $(this).attr("data-packageitineraryhotelid");

            $("#hdnSearchPackageItineraryHotelId").val(id);

            GetPackageItineraryHotelById(); 
          
            //$("#divPlanServices1").show();

            $("#btnDeletePackageItineraryHotels").removeAttr("disabled");

        }

    });

    $("#btnDeletePackageItineraryHotels").click(function () {

        DeletePackageItineraryHotel();

    });


});