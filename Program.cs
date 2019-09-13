using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using DiskDriveSadness.Container;
using Microsoft.Extensions.Configuration;

namespace DiskDriveSadness
{
	class Program
	{

		public static IConfigurationRoot Configuration { get; set; }
		private static Int32 Main(String[] args)
		{
			System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory);
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");

			Configuration = builder.Build();

			var app = new Application();
			return app.Run();
		}		
	}
}