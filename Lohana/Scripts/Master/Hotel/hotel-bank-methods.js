
function SaveHotelBank() {

    $("#frmHotelbank").blur();

    var hViewModel = {

        HotelBank:
            {
                BankId: $("[name='HotelBankFilter.BankId']").val(),

                BankName: $("[name='Hotel.Bank.BankName']").val(),

                BranchName: $("[name='Hotel.Bank.BranchName']").val(),

                AccountHolderName: $("[name='Hotel.Bank.AccountHolderName']").val(),

                AccountNo: $("[name='Hotel.Bank.AccountNo']").val(),

                IFSCCode: $("[name='Hotel.Bank.IFSCCode']").val(),

                MICRCode: $("[name='Hotel.Bank.MICRCode']").val(),

                SWIFTCode: $("[name='Hotel.Bank.SWIFTCode']").val(),

                HotelId: $("[name='Hotel.Bank.HotelId']").val(),
            }
    }
    var url = "";

    if ($("[name='HotelBankFilter.BankId']").val() == 0) {
        url = "/Hotel/InsertHotelBank"
    }
    else {
        url = "/Hotel/UpdateHotelBank"
    }

    PostAjaxJson(url, hViewModel, AfterHotelBankSave);
}

function AfterHotelBankSave(data) {

    var obj = $.parseJSON(data);

    FriendlyMessage(obj);

    ResetHotelBank();

    GetHotelBank();
}

function ResetHotelBank() {

    $("#hdnSearchBankId").val('');

    $("#txtBankName").val('');

    $("#txtBranchName").val('');

    $("#txtAccountNo").val('');

    $("#txtAccountHolderName").val('');

    $("#txtIFSCCode").val('');

    $("#txtMICRCode").val('');

    $("#txtSWIFTCode").val('');
}

function GetHotelBank() {
    var hViewModel =
		{
		    HotelBank: {
		        HotelId: $("[name='Hotel.Bank.HotelId']").val(),
		    },
		    Pager: {
		        CurrentPage: $('#tblHotelBankDetails').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/Hotel/GetHotelBank", hViewModel, BindHotelBank);
}

function BindHotelBank(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["BankName", "BranchName", "AccountNo", "AccountHolderName", "IFSCCode", "MICRCode", "SWIFTCode"],
        primayKey: "BankId",
        hiddenFields: ["BankId", "BankName"],
        headerNames: ["Bank Name", "Branch Name", "Account No", "Account Holder Name", "IFSC Code", "MICR Code", "SWIFTCode"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblHotelBankDetails'));

    BindPagination(list.Pager, $('#tblHotelBankDetails'), "HotelBankPagination");
}

function GetHotelBankById(data) {
    var hViewModel =
      {
          HotelBank: {
              BankId: $("[name='HotelBankFilter.BankId']").val(),
          },
          Pager: {
              CurrentPage: $('#hdnCurrentPage').val()
          },
      }

    PostAjaxJson("/Hotel/GetHotelBankById", hViewModel, BindHotelBankById);
}

function BindHotelBankById(data) {

    $("[name='Hotel.Bank.BankId']").val(data.HotelBank.BankId),

    $("[name='Hotel.Bank.BankName']").val(data.HotelBank.BankName),

    $("[name='Hotel.Bank.BranchName']").val(data.HotelBank.BranchName),

    $("[name='Hotel.Bank.AccountNo']").val(data.HotelBank.AccountNo),

    $("[name='Hotel.Bank.AccountHolderName']").val(data.HotelBank.AccountHolderName),

    $("[name='Hotel.Bank.IFSCCode']").val(data.HotelBank.IFSCCode),

    $("[name='Hotel.Bank.MICRCode']").val(data.HotelBank.MICRCode),

    $("[name='Hotel.Bank.SWIFTCode']").val(data.HotelBank.SWIFTCode),

    $("#hdnBankHotelId").val(data.HotelBank.HotelId)
}

function DeleteHotelBank() {

    var hViewModel =
      {
          HotelBank: {
              BankId: $("[name='HotelBankFilter.BankId']").val(),

              HotelId: $("#hdnBankHotelId").val(),
          },
          Pager: {
              CurrentPage: $('#hdnCurrentPage').val()
          },
      }
    PostAjaxJson("/Hotel/DeleteHotelBank", hViewModel, AfterHotelBankDelete);

    $("#hdnSearchBankId").val('');
}


function AfterHotelBankDelete(data) {

    FriendlyMessage(data);

    ResetHotelBank();

    GetHotelBank();
}

function HotelBankPagination(CurrentPage) {

    $('#tblHotelBankDetails').attr("data-current-page", CurrentPage);

    GetHotelBank();
}