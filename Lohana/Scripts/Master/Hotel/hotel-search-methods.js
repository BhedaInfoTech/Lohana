function GetHotel() {

    var hViewModel =
		{
		    Hotel: {

		        HotelName: $("[name='Hotel.hotelName']").val(),

		        StarCategory: $('#drpstarCategory').val(),
  
		        CityId:  $('#drpcity').val()

		    },
		    Pager: {

		        CurrentPage: $('#tblHotel').attr("data-current-page"),

		    },
		}

    PostAjaxJson("/Hotel/GetHotel", hViewModel, BindHotels);
}

function BindHotels(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["HotelName", "CityName", "HotelGroup", "StarCategoryStr"],
        primayKey: "HotelId",
        hiddenFields: ["HotelId", "HotelName", "CityId"],
        headerNames: ["Hotel Name", "Location", "Hotel Group", "Star Category"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblHotel'));

    BindPagination(list.Pager, $('#tblHotel'));


}


function GetContactPerson() {

    var hViewModel =
		{
		    ContactPerson: {

		        RefId: $("#hdnSearchHotelId").val(),

		        RefType: $("#hdnRefType").val()

		    },

		    Pager: {

		        CurrentPage: $('#tblContactPerson').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/Hotel/GetContactPerson", hViewModel, BindContactPerson);
}

function BindContactPerson(data) {


    var list = JSON.parse(data);

    var kTable = {
        dataList: ["ContactPersonName", "MobileNo", "DesignationName"],
        headerNames: ["Contact Person Name", "Mobile No", "Designation"],
        data: list.dt,
    }

    buildHtmlViewTable(kTable, $('#tblContactPerson'));

    BindPagination(list.Pager, $('#tblContactPerson'), "ContactPersonPagination");

}

function Pagination(CurrentPage) {

            $('#tblHotel').attr("data-current-page", CurrentPage);

            GetHotel();

            document.getElementById("btnEditHotel").disabled = true;

            document.getElementById("btnViewContactDetails").disabled = true;

        }
    
function ContactPersonPagination(CurrentPage) {

    $('#tblContactPerson').attr("data-current-page", CurrentPage);

    GetContactPerson();

}
