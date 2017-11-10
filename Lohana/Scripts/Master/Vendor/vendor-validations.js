$(document).ready(function () {

    $("#frmVendor").validate({
                 
        rules: {

            "Vendor.VendorName":
             {
                 required: true,
                 CheckVendorNameExist: true
             },
            "Vendor.BusinessType":
             {
                 DropdownRequired: true
             },
            "Vendor.PINCode": 
           {
               number: true,
               required: true
           },
            "Vendor.EmailId":
             {
                 email: true,
                 required: true,
                 CheckEmailIdExist: true
             },
            "Vendor.PhoneNo":
            {
                required: true,
                number: true,
            },
            "Vendor.MobileNo":
           {
               required: true,
               number: true,

           },

            "Vendor.FaxNo":
             {
                 //required: true
             },
            "Vendor.City":
             {
                 City: true
             },
            "Vendor.WebsiteURL":
             {
                // Url: true
             },
            "Vendor.PaymentOption":
             {
                 DropdownRequired: true
             }
        },
        messages: {

            "Vendor.VendorName":
                {
                    required: "Vendor name is required."
                },
            "Vendor.BusinessType":
            {
                DropdownRequired: "Business type is required."
            },
                 "Vendor.PINCode": 
                {
                    required:"PIN code is required.",
                    number:"Enter digits only."
                },
                 "Vendor.Emaild":
               {
                   email: "Invalid email id.",
                   required:"Email id is required."
               },

                 "Vendor.PhoneNo":
                  {                     
                      required: "Phone number is required."
                  },
                 "Vendor.MobileNo":
                       {
                           required: "Mobile number is required."
                       },
               "Vendor.FaxNo":
               {
                //required: "Fax number is required."
               },
            "Vendor.PaymentOption":
            {
                DropdownRequired: "Payment option is required."
            },
               "Vendor.WebsiteURL":
				{
					//Url: "Invalid url."
				},
            
        }

    });





    jQuery.validator.addMethod("CheckVendorNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/Vendor/CheckVendorNameExist', { VendorName: value }, $("#txtVendorName"), $("#hdnVendorName"));

    }, "Vendor name is already exist.");


    jQuery.validator.addMethod("CheckEmailIdExist", function (value, element) {

        return GetAjaxAlreadyExists('/Vendor/CheckEmailIdExist', { EmailId: value }, $("#txtEmailId"), $("#hdnEmailId"));

    }, "Email id already exist.");


    //jQuery.validator.addMethod("Url", function (value, element) {

    //    return /^http(s)?:\/\/(www\.)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$/.test(value);
    //});














    jQuery.validator.addMethod("BusinessType", function (value, element) {
        var result = true;

        if ($("#drpBusinessType").val() == "0") {
            result = false;
        }

        return result;

    }, "Service type is required.");

    jQuery.validator.addMethod("City", function (value, element) {
        var result = true;

        if ($("#drpCity").val() == "0") {
            result = false;
        }

        return result;

    }, "City name is required.");

    jQuery.validator.addMethod("PaymentOption", function (value, element) {
        var result = true;

        if ($("#drpPaymentOption").val() == "0") {
            result = false;
        }

        return result;

    }, "Payment option is required.");

       

    //$("#frmVendorbank").validate({

    //    rules: {

    //        "Vendor.Bank.BankName":
    //         {
    //             required: true,
               
    //         },
    //        "Vendor.Bank.BranchName":
    //         {
    //             required: true

    //         },
    //        "Vendor.Bank.AccountNo":
    //       {            
    //           required: true
    //       },
    //        "Vendor.Bank.IFSCCode":
    //         {
    //             required: true,
    //         },
    //        "Vendor.Bank.MICRCode":
    //         {
    //             required: true
    //         },        
    //    },
    //    messages: {

    //        "Vendor.Bank.BankName":
    //            {
    //                required: "Bank name is required."
    //            },
    //        "Vendor.Bank.BranchName":
    //           {
    //               required: "Branch name is required.",
    //           },
    //        "Vendor.Bank.AccountNo":
    //          {
    //              required: "Account number is required.",
    //          },
    //      "Vendor.Bank.IFSCCode":
    //            {
    //                required: "IFSC code is required."
    //            },
    //      "Vendor.Bank.MICRCode":
    //         {
    //             required: "MICR code is required."
    //         }

    //    }

    //});

    //$("#frmContactPerson").validate({

    //    rules: {

    //        "Vendor.ContactPerson.ContactPersonName":
    //         {
    //             required: true,

    //         },
    //        "Vendor.ContactPerson.DesignationId":
    //         {
    //             required: true,
    //         },

    //        "Vendor.ContactPerson.PhoneNo":
    //         {
    //             required: true,
    //             number: true,
    //         },         
    //        "Vendor.ContactPerson.MobileNo":
    //         {
    //             required: true,
    //             number: true,
    //         },
    //        "Vendor.ContactPerson.FaxNo":
    //         {
    //             required: true,
    //         },
    //        "Vendor.ContactPerson.EmailId":
    //         {
    //             required: true,
    //         },          
    //    },
    //    messages: {

    //        "Vendor.ContactPerson.ContactPersonName":
    //         {
    //             required: "Contact person name is required.",

    //         },
    //        //"Vendor.ContactPerson.Designation":
    //        // {
    //        //     required: "Designation is required."

    //        // },          
    //        "Vendor.ContactPerson.PhoneNo":
    //        {
    //            required: "Phone number is required.",
    //            number: "Enter only digit.",
    //        },
    //        "Vendor.ContactPerson.MobileNo":
    //         {
    //             required: "Mobile number is required.",
    //         },
    //        "Vendor.ContactPerson.FaxNo":
    //         {
    //             required: "Fax number is required.",
    //         },
    //        "Vendor.ContactPerson.EmailId":
    //         {
    //             required: "Enter valid email id.",
    //         },          

    //    }

    //});

    //jQuery.validator.addMethod("Designation", function (value, element) {
    //    var result = true;

    //    if ($("#drpDesignation").val() == "0") {
    //        result = false;
    //    }

    //    return result;

    //}, "Designation is required.");

    
});





