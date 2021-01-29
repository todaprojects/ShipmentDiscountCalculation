using ShipmentDiscountCalculation.Domain.Enums;

namespace ShipmentDiscountCalculation.Domain.Models
{
    public class Package
    {
        public PackageSize Size { get; set; }
        
        public decimal Price { get; set; }
    }
}