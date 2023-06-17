﻿using System;
using System.Collections.Generic;

namespace creamMUProductFinal.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Telephone { get; set; }
        public string? Password { get; set; }
        public int? EmailId { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public DateOnly? Birthday { get; set; }
        public string? Title { get; set; }
        public DateOnly? JoinDate { get; set; }
        public string? Notes { get; set; }
    }
}
