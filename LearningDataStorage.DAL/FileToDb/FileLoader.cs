using LearningDataStorage.Core.Models;
using System.IO;
using System.Threading.Tasks;

namespace LearningDataStorage.DAL
{
    /// <summary>
    /// Загрузчик файлов.
    /// </summary>
    public class FileLoader
    {
        /// <summary>
        /// Получить путь к папке сервера.
        /// </summary>
        public string GetFileServerString()
        {
            string fileServerString = ConfigurationManager.AppSetting["ApplicationConfiguration:ServerUploadFolder"];
            return fileServerString;
        }

        /// <summary>
        /// Копировать файл.
        /// </summary>
        /// <param name="sourceFilePath">Путь к исходному файлу.</param>
        /// <param name="destPath">Путь к конечному файлу.</param>
        private async Task CopyFilesAsync(string sourceFilePath, string destServerFolder)
        {
            var fileServerString = GetFileServerString();
            var fileName = Path.GetFileName(sourceFilePath);
            var destPath = $"{fileServerString}\\{destServerFolder}\\{fileName}";

            using FileStream SourceStream = File.Open(sourceFilePath, FileMode.Open);
            using FileStream DestinationStream = File.Create(destPath);
            await SourceStream.CopyToAsync(DestinationStream);
        }

        /// <summary>
        /// Загрузить обложку книги.
        /// </summary>
        /// <param name="sourceFilePath">Путь к исходному файлу.</param>
        public async void LoadBookCover(string sourceFilePath, int bookId)
        {
            var bookCovers = "BookCovers";
            await CopyFilesAsync(sourceFilePath, bookCovers);

            var fileType = Path.GetExtension(sourceFilePath);
            var fileName = Path.GetFileName(sourceFilePath);

            var sp = new StoredProcedure();
            var fileGuid = sp.GetBookCoverGuid(fileName);

            using ApplicationContext ctx = new ApplicationContext();
            var dbFile = new DbFile(fileGuid, bookCovers, fileName, fileType);
            ctx.DbFiles.Add(dbFile);
            ctx.SaveChanges();

            var bookCover = new BookCover(dbFile.Id, bookId);
            ctx.BookCovers.Add(bookCover);
            ctx.SaveChanges();
        }
    }
}
