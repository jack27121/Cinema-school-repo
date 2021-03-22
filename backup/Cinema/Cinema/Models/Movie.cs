using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
	public class Movie
	{
		public int movieId { get; set; } //make special
		public string title { get; set; }
		public int length { get; set; }
		public DateTime releaseDate { get; set; }
		public string director { get; set; }
		public string imgUrl { get; set; }
		public string url { get; set; }
		public int ageRating { get; set; }
	}
}
