using System;
using System.Collections.Generic;
using System.Linq;
using ShipmentDiscountCalculation.Domain.Models;

namespace ShipmentDiscountCalculation.Application.Helpers
{
    public static class CarrierParseHelper
    {
        public static Carrier Parse(IEnumerable<Carrier> carriers, string[] inputs, int i)
        {
            try
            {
                var carrier = carriers.First(s => s.Code.Equals(inputs[i]));
                return carrier;
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