using System;
using System.Linq;

namespace ShipmentDiscountCalculation.Application.Helpers
{
    public static class DateParseHelper
    {
        public static DateTime Parse(string[] inputs, int i)
        {
            try
            {
                var dateTime = DateTime.Parse(inputs[i]);
                return dateTime;
            }
            catch (Exception)
            {
                var msg = 
                    inputs.Aggregate<string, string>(null, (current, i) => current + (i + " "));
                throw new ArgumentException(msg);
            }
        }
    }
}