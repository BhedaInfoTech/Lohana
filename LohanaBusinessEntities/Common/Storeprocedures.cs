using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.Common
{
    public enum Storeprocedures
    {

        # region Country

        spInsertCountry,
        spGetCountries,
        spUpdateCountry,
        spCheckCountryCodeExist,
        spCheckCountryNameExist,

        #endregion

        #region RoomType

        spInsertRoomType,
        spGetRoomTypes,
        spUpdateRoomType,
        spCheckRoomTypeCodeExist,
        spCheckRoomTypeNameExist,

        #endregion

        #region Meal

        spInsertMeal,
        spGetMeals,
        spUpdateMeal,
        spCheckMealCodeExist,
        spCheckMealNameExist,

        #endregion

        #region Occupancy

        spInsertOccupancy,
        spGetOccupancies,
        spUpdateOccupancy,
        spCheckOccupancyCodeExist,
        spCheckOccupancyNameExist,

        #endregion

        #region Business

        spInsertBusiness,
        spGetBusinesses,
        spUpdateBusiness,
        spCheckBusinessCodeExist,
        spCheckBusinessNameExist,

        #endregion

        #region Designation

        spInsertDesignation,
        spGetDesignations,
        spUpdateDesignation,
        spCheckDesignationCodeExist,
        spCheckDesignationNameExist,

        #endregion

        #region State

        spInsertState,
        spGetStates,
        spUpdateState,
        spCheckStateCodeExist,
        spCheckStateNameExist,
        spdrpGetCountries,

        #endregion

        #region City

        spInsertCity,
        spGetCities,
        spUpdateCity,
        spCheckCityCodeExist,
        spCheckCityNameExist,
        spdrpGetStates,
        spSetDrpStateValues,
        spGetStatesByCountryId,
        #endregion

        #region FacilityType

        spInsertFacilityType,
        spGetFacilityTypes,
        spUpdateFacilityType,
        spCheckFacilityTypeNameExist,
        #endregion

        #region Facility

        spInsertFacility,
        spGetFacilities,
        spUpdateFacility,
        spCheckFacilityNameExist,
        spdrpGetFacilityTypes,
        #endregion

        #region Charges

        spInsertCharges,
        spGetCharges,
        spUpdateCharges,
        spCheckChargesNameExist,
        spCheckChargesAbbrevationExist,
        spGetStandardCharges,
        spGetChargesById,

        #endregion

        #region Vendor

        spInsertVendor,
        spInsertContactPerson,
        spdrpGetCities,
        spdrpGetBusiness,
        spGetContactPerson,
        spGetVendor,
        spGetVendorById,
        spUpdateVendor,
        spGetContactPersonById,
        spUpdateContactPerson,
        spCheckVendorNameExist,
        spCheckVendorEmailIdExist,
        spDeleteContactPerson,
        spDeleteVendorBank,
        #endregion

        #region Hotel

        SpGetHotelRoomTypeDetails,
        spGetHotelRoomByHotelId,
        SpUpdateHotelRoomTypeDetails,
        SpInsertHotelRoomTypeDetails,
        spGetHotelRoomTypeById,
        spDeleteHotelRoomType,

        SpGetHotelFacilityDetails,
        SpUpdateHotelFacilityDetails,
        SpInsertHotelFacilityDetails,
        spDeleteHotelFacilities,
        spCheckHotelNameExist,
        spCheckHotelWebsiteExist,

        //spGetHotelFacilitesById,

        spInsertHotelBankDetails,
        spUpdateHotelBankDetails,
        spGetHotelBankDetails,
        spGetHotelBankDetailsById,
        spDeleteHotelBankDetails,


        SpGetHotel,
        SpUpdateHotel,
        SpInsertHotel,
        spGetHotelById,

        SpGetHotelNearestLandMarkDetails,
        SpUpdateHotelNearestLandMarkDetails,
        SpInsertHotelNearestLandMarkDetails,

        spdrpGetCountryStateCity,
        spHotelFacilities,
        spdrpGetRoomType,
        spdrpGetDesignation,
        spdrpGetHotelType,


        spHotelFacility,
        spHotelFacilityType,


        spInsertVendorBank,
        spGetVendorBank,
        spGetVendorBankById,
        spUpdateVendorbank,

        #endregion

        #region Tax Formula

        spdrpGetChargeType,
        spInsertTaxFormula,
        spUpdateTaxFormula,
        spGetTaxFormula,
        spCheckTaxFormulaNameExist,
        spGetTaxFormulaListing,
        spGetTaxFormulaById,
        spCheckTaxFormulaExist,
        spdrpGetTaxFormula,

        #region Tax Formula Cal on

        spInsertTaxFormulaCalOn,
        spDeleteTaxFormulaCalOn,
        spInsertTaxFormulaCharges,
        spInsertTaxFormulaCalculatedOn,
        spGetTaxFormulaCharges,
        spDeleteTaxFormulaCharges,
        spDeleteTaxFormulaCalculatedOn,
        #endregion

        #endregion

        #region CustomerCategory

        spCheckCustomerCategoryNameExist,
        // spCheckCustomerCategoryExist,
        spUpdateCustomerCategory,
        // spCheckMarginExist,
        spGetCustomerCategory,
        spInsertCustomerCategory,


        #endregion

        #region Attachments
        spInsertAttachment,
        spGetImages,
        spGetImagesByRefType,
        spDeleteAttachment,
        #endregion

        #region Customer
        spInsertCustomer,
        spGetCustomer,
        spGetCustomerById,
        spdrpGetCust_Category,
        spUpdateCustomer,
        spCheckCustomerEmailIdExist,
        spCheckCustomerNameExist,
        #endregion

        #region Package

        spInsertPackage,
        spUpdatePackage,
        spUpdatePackageDetails,
        spInsertPackageItinerary,
        spUpdatePackageItinerary,
        spInsertPackageDates,
        spUpdatePackageDates,

        spdrpGetPackageTypes,
        spdrpGetHotels,
        spdrpGetMeals,

        spGetPackage,
        spGetPackageById,
        spGetPackageDateById,
        spGetPackageDateDetails,
        spDeletePackageDate,
        spInsertPackageTypeMapping,
        spDeletePackageTypeMapping,
        GetPackageTypeListById,
        spGetPackageItinerary,
        spGetPackageItineraryById,
        spDeletePackageItinerary,
        spCheckPackageCodeExist,
        spCheckPackageNameExist,
        spGetSearchPackageDetails,

        #region packagetariffdate
        sp_Insert_PackageGitTriff,
        sp_Update_GitItinararyDays,
        sp_Get_PackageGitDays,
        sp_Get_GitDayItems,
        sp_Insert_GitItinararyDayItem,
        spDeleteGitDayItems,
        spInsertPackageTariffDuration,
        spInsertPackageTariffCustomerCategory,
        spGetpackagePrice,
        #endregion

        #region Package Itinerary Hotel
        spInsertPackageItineraryHotel,
        spGetPackageItineraryHotelById,
        spUpdatePackageItineraryHotel,
        spGetPackageItineraryHotels,
        spDeletePackageItineraryHotel,
        #endregion

        #region Package Itinerary Flight
        spInsertPackageItineraryFlight,
        spGetPackageItineraryFlightById,
        spUpdatePackageItineraryFlight,
        spGetPackageItineraryFlights,
        spDeletePackageItineraryFlight,
        #endregion

        #region Package Itinerary Train
        spInsertPackageItineraryTrain,
        spGetPackageItineraryTrainById,
        spUpdatePackageItineraryTrain,
        spGetPackageItineraryTrains,
        spDeletePackageItineraryTrain,
        #endregion

        #region Package Itinerary Bus
        spInsertPackageItineraryBus,
        spGetPackageItineraryBusById,
        spUpdatePackageItineraryBus,
        spGetPackageItineraryBuss,
        spDeletePackageItineraryBus,
        #endregion

        #region Package Itinerary Vehicle
        spInsertPackageItineraryVehicle,
        spGetPackageItineraryVehicleById,
        spUpdatePackageItineraryVehicle,
        spGetPackageItineraryVehicles,
        spDeletePackageItineraryVehicle,
        spGetSearchGitDetails,
        spGetSightSeeingEnquiryDetails,
        #endregion

        spGetPackageItineraryDtailsById,

        #endregion

        #region Role

        spUpdateRole,
        spGetRoles,
        spInsertRole,
        spCheckRoleNameExist,
        spGetRoleById,

        #endregion

        #region Module

        spUpdateRoleModule,
        spInsertRoleModule,
        spGetModuleByRoleId,

        #endregion

        #region Tax

        spInsertTax,
        spGetTaxes,
        spGetTaxById,
        spUpdateTax,
        spCheckTaxNameExist,
        spCheckTaxCodeExist,

        #endregion

        #region Vehicle

        spInsertVehicle,
        spGetVehicles,
        spdrpGetVehicleType,
        spdrpGetVehicleBrand,
        spGetVehicleById,
        spUpdateVehicle,
        spCheckVehicleNameExist,

        #endregion

        #region VehicleBrand

        spInsertVehicleBrand,
        spGetVehicleBrands,
        //spdrpGetVehicleBrand,
        spUpdateVehicleBrand,
        spCheckVehicleBrandNameExist,

        #endregion

        #region VehicleType

        spInsertVehicleType,
        //spdrpGetVehicleType,
        spGetVehicleTypes,
        spUpdateVehicleType,
        spCheckVehicleTypeNameExist,

        #endregion

        #region VehicleTariff

        spInsertVehicleTariff,
        spUpdateVehicleTariff,
        spGetVehicleTariff,
        spGetVehicleTariffById,
        spdrpGetVehicles,
        spGetVehicleTypeandSeatingCapacityOndrpVehicle,
        spSearchVehicleTariff,

        spInsertVehicleTariffPriceDetails,
        spUpdateVehicleTariffPriceDetails,
        spGetVehicleTariffPriceDetails,
        spGetVehicleTariffPriceDetailsById,
        spDeleteVehicleTariffPriceDetails,

        spInsertVehicleTariffCustomerCategoryDetails,
        spUpdateVehicleTariffCustomerCategoryDetails,
        spGetVehicleTariffCustomerCategoryDetails,
        spGetVehicleTariffCustomerCategoryDetailsById,
        spdrpGetCustomerCategory,
        spDeleteVehicleTariffCustomerCategoryDetails,
        spGetMarginOndrpCustomerCategory,

        #endregion

        #region User
        spInsertUser,
        spGetUser,
        spUpdateUser,
        spGetUserById,
        spCheckUserNameExist,
        spGetUsers,
        spGetUserEnquiryTask,
        spGetUserQuotationTask,

        spInsertUserLocations,
        spInsertUserTeamLead,
        spUpdateUserLocations,
        spUpdateUserTeamLead,
        spDeleteUserLocations,
        spDeleteUserSpecializationes,
        spInsertUserSpecialization,
        spDeleteUserTeamLead,
        #endregion

        AuthenticationLogin,
        spdrpGetRole_Id,
        spCheckWorkFlow,
        spGetUserApprovalTask,

        #region SightSeeing

        spInsertSightSeeing,

        spGetSightSeeing,

        spGetSightSeeingById,

        spUpdateSightSeeing,

        spCheckSightSeeingNameExist,

        GetSightSeeingInfo,

        #endregion

        #region SightSeeingTariff

        spdrpGetVendors,
        spdrpGetSightSeeings,
        spInsertSightSeeingTariffBasicDetails,
        spGetSightSeeingTariffBasicDetails,
        spUpdateSightSeeingTariffBasicDetails,
        spIsSameSightSeeingVendorExists,

        spInsertSightSeeingTariffDuration,
        spInsertSightSeeingTariffDurationDate,
        spGetSightSeeingTariffDuration,
        spGetSupplierHotelDetail,
        spGetSupplierHotelDuration,
        spInsertSightSeeingTariffOccupancy,
        spUpdateSightSeeingtTariffOccupancy,
        spGetSightSeeingTariffOccupancy,
        spDeleteSightSeeingTariffOccupancy,

        spGetSightSeeingTariffTaxCharges,
        spInsertSightSeeingTariffPrice,
        spInsertSightSeeingTariffCharges,
        spGetSightSeeingTariffPrice,
        spUpdateSightSeeingTariffPrice,
        spDeleteSightSeeingTariffCharges,
        spGetSightSeeingTariffPriceById,

        spGetSightSeeingTariffDurationPrice,
        spInsertSightSeeingTariffDate,
        spInsertSightSeeingTariffCustomerCategory,
        spUpdateSightSeeingTariffCustomerCategory,
        spGetSightSeeingTariffCustomerCategory,
        spGetSightSeeingTariffCustomerCategories,
        #endregion

        #region Hotel Tariff

        #region Basic Details
        spUpdateHotelTariff,
        spInsertHotelTariff,
        spGetHotelTariff,
        spIsSameHotelVendorExists,
        #endregion

        #region Room Details
        spUpdateHotelTariffRoomDetails,
        spInsertHotelTariffRoomDetails,
        spdrpGetOccupancies,
        spGetHotelTariffRoom,
        spDeleteHotelTariffRoom,
        #endregion

        #region Room Occupancy
        spUpdateHotelTariffRoomOccupancy,
        spInsertHotelTariffRoomOccupancy,
        spGetHotelTariffRoomOccupancy,
        spDeleteHotelTariffRoomOccupancy,
        #endregion

        #region Price Details
        spUpdateHotelTariffPriceDetails,
        spInsertHotelTariffPriceDetails,
        spInsertHotelTariffCharges,
        spGetHotelTariffDurationById,
        spGetHotelTariffPrice,
        spGetHotelTariffCharges,
        spGetHotelTariffTaxCharges,
        spUpdateHotelTariffCharges,
        spDeletHotelTariffCharges,
        spDeletHotelTariffDates,
        spGetHotelTariffPriceById,

        #endregion

        #region Duration Details
        spUpdateHotelTariffDurationDetails,
        spInsertHotelTariffDurationDetails,
        spUpdateHotelTariffDateDetails,
        spInsertHotelTariffDateDetails,
        spGetHotelTariffDuration,
        spDeleteHotelTariffDuration,
        spGetHotelTariffDurationPrice,
        #endregion

        #region Customer Category

        spInsertHotelTariffCustomerCategory,
        spGetHotelTariffCustomerCategory,
        spUpdateHotelTariffCustomerCategory,
        spDeleteHotelTariffCustomerCategory,
        spGetHotelTariffCustomerCategoriess,

        #endregion

        #endregion

        #region Supplier Hotel Tariff

        spInsertSupplierHotelTariff,
        spGetSupplierHotel,
        spInsertSupplierHotelDetail,
        spdrpGetHotelsByCity,
        spInsertSupplierHotelDuration,
        spInsertSupplierHotelPrice,
        spInsertSupplierOccupancy,
        spInsertSupplierHotelPriceDetail,
        spInsertSupplierHotelTariffDuration,
        spGetPriceDetailByDurationId,
        spGetSupplierHotelTariffDurationPrice,
        spDeleteSupplierHotelPrice,
        spUpdateSupplierHotelDuration,
        spUpdateSupplierHotelDetail,
        spDeleteSupplierHotelDetail,
        spUpdateSupplierHotelTariff,
        spGetSupplietHotelSummary,
        spInsertSupplierHotelCustomerCategory,
        spInsertSupplierHotelTariffCustomerCategory,
        spGetSupplierHotelTariffCustomerCategories,
        spGetSupplierHotelTariffCustomerCategoriess,

        spGetSupplierHotelCustomerCategory,
        spUpdateSupplierHotelCustomerCategory,
        spDeleteSupplierHotelCustomerCategory,

        spInsertSupplierHotel,
        spUpdateSupplierHotel,
        spUpdateSupplierHotelPrice,
        spUpdateSupplierOccupancy,
        spDeleteSupplierHotelChargeDetail,
        spGetSupplierHotelPrice,
        spGetSupplierOccupancy,
        spGetSupplierHotelTaxFormulaChargesByPriceId,
        spGetSupplierHotelPriceById,
        spInsertSupplierHotelChargeDetail,

        sp_Insert_SupplierHotelDays,
        sp_Update_SupplierHotelDays,
        sp_Get_SupplierHotelDays,
        sp_Get_SupplierHotelDayItems,
        sp_Insert_SupplierHotelDayItem,
        spDeleteSupplierDayItems,

        #endregion

        #region Hotel Tariff Tax Updation

        spGetHotelTariffTax,

        #endregion

        #region LohanPackageTariff
        spInsertLohanaPackageTariffBasic,
        spGetLohanaPackageTariffBasic,
        spUpdateLohanaPackageTariffBasic,

        spGetLohanaPackageTariffHotelListing,
        spInsertLohanaPackageTariffHotel,
        spGetLohanaPackageTariffHotel,
        spUpdateLohanaPackageTariffHotel,
        spDeleteLohanaPackageTariffHotel,

        spGetLohanaPackageTariffVehicleListing,
        spInsertLohanaPackageTariffVehicle,
        spGetLohanaPackageTariffVehicle,
        spUpdateLohanaPackageTariffVehicle,
        spDeleteLohanaPackageTariffVehicle,
        spGetLohanaPackageTariffRootListing,
        spInsertLohanaPackageTariffRootDetails,
        spUpdateLohanaPackageTariffRootTitle,
        spCheckLohanaPackageTariffRootDetailExist,
        spDeleteLohanaPackageTariffRootDetail,

        GetLohanaPackageTariffSearchItienaryDetails,

        #endregion

        #region HotelSearch

        SpGetHotelSearchHotelDetails,
        SpGetHotelSearchRoomMealOccupancyPrice,
        GetHotelRoomDetails_Sp,
        GetHotelSearchList_Sp,
        GetHotelSearchLists_Sp,

        GetHotelSearchByRoom,
        #endregion

        #region Autocomplete

        spGetAutocompleteByPageName,

        #endregion

        #region supplier hotel search
        GetSupplierSearchLists_Sp,

        GetSupplierHotelSearchDetails,

        #endregion

        #region Enquiry

        spdrpGetUsers,


        spInsertEnquiry,
        spUpdateEnquiry,

        spInsertEnquiryItem,
        spdrpSpecialization,


        spDeleteEnquiryItemById,
        spDeleteItemPassByEnquiryItemId,
        spDeleteTransferTypeByEnquiryItemId,
        spDeletetEnquiryTypeByEnquiryItemId,


        spGetEnquiryItemTypeDetails,
        spGetEnquiryItemTransferTypeDetails,

        spGetAutoAssigneName,





        spGetGitDetails,
        spGetGitDetailsById,
        spUpdateEnquiryGitDetails,

        spGetFitDetailsById,
        spGetFitDetails,
        spUpdateEnquiryFitDetails,

        spGetEnquiryHotelDetailsById,
        spGetEnquiryHotelDetails,
        spUpdateEnquiryHotelDetails,

        spGetEnquirySightseeingDetailsById,
        spGetEnquirySightseeingDetails,
        spUpdateEnquirySightseeingDetails,

        spInsertEnquiryItemTypeDetails,
        spInsertEnquiryItemPassDetails,
        spInsertEnquiryItemTransferDetails,

        spGetFlightDetails,
        spGetFlightTypeDetails,
        spGetEnquiryFlightDetailsById,

        spGetQuotationgitDetailsById,
        spGetFlightTypeDetailsById,
        spUpdateEnquiryFlightDetails,


        spGetTransferDetails,
        spGetEnquiryTransferDetailsById,
        spGetTransferTypeDetails,
        spGetTransferTypeDetailsById,
        spUpdateEnquiryTransferDetails,


        spGetTrainBasicDetails,
        spGetEnquiryTrainDetailsById,
        spGetTrainTypeDetails,
        spGetTrainTypeDetailsById,
        spGetTrainPassDetails,
        spGetTrainPassDetailsById,
        spUpdateEnquiryTrainDetails,
        spDeletetTrainPassByEnquiryItemId,
        spDeletetTrainTypeByEnquiryItemId,


        spGetEnquiry,
        spGetEnquiryById,
        spGetEnquiryItemDetails,
        spDeleteItemTypeByEnquiryItemId,


        spInsertEnquiryTask,
        spdrpGetGitCity,

        //spGetUserEnquiryTask,

        #endregion

        #region HotelType
        spInsertHotelType,
        spGetHotelType,
        spCheckHotelTypeExist,
        spUpdateHotelType,
        #endregion

        #region Quotation

        spInsertQuotation,

        spInsertQuotationItem,

        spInsertQuotationItemTypeDetails,
        spInsertQuotationItemPassDetails,

        spUpdateQuotationBasic,

        spUpdateFlightQuotationItem,
        spUpdateTrainQuotationItem,

        spUpdateQuotationItemTypeDetails,
        spUpdateQuotationItemPassDetails,

        spGetQuotationItemDetails,

        spGetQuotationFlightDetailsById,
        spGetQuotationItemTypeDetails,
        spGetQuotationFlightDetails,
        spGetQuotationFlightTypeDetails,
        spGetQuotationFlightTypeDetailsById,

        spGetQuotationFlightDetailsByQuotationId,

        // spDeletetQuotationFlightTypeByQuotationItemId,
        spDeletetQuotationItemTypeByQuotationItemId,
        spDeleteQuotationItemPassByQuotationItemId,


        spGetQuotationTrainDetailsById,
        spGetQuotationTrainTypeDetailsById,
        spGetQuotationTrainPassDetailsById,
        spGetQuotationItemPassDetails,
        spGetQuotationTrainTypeDetails,
        spGetQuotationGitItemDetails,
        spDeleteGitById,
        spGetQuotationSightSeeingItemDetails,

        spGetQuotationTrainDetailsByQuotationId,
        spUpdateQuotationStatus,
        spUpdateQuotationItemStatus,
        spGetApprovedQuotationItem,
        spInsertQuotationTask,
        spGetQuotationTaskAssignee,
        #endregion

        #region Task
        spGetTeamLeadUsersTask,
        spGetTaskByTaskId,
        spUpdateTask,
        #endregion

        #region

        spGetSearchSightseeingDetails,
        #endregion

        #region Booking
        sp_Insert_Booking,
        spInsertTravellersInformation,
        spGetTravellersInformation,
        spUpdateTravellersInformation,
        spDeleteTravellersInformation,
        spInsertTravellersDocumentDetails,
        spGetTravellersDocumentDetails,
        spDeleteTravellersDocument,
        spInsertPackageDetails,
        spUpdateBookingAmount,
        spGetProductTotalAmount,
        InsertTrainOrFlightDetails,
        InsertTrainOrFlightPassangerDetails,
        GetTrainFlightDetails,
        DeleteTrainOrFlightDetails,
        DeletePassangerDetails,
        UpdateTrainOrFlightDetails,
        UpdatePassangerDetails,
        GetTrainFlightPassangerDetails,
        #endregion

        #region Invoice & ReceivablePayment
        spGetInvoiceDetails,
        spGetBookingListInformation,
        sp_Insert_Payment,
        spGetPaymentHistoryList,
        spGetProductItemsDetails,
        spGetReceiptDetails,
        #endregion

        #region LohanaPackageTariffSearch
        spGetLohanaPackageTariffDetailsSearch,
        #endregion


        #region Payable
        spGetPaybles,
        spGetPayableById,
        spInsertPayable,
        spInsertPayableHistory,
        spGetPaymentHistoryForPaybleList,
        UpdateVendorPayable,
        spInsertTransaction,
        GetPayblesList,
        #endregion
    }
}



