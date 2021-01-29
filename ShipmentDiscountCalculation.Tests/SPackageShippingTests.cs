using System;
using Xunit;

namespace ShipmentDiscountCalculation.Tests
{
    public class SPackageShippingTests
    {
        [Theory]
        [InlineData("2015-02-01", "S", "MR", 1.50, 0.50)]
        [InlineData("2015-02-02", "S", "MR", 1.50, 0.50)]
        [InlineData("2015-02-03", "L", "LP", 6.90, 0.00)]
        [InlineData("2015-02-05", "S", "LP", 1.50, 0.00)]
        [InlineData("2015-02-06", "S", "MR", 1.50, 0.50)]
        [InlineData("2015-02-06", "L", "LP", 6.90, 0.00)]
        [InlineData("2015-02-07", "L", "MR", 4.00, 0.00)]
        [InlineData("2015-02-08", "M", "MR", 3.00, 0.00)]
        [InlineData("2015-02-09", "L", "LP", 0.00, 6.90)]
        [InlineData("2015-02-10", "L", "LP", 6.90, 0.00)]
        [InlineData("2015-02-10", "S", "MR", 1.50, 0.50)]
        [InlineData("2015-02-11", "S", "MR", 1.50, 0.50)]
        [InlineData("2015-02-11", "L", "LP", 6.90, 0.00)]
        [InlineData("2015-02-12", "M", "MR", 3.00, 0.00)]
        [InlineData("2015-02-13", "M", "LP", 4.90, 0.00)]
        [InlineData("2015-02-15", "S", "MR", 1.50, 0.50)]
        [InlineData("2015-02-17", "L", "LP", 6.90, 0.00)]
        [InlineData("2015-02-17", "S", "MR", 1.90, 0.10)]
        [InlineData("2015-02-24", "L", "LP", 6.90, 0.00)]
        [InlineData("2015-03-01", "S", "MR", 1.50, 0.50)]
        public void RunTest(DateTime date, string packageSize, string carrierCode, decimal price, decimal discount)
        {
        }
    }
}