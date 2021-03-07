using System.Collections.Generic;
using ShipmentDiscountCalculation.Domain.Models;

namespace ShipmentDiscountCalculation.Domain.Interfaces
{
    public interface IDiscountService
    {
        public decimal AdjustDiscount(IEnumerable<Shipment> shipments, Shipment shipment, decimal shippingPrice);
    }
}