﻿namespace DataAccess.Models
{
    public class Equation
    {
        public int Id { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public double? Dscrmnnt { get; set; }

        public double? X1 { get; set; }
        public double? X2 { get; set; }
    }
}
