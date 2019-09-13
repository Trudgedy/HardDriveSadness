using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using DiskDriveSadness.Container;
using log4net;
using Topshelf;

namespace DiskDriveSadness
{
	public class ProcessService : ServiceControl
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(ProcessService));
		public Boolean Start(HostControl hostControl)
		{
			try
			{
				var config = ContainerConfig.ConfigurationInstance;


				log.Info("Starting Threads...");

				new Thread(() =>
				{
					Thread.CurrentThread.IsBackground = true;
					/* run your code here */
					Sadness.Start(config);
				}).Start();



			}
			catch (Exception ex)
			{
				log.Error($"Top Level Error: {ex.Message}");
			}
			return true;
		}

		public Boolean Stop(HostControl hostControl)
		{
			log.Info("Stopping bus...");
			return true;
		}
		
	}
}
