$(document).ready(function () {


    $("#frmHotelbank").validate({
        rules:
            {
            "Hotel.Bank.BankName":
             {
                 required: true,
             },
            "Hotel.Bank.BranchName":
             {
                 required: true
             },
            "Hotel.Bank.AccountNo":
           {
               required: true
           },
            "Hotel.Bank.IFSCCode":
             {
                 required: true,
             },
            "Hotel.Bank.MICRCode":
             {
                 required: true
             },
        },
        messages: {
            "Hotel.Bank.BankName":
                {
                    required: "Bank name is required."
                },
            "Hotel.Bank.BranchName":
               {
                   required: "Branch name is required.",
               },
            "Hotel.Bank.AccountNo":
              {
                  required: "Account number is required.",
              },
            "Hotel.Bank.IFSCCode":
                  {
                      required: "IFSC code is required."
                  },
            "Hotel.Bank.MICRCode":
               {
                   required: "MICR code is required."
               }
        }
    });

});