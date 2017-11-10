$(document).ready(function () {

    $("#frmVendorbank").validate({

        rules: {

            "Vendor.Bank.BankName":
             {
                 required: true,

             },
            "Vendor.Bank.BranchName":
             {
                 required: true

             },
            "Vendor.Bank.AccountNo":
           {
               required: true
           },
            "Vendor.Bank.IFSCCode":
             {
                 required: true,
             },
            "Vendor.Bank.MICRCode":
             {
                 required: true
             },
        },
        messages: {

            "Vendor.Bank.BankName":
                {
                    required: "Bank name is required."
                },
            "Vendor.Bank.BranchName":
               {
                   required: "Branch name is required.",
               },
            "Vendor.Bank.AccountNo":
              {
                  required: "Account number is required.",
              },
            "Vendor.Bank.IFSCCode":
                  {
                      required: "IFSC code is required."
                  },
            "Vendor.Bank.MICRCode":
               {
                   required: "MICR code is required."
               }

        }

    });


});