$(document).ready(function () {

    $("#frmCustomer").validate({
                 
        rules: {

            "Customer.FirstName":
             {
                 required: true,            
             },
            "Customer.MiddleName":
            {
                required: true,
            },
            "Customer.LastName":
            {
                required: true,
            },
            "Customer.Gender":
             {
                 Gender:true,               
             },
            "Customer.DOB": 
           {              
               required:true,
           },
            "Customer.EmailId":
             {
                 email: true,
                 required: true,
                 CheckEmailIdExist: true,
             },
            "Customer.PhoneNo":
            {
                required: true,
                number:true
            },
            "Customer.MobileNo":
           {
               required: true,
               number:true
           },
            "Customer.PanNo":
           {
               required: true,

           },
            "Customer.Address":
          {
              required: true,

          },
            "Customer.CustomerCategoryId":
             {
                 CustomerCategoryId: true,
             },
        },
        messages: {

            "Customer.FirstName":
                {
                    required:"First name is required."
                },
            "Customer.MiddleName":
                {
                    required: "Middle name is required."
                },
            "Customer.LastName":
                {
                    required: "Last name is required."
                },
           
            "Customer.Emaild":
              {
              email: "Invalid email id",
              required:"Email id is required."
              },

            "Customer.PhoneNo":
             {                     
                 required: "Phone number is required.",
                 number: "Only Enter Digit"
             },
            "Customer.MobileNo":
                  {
                      required: "Mobile number is required.",
                      number: "Only Enter Digit"
                  },
            "Customer.PanNo":
                  {
                      required: "Pan number is required."
                  },
            "Customer.Address":
                  {
                      required: "Address is required."
                  },
            "Customer.DOB":
            {
                required:"Date of birth is required."
            },
            
        }

    });

    jQuery.validator.addMethod("CheckEmailIdExist", function (value, element) {

        debugger;
         
        return GetAjaxAlreadyExists('/Customer/CheckEmailIdExist', { EmailId: value }, $("#txtEmailId"), $("#hdnEmailId"));

    }, "Email id is already exist.");

    jQuery.validator.addMethod("Gender", function (value, element) {
        var result = true;

        if ($("#drpGender").val() == "0") {

            result = false;
        }

        return result;

    }, "Gender is required.");

    jQuery.validator.addMethod("CustomerCategoryId", function (value, element) {
        var result = true;

        if ($("#drpCustomerCategoryId").val() == "0") {
            result = false;
        }

        return result;

    }, "Customer category is required.");
    
    });