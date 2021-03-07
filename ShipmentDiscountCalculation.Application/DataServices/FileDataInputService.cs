using System;
using System.IO;
using ShipmentDiscountCalculation.Application.Helpers;
using ShipmentDiscountCalculation.Application.Interfaces;

namespace ShipmentDiscountCalculation.Application.DataServices
{
    public class FileDataInputService : IDataInputService
    {
        private readonly StreamReader _file;
        private readonly string _inputFilePath = InputFilePathHelper.GetInputFilePath();

        public FileDataInputService()
        {
            if (File.Exists(_inputFilePath))
            {
                _file = new StreamReader(_inputFilePath);
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