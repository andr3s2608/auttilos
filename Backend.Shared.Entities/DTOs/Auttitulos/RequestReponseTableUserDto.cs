using System;

namespace Backend.Shared.Entities.DTOs.Auttitulos
{
    public class RequestReponseTableUserDto
    {
        public int? IdProcedureRequest { get; set; }
        public string? filed_number { get; set; }
        public string? titleType { get; set; }
        public DateTime? filedDate { get; set; }
        public string? institute { get; set; }
        public string? profession { get; set; } 
        public int? statusId { get; set; } 
        public string? status { get; set; }
        public string? colorTime { get; set; } 
        public string? resolutionPath { get; set; } 
    }
}