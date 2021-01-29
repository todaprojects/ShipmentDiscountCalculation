using ShipmentDiscountCalculation.Domain.Models;

namespace ShipmentDiscountCalculation.Application.Interfaces
{
    public interface IOutputService
    {
        void Print(Shipment shipment);

        void ErrorMsg(string msg);
    }
}