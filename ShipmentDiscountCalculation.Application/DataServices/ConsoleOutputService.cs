using System;
using ShipmentDiscountCalculation.Application.Interfaces;
using ShipmentDiscountCalculation.Domain.Models;

namespace ShipmentDiscountCalculation.Application.DataServices
{
    public class ConsoleOutputService : IOutputService
    {
        public void Print(Shipment shipment)
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