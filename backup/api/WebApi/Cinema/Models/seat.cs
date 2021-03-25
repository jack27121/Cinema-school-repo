using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
	public class Seat
	{
		public int seatId { get; set; }
		public int theaterId { get; set; }
		public int row { get; set; }
		public int number { get; set; }
	}
}