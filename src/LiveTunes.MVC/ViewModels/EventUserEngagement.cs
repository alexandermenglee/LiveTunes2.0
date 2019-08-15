using LiveTunes.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveTunes.MVC.ViewModels
{
	public class EventUserEngagement
	{
		public string EventName { get; set; }
		public DateTime EventDate { get; set; }
		public int UserEngagement { get; set; }
	}
}
