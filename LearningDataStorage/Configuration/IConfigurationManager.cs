using Microsoft.Extensions.Configuration;

namespace LearningDataStorage
{
    public interface IConfigurationManager
    {
        IConfiguration AppSetting { get; }

        string GetConnectionString();
        string GetFileServerPathString();
    }
}