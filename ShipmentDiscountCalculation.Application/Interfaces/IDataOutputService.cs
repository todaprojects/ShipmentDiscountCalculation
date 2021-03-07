using ShipmentDiscountCalculation.Domain.Models;

namespace ShipmentDiscountCalculation.Application.Interfaces
{
    public interface IDataOutputService
    {
        void Print(Shipment shipment);

        void ErrorMsg(string msg);
    }
}