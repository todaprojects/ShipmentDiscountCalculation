using System.Collections.Generic;

namespace ShipmentDiscountCalculation.Domain.Models
{
    public class Carrier
    {
        public string Code { get; set; }
        
        public IEnumerable<Package> Packages { get; set; }
    }
}