using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
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
        /// <returns></returns>
        private string GetFileServerString()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string fileServerString = config.GetConnectionString("ServerUploadFolder");
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

            using (FileStream SourceStream = File.Open(sourceFilePath, FileMode.Open))
            {                
                using (FileStream DestinationStream = File.Create(destPath))
                {
                    await SourceStream.CopyToAsync(DestinationStream);
                }
            }
        }

        /// <summary>
        /// Получить Id загруженного файла.
        /// </summary>
        /// <returns></returns>
        private int? GetLoadedFileId(string fileName)
        {
            int? res = 0;
            using (ApplicationContext ctx = new ApplicationContext())
            {
                var maxFileCreatedTime = ctx.FileDescriptions
                    .Where(x => x.FileName == fileName)
                    .Max(x => x.CreatedTimestamp);

                res = ctx.FileDescriptions
                    .Where(x => x.CreatedTimestamp == maxFileCreatedTime)
                    .FirstOrDefault()
                    .Id;
            }
            return res;
        }

        /// <summary>
        /// Загрузить обложку книги.
        /// </summary>
        /// <param name="sourceFilePath">Путь к исходному файлу.</param>
        public async void LoadBookCover(string sourceFilePath, int bookEditionId)
        {
            await CopyFilesAsync(sourceFilePath, "BookCovers");

            var fileName = Path.GetFileName(sourceFilePath);
            var fileId = GetLoadedFileId(fileName);
            if (fileId is null)
            {
                throw new ArgumentNullException("Изображение с обложкой не загружено в БД.");
            }

            var bookCover = new BookCover((int)fileId, bookEditionId);

            using (ApplicationContext ctx = new ApplicationContext())
            {
                ctx.BookCovers.Add(bookCover);
                ctx.SaveChanges();
            }
        }
    }
}
