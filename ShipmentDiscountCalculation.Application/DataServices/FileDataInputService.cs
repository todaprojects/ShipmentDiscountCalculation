using System;
using System.IO;
using ShipmentDiscountCalculation.Application.Interfaces;

namespace ShipmentDiscountCalculation.Application.DataServices
{
    public class FileDataInputService : IDataInputService
    {
        private readonly StreamReader _file;

        public FileDataInputService(string inputFilePath)
        {
            if (File.Exists(inputFilePath))
            {
                _file = new StreamReader(inputFilePath);
            }
        }

        public string GetData()
        {
            if (_file == null) throw new Exception("Input file has not been found!");

            string line;
            if ((line = _file.ReadLine()) != null)
            {
                return line;
            }

            _file.Close();
            return null;
        }
    }
}