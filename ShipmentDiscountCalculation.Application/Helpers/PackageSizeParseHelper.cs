using System;
using System.Linq;
using ShipmentDiscountCalculation.Domain.Enums;

namespace ShipmentDiscountCalculation.Application.Helpers
{
    public static class PackageSizeParseHelper
    {
        public static PackageSize Parse(string[] inputs, int i)
        {
            try
            {
                var packageSize = (PackageSize) Enum.Parse(typeof(PackageSize), inputs[i]);
                return packageSize;
            }
            catch (Exception e)
            {
                var msg = 
                    inputs.Aggregate<string, string>(null, (current, i) => current + (i + " "));
                throw new ArgumentException(msg);
            }
        }
    }
}