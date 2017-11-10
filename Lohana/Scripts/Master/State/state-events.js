$(document).ready(function () {

	GetAutocompleteScript("State");

    GetStates();

    $(document).on('change', "[name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetStateValues($(this));

            SetActive($("[name='State.IsActive']"), $(this).attr("data-isactive"));
                }


    });

    $("#btnSaveState").click(function () {

        if ($("#frmState").valid()) {

            SaveState();
        }

    });

    $("#btnSearchState").click(function () {

        $("#tblState").attr("data-current-page", "0");

        GetStates();

    });


    $("#btnResetState").click(function () {

        document.getElementById("frmSearchState").reset();

        ResetState();
    });




    });




