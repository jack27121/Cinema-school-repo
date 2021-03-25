using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
	public class Show
	{
		public int showId { get; set; }
		public int theaterId { get; set; }
		public int movieId { get; set; }
		public DateTime date { get; set; }
	}
}