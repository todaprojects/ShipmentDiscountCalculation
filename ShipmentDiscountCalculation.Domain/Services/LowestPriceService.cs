using System.Collections.Generic;
using System.Linq;
using ShipmentDiscountCalculation.Domain.Interfaces;
using ShipmentDiscountCalculation.Domain.Models;

namespace ShipmentDiscountCalculation.Domain.Services
{
    public class LowestPriceService : IPriceService
    {
        public IDiscountService DiscountService { get; set; }

        public LowestPriceService(IDiscountService discountService)
        {
            DiscountService = discountService;
        }

        /// <summary>
        /// All "requested-size" shipments should always match the lowest "requested-size" package price among the providers.
        /// </summary>
        /// <param name="carriers"></param>
        /// <param name="shipments"></param>
        /// <param name="shipment"></param>
        /// <returns></returns>
        public decimal GetShippingPrice(IEnumerable<Carrier> carriers,
            IEnumerable<Shipment> shipments,
            Shipment shipment)
        {
            var shippingPrice = shipment.Carrier.Packages.Single(p => p.Size == shipment.PackageSize).Price;

            foreach (var sp in carriers)
            {
                shippingPrice = (from package in sp.Packages
                        where package.Size == shipment.PackageSize
                        select package.Price)
                    .Prepend(shippingPrice).Min();
            }

            return shippingPrice + DiscountService.AdjustDiscount(shipments, shipment, shippingPrice);
        }
    }
}