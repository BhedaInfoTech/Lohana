
$(function () {

    // Package Itinerary

    $('.summernote').summernote({
        toolbar: [
   // [groupName, [list of button]]
   ['style', ['bold', 'italic', 'underline', 'clear']], 
   ['fontsize', ['fontsize']],
   ['color', ['color']],
   ['para', ['ul', 'ol', 'paragraph']]
   
        ]
    });
     

    GetAutocompleteScript("Package");

    $("#btnAddPackageItinerary").click(function () {
        if ($("#frmPackageItineraryDetails").valid()) {
            SavePackageItinerary();
        }
    }); 

    $(document).on('change', "#tblPackageItinerary [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            debugger

            var id = $(this).attr("data-packageitineraryid");

            $("#hdnSearchPackageItineraryId").val(id);

            GetPackageItineraryById();
 
            $("#divPlanServices1").show();

            $("#btnDeletePackageItinerary").removeAttr("disabled");

        }

    });

    $("#btnDeletePackageItinerary").click(function () {

        DeletePackageItinerary();

    });



    // Package Itinerary Hide Show
    $("#btnHotel").click(function (event) {

        LoadParentModal("/Package/PackageItineraryHotel", null, null, "Hotel details", null)

    });

    $("#btnPlane").click(function () {

        //$("#divFlight").toggle();
        LoadParentModal("/Package/PackageItineraryFlight", null, null, "Flight details", null)

    });

    $("#btnTrain").click(function () {

        //$("#divTrain").toggle();
        LoadParentModal("/Package/PackageItineraryTrain", null, null, "Train details", null)

    });

    $("#btnBus").click(function () {

        //$("#divBus").toggle();
        LoadParentModal("/Package/PackageItineraryBus", null, null, "Bus details", null)

    });

    $("#btnVehicle").click(function () {

        //$("#divVehicle").toggle();
        LoadParentModal("/Package/PackageItineraryVehicle", null, null, "Vehicle details", null)

    });

});