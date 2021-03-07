using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using ShipmentDiscountCalculation.Application.DataServices;
using ShipmentDiscountCalculation.Application.Factories;
using ShipmentDiscountCalculation.Application.Helpers;
using ShipmentDiscountCalculation.Application.Interfaces;
using ShipmentDiscountCalculation.Domain.Models;

namespace ShipmentDiscountCalculation.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataInputService inputService = new FileDataInputService();
            IDataOutputService outputService = new ConsoleDataOutputService();
            
            // Get the list of available Shipping Providers in selected country
            var carriers = CarrierFactory.GetShippingProviders();
            
            // Initialize all Transactions into Shipping objects - for processing shipment discount calculations
            var shipments = new List<Shipment>();
            
            var runApp = true;
            while (runApp)
            {
                try
                {
                    var inputLine = inputService.GetData();
                    if (inputLine == null)
                    {
                        runApp = false;
                        break;
                    }
            
                    var inputs = inputLine.Split(" ");
            
                    var date = DateParseHelper.Parse(inputs, 0);
                    var packageSize = PackageSizeParseHelper.Parse(inputs, 1);
                    var carrier = CarrierParseHelper.Parse(carriers, inputs, 2);
                    var priceService = ShippingPriceFactory.GetPriceService(packageSize);
            
                    var shipment = new Shipment(date, packageSize, carrier, priceService);
            
                    shipment.ShippingPrice =
                        shipment.PriceService.GetShippingPrice(carriers, shipments, shipment);
            
                    shipment.Discount =
                        shipment.Carrier.Packages
                            .Single(p => p.Size == packageSize)
                            .Price - shipment.ShippingPrice;
            
                    shipments.Add(shipment);
            
                    outputService.Print(shipment);
                }
                catch (ArgumentException e)
                {
                    outputService.ErrorMsg($"{e.Message}Ignored");
                }
                catch (Exception e)
                {
                    outputService.ErrorMsg($"Error: {e.Message}");
                    runApp = false;
                }
            }
        }
    }
}