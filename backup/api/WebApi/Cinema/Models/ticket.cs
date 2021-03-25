using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
	public class Ticket
	{
		public int ticketId { get; set; }
		public int seatId { get; set; }
		public int showId { get; set; }
		public string qrCode { get; set; }
	}
}