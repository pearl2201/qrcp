using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
namespace Qrdesktop.Utils
{
    public class FileHelper
    {
        public static void CreateZipFile(string fileName, IEnumerable<string> files)
        {
            // Create and open a new ZIP file
            using (var stream = File.OpenWrite(fileName))
            {
                var zip = new ZipArchive(stream, ZipArchiveMode.Create);
                foreach (var file in files)
                {
                    // Add the entry for each file
                    zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
                }
                // Dispose of the object when we are done
                zip.Dispose();
            }
               
        }

        private static void CreateZipFile(IEnumerable<FileInfo> files, string archiveName)
        {
            using (var stream = File.OpenWrite(archiveName))
            using (ZipArchive archive = new ZipArchive(stream, System.IO.Compression.ZipArchiveMode.Create))
            {
                foreach (var item in files)
                {
                    archive.CreateEntryFromFile(item.FullName, item.Name, CompressionLevel.Optimal);
                }
            }
        }
    }
}
