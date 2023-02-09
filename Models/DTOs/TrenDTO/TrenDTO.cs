using System;

namespace NewRepo.Models.DTOs.TrenDTO
{
    public class TrenDTO
    {
        public Guid? TrenId { get; set; }
        public int Vagoane { get; set; }
        public int Vagoane { get; set; }
        public int locuri_per_vagon { get; set; }
        public string loc_plecare { get; set; }
        public string loc_sosire { get; set; }
    }
}