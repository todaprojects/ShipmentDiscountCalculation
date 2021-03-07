using System;
using ShipmentDiscountCalculation.Domain.Enums;
using ShipmentDiscountCalculation.Domain.Interfaces;

namespace ShipmentDiscountCalculation.Domain.Models
{
    public class Shipment
    {
        public DateTime Date { get; set; }

        public PackageSize PackageSize { get; set; }

        public decimal ShippingPrice { get; set; }

        public decimal Discount { get; set; } = 0;

        public Carrier Carrier { get; set; }

        public IPriceService PriceService { get; set; }

        public Shipment()
        {
        }

        public Shipment(DateTime date, PackageSize packageSize, Carrier carrier,
            IPriceService priceService)
        {
            Date = date;
            PackageSize = packageSize;
            Carrier = carrier;
            PriceService = priceService;
        }
    }
}