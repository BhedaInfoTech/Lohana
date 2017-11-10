using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lohana.Common
{
	public class MessageStore
	{
		public static FixedSizeGenericHashTable<string, FriendlyMessage> hash = new FixedSizeGenericHashTable<string, FriendlyMessage>(400);

		static MessageStore()
		{
			#region System

			FriendlyMessage SYS01 = new FriendlyMessage("SYS01", MessageType.Error, "We are currently unable to process your request, Please try again later or contact system administrator.");
			hash.Add("SYS01", SYS01);

			FriendlyMessage SYS02 = new FriendlyMessage("SYS02", MessageType.Information, "Your session has expired. Please login again.");
			hash.Add("SYS02", SYS02);

			FriendlyMessage SYS03 = new FriendlyMessage("SYS03", MessageType.Error, "Please login with valid Username & Password to view this page.");
			hash.Add("SYS03", SYS03);

			FriendlyMessage SYS04 = new FriendlyMessage("SYS04", MessageType.Information, "No records found.");
			hash.Add("SYS04", SYS04);

			FriendlyMessage SYS05 = new FriendlyMessage("SYS05", MessageType.Information, "Password has been changed successfully.");
			hash.Add("SYS05", SYS05);

			FriendlyMessage SYS06 = new FriendlyMessage("SYS06", MessageType.Error, "You dont have online access. Please contact administrator.");
			hash.Add("SYS06", SYS06);

			FriendlyMessage SYS07 = new FriendlyMessage("SYS07", MessageType.Error, "File not found, Please contact administrator.");
			hash.Add("SYS07", SYS07);

			FriendlyMessage SYS08 = new FriendlyMessage("SYS08", MessageType.Error, "Entered User is not an Valid Active directory Member");
			hash.Add("SYS08", SYS08);

            FriendlyMessage SYS010 = new FriendlyMessage("SYS010", MessageType.Information, "You have successfully logged out!");
            hash.Add("SYS010", SYS010);

            FriendlyMessage SYS011 = new FriendlyMessage("SYS011", MessageType.Information, "You dont have access to this functionality.");
            hash.Add("SYS011", SYS011);

			#endregion

            #region Country

            FriendlyMessage COUNTRY01 = new FriendlyMessage("COUNTRY01", MessageType.Success, "Country added successfully.");
            hash.Add("COUNTRY01", COUNTRY01);

            FriendlyMessage COUNTRY02 = new FriendlyMessage("COUNTRY02", MessageType.Success, "Country updated successfully.");
            hash.Add("COUNTRY02", COUNTRY02);

            FriendlyMessage COUNTRY03 = new FriendlyMessage("COUNTRY03", MessageType.Information, "No records found.");
            hash.Add("COUNTRY03", COUNTRY03);

            #endregion

            #region State

            FriendlyMessage STATE01 = new FriendlyMessage("STATE01", MessageType.Success, "State added successfully.");
            hash.Add("STATE01", STATE01);

            FriendlyMessage STATE02 = new FriendlyMessage("STATE02", MessageType.Success, "State updated successfully.");
            hash.Add("STATE02", STATE02);

            FriendlyMessage STATE03 = new FriendlyMessage("STATE03", MessageType.Information, "No records found.");
            hash.Add("STATE03", STATE03);

            #endregion

            #region City

            FriendlyMessage CITY01 = new FriendlyMessage("CITY01", MessageType.Success, "City added successfully.");
            hash.Add("CITY01", CITY01);

            FriendlyMessage CITY02 = new FriendlyMessage("CITY02", MessageType.Success, "City updated successfully.");
            hash.Add("CITY02", CITY02);

            FriendlyMessage CITY03 = new FriendlyMessage("CITY03", MessageType.Information, "No records found.");
            hash.Add("CITY03", CITY03);

            #endregion

            #region Room Type

            FriendlyMessage RT01 = new FriendlyMessage("RT01", MessageType.Success, "Room type added successfully.");
            hash.Add("RT01", RT01);

            FriendlyMessage RT02 = new FriendlyMessage("RT02", MessageType.Success, "Room type updated successfully.");
            hash.Add("RT02", RT02);

            FriendlyMessage RT03 = new FriendlyMessage("RT03", MessageType.Information, "No records found.");
            hash.Add("RT03", RT03);

            FriendlyMessage RT04 = new FriendlyMessage("RT04", MessageType.Information, "Room type deleted successfully. ");
            hash.Add("RT04", RT04);

            #endregion

            #region Meal

            FriendlyMessage M01 = new FriendlyMessage("M01", MessageType.Success, "Meal added successfully.");
            hash.Add("M01", M01);

            FriendlyMessage M02 = new FriendlyMessage("M02", MessageType.Success, "Meal updated successfully.");
            hash.Add("M02", M02);

            FriendlyMessage M03 = new FriendlyMessage("M03", MessageType.Information, "No records found.");
            hash.Add("M03", M03);

            #endregion

            #region Occupancy

            FriendlyMessage O01 = new FriendlyMessage("O01", MessageType.Success, "Occupancy added successfully.");
            hash.Add("O01", O01);

            FriendlyMessage O02 = new FriendlyMessage("O02", MessageType.Success, "Occupancy updated successfully.");
            hash.Add("O02", O02);

            FriendlyMessage O03 = new FriendlyMessage("O03", MessageType.Information, "No records found.");
            hash.Add("O03", O03);

            #endregion

            #region Business

            FriendlyMessage B01 = new FriendlyMessage("B01", MessageType.Success, "Business added successfully.");
            hash.Add("B01", B01);

            FriendlyMessage B02 = new FriendlyMessage("B02", MessageType.Success, "Business updated successfully.");
            hash.Add("B02", B02);

            FriendlyMessage B03 = new FriendlyMessage("B03", MessageType.Information, "No records found.");
            hash.Add("B03", B03);

            #endregion

            #region Designation

            FriendlyMessage D01 = new FriendlyMessage("D01", MessageType.Success, "Designation added successfully.");
            hash.Add("D01", D01);

            FriendlyMessage D02 = new FriendlyMessage("D02", MessageType.Success, "Designation updated successfully.");
            hash.Add("D02", D02);

            FriendlyMessage D03 = new FriendlyMessage("D03", MessageType.Information, "No records found.");
            hash.Add("D03", D03);

            #endregion

            #region FacilityType

            FriendlyMessage FT01 = new FriendlyMessage("FT01", MessageType.Success, "Facility type added successfully.");
            hash.Add("FT01", FT01);

            FriendlyMessage FT02 = new FriendlyMessage("FT02", MessageType.Success, "Facility type updated successfully.");
            hash.Add("FT02", FT02);

            FriendlyMessage FT03 = new FriendlyMessage("FT03", MessageType.Information, "No records found.");
            hash.Add("FT03", FT03);

            #endregion

            #region Facility

            FriendlyMessage F01 = new FriendlyMessage("F01", MessageType.Success, "Facility added successfully.");
            hash.Add("F01", F01);

            FriendlyMessage F02 = new FriendlyMessage("F02", MessageType.Success, "Facility updated successfully.");
            hash.Add("F02", F02);

            FriendlyMessage F03 = new FriendlyMessage("F03", MessageType.Information, "No records found.");
            hash.Add("F03", F03);

            #endregion

            #region Charges

            FriendlyMessage Cr01 = new FriendlyMessage("Cr01", MessageType.Success, "Charges added successfully.");
            hash.Add("Cr01", Cr01);

            FriendlyMessage Cr02 = new FriendlyMessage("Cr02", MessageType.Success, "Charges updated successfully.");
            hash.Add("Cr02", Cr02);

            FriendlyMessage Cr03 = new FriendlyMessage("Cr03", MessageType.Information, "No records found.");
            hash.Add("Cr03", Cr03);

            #endregion

            #region Vendor

            FriendlyMessage V01 = new FriendlyMessage("V01", MessageType.Success, "Vendor added successfully.");
            hash.Add("V01", V01);

            FriendlyMessage V02 = new FriendlyMessage("V02", MessageType.Success, "Vendor updated successfully.");
            hash.Add("V02", V02);

            FriendlyMessage V03 = new FriendlyMessage("V03", MessageType.Information, "No records found.");
            hash.Add("V03", V03);

            #endregion

            #region ContactPerson

            FriendlyMessage CP01 = new FriendlyMessage("CP01", MessageType.Success, "Vendor Contact person added successfully.");
            hash.Add("CP01", CP01);

            FriendlyMessage CP02 = new FriendlyMessage("CP02", MessageType.Success, "Vendor Contact person updated successfully.");
            hash.Add("CP02", CP02);

            FriendlyMessage CP03 = new FriendlyMessage("CP03", MessageType.Information, "Vendor Contact person deleted successfully.");
            hash.Add("CP03", CP03);

            FriendlyMessage CP04 = new FriendlyMessage("CP04", MessageType.Information, "No records found.");
            hash.Add("CP04", CP04);

            #endregion

            #region Vendors Bank

            FriendlyMessage VB01 = new FriendlyMessage("VB01", MessageType.Success, "Vendor bank details added successfully.");
            hash.Add("VB01", VB01);

            FriendlyMessage VB02 = new FriendlyMessage("VB02", MessageType.Success, "Vendor bank details updated successfully.");
            hash.Add("VB02", VB02);

            FriendlyMessage VB03 = new FriendlyMessage("VB03", MessageType.Information, "Vendor bank details deleted successfully.");
            hash.Add("VB03", VB03);

            FriendlyMessage VB04 = new FriendlyMessage("VB04", MessageType.Information, "No records found.");
            hash.Add("VB04", VB04);
            #endregion

            #region Package

            FriendlyMessage PKG01 = new FriendlyMessage("PKG01", MessageType.Success, "Package added successfully.");
            hash.Add("PKG01", PKG01);

            FriendlyMessage PKG02 = new FriendlyMessage("PKG02", MessageType.Success, "Package updated successfully.");
            hash.Add("PKG02", PKG02);

            FriendlyMessage PKG03 = new FriendlyMessage("PKG03", MessageType.Information, "No records found.");
            hash.Add("PKG03", PKG03);

            FriendlyMessage PKGD01 = new FriendlyMessage("PKGD01", MessageType.Success, "Package date added successfully.");
            hash.Add("PKGD01", PKGD01);

            FriendlyMessage PKGD02 = new FriendlyMessage("PKGD02", MessageType.Success, "Package date updated successfully.");
            hash.Add("PKGD02", PKGD02);

            FriendlyMessage PKGD03 = new FriendlyMessage("PKGD03", MessageType.Information, "No records found.");
            hash.Add("PKGD03", PKGD03);

            FriendlyMessage PKGD04 = new FriendlyMessage("PKGD04", MessageType.Success, "Package date deleted successfully.");
            hash.Add("PKGD04", PKGD04);

            FriendlyMessage PKGI01 = new FriendlyMessage("PKGI01", MessageType.Success, "Package itinerary added successfully.");
            hash.Add("PKGI01", PKGI01);

            FriendlyMessage PKGI02 = new FriendlyMessage("PKGI02", MessageType.Success, "Package itinerary updated successfully.");
            hash.Add("PKGI02", PKGI02);

            FriendlyMessage PKGI03 = new FriendlyMessage("PKGI03", MessageType.Information, "No records found.");
            hash.Add("PKGI03", PKGI03);

            FriendlyMessage PKGI04 = new FriendlyMessage("PKGI04", MessageType.Success, "Package itinerary deleted successfully.");
            hash.Add("PKGI04", PKGI04);

            FriendlyMessage PKGO01 = new FriendlyMessage("PKGO01", MessageType.Success, "Package other details added successfully.");
            hash.Add("PKGO01", PKGO01);

            FriendlyMessage PKGO02 = new FriendlyMessage("PKGO02", MessageType.Success, "Package other details updated successfully.");
            hash.Add("PKGO02", PKGO02);

            #region Package Itinerary Hotel

            FriendlyMessage PKGH01 = new FriendlyMessage("PKGH01", MessageType.Success, "Package itinerary hotel added successfully.");
            hash.Add("PKGH01", PKGH01);

            FriendlyMessage PKGH02 = new FriendlyMessage("PKGH02", MessageType.Success, "Package itinerary hotel updated successfully.");
            hash.Add("PKGH02", PKGH02);

            FriendlyMessage PKGH03 = new FriendlyMessage("PKGH03", MessageType.Success, "Package itinerary hotel deleted successfully.");
            hash.Add("PKGH03", PKGH03);

            #endregion

            #region Package Itinerary Flight

            FriendlyMessage PKGF01 = new FriendlyMessage("PKGF01", MessageType.Success, "Package itinerary flight added successfully.");
            hash.Add("PKGF01", PKGF01);

            FriendlyMessage PKGF02 = new FriendlyMessage("PKGF02", MessageType.Success, "Package itinerary flight updated successfully.");
            hash.Add("PKGF02", PKGF02);

            FriendlyMessage PKGF03 = new FriendlyMessage("PKGF03", MessageType.Success, "Package itinerary flight deleted successfully.");
            hash.Add("PKGF03", PKGF03);

            #endregion

            #region Package Itinerary Train

            FriendlyMessage PKGT01 = new FriendlyMessage("PKGT01", MessageType.Success, "Package itinerary train added successfully.");
            hash.Add("PKGT01", PKGT01);

            FriendlyMessage PKGT02 = new FriendlyMessage("PKGT02", MessageType.Success, "Package itinerary train updated successfully.");
            hash.Add("PKGT02", PKGT02);

            FriendlyMessage PKGT03 = new FriendlyMessage("PKGT03", MessageType.Success, "Package itinerary train deleted successfully.");
            hash.Add("PKGT03", PKGT03);

            #endregion

            #region Package Itinerary Bus

            FriendlyMessage PKGB01 = new FriendlyMessage("PKGB01", MessageType.Success, "Package itinerary bus added successfully.");
            hash.Add("PKGB01", PKGB01);

            FriendlyMessage PKGB02 = new FriendlyMessage("PKGB02", MessageType.Success, "Package itinerary bus updated successfully.");
            hash.Add("PKGB02", PKGB02);

            FriendlyMessage PKGB03 = new FriendlyMessage("PKGB03", MessageType.Success, "Package itinerary bus deleted successfully.");
            hash.Add("PKGB03", PKGB03);

            #endregion


            #region Package Itinerary Vehicle

            FriendlyMessage PKGV01 = new FriendlyMessage("PKGV01", MessageType.Success, "Package itinerary vehicle added successfully.");
            hash.Add("PKGV01", PKGV01);

            FriendlyMessage PKGV02 = new FriendlyMessage("PKGV02", MessageType.Success, "Package itinerary vehicle updated successfully.");
            hash.Add("PKGV02", PKGV02);

            FriendlyMessage PKGV03 = new FriendlyMessage("PKGV03", MessageType.Success, "Package itinerary vehicle deleted successfully.");
            hash.Add("PKGV03", PKGV03);

            #endregion

            #endregion

            #region CustomerCategory

            FriendlyMessage CustomerCategory01 = new FriendlyMessage("CustomerCategory01", MessageType.Success, "Customer category added successfully.");
            hash.Add("CustomerCategory01", CustomerCategory01);

            FriendlyMessage CustomerCategory02 = new FriendlyMessage("CustomerCategory02", MessageType.Success, "Customer category updated successfully.");
            hash.Add("CustomerCategory02", CustomerCategory02);

            FriendlyMessage CustomerCategory03 = new FriendlyMessage("CustomerCategory03", MessageType.Information, "No records found.");
            hash.Add("CustomerCategory03", CustomerCategory03);

            #endregion

			#region Tax Formula

			FriendlyMessage TF01 = new FriendlyMessage("TF01", MessageType.Success, "Tax formula added successfully.");
			hash.Add("TF01", TF01);

			FriendlyMessage TF02 = new FriendlyMessage("TF02", MessageType.Success, "Tax formula updated successfully.");
			hash.Add("TF02", TF02);

			#endregion

            #region Customer

            FriendlyMessage Cu01 = new FriendlyMessage("Cu01", MessageType.Success, "Customer added successfully.");
            hash.Add("Cu01", Cu01);

            FriendlyMessage Cu02 = new FriendlyMessage("Cu02", MessageType.Success, "Customer updated successfully.");
            hash.Add("Cu02", Cu02);

            FriendlyMessage Cu03 = new FriendlyMessage("Cu03", MessageType.Information, "No records found.");

            hash.Add("Cu03", Cu03);

            #endregion

            #region Role

            FriendlyMessage Ro01 = new FriendlyMessage("Ro01", MessageType.Success, "Role added successfully.");
            hash.Add("Ro01", Ro01);

            FriendlyMessage Ro02 = new FriendlyMessage("Ro02", MessageType.Success, "Role updated successfully.");
            hash.Add("Ro02", Ro02);

            FriendlyMessage Ro03 = new FriendlyMessage("Ro03", MessageType.Information, "No records found.");
            hash.Add("Ro03", Ro03);

            #endregion

            #region Tax

            FriendlyMessage To01 = new FriendlyMessage("To01", MessageType.Success, "Tax added successfully.");
            hash.Add("To01", To01);

            FriendlyMessage To02 = new FriendlyMessage("To02", MessageType.Success, "Tax updated successfully.");
            hash.Add("To02", To02);

            FriendlyMessage To03 = new FriendlyMessage("To03", MessageType.Information, "No records found.");
            hash.Add("To03", To03);

            #endregion

            #region Vehicle

            FriendlyMessage Ve01 = new FriendlyMessage("Ve01", MessageType.Success, "Vehicle added successfully.");
            hash.Add("Ve01", Ve01);

            FriendlyMessage Ve02 = new FriendlyMessage("Ve02", MessageType.Success, "Vehicle updated successfully.");
            hash.Add("Ve02", Ve02);

            FriendlyMessage Ve03 = new FriendlyMessage("Ve03", MessageType.Information, "No records found.");
            hash.Add("Ve03", Ve03);

            #endregion

            #region VehicleBrand

            FriendlyMessage Vb01 = new FriendlyMessage("Vb01", MessageType.Success, "Vehicle brand name added successfully.");
            hash.Add("Vb01", Vb01);

            FriendlyMessage Vb02 = new FriendlyMessage("Vb02", MessageType.Success, "Vehicle brand name updated successfully.");
            hash.Add("Vb02", Vb02);

            FriendlyMessage Vb03 = new FriendlyMessage("Vb03", MessageType.Information, "No records found.");
            hash.Add("Vb03", Vb03);

            #endregion

            #region VehicleType

            FriendlyMessage Vt01 = new FriendlyMessage("Vt01", MessageType.Success, "Vehicle type name added successfully.");
            hash.Add("Vt01", Vt01);

            FriendlyMessage Vt02 = new FriendlyMessage("Vt02", MessageType.Success, "Vehicle type name updated successfully.");
            hash.Add("Vt02", Vt02);

            FriendlyMessage Vt03 = new FriendlyMessage("Vt03", MessageType.Information, "No records found.");
            hash.Add("Vt03", Vt03);

            #endregion

            #region User

            FriendlyMessage U01 = new FriendlyMessage("U01", MessageType.Success, "User added successfully.");
            hash.Add("U01", U01);

            FriendlyMessage U02 = new FriendlyMessage("U02", MessageType.Success, "User updated successfully.");
            hash.Add("U02", U02);

            FriendlyMessage U03 = new FriendlyMessage("U03", MessageType.Information, "No records found.");

            hash.Add("U03", U03);

            #endregion

            #region User Login

            FriendlyMessage UM001 = new FriendlyMessage("UM001",MessageType.Warning, "Username and password does not match. Please Login again.");
            hash.Add("UM001", UM001);

            FriendlyMessage UM002 = new FriendlyMessage("UM002",MessageType.Success, "User has been added successfully. please check your Email to Activate start using your account");
            hash.Add("UM002", UM002);

            FriendlyMessage UM003 = new FriendlyMessage("UM003",MessageType.Success, "User has been updated successfully.");
            hash.Add("UM003", UM003);

            FriendlyMessage UM004 = new FriendlyMessage("UM004",MessageType.Warning, "User Session has been Expired. Please Login again.");
            hash.Add("UM004", UM004);

            FriendlyMessage UM005 = new FriendlyMessage("UM005",MessageType.Information, "User can now login with User name and Created password.");
            hash.Add("UM005", UM005);

            FriendlyMessage UM006 = new FriendlyMessage("UM006",MessageType.Information, "please check your Email to Reset password and start using your account");
            hash.Add("UM006", UM006);

            FriendlyMessage UM007 = new FriendlyMessage("UM007", MessageType.Warning, "User is InActive. Contact system administrator.");
            hash.Add("UM007", UM007);

            #endregion

            #region SightSeeing

            FriendlyMessage SS01 = new FriendlyMessage("SS01", MessageType.Success, "Sight Seeing  added successfully.");
            hash.Add("SS01", SS01);

            FriendlyMessage SS02 = new FriendlyMessage("SS02", MessageType.Success, "Sight Seeing updated successfully.");
            hash.Add("SS02", SS02);

            FriendlyMessage SS03 = new FriendlyMessage("SS03", MessageType.Information, "No records found.");
            hash.Add("SS03", SS03);

            #endregion

			#region Hotel 

			FriendlyMessage HM01 = new FriendlyMessage("HM01", MessageType.Success, "Hotel basic details added successfully.");
			hash.Add("HM01", HM01);

			FriendlyMessage HM02 = new FriendlyMessage("HM02", MessageType.Success, "Hotel basic details updated successfully.");
			hash.Add("HM02", HM02);

			FriendlyMessage HM03 = new FriendlyMessage("HM03", MessageType.Success, "Facilities inserted successfully.");
			hash.Add("HM03", HM03);

			FriendlyMessage HM04 = new FriendlyMessage("HM04", MessageType.Success, "Hotel room type added successfully.");
			hash.Add("HM04", HM04);

			FriendlyMessage HM05 = new FriendlyMessage("HM05", MessageType.Success, "Hotel room type updated successfully.");
			hash.Add("HM05", HM05);

			FriendlyMessage HM06 = new FriendlyMessage("HM06", MessageType.Success, "Hotel room type deleted successfully.");
			hash.Add("HM06", HM06);

			FriendlyMessage HM07 = new FriendlyMessage("HM07", MessageType.Success, "Hotel contact person added successfully.");
			hash.Add("HM07", HM07);

			FriendlyMessage HM08 = new FriendlyMessage("HM08", MessageType.Success, "Hotel contact person updated successfully.");
			hash.Add("HM08", HM08);

			FriendlyMessage HM09 = new FriendlyMessage("HM09", MessageType.Success, "Hotel contact person deleted successfully.");
			hash.Add("HM09", HM09);

			FriendlyMessage HM10 = new FriendlyMessage("HM10", MessageType.Success, "Hotel bank details added successfully.");
			hash.Add("HM10", HM10);

			FriendlyMessage HM11 = new FriendlyMessage("HM11", MessageType.Success, "Hotel bank details updated successfully.");
			hash.Add("HM11", HM11);

			FriendlyMessage HM12 = new FriendlyMessage("HM12", MessageType.Success, "Hotel bank details deleted successfully.");
			hash.Add("HM12", HM12);

			#endregion

            #region HotelType

            FriendlyMessage HOTELTYPE01 = new FriendlyMessage("HOTELTYPE01", MessageType.Success, "Hotel type added successfully.");
            hash.Add("HOTELTYPE01", HOTELTYPE01);

            FriendlyMessage HOTELTYPE02 = new FriendlyMessage("HOTELTYPE02", MessageType.Success, "Hotel type updated successfully.");
            hash.Add("HOTELTYPE02", HOTELTYPE02);


            #endregion

            #region Vehicle Tariff

            FriendlyMessage VT01 = new FriendlyMessage("VT01", MessageType.Success, "Vehicle tariff  added successfully.");
            hash.Add("VT01", VT01);

            FriendlyMessage VT02 = new FriendlyMessage("VT02", MessageType.Success, "Vehicle tariff updated successfully.");
            hash.Add("VT02", VT02);

            FriendlyMessage VT03 = new FriendlyMessage("VT03", MessageType.Information, "No records found.");
            hash.Add("VT03", VT03);

            FriendlyMessage VTP01 = new FriendlyMessage("VTP01", MessageType.Success, "Vehicle tariff price  added successfully.");
            hash.Add("VTP01", VTP01);

            FriendlyMessage VTP02 = new FriendlyMessage("VTP02", MessageType.Success, "Vehicle tariff price updated successfully.");
            hash.Add("VTP02", VTP02);

            FriendlyMessage VTP03 = new FriendlyMessage("VTP03", MessageType.Information, "No records found.");
            hash.Add("VTP03", VTP03);

            FriendlyMessage VTP04 = new FriendlyMessage("VTP04", MessageType.Success, "Vehicle tariff price deleted successfully.");
            hash.Add("VTP04", VTP04);

            FriendlyMessage VTCP01 = new FriendlyMessage("VTCP01", MessageType.Success, "Vehicle tariff customer category  added successfully.");
            hash.Add("VTCP01", VTCP01);

            FriendlyMessage VTCP02 = new FriendlyMessage("VTCP02", MessageType.Success, "Vehicle tariff customer category  updated successfully.");
            hash.Add("VTCP02", VTCP02);

            FriendlyMessage VTCP03 = new FriendlyMessage("VTCP03", MessageType.Information, "No records found.");
            hash.Add("VTCP03", VTCP03);

            FriendlyMessage VTCP04 = new FriendlyMessage("VTCP04", MessageType.Success, "Vehicle tariff customer category deleted successfully.");
            hash.Add("VTCP04", VTCP04);

            #endregion

            #region HotelTariff

            FriendlyMessage HotelTariff01 = new FriendlyMessage("HotelTariff01", MessageType.Success, "Hotel tariff  added successfully.");
            hash.Add("HotelTariff01", HotelTariff01);

            FriendlyMessage HotelTariff02 = new FriendlyMessage("HotelTariff02", MessageType.Success, "Hotel tariff  updated successfully.");
            hash.Add("HotelTariff02", HotelTariff02);

            FriendlyMessage HotelTariff03 = new FriendlyMessage("HotelTariff03", MessageType.Information, "No records found.");
            hash.Add("HotelTariff03", HotelTariff03);

            FriendlyMessage HotelTariffDuration01 = new FriendlyMessage("HotelTariffDuration01", MessageType.Success, "Hotel tariff duration details and customer categories added successfully.");
            hash.Add("HotelTariffDuration01", HotelTariffDuration01);

            FriendlyMessage HotelTariffDuration02 = new FriendlyMessage("HotelTariffDuration02", MessageType.Success, "Hotel tariff duration details and customer categories updated successfully.");
            hash.Add("HotelTariffDuration02", HotelTariffDuration02);

            FriendlyMessage HotelTariffDuration03 = new FriendlyMessage("HotelTariffDuration03", MessageType.Information, "Hotel tariff duration details and customer categories deleted successfully.");
            hash.Add("HotelTariffDuration03", HotelTariffDuration03);

            FriendlyMessage HotelTariffRoom01 = new FriendlyMessage("HotelTariffRoom01", MessageType.Success, "Hotel tariff room details  added successfully.");
            hash.Add("HotelTariffRoom01", HotelTariffRoom01);

            FriendlyMessage HotelTariffRoom02 = new FriendlyMessage("HotelTariffRoom02", MessageType.Success, "Hotel tariff room details  updated successfully.");
            hash.Add("HotelTariffRoom02", HotelTariffRoom02);

            FriendlyMessage HotelTariffRoom03 = new FriendlyMessage("HotelTariffRoom03", MessageType.Information, "Hotel tariff room details deleted successfully.");
            hash.Add("HotelTariffRoom03", HotelTariffRoom03);

            FriendlyMessage HotelTariffRoomOccupancy01 = new FriendlyMessage("HotelTariffRoomOccupancy01", MessageType.Success, "Hotel tariff room Occupancy details added successfully.");
            hash.Add("HotelTariffRoomOccupancy01", HotelTariffRoomOccupancy01);

            FriendlyMessage HotelTariffRoomOccupancy02 = new FriendlyMessage("HotelTariffRoomOccupancy02", MessageType.Success, "Hotel tariff room Occupancy details updated successfully.");
            hash.Add("HotelTariffRoomOccupancy02", HotelTariffRoomOccupancy02);

            FriendlyMessage HotelTariffRoomOccupancy03 = new FriendlyMessage("HotelTariffRoomOccupancy03", MessageType.Information, "Hotel tariff room Occupancy details deleted successfully.");
            hash.Add("HotelTariffRoomOccupancy03", HotelTariffRoomOccupancy03);

            FriendlyMessage HotelTariffPrice01 = new FriendlyMessage("HotelTariffPrice01", MessageType.Success, "Hotel tariff price details added successfully.");
            hash.Add("HotelTariffPrice01", HotelTariffPrice01);

            FriendlyMessage HotelTariffPrice02 = new FriendlyMessage("HotelTariffPrice02", MessageType.Success, "Hotel tariff price details updated successfully.");
            hash.Add("HotelTariffPrice02", HotelTariffPrice02);

            FriendlyMessage HotelTariffPrice03 = new FriendlyMessage("HotelTariffPrice03", MessageType.Information, "Hotel tariff price details deleted successfully.");
            hash.Add("HotelTariffPrice03", HotelTariffPrice03);


            FriendlyMessage HotelTariffCustomerCategory01 = new FriendlyMessage("HotelTariffCustomerCategory01", MessageType.Success, "Hotel tariff customer category added successfully.");
            hash.Add("HotelTariffCustomerCategory01", HotelTariffCustomerCategory01);

            FriendlyMessage HotelTariffCustomerCategory02 = new FriendlyMessage("HotelTariffCustomerCategory02", MessageType.Success, "Hotel tariff customer category updated successfully.");
            hash.Add("HotelTariffCustomerCategory02", HotelTariffCustomerCategory02);

            FriendlyMessage HotelTariffCustomerCategory03 = new FriendlyMessage("HotelTariffCustomerCategory03", MessageType.Information, "Hotel tariff customer category deleted successfully.");
            hash.Add("HotelTariffCustomerCategory03", HotelTariffCustomerCategory03);

            #endregion

            #region Hotel Tariff Tax Updation

            FriendlyMessage HTTU01 = new FriendlyMessage("HTTU01", MessageType.Success, "Hotel tariff tax updation updated successfully.");
            hash.Add("HTTU01", HTTU01);

            #endregion

            #region Supplier Hotel Tariff

            FriendlyMessage SUPPLIERHOTELTARIFF01 = new FriendlyMessage("SUPPLIERHOTELTARIFF01", MessageType.Success, "Supplier hotel added successfully.");
            hash.Add("SUPPLIERHOTELTARIFF01", SUPPLIERHOTELTARIFF01);

            FriendlyMessage SUPPLIERHOTELTARIFF02 = new FriendlyMessage("SUPPLIERHOTELTARIFF02", MessageType.Success, "Supplier hotel detail added successfully.");
            hash.Add("SUPPLIERHOTELTARIFF02", SUPPLIERHOTELTARIFF02);

            FriendlyMessage SUPPLIERHOTELTARIFF03 = new FriendlyMessage("SUPPLIERHOTELTARIFF03", MessageType.Success, "Supplier hotel duration detail added successfully.");
            hash.Add("SUPPLIERHOTELTARIFF03", SUPPLIERHOTELTARIFF03);

            FriendlyMessage SUPPLIERHOTELTARIFF04 = new FriendlyMessage("SUPPLIERHOTELTARIFF04", MessageType.Success, "Supplier hotel prices added successfully.");
            hash.Add("SUPPLIERHOTELTARIFF04", SUPPLIERHOTELTARIFF04);

            FriendlyMessage SUPPLIERHOTELTARIFF05 = new FriendlyMessage("SUPPLIERHOTELTARIFF05", MessageType.Success, "Supplier hotel duration detail updated successfully.");
            hash.Add("SUPPLIERHOTELTARIFF05", SUPPLIERHOTELTARIFF05);

            FriendlyMessage SUPPLIERHOTELTARIFF06 = new FriendlyMessage("SUPPLIERHOTELTARIFF06", MessageType.Success, "Supplier hotel detail updated successfully.");
            hash.Add("SUPPLIERHOTELTARIFF06", SUPPLIERHOTELTARIFF06);

            FriendlyMessage SUPPLIERHOTELTARIFF07 = new FriendlyMessage("SUPPLIERHOTELTARIFF07", MessageType.Success, "Supplier hotel detail deleted successfully.");
            hash.Add("SUPPLIERHOTELTARIFF07", SUPPLIERHOTELTARIFF07);


            FriendlyMessage SUPPLIERHOTELTARIFF08 = new FriendlyMessage("SUPPLIERHOTELTARIFF08", MessageType.Success, "Supplier hotel tariff detail updated successfully.");
            hash.Add("SUPPLIERHOTELTARIFF08", SUPPLIERHOTELTARIFF08);


            FriendlyMessage SUPPLIERHOTELTARIFF09 = new FriendlyMessage("SUPPLIERHOTELTARIFF09", MessageType.Success, "Supplier hotel tariff customer category added successfully.");
            hash.Add("SUPPLIERHOTELTARIFF09", SUPPLIERHOTELTARIFF09);

            FriendlyMessage SUPPLIERHOTELTARIFF10 = new FriendlyMessage("SUPPLIERHOTELTARIFF10", MessageType.Success, "Supplier hotel tariff customer category updated successfully.");
            hash.Add("SUPPLIERHOTELTARIFF10", SUPPLIERHOTELTARIFF10);


            FriendlyMessage SUPPLIERHOTELTARIFF11 = new FriendlyMessage("SUPPLIERHOTELTARIFF11", MessageType.Success, "Supplier hotel tariff customer category deleted scuccessfully.");
            hash.Add("SUPPLIERHOTELTARIFF11", SUPPLIERHOTELTARIFF11);

            FriendlyMessage SUPPLIERHOTELTARIFF12 = new FriendlyMessage("SUPPLIERHOTELTARIFF12", MessageType.Success, "Supplier Occupancy Details added successfully.");
            hash.Add("SUPPLIERHOTELTARIFF12", SUPPLIERHOTELTARIFF12);

            FriendlyMessage SUPPLIERHOTELTARIFF13 = new FriendlyMessage("SUPPLIERHOTELTARIFF13", MessageType.Success, "Supplier Occupancy Details Updated successfully.");
            hash.Add("SUPPLIERHOTELTARIFF13", SUPPLIERHOTELTARIFF13);

            FriendlyMessage SUPPLIERHOTELTARIFF14 = new FriendlyMessage("SUPPLIERHOTELTARIFF14", MessageType.Success, " Supplier Hotel tariff duration details and customer categories added successfully.");
            hash.Add("SUPPLIERHOTELTARIFF14", SUPPLIERHOTELTARIFF14);

            #region Supplier hotel days

            FriendlyMessage SUPPLIERHOTELTARIFF15 = new FriendlyMessage("SUPPLIERHOTELTARIFF15", MessageType.Success, " Supplier Hotel tariff day details updated successfully.");
            hash.Add("SUPPLIERHOTELTARIFF15", SUPPLIERHOTELTARIFF15);

            FriendlyMessage SUPPLIERHOTELTARIFF16 = new FriendlyMessage("SUPPLIERHOTELTARIFF16", MessageType.Success, " Supplier Hotel tariff day item details inserted successfully.");
            hash.Add("SUPPLIERHOTELTARIFF16", SUPPLIERHOTELTARIFF16);


            FriendlyMessage SUPPLIERHOTELTARIFF17 = new FriendlyMessage("SUPPLIERHOTELTARIFF17", MessageType.Success, " Supplier Hotel tariff day item details deleted successfully.");
            hash.Add("SUPPLIERHOTELTARIFF17", SUPPLIERHOTELTARIFF17);

            #endregion

            #endregion

            #region Authentication

            FriendlyMessage AUTHENTICATION01 = new FriendlyMessage("AUTHENTICATION01", MessageType.AcessDenied, "Sorry, you don't have permission to access on this server.");
            hash.Add("AUTHENTICATION01", AUTHENTICATION01);

            #endregion

            #region Accessories

            FriendlyMessage ACCESSORIES01 = new FriendlyMessage("ACCESSORIES01", MessageType.Success, "File uploaded successfully.");
            hash.Add("ACCESSORIES01", ACCESSORIES01);

            FriendlyMessage ACCESSORIES02 = new FriendlyMessage("ACCESSORIES02", MessageType.Success, "File deleted successfully.");
            hash.Add("ACCESSORIES02", ACCESSORIES02);

            #endregion

            #region LohanaPackageTariff

            FriendlyMessage LohanaTariff01 = new FriendlyMessage("LohanaTariff01", MessageType.Success, "Lohana package tariff added successfully.");
            hash.Add("LohanaTariff01", LohanaTariff01);

            FriendlyMessage LohanaTariff02 = new FriendlyMessage("LohanaTariff02", MessageType.Success, "Lohana package tariff  updated successfully.");
            hash.Add("LohanaTariff02", LohanaTariff02);

            FriendlyMessage LohanaTariff03 = new FriendlyMessage("LohanaTariff03", MessageType.Information, "No records found.");
            hash.Add("LohanaTariff03", LohanaTariff03);

            FriendlyMessage LohanaTariff04 = new FriendlyMessage("LohanaTariff04", MessageType.Information, "Hotel details added successfully.");
            hash.Add("LohanaTariff04", LohanaTariff04);

            FriendlyMessage LohanaTariff05 = new FriendlyMessage("LohanaTariff05", MessageType.Information, "Hotel details updated successfully.");
            hash.Add("LohanaTariff05", LohanaTariff05);

            FriendlyMessage LohanaTariff06 = new FriendlyMessage("LohanaTariff06", MessageType.Information, "Hotel details deleted successfully.");
            hash.Add("LohanaTariff06", LohanaTariff06);

            FriendlyMessage LohanaTariff07 = new FriendlyMessage("LohanaTariff07", MessageType.Information, "vehicle details added successfully.");
            hash.Add("LohanaTariff07", LohanaTariff07);

            FriendlyMessage LohanaTariff08 = new FriendlyMessage("LohanaTariff08", MessageType.Information, "vehicle details updated successfully.");
            hash.Add("LohanaTariff08", LohanaTariff08);

            FriendlyMessage LohanaTariff09 = new FriendlyMessage("LohanaTariff09", MessageType.Information, "vehicle details deleted successfully.");
            hash.Add("LohanaTariff09", LohanaTariff09);

            FriendlyMessage LohanaTariff10 = new FriendlyMessage("LohanaTariff10", MessageType.Success, "Lohana package tariff Root added successfully.");
            hash.Add("LohanaTariff10", LohanaTariff10);

            FriendlyMessage LohanaTariff11 = new FriendlyMessage("LohanaTariff11", MessageType.Success, "Lohana package tariff Root updated successfully.");
            hash.Add("LohanaTariff11", LohanaTariff11);

            FriendlyMessage LohanaTariff12 = new FriendlyMessage("LohanaTariff12", MessageType.Information, "No records found.");
            hash.Add("LohanaTariff12", LohanaTariff12);

            FriendlyMessage LohanaTariff13 = new FriendlyMessage("LohanaTariff13", MessageType.Information, "Lohana package tariff Root detail deleted successfully.");
            hash.Add("LohanaTariff13", LohanaTariff13);

            #endregion

            #region Enquiry

            FriendlyMessage Enq01 = new FriendlyMessage("Enq01", MessageType.Success, "Enquiry added successfully.");
            hash.Add("Enq01", Enq01);

            FriendlyMessage Enq02 = new FriendlyMessage("Enq02", MessageType.Success, "Enquiry updated successfully.");
            hash.Add("Enq02", Enq02);

            FriendlyMessage Enq03 = new FriendlyMessage("Enq03", MessageType.Information, "No records found.");
            hash.Add("Enq03", Enq03);

            FriendlyMessage Enq04 = new FriendlyMessage("Enq04", MessageType.Success, "Enquiry item added successfully.");
            hash.Add("Enq04", Enq04);

            FriendlyMessage Enq05 = new FriendlyMessage("Enq05", MessageType.Success, "Enquiry item updated successfully.");
            hash.Add("Enq05", Enq05);

            FriendlyMessage Enq06 = new FriendlyMessage("Enq06", MessageType.Success, "Enquiry item deleted successfully.");
            hash.Add("Enq06", Enq06);

            FriendlyMessage EnqTask01 = new FriendlyMessage("EnqTask01", MessageType.Success, "Enquiry Tasks added successfully.");
            hash.Add("EnqTask01", EnqTask01);

            #endregion

            #region Quotation

            FriendlyMessage Q01 = new FriendlyMessage("Q01", MessageType.Success, "Quotation added successfully.");
            hash.Add("Q01", Q01);

            FriendlyMessage Q02 = new FriendlyMessage("Q02", MessageType.Success, "Quotation updated successfully.");
            hash.Add("Q02", Q02);

            FriendlyMessage Q03 = new FriendlyMessage("Q03", MessageType.Information, "No records found.");
            hash.Add("Q03", Q03);

            FriendlyMessage Q04 = new FriendlyMessage("Q04", MessageType.Success, "Quotation item added successfully.");
            hash.Add("Q04", Q04);

            FriendlyMessage Q05 = new FriendlyMessage("Q05", MessageType.Success, "Quotation item updated successfully.");
            hash.Add("Q05", Q05);

            FriendlyMessage Q06 = new FriendlyMessage("Q06", MessageType.Success, "Quotation item deleted successfully.");
            hash.Add("Q06", Q06);

            FriendlyMessage Q07 = new FriendlyMessage("Q07", MessageType.Success, "Quotation Status updated successfully.");
            hash.Add("Q07", Q07);

            #endregion

            #region SightSeeingTariff

            FriendlyMessage SightSeeingTariff01 = new FriendlyMessage("SightSeeingTariff01", MessageType.Success, "SightSeeing tariff  added successfully.");
            hash.Add("SightSeeingTariff01", SightSeeingTariff01);

            FriendlyMessage SightSeeingTariff02 = new FriendlyMessage("SightSeeingTariff02", MessageType.Success, "SightSeeing tariff  updated successfully.");
            hash.Add("SightSeeingTariff02", SightSeeingTariff02);

            FriendlyMessage SightSeeingTariff03 = new FriendlyMessage("SightSeeingTariff03", MessageType.Success, "SightSeeing Occupancy tariff  added successfully.");
            hash.Add("SightSeeingTariff03", SightSeeingTariff03);

            FriendlyMessage SightSeeingTariff04 = new FriendlyMessage("SightSeeingTariff04", MessageType.Success, "SightSeeing Occupancy tariff  updated successfully.");
            hash.Add("SightSeeingTariff04", SightSeeingTariff04);

            FriendlyMessage SightSeeingTariff05 = new FriendlyMessage("SightSeeingTariff05", MessageType.Success, "SightSeeing Occupancy tariff  deleted successfully.");
            hash.Add("SightSeeingTariff05", SightSeeingTariff05);

            FriendlyMessage SightSeeingTariff06 = new FriendlyMessage("SightSeeingTariff06", MessageType.Success, "SightSeeing Price tariff  added successfully.");
            hash.Add("SightSeeingTariff06", SightSeeingTariff06);

            FriendlyMessage SightSeeingTariff07 = new FriendlyMessage("SightSeeingTariff07", MessageType.Success, "SightSeeing Price tariff  updated successfully.");
            hash.Add("SightSeeingTariff07", SightSeeingTariff07);

            FriendlyMessage SightSeeingTariff08 = new FriendlyMessage("SightSeeingTariff08", MessageType.Success, "SightSeeing Duration tariff  added successfully.");
            hash.Add("SightSeeingTariff08", SightSeeingTariff08);


            #endregion

            #region Booking

            FriendlyMessage Booking01 = new FriendlyMessage("Booking01", MessageType.Success, "Traveller Detail added successfully.");
            hash.Add("Booking01", Booking01);

            FriendlyMessage Booking02 = new FriendlyMessage("Booking02", MessageType.Success, "Traveller Detail updated successfully.");
            hash.Add("Booking02", Booking02);

            FriendlyMessage Booking03 = new FriendlyMessage("Booking03", MessageType.Success, "Traveller Detail deleted successfully.");
            hash.Add("Booking03", Booking03);

            FriendlyMessage Booking04 = new FriendlyMessage("Booking04", MessageType.Success, "Traveller Document deleted successfully.");
            hash.Add("Booking04", Booking04);

            FriendlyMessage Booking05 = new FriendlyMessage("Booking05", MessageType.Success, "Flight Details added successfully.");
            hash.Add("Booking05", Booking05);

            FriendlyMessage Booking06 = new FriendlyMessage("Booking06", MessageType.Success, "Flight Details updated successfully.");
            hash.Add("Booking06", Booking06);

            FriendlyMessage Booking07 = new FriendlyMessage("Booking07", MessageType.Success, "Flight Details deleted successfully.");
            hash.Add("Booking07", Booking07);

            FriendlyMessage Booking08 = new FriendlyMessage("Booking08", MessageType.Success, "Traveller Flight Details added successfully.");
            hash.Add("Booking08", Booking08);

            FriendlyMessage Booking09 = new FriendlyMessage("Booking09", MessageType.Success, "Traveller Flight Details deleted successfully.");
            hash.Add("Booking09", Booking09);

            FriendlyMessage Booking10 = new FriendlyMessage("Booking10", MessageType.Success, "Train Details added successfully.");
            hash.Add("Booking10", Booking10);

            FriendlyMessage Booking11 = new FriendlyMessage("Booking11", MessageType.Success, "Train Details updated successfully.");
            hash.Add("Booking11", Booking11);

            FriendlyMessage Booking12 = new FriendlyMessage("Booking12", MessageType.Success, "Train Details deleted successfully.");
            hash.Add("Booking12", Booking12);


            #endregion

            FriendlyMessage Pa01 = new FriendlyMessage("Pa01", MessageType.Success, "Payable added successfully.");
            hash.Add("Pa01", Pa01);

            FriendlyMessage Pa02 = new FriendlyMessage("Pa02", MessageType.Success, "Payable updated successfully.");
            hash.Add("Pa02", Pa02);

            #region ReceivablePayment

            FriendlyMessage PAY01 = new FriendlyMessage("PAY01", MessageType.Success, "Customer Payment added successfully.");
            hash.Add("PAY01", PAY01);


            #endregion

        }

		public static FriendlyMessage Get(string code)
		{
			FriendlyMessage message = hash.Find(code);

			return message;
		}

		/// <summary>
		/// struct to hold generic key and value
		/// </summary>
		/// <typeparam name="K">Key</typeparam>
		/// <typeparam name="V">Value</typeparam>
		/// <remarks></remarks>
        /// 
		public struct KeyValue<K, V>
		{
			/// <summary>
			/// Gets or sets the key.
			/// </summary>
			/// <value>The key.</value>
			/// <remarks></remarks>
			public K Key
			{
				get;
				set;
			}
			/// <summary>
			/// Gets or sets the value.
			/// </summary>
			/// <value>The value.</value>
			/// <remarks></remarks>
			public V Value
			{
				get;
				set;
			}
		}

		/// <summary>
		/// FixedSizeGenericHashTable
		/// </summary>
		/// <typeparam name="K">Key</typeparam>
		/// <typeparam name="V">Value</typeparam>
		/// <remarks>Object for FixedSizeGenericHashTable of key K and of value V</remarks>
		public class FixedSizeGenericHashTable<K, V>
		{
			private readonly int size;
			private readonly LinkedList<KeyValue<K, V>>[] items;

			public FixedSizeGenericHashTable(int size)
			{
				this.size = size;
				items = new LinkedList<KeyValue<K, V>>[size];
			}

			protected int GetArrayPosition(K key)
			{
				int position = key.GetHashCode() % size;
				return Math.Abs(position);
			}

			public V Find(K key)
			{
				int position = GetArrayPosition(key);
				LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
				foreach(KeyValue<K, V> item in linkedList)
				{
					if(item.Key.Equals(key))
					{
						return item.Value;
					}
				}

				return default(V);
			}

			/// <summary>
			/// Adds the specified key.
			/// </summary>
			/// <param name="key">The key.</param>
			/// <param name="value">The value.</param>
			/// <remarks></remarks>
			public void Add(K key, V value)
			{
				int position = GetArrayPosition(key);
				LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
				KeyValue<K, V> item = new KeyValue<K, V>()
				{
					Key = key,
					Value = value
				};
				linkedList.AddLast(item);
			}

			/// <summary>
			/// Removes the specified key.
			/// </summary>
			/// <param name="key">The key.</param>
			/// <remarks></remarks>
			public void Remove(K key)
			{
				int position = GetArrayPosition(key);
				LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
				bool itemFound = false;
				KeyValue<K, V> foundItem = default(KeyValue<K, V>);
				foreach(KeyValue<K, V> item in linkedList)
				{
					if(item.Key.Equals(key))
					{
						itemFound = true;
						foundItem = item;
					}
				}

				if(itemFound)
				{
					linkedList.Remove(foundItem);
				}
			}

			/// <summary>
			/// Gets the linked list.
			/// </summary>
			/// <param name="position">The position.</param>
			/// <returns></returns>
			/// <remarks></remarks>
			protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
			{
				LinkedList<KeyValue<K, V>> linkedList = items[position];
				if(linkedList == null)
				{
					linkedList = new LinkedList<KeyValue<K, V>>();
					items[position] = linkedList;
				}

				return linkedList;
			}
		}
	}
}
