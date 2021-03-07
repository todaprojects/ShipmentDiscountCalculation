using ShipmentDiscountCalculation.Domain.Models;

namespace ShipmentDiscountCalculation.Domain.Interfaces
{
    public interface IShipmentDiscountCalculation
    {
        Shipment GetShipmentDiscountData();
    }
}