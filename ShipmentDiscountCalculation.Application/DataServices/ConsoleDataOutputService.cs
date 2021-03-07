using System;
using ShipmentDiscountCalculation.Application.Interfaces;
using ShipmentDiscountCalculation.Domain.Interfaces;

namespace ShipmentDiscountCalculation.Application.DataServices
{
    public class ConsoleDataOutputService : IDataOutputService
    {
        public void Print(IShipment shipment)
        {
            Console.Write(
                $"{shipment.Date:yyyy-MM-dd} " +
                $"{shipment.PackageSize} " +
                $"{shipment.Carrier.Code} " +
                $"{shipment.ShippingPrice:F2} ");

            Console.WriteLine(shipment.Discount != 0 ? $"{shipment.Discount:F2}" : "-");
        }

        public void ErrorMsg(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}