using System.Collections.Generic;
using System.Linq;
using ShipmentDiscountCalculation.Domain.Interfaces;
using ShipmentDiscountCalculation.Domain.Models;

namespace ShipmentDiscountCalculation.Domain.Services
{
    public class StandardPriceService : IPriceService
    {
        public IDiscountService DiscountService { get; set; }

        public StandardPriceService(IDiscountService discountService)
        {
            DiscountService = discountService;
        }

        /// <summary>
        /// Shipping price matches provider's standard price for a given package. 
        /// </summary>
        /// <param name="carriers"></param>
        /// <param name="shipments"></param>
        /// <param name="shipment"></param>
        /// <returns></returns>
        public decimal GetShippingPrice(IEnumerable<Carrier> carriers,
            IEnumerable<IShipment> shipments,
            IShipment shipment)
        {
            var packages = shipment.Carrier.Packages;

            var shippingPrice = (from package in packages
                    where package.Size == shipment.PackageSize
                    select package.Price)
                .FirstOrDefault();

            return shippingPrice + DiscountService.AdjustDiscount(shipments, shipment, shippingPrice);
        }
    }
}