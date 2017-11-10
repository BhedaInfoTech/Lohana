
$(function () {

    $("#btnAddHotelContactPerson").click(function () {
        if ($("#frmContactPerson").valid()) {
            SaveContactPerson();
        }
    });

    //$("#btnEditHotelContactPerson").click(function () {
    //    GetContactPersonById();
    //});

    $(document).on('change', "#tblContactPerson [name='c1']", function (event) {
        if ($(this).prop('checked')) {
            var id = $(this).attr("data-contactpersonid");

            $("#hdnSearchHotelContactPersonId").val(id);

            GetContactPersonById();

            $("#btnDeleteHotelContactPerson").removeAttr("disabled");

        }
    });

    $("#btnDeleteHotelContactPerson").click(function () {
        DeleteHotelContactPerson();
    });

    $("#btnCreateDesignation").click(function () {
        $("#hdnCreateDesignationFlag").val(true);

        $("#frmContactPerson").attr("action", "/Designation/Index/");

        $('#frmContactPerson').attr("method", "POST");

        $('#frmContactPerson').submit();

    });


    $("#btnAddDesignation").click(function () {
        $(".parent-modal").find(".modal-body").load("/Designation/GetDesignationPartialView", null, function () {
            $(".parent-modal").modal("show");
        });
    });

    $(".parent-modal").on('hidden.bs.modal', function () {
        $(".parent-modal").find(".modal-body").html("");

        $("#dvDesignationDropDown").load("/Hotel/GetDesignationDropDown");
    })

});