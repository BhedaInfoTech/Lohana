$(document).ready(function () {

    $("#frmpayble").validate({
        rules: {
            "PayableInfo.PayableHistoryInfo.PayableDate":
                {
                    required: true,
                },
            "PayableInfo.PayableHistoryInfo.ReceiptNo":
                {
                    required: true,
                },
            "PayableInfo.PayableHistoryInfo.ModeOfPayment":
             {
                 required: true,
             },
            "PayableInfo.PayableHistoryInfo.AmountPaid":
                {
                  //  required: true,
                    number: true,
                    digits: true,
                },
            "PayableInfo.Debit_Card_No":
                {
                  //  required: true,
                    number: true,
                },
            "PayableInfo.Credit_Card_No":
            {
               // required: true,
                number: true,
            },
            "PayableInfo.Cheque_No":
                {
                  //  required: true,
                    number: true,
                },
            "PayableInfo.Bank_Name":
                {
                  //  required: true,
                },
        },
        messages: {

            "PayableInfo.PayableHistoryInfo.PayableDate":
                {
                    required: "Payable Date is required."
                },
            "PayableInfo.PayableHistoryInfo.ReceiptNo":
                {
                    required: "Receipt No is required."
                },
            "PayableInfo.PayableHistoryInfo.ModeOfPayment":
                {
                    required: "Mode Of Payment is required."
                },
            "PayableInfo.PayableHistoryInfo.AmountPaid":
               {
                  // required: "AmountPaid is Requird",
                   number: "Enter Number Only",
                   digits: "Enter only digits."
               },
            "PayableInfo.Cheque_No":
                {
                  //  required: "Cheque_No is Requird",
                    number: "Enter Number Only",
                },
            "PayableInfo.Bank_Name":
              {
                //  required: "Bank_Name is Requird",
              },
        }
    });

});