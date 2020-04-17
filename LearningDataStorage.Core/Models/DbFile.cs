using System;

namespace LearningDataStorage.Core.Models
{
    public class DbFile
    {
        public DbFile(Guid streamGuid, string fileTable, string fileName, string fileType)
        {
            StreamGuid = streamGuid;
            FileTable = fileTable;
            FileName = fileName;
            FileType = fileType;
        }

        public int Id { get; set; }

        public Guid StreamGuid { get; set; }

        public string FileTable { get; set; }

        public string FileName { get; set; }        
        
        public string FileType { get; set; }

    }
}
