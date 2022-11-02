using System;
using System.Collections.Generic;

namespace WebApplication_P.Models
{
    public partial class Tbldoctor
    {
        public int Id { get; set; }
        public string DoctorName { get; set; } = null!;
        public string? Gender { get; set; }
        public int? Salary { get; set; }
    }
}
