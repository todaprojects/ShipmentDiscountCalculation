using ShipmentDiscountCalculation.Domain.Enums;
using ShipmentDiscountCalculation.Domain.Interfaces;
using ShipmentDiscountCalculation.Domain.Services;

namespace ShipmentDiscountCalculation.Application.Factories
{
    public static class ShippingPriceFactory
    {
        public static IPriceService GetPriceService(PackageSize packageSize)
        {
            var discountService = new AccumulatedDiscountService();
            
            return packageSize switch
            {
                PackageSize.S => new LowestPriceService(discountService),
                PackageSize.M => new StandardPriceService(discountService),
                PackageSize.L => new FreePriceService(discountService),
                _ => null
            };
        }
    }
}