﻿
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Doctor : TableEntityBase
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string MedicalDiagnose { get; set; } = string.Empty;
        [Required]
        public string MedicalRecommendation {  get; set; } = string.Empty;
    }
}
