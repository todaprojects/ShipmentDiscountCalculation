using System.Collections.Generic;
using System.Linq;
using ShipmentDiscountCalculation.Domain.Interfaces;
using ShipmentDiscountCalculation.Domain.Models;

namespace ShipmentDiscountCalculation.Domain.Services
{
    public class AccumulatedDiscountService : IDiscountService
    {
        /// <summary>
        /// Accumulated discounts maximum amount.
        /// </summary>
        private const decimal MaximumAccumulatedDiscount = 10M;

        /// <summary>
        /// Accumulated discounts cannot exceed 10 € in a calendar month.
        /// If there are not enough funds to fully cover a discount this calendar month, it should be covered partially.
        /// </summary>
        public decimal AdjustDiscount(IEnumerable<IShipment> shipments, IShipment shipment, decimal shippingPrice)
        {
            var month = shipment.Date.Month;
            var accumulatedDiscount = 0M;
            var adjustDiscount = 0M;

            decimal defaultPrice;

            // Get total amount of given discounts per month
            foreach (var s in shipments)
            {
                if (s.Date.Month == month)
                {
                    defaultPrice = s.Carrier.Packages.Single(p => p.Size == s.PackageSize).Price;
                    var assignedPrice = s.ShippingPrice;
                    accumulatedDiscount += defaultPrice - assignedPrice;
                }
            }

            var allowedDiscount = MaximumAccumulatedDiscount - accumulatedDiscount;

            // Get discount of actual shipment and check it with the maximum allowable discount
            defaultPrice = shipment.Carrier.Packages.Single(p => p.Size == shipment.PackageSize).Price;

            if (defaultPrice - shippingPrice > allowedDiscount)
            {
                adjustDiscount = defaultPrice - shippingPrice - allowedDiscount;
            }

            return adjustDiscount;
        }
    }
}