using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Configuration;
using System.Web;

[assembly: OwinStartup(typeof(SeparateConfigTest.Startup))]

namespace SeparateConfigTest
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            Console.WriteLine("Starting the thing");
            var currentEnvironment = Environment.GetEnvironmentVariable("DebugRuntimeEnvironment");
            var configFileName = "Config-rod.xml";
            if (currentEnvironment != null)
            {
                if (currentEnvironment.Trim() == "debug")
                {
                    configFileName = "Config-debug.xml";
                }
            }

            var physicalWebAppPath  = System.Web.Hosting.HostingEnvironment.MapPath("~/" + configFileName);

            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = physicalWebAppPath;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            AppSettingsSection appSettings;
            appSettings = (AppSettingsSection)config.GetSection("appSettings");
            System.Configuration.KeyValueConfigurationCollection settings;
            settings = config.AppSettings.Settings;
            HttpContext.Current.Application["CustomAppConfig"] = settings;
        }
    }
}
