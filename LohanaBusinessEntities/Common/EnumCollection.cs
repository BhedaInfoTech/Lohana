using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.Common
{
    public class EnumCollection
    {
        public enum RateTypes
        {
            Publish_Price = 1,
            Commision_Price = 2,
            Special_Price = 3,
        }

        public enum ChargeBehaviour
        {
            Add = 1,
            Subtract = 2,
        }

       

        public enum EnquiryType
        {
            Git = 1,
            Fit = 2,
            Hotel = 3,
            Flight = 4,
            Train = 5,
            Transfer = 6,
            Sightseeing = 7,
            Spt=8,
        }


        public enum ProductType
        {
            //Hotel = 1,
            //Sightseeing = 2,
            //Flight = 3,
            //Train = 4,
            //Package = 5,
            //SupplierPackage = 6,
            //LohanaPackage = 7,

            Git = 1,
            Fit = 2,
            Hotel = 3,
            Flight = 4,
            Train = 5,
            Transfer = 6,
            Sightseeing = 7,
            Spt = 8,

        }
        public enum LohanaPackageTariffType
        {
            LohanaPackageTariffHotel = 1,
            LohanaPackageTariffSight = 2,
            LohanaPackageTariffVehicle = 3,
            LohanaPackageTariffMeal = 4,
        }

            
        }

        public enum Transaction
        {
            Payable=1,
            Recivable=2,
        }
    }
