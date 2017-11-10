// THIS FILE HAVE FUNCTIONALITY DEFINED INSIDE THE POPUP CONTROL.

$(document).ready(function () {

    $("#btnOK").click(function () {

        //alert("ok");

        $('.edit').each(function ()
        {
            $(this).attr('disabled', 'disabled');
        });

        var hiddenTextValue = $("#hdnValue").val();

        var id = $("#hdnId").val();

        var Textboxname = "#" + $("#hdnLookupLabelId").val();
      

        $('.border-bottom').each(function ()
        {
            alert("borderbottom");
            $('#lookupUlAuto').remove()
        });

      

        $(Textboxname).parents('.form-group').find('#lookupUlLookup').remove();

        $("#" + $("#hdnLookupHiddenId").val()).val(id);

        $("#" + $("#hdnLookupHiddenValue").val()).val(hiddenTextValue);

        $("#" + $("#hdnLookupHiddenId").val()).parents('.form-group').find(".autocomplete-text").val(hiddenTextValue);

        $("#" + $("#hdnLookupHiddenId").val()).parents('.form-group').find(".autocomplete-text").focus();

        $("#" + $("#hdnLookupHiddenId").val()).trigger("change");

        $("#" + $("#hdnLookupHiddenValue").val()).trigger("change");

        var htmlText = "<ul id='lookupUlLookup' class='list-group border-bottom'><li class='list-group-item'><span class='text'>" + hiddenTextValue + "<div class='pull-right'><i class='fa fa-times'></i></div></li></ul>";

        if (hiddenTextValue!="")
        {
            $(Textboxname).parents('.form-group').find('#lookupUlLookup').remove();

            $(Textboxname).parents('.form-group').append(htmlText);
        }
        

        $(Textboxname).parents('.form-group').find('.fa-times').click(function (event) {

            event.preventDefault();
            $(this).parents('.form-group').find('input[type=text]').val("");         
            $(this).parents('.form-group').find('.auto-complete-value').val("");
            $(this).parents('.form-group').find('.auto-complete-label').val("");
            $(this).parents('.form-group').find('.auto-complete-value').trigger('change');
            //$(this).parents('.form-group').find('.auto-complete-label').trigger('change');
            $(this).parents('.form-group').find('#lookupUlLookup').remove();
        });

        $('#div_Parent_Modal_Fade').find(".modal-body").empty();

        $('#div_Parent_Modal_Fade').modal('hide')

    });

    $(".close").click(function () {

        //alert("close");

        if ($("#" + $('#div_Parent_Modal_Fade').find(".modal-title").data("obj")).length) {

            Close_Pop_Up(true);
        }
        else {

            Close_Pop_Up(false);
        }
    });

    if ($("#hdnLookupLabelId").val() == "txtPurchasingOrganisation" || $("#hdnLookupLabelId").val() == "txtCompanyCode") {
        $("#btnfilter_Vendor").show();
    }


    //Radio Change Code.

    $(document).on("change", "[name='r1_Lookup']", function () {
       
        if ($(this).prop('checked')) {

            $("#hdnId").val(this.id.replace("r1_Lookup_", ""));

            $("#hdnValue").val($(this).closest("td").next().find(".v1").val());

            //alert("radiochange");

        }
    });


});

// PAGE MORE METHOD FOR LOOKUPS.

function PageMoreFilter(Id) {

    var textValue = $("#hdnLookupText").val();

    $('#hdfCurrentPage').val((parseInt(Id) - 1));

    if (textValue != undefined) {
        Get_Look_Up_Filter(textValue);
    }
    else {
        Get_Look_Up(true, $("#" + $("#hdnLookupLabelId").val()).closest(".form-group").find(".lookup-btn"), true);
    }

}

