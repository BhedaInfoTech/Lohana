function SaveVendorBank() {

    $("#frmVendorBank").blur();

    var vViewModel = {

        Bank: {

            BankId: $("[name='BankFilter.BankId']").val(),

            BankName: $("[name='Vendor.Bank.BankName']").val(),

            BranchName: $("[name='Vendor.Bank.BranchName']").val(),

            AccountHolderName: $("[name='Vendor.Bank.AccountHolderName']").val(),

            AccountNo: $("[name='Vendor.Bank.AccountNo']").val(),

            IFSCCode: $("[name='Vendor.Bank.IFSCCode']").val(),

            MICRCode: $("[name='Vendor.Bank.MICRCode']").val(),

            SWIFTCode: $("[name='Vendor.Bank.SWIFTCode']").val(),

            VendorId: $("#hdnBankVendorId").val(),

        }
    }
    var url = "";

    if ($("[name='BankFilter.BankId']").val() == 0) {

        url = "/Vendor/InsertVendorBank"
    }
    else {

        url = "/Vendor/UpdateVendorBank"
    }
    PostAjaxJson(url, vViewModel, AfterVendorBankSave);
}

function AfterVendorBankSave(data) {

    FriendlyMessage(data);

    ResetVendorBank();

    GetVendorBank();
}

function ResetVendorBank() {

    $("#hdnSearchBankId").val('');

    $("#txtBankName").val('');

    $("#txtBranchName").val('');

    $("#txtAccountNo").val('');

    $("#txtAccountHolderName").val('');

    $("#txtIFSCCode").val('');

    $("#txtMICRCode").val('');

    $("#txtSWIFTCode").val('');
}

function GetVendorBank() {

    var vViewModel =
		{
		    Bank: {

		        VendorId: $("#hdnBankVendorId").val(),

		    },
		    Pager: {

		        CurrentPage: $('#tblVendorBankDetails').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/Vendor/GetVendorBank",vViewModel,BindVendorBank);
}

function BindVendorBank(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["BankName", "BranchName", "AccountNo", "AccountHolderName", "IFSCCode", "MICRCode", "SWIFTCode"],
        primayKey: "BankId",
        hiddenFields: ["BankId", "BankName"],
        headerNames: ["Bank Name", "Branch", "Account No", "Account Holder Name", "IFSC Code", "MICR Code", "SWIFTCode"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblVendorBankDetails'));

   BindPagination(list.Pager, $('#tblVendorBankDetails'), "BankPagination");

}

function GetVendorBankById(data) {

    var vViewModel =
      {

          Bank: {

              BankId: $("[name='BankFilter.BankId']").val(),

          },
          Pager: {

              CurrentPage: $('#tblVendorBankDetails').attr("data-current-page"),
          },
      }

    PostAjaxJson("/Vendor/GetVendorBankById", vViewModel, BindVendorBankById);

}

function BindVendorBankById(data) {

    $("[name='Vendor.Bank.BankId']").val(data.Bank.BankId),

    $("[name='Vendor.Bank.BankName']").val(data.Bank.BankName),

    $("[name='Vendor.Bank.BranchName']").val(data.Bank.BranchName),

    $("[name='Vendor.Bank.AccountNo']").val(data.Bank.AccountNo),

    $("[name='Vendor.Bank.AccountHolderName']").val(data.Bank.AccountHolderName),

    $("[name='Vendor.Bank.IFSCCode']").val(data.Bank.IFSCCode),

    $("[name='Vendor.Bank.MICRCode']").val(data.Bank.MICRCode),

    $("[name='Vendor.Bank.SWIFTCode']").val(data.Bank.SWIFTCode),

    $("#hdnBankVendorId").val(data.Bank.VendorId)

}

function DeleteVendorBank() {

    var vViewModel =
      {
          Bank: {

              BankId: $("[name='BankFilter.BankId']").val(),

              VendorId: $("#hdnBankVendorId").val(),
          },
          Pager: {

              CurrentPage: $('#hdnCurrentPage').val()
          },
      }
    PostAjaxJson("/Vendor/DeleteVendorBank", vViewModel, AfterVedorBankDelete);

    $("#hdnSearchBankId").val('');

}

function AfterVedorBankDelete(data) {

    FriendlyMessage(data);

    ResetVendorBank();

    GetVendorBank();
}

function BankPagination(CurrentPage) {

    $('#tblVendorBankDetails').attr("data-current-page", CurrentPage);

    GetVendorBank();

}