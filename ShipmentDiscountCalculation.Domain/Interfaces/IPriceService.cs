using System.Collections.Generic;
using ShipmentDiscountCalculation.Domain.Models;

namespace ShipmentDiscountCalculation.Domain.Interfaces
{
    public interface IPriceService
    {
        public IDiscountService DiscountService { get; set; }
        
        decimal GetShippingPrice(IEnumerable<Carrier> carriers, IEnumerable<Shipment> shipments,
            Shipment shipment);
    }
}