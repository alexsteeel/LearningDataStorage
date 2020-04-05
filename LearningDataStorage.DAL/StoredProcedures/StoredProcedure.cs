using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace LearningDataStorage.DAL
{
    public class StoredProcedure
    {
        public Guid GetAuthorsPhotoGuid(string fileName)
        {
            using (ApplicationContext ctx = new ApplicationContext())
            {
                SqlParameter fileNameParam = new SqlParameter()
                {
                    ParameterName = "@FileName",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = fileName
                };

                SqlParameter guidParam = new SqlParameter()
                {
                    ParameterName = "@FileGuid",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Direction = ParameterDirection.Output
                };

                ctx.Database.ExecuteSqlCommand($"exec @FileGuid = [file].GetAuthorsPhotoGuid", guidParam);

                return (Guid)guidParam.Value;
            }
        }

        public Guid GetBookCoverGuid(string fileName)
        {
            using (ApplicationContext ctx = new ApplicationContext())
            {
                SqlParameter fileNameParam = new SqlParameter()
                {
                    ParameterName = "@FileName",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = fileName
                };

                SqlParameter guidParam = new SqlParameter()
                {
                    ParameterName = "@FileGuid",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Direction = ParameterDirection.Output
                };

                var sqlParams = new SqlParameter[] {fileNameParam, guidParam};

                ctx.Database.ExecuteSqlCommand($"exec [file].GetBookCoverGuid @FileName, @FileGuid output", sqlParams);

                return (Guid)guidParam.Value;
            }
        }
    }
}