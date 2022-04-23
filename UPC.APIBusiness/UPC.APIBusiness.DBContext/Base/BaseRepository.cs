using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace DBContext
{
    public class BaseRepository
    {
        public static IConfigurationRoot Configuration { get; set; }

        public SqlConnection GetSqlConnectionEnvios(bool open = true)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            string cs = Configuration["Logging:AppSettings:SqlConnectionStringEnvios"];

            var csb = new SqlConnectionStringBuilder(cs) { };

            var conn = new SqlConnection(csb.ConnectionString);
            if (open) conn.Open();
            return conn;
        }

    }
}
