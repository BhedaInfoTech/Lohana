
$(document).ready(function () {

    GetAutocompleteScript("Hotel");

    document.getElementById("btnEditHotel").disabled = true;

    document.getElementById("btnViewContactDetails").disabled = true;

    document.getElementById("btnView").disabled = true;
 
    $(document).on('change', "#tblHotel [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            var id = $(this).attr("data-hotelid");

            $("#hdnSearchHotelId").val(id);

            document.getElementById("btnEditHotel").disabled = false;

            document.getElementById("btnViewContactDetails").disabled = false;

            document.getElementById("btnEditHotel").disabled = false;

            document.getElementById("btnView").disabled = false;

        }

    });

    $("#btnSearchHotel").click(function () {

        $("#tblHotel").attr("data-current-page", "0");

        GetHotel();
    });

    GetHotel();

    $("#btnEditHotel").click(function () {
        $("#frmSearchHotel").attr("action", "/Hotel/GetHotelById");
        $("#frmSearchHotel").submit();
    });


    $("#btnViewContactDetails").click(function (event) {
          
        $(".parent-modal").find(".modal-body").load("/Hotel/GetContactPersonListing",null,call_back);           

    });

    $("#btnView").click(function () {

        $("#frmSearchHotel").attr("target", "_blank");
        $("#frmSearchHotel").attr("action", "/Hotel/GetHotelView");
        $("#frmSearchHotel").submit();
        $("#frmSearchHotel").attr("target", "_self");

    });

    function call_back(data)
    {
        $(".parent-modal").find(".modal-title").html("Contact details");
       
        GetContactPerson();

        $(".parent-modal").modal("show");
    }
 

});

