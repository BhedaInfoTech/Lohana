$(document).ready(function () {

    $("#frmCustomerCategory").validate({

        rules: {

            "CustomerCategory.Margin":
            {
                required: true,
                number: true,
              
            },
            "CustomerCategory.CustomerCategoryName":
             {
                 required: true,
                 CheckCustomerCategoryNameExist: true
             }

        },
        messages: {

            "CustomerCategory.Margin":
                {
                    required: "Margin is required.",
                                     
                },

            "CustomerCategory.CustomerCategoryName":
                {
                    required: "Customer category name is required."
                    
                }
        }

    });

   
    jQuery.validator.addMethod("CheckCustomerCategoryNameExist", function (value) {
        
        return GetAjaxAlreadyExists('/CustomerCategory/CheckCustomerCategoryNameExist', { customerCategoryName: value }, $("#txtCustomerCategoryName"), $("#hdnCustomerCategoryName"));
        
    }, "Customer category name already exist.");


});

