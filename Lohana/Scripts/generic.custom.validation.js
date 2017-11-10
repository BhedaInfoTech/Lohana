$(function () {

    $.validator.setDefaults({
        ignore: [],
        errorElement: "div",
        errorClass: "form-control-feedback",
        highlight: function (element, errorClass, validClass) {

            if ($(element).closest('.input-group').length || $(element).prop('type') === 'checkbox' || $(element).prop('type') === 'radio') {
                $(element).closest('.input-group').parent().addClass("has-danger");
            }
            else {
                $(element).closest(".form-group").addClass("has-danger");
            }           
        },
        unhighlight: function (element, errorClass, validClass) {
            if ($(element).closest('.input-group').length || $(element).prop('type') === 'checkbox' || $(element).prop('type') === 'radio') {
                $(element).closest('.input-group').parent().removeClass("has-danger");
            }
            else {
                $(element).closest(".form-group").removeClass("has-danger");
            }
        },
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length || element.prop('type') === 'checkbox' || element.prop('type') === 'radio') {
                error.insertAfter(element.parent());
            }
            else {
                error.insertAfter(element);
            }
        },

    	onkeyup: false,

    	onclick: false,

        onfocusout: false,
    
    });

    jQuery.validator.addMethod("DropdownRequired", function (value, element)
    {
    	var result = true;

    	if ($(element).val() == 0 || $(element).val() == null || $(element).val() == undefined || $(element).val() == "")
    	{
    		result = false;
    	}

    	return result;
    });
});

