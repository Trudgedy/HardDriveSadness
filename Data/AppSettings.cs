using System;

namespace DiskDriveSadness.Data
{
	public class AppSettings
	{
		public Boolean CanClose { get; set; }
		public Int32 StartWaitTime { get; set; }
		public Int32 MaxWaitDelay { get; set; }
		public Int32 MinWaitDelay { get; set; }
	}
}
