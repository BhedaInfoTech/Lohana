
$(function ()
{

    $("#btnAddPackageDate").click(function () {
        if ($("#frmPackageDateDetails").valid()) {
            SavePackageDate();
        }
    });

  

    $(document).on('change', "#tblPackageDate [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            var id = $(this).attr("data-packagedateid");

            $("#hdnSearchPackageDateId").val(id);

            GetPackageDateById();

            $("#btnDeletePackageDate").removeAttr("disabled");

        }

    });

    $("#btnDeletePackageDate").click(function () {

        DeletePackageDate();

    });

});
