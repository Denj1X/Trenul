using System;
using NewRepo.Models.Base;
using NewRepo.Models.Enums;

namespace NewRepo.Models
{
	public class Bilet
	{	
		public Rezervare RezervareId { get; set; }
		public Tren TrenId { get; set; }

    }
}
