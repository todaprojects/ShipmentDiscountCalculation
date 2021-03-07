using ShipmentDiscountCalculation.Domain.Interfaces;

namespace ShipmentDiscountCalculation.Application.Interfaces
{
    public interface IDataOutputService
    {
        void Print(IShipment shipment);

        void ErrorMsg(string msg);
    }
}