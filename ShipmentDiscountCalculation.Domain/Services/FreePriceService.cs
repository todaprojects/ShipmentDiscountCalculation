using System.Collections.Generic;
using System.Linq;
using ShipmentDiscountCalculation.Domain.Enums;
using ShipmentDiscountCalculation.Domain.Interfaces;
using ShipmentDiscountCalculation.Domain.Models;

namespace ShipmentDiscountCalculation.Domain.Services
{
    public class FreePriceService : IPriceService
    {
        /// <summary>
        /// Third L shipment via LP.
        /// </summary>
        private const int ThirdShipment = 3;

        public IDiscountService DiscountService { get; set; }

        public FreePriceService(IDiscountService discountService)
        {
            DiscountService = discountService;
        }

        /// <summary>
        /// Third L shipment via LP should be free, but only once a calendar month.
        /// </summary>
        /// <param name="carriers"></param>
        /// <param name="shipments"></param>
        /// <param name="shipment"></param>
        /// <returns></returns>
        public decimal GetShippingPrice(IEnumerable<Carrier> carriers,
            IEnumerable<IShipment> shipments,
            IShipment shipment)
        {
            var shippingPrice = 0M;
            var countPerMonth = 0;

            if (shipment.Carrier.Code.Equals("LP") && shipment.PackageSize == PackageSize.L)
            {
                countPerMonth = GetTransactionCount(shipments, shipment);
            }

            if (countPerMonth != ThirdShipment)
            {
                foreach (var package in shipment.Carrier.Packages)
                {
                    if (package.Size == shipment.PackageSize)
                    {
                        shippingPrice = package.Price;
                        break;
                    }
                }
            }

            return shippingPrice + DiscountService.AdjustDiscount(shipments, shipment, shippingPrice);
        }

        private static int GetTransactionCount(IEnumerable<IShipment> shipments, IShipment shipment)
        {
            return 1 + shipments.Count(s =>
                s.PackageSize == shipment.PackageSize &&
                s.Carrier.Code.Equals(shipment.Carrier.Code) &&
                s.Date.Month == shipment.Date.Month);
        }
    }
}