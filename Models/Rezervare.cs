using System;
using NewRepo.Models.Base;
using NewRepo.Models.Enums;

namespace NewRepo.Models
{
	public class Rezervare: BaseEntity
	{
        public string Description { get; set; }
        public bool IsConfirmed { get; set; }
        public User UserId { get; set; }
        public User FirstName { get; set; }
        public User LastName { get; set; }
        public Guid? RezervareId { get; set; }
        public List<Bilet> bilete { get; set; } = new List<bilet>();
    }
}
