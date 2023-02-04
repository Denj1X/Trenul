using System;
using NewRepo.Models.Base;
using NewRepo.Models.Enums;

namespace NewRepo.Models
{
	public class Tren: BaseEntity
	{
        public Guid? TrenId { get; set; }
        public int Vagoane { get; set; }
        public int locuri_per_vagon { get; set; }
        public string loc_plecare { get; set; }
        public string loc_sosire { get; set; }
        public List<bilet> bilete { get; set; } = new List<bilet>();
    }
}
