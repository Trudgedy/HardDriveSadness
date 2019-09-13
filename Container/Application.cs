using System;
using System.IO;
using System.Reflection;
using System.Xml;
using Topshelf;

namespace DiskDriveSadness.Container
{
	public class Application : IApplication
	{
		public Int32 Run()
		{

			return (Int32)HostFactory.Run(x =>
			{
				var log4netConfig = new XmlDocument();
				log4netConfig.Load(File.OpenRead("log4net.config"));
				var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(),
						   typeof(log4net.Repository.Hierarchy.Hierarchy));
				log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
				//Topshelf to use Log4Net
				x.UseLog4Net();

				x.StartAutomatically();
				x.Service<ProcessService>();
			});
		}
	}
}
