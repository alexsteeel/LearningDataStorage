using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage.DAL
{
    /// <summary>
    /// Файл.
    /// </summary>
    public class DbFile
    {
        public DbFile(Guid streamGuid, string fileTable, string fileName, string fileType)
        {
            StreamGuid = streamGuid;
            FileTable = fileTable;
            FileName = fileName;
            FileType = fileType;
        }

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Guid файла в файловой таблице.
        /// </summary>
        [Required]
        public Guid StreamGuid { get; set; }

        /// <summary>
        /// Файловая таблица.
        /// </summary>
        [Required]
        public string FileTable { get; set; }

        /// <summary>
        /// Имя файла.
        /// </summary>
        [Required]
        public string FileName { get; set; }        

        /// <summary>
        /// Тип содержимого.
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string FileType { get; set; }

        /// <summary>
        /// Полный путь к файлу.
        /// </summary>
        [NotMapped]
        public string FullPath
        {
            get
            {
                var fileLoader = new FileLoader();
                return $@"{fileLoader.GetFileServerString()}\{FileTable}\{FileName}"; 
            }
        }
    }
}
