using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using log4net;
using Microsoft.Extensions.Configuration;

namespace DiskDriveSadness
{
	public class Sadness
	{

		private static readonly ILog log = LogManager.GetLogger(typeof(Sadness));

		public Sadness()
		{

		}
		public static void Start(IConfigurationRoot config)
		{
			log.Info("Starting Sadness");
			Thread.Sleep(TimeSpan.FromMinutes(Convert.ToInt32(config["Settings:StartWaitTime"])));
			while (true)
			{
				open();
				Thread.Sleep(TimeSpan.FromMinutes(new Random().Next(Convert.ToInt32(config["Settings:MinWaitDelay"]), Convert.ToInt32(config["Settings:MaxWaitDelay"]))));

				if (Convert.ToBoolean(config["Settings:CanClose"]))
				{
					close();
					Thread.Sleep(TimeSpan.FromSeconds(new Random().Next(5, 15)));
				}
			}
		}
		private static void open()
		{
			log.Info("Opening drive");
			var ret = mciSendString("set cdaudio door open", null, 0, IntPtr.Zero);
		}

		private static void close()
		{
			log.Info("Closing drive");
			var ret = mciSendString("set cdaudio door closed", null, 0, IntPtr.Zero);
		}

		[DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi)]
		protected static extern Int32 mciSendString(String lpstrCommand,
												   StringBuilder lpstrReturnString,
												   Int32 uReturnLength,
												   IntPtr hwndCallback);
	}
}
