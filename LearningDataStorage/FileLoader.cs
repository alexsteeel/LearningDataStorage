using System.IO;
using System.Threading.Tasks;

namespace LearningDataStorage
{
    public class FileLoader
    {
        private IConfigurationManager _manager;
        public FileLoader(IConfigurationManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Копировать файл.
        /// </summary>
        /// <param name="sourceFilePath">Путь к исходному файлу.</param>
        /// <param name="destPath">Путь к конечному файлу.</param>
        private async Task CopyFilesAsync(string sourceFilePath, string destServerFolder)
        {
            var fileServerString = new ConfigurationManager().GetFileServerPathString();
            var fileName = Path.GetFileName(sourceFilePath);
            var destPath = $"{fileServerString}\\{destServerFolder}\\{fileName}";

            using FileStream SourceStream = File.Open(sourceFilePath, FileMode.Open);
            using FileStream DestinationStream = File.Create(destPath);
            await SourceStream.CopyToAsync(DestinationStream);
        }
    }
}
