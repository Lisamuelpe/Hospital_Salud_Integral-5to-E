using System;
using System.Configuration;

namespace Forms.Config
{
    public static class DatabaseConfig
    {
        public static string ConnectionString
        {
            get
            {
                var setting = ConfigurationManager.ConnectionStrings["HospitalDb"];
                if (setting != null && !string.IsNullOrWhiteSpace(setting.ConnectionString))
                {
                    return setting.ConnectionString;
                }
                return "Server=localhost;Port=3306;Database=hospital_salud_integral;Uid=root;Pwd=;CharSet=utf8mb4;";
            }
        }
    }
}
