using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GWAPI.Configuration

{ 
    public class AppConfiguration
    {
        
            private readonly IConfiguration _configuration;

            public AppConfiguration()
            {
            
           // var configFile = "configsetting.json";

          var configFile = System.IO.Directory.GetParent(@"../../../").FullName + Path.DirectorySeparatorChar + "Configuration/configsetting.json";

#if DEV
        configFile = "appsettings.dev.json";
#elif TEST
        configFile = "appsettings.test.json";
#elif UAT
        configFile = "appsettings.uat.json";
#endif

            _configuration ??= new ConfigurationBuilder()

             .AddJsonFile(configFile, optional: false, reloadOnChange: true)
              .Build();
            }
            public string synergyBaseUrl => _configuration["synergyBaseUrl"];
        public string user => _configuration["user"];
        public string apiversion => _configuration["api-version"];
      

    }
}

