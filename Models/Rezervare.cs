using System;
using NewRepo.Models.Base;
using NewRepo.Models.Enums;

namespace NewRepo.Models
{
	public class Rezervare: BaseEntity
	{
        public string Description { get; set; }
        public bool IsConfirmed { get; set; }
        public User? Client { get; set; }
        public Guid? ClientId { get; set; }
    }
}
