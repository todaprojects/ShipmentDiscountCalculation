using System;
using ShipmentDiscountCalculation.Application.DataServices;
using ShipmentDiscountCalculation.Application.Interfaces;
using ShipmentDiscountCalculation.Domain.Interfaces;

namespace ShipmentDiscountCalculation.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataOutputService outputService = new ConsoleDataOutputService();

            IShipmentDiscountCalculation shipmentDiscountCalculation = new ShipmentDiscountCalculation();

            while (true)
            {
                try
                {
                    var shipmentDiscountData = shipmentDiscountCalculation.GetShipmentDiscountData();
                    if (shipmentDiscountData != null)
                    {
                        outputService.Print(shipmentDiscountData);
                    }
                    else
                    {
                        break;
                    }
                }
                catch (ArgumentException e)
                {
                    outputService.ErrorMsg($"{e.Message}Ignored");
                }
                catch (Exception e)
                {
                    outputService.ErrorMsg($"Error: {e.Message}");
                    break;
                }
            }
        }
    }
}