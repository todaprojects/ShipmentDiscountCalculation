using System.IO;

namespace ShipmentDiscountCalculation.Application.Helpers
{
    public static class FilePathHelper
    {
        public static string GetInputFilePath(string inputFilePath, char Separator)
        {
            if (File.Exists(inputFilePath))
            {
                return inputFilePath;
            }

            var inputFilePathDirs = inputFilePath.Split(Separator);
            inputFilePath = $"..{Separator}";

            if (inputFilePathDirs.Length >= 3)
            {
                inputFilePath += $"{inputFilePathDirs[^2]}{Separator}{inputFilePathDirs[^1]}";
            }

            return inputFilePath;
        }
    }
}