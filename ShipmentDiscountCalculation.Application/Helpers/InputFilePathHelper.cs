using System.IO;
using Microsoft.Extensions.Configuration;

namespace ShipmentDiscountCalculation.Application.Helpers
{
    public static class InputFilePathHelper
    {
        private static readonly char Separator = Path.DirectorySeparatorChar;
        
        public static string GetInputFilePath()
        {
            var projectPath =
                Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            
            var inputFilePath = GetAppSettingsData(projectPath);
            if (inputFilePath != null)
            {
                return $"..{Separator}..{Separator}..{Separator}..{Separator}{inputFilePath}";
            }

            projectPath = Directory.GetCurrentDirectory();
            inputFilePath = GetAppSettingsData(projectPath);
            return $"..{Separator}{inputFilePath}";
        }

        private static string GetAppSettingsData(string projectPath)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            var folderName = configuration.GetValue<string>("InputFilePath:FolderName");
            if (folderName == null)
            {
                return null;
            }

            var fileName = configuration.GetValue<string>("InputFilePath:FileName");

            return $"{folderName}{Separator}{fileName}";
        }
    }
}