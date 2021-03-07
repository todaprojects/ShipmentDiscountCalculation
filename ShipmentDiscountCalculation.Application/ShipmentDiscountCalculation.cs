using System;
using System.Collections.Generic;
using System.Linq;
using ShipmentDiscountCalculation.Application.DataServices;
using ShipmentDiscountCalculation.Application.Factories;
using ShipmentDiscountCalculation.Application.Helpers;
using ShipmentDiscountCalculation.Application.Interfaces;
using ShipmentDiscountCalculation.Domain.Interfaces;
using ShipmentDiscountCalculation.Domain.Models;

namespace ShipmentDiscountCalculation.Application
{
    public class ShipmentDiscountCalculation : IShipmentDiscountCalculation
    {
        private readonly IDataInputService _inputService = new FileDataInputService();
        private readonly List<Carrier> _carriers = CarrierFactory.GetShippingProviders();
        private readonly List<Shipment> _shipments = new List<Shipment>();

        public Shipment GetShipmentDiscountData()
        {
            try
            {
                var inputLine = _inputService.GetData();
                if (inputLine == null)
                {
                    return null;
                }

                var inputs = inputLine.Split(" ");

                var date = DateParseHelper.Parse(inputs, 0);
                var packageSize = PackageSizeParseHelper.Parse(inputs, 1);
                var carrier = CarrierParseHelper.Parse(_carriers, inputs, 2);
                var priceService = ShippingPriceFactory.GetPriceService(packageSize);

                var shipment = new Shipment(date, packageSize, carrier, priceService);

                shipment.ShippingPrice =
                    shipment.PriceService.GetShippingPrice(_carriers, _shipments, shipment);

                shipment.Discount =
                    shipment.Carrier.Packages
                        .Single(p => p.Size == packageSize)
                        .Price - shipment.ShippingPrice;

                _shipments.Add(shipment);

                return shipment;
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException($"{e.Message}");
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }
    }
}