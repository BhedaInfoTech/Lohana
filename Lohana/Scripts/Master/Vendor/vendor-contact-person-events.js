$(function () {


    $(document).on('change', " #tblContactPerson [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            var id = $(this).attr("data-contactpersonid");

            $("#hdnSearchContactPersonId").val(id);

            //document.getElementById("btnEditContactPerson").disabled = false;

            //document.getElementById("btnDeleteContactPerson").disabled = false;

            GetContactPersonById();

            $("#btnDeleteContactPerson").removeAttr("disabled");
        }

    });


    $("#btnAdd").click(function () {
        if ($("#frmContactPerson").valid()) {
            SaveContactPerson();
        }
    });

    //$("#btnEditContactPerson").click(function () {
    //    GetContactPersonById();
    //});

    $("#btnDeleteContactPerson").click(function () {

        DeleteContactPerson();
    });

});