using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
	public class Movie
	{
		public int movieId { get; set; }
		public string name { get; set; }
		public int ageRating { get; set; }
		public string image { get; set; }
		public string trailer { get; set; }
		public string description { get; set; }
		public DateTime release { get; set; }
	}
}