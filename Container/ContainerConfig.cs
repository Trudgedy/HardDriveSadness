using System;
using System.IO;
using DiskDriveSadness.Data;
using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiskDriveSadness.Container
{
	public static class ContainerConfig
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(ContainerConfig));
		private static ServiceProvider _serviceProvider { get; set; }
		public static ServiceProvider ServiceProvider
		{
			get
			{
				if (_serviceProvider == null) _serviceProvider = Configure();
				return _serviceProvider;
			}
		}
		public static ServiceProvider Configure()
		{
			var services = new ServiceCollection();
			
			services.Configure<AppSettings>(Program.Configuration.GetSection("Settings"));
			return services.BuildServiceProvider();
		}

		private static IConfigurationRoot _configuration { get; set; }
		public static IConfigurationRoot ConfigurationInstance
		{
			get
			{
				if (_configuration == null)
				{
					_configuration = new ConfigurationBuilder()
											.SetBasePath(Directory.GetCurrentDirectory())
											.AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true)
											.Build();
				}

				return _configuration;
			}
		}
	}
}
