using System.Collections.Generic;
using ShipmentDiscountCalculation.Domain.Enums;
using ShipmentDiscountCalculation.Domain.Models;

namespace ShipmentDiscountCalculation.Application.Factories
{
    public static class CarrierFactory
    {
        public static List<Carrier> GetShippingProviders()
        {
            return new List<Carrier>()
            {
                new Carrier()
                {
                    Code = "LP",
                    Packages = new List<Package>()
                    {
                        new Package {Size = PackageSize.S, Price = 1.50M},
                        new Package {Size = PackageSize.M, Price = 4.90M},
                        new Package {Size = PackageSize.L, Price = 6.90M}
                    }
                },
                new Carrier()
                {
                    Code = "MR",
                    Packages = new List<Package>()
                    {
                        new Package {Size = PackageSize.S, Price = 2M},
                        new Package {Size = PackageSize.M, Price = 3M},
                        new Package {Size = PackageSize.L, Price = 4M}
                    }
                }
            };
        }
    }
}