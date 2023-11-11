using MOE_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows;

namespace MOE_UI.Helpers
{
    public class FileHelper
    {
        private const string BaseDirectory = "C:\\Temp\\Campaigns";

        public static void ExportCampaign(CampaignViewModel campaign)
        {
            foreach (var region in campaign.AddedRegions)
            {
                var directoryPath = CreateRegionDirectory(region.RegionName);
                var archiveFolderPath = CreateArchiveDirectory(directoryPath);

                var filesToArchive = GetFilesToArchive(region, directoryPath);

                if (filesToArchive.Any())
                {
                    ArchiveFiles(filesToArchive, archiveFolderPath, region.RegionName);
                }
            }
        }

        private static string CreateRegionDirectory(string regionName)
        {
            var directoryPath = Path.Combine(BaseDirectory, regionName);
            Directory.CreateDirectory(directoryPath);
            return directoryPath;
        }

        private static string CreateArchiveDirectory(string directoryPath)
        {
            var archiveFolderPath = Path.Combine(directoryPath, "Archive");
            Directory.CreateDirectory(archiveFolderPath);
            return archiveFolderPath;
        }

        private static List<string> GetFilesToArchive(CriteriaFileViewModel region, string directoryPath)
        {
            List<string> filesToArchive = new List<string>();

            // Handling JSON file export
            var jsonFilePath = HandleFileExport(region.ToJson(), "Criteria.json", directoryPath);
            if (!string.IsNullOrEmpty(jsonFilePath))
            {
                filesToArchive.Add(jsonFilePath);
            }

            // Handling Email Addresses file export
            if (region.EmailAddresses != null && region.EmailAddresses.Any())
            {
                var emailContents = String.Join(Environment.NewLine, region.EmailAddresses);
                var emailFilePath = HandleFileExport(emailContents, $"EmailAddresses.txt", directoryPath);
                if (!string.IsNullOrEmpty(emailFilePath))
                {
                    filesToArchive.Add(emailFilePath);
                }
            }

            return filesToArchive;
        }


        private static void ArchiveFiles(List<string> filesToArchive, string archiveFolderPath, string regionName)
        {
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var zipFileName = $"{regionName}_{timestamp}.zip";
            var zipFilePath = Path.Combine(archiveFolderPath, zipFileName);

            using (var zip = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
            {
                foreach (var file in filesToArchive)
                {
                    zip.CreateEntryFromFile(file, Path.GetFileName(file));
                    File.Delete(file);
                }
            }
        }

        private static string HandleFileExport(string contents, string fileName, string directoryPath)
        {
            var filePath = Path.Combine(directoryPath, fileName);
            bool fileExists = File.Exists(filePath);

            // Write the new contents to the file
            WriteFileContents(filePath, contents);

            // If the file already existed before writing, return its path for archiving
            return fileExists ? filePath : string.Empty;
        }


        public static void ExportCampaignPrompt(CampaignViewModel campaign)
        {
            string message = BuildExportMessage(campaign);
            var response = MessageBox.Show(message, "Export Campaign", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (response == MessageBoxResult.Yes)
            {
                ExportCampaign(campaign);
            }
        }

        private static string BuildExportMessage(CampaignViewModel campaign)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Campaign regions for export:");

            foreach (var region in campaign.AddedRegions)
            {
                sb.AppendLine($"{region.RegionName}: {region.EmailAddressCount} email addresses");
            }

            return sb.ToString();
        }

        public static void WriteFileContents(string path, string contents)
        {
            System.IO.File.WriteAllText(path, contents);
        }
    }

}
