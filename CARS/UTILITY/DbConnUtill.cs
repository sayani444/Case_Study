using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.UTILITY
{
   internal static class DbConnUtil
    {
        private static IConfiguration _iConfiguration;
        //constructor
        static DbConnUtil()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json");
                _iConfiguration = builder.Build();
        }

        public static string GetConnectionString()
        {
           return _iConfiguration.GetConnectionString("LocalConnString");
        }
    }
} 