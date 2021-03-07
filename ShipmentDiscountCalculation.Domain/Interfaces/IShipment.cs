using System;
using ShipmentDiscountCalculation.Domain.Enums;
using ShipmentDiscountCalculation.Domain.Models;

namespace ShipmentDiscountCalculation.Domain.Interfaces
{
    public interface IShipment
    {
        public DateTime Date { get; set; }

        public PackageSize PackageSize { get; set; }

        public decimal ShippingPrice { get; set; }

        public decimal Discount { get; set; }

        public Carrier Carrier { get; set; }

        public IPriceService PriceService { get; set; }
    }
}