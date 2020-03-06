using log4net;
using log4net.Config;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml;

namespace EvoRpg2.Helpers
{
    public class LogHelper
    {
        public ILog logger { get; set; }

        public LogHelper()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            //XmlDocument log4netConfig = new XmlDocument();
            //log4netConfig.Load(File.OpenRead("log4net.config"));
            //var loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            //XmlConfigurator.Configure(loggerRepository, log4netConfig["log4net"]);

            logger = LogManager.GetLogger(typeof(App));
            logger.Info("#######################################################################################################################");
           



        }
        

    }

 
}
