﻿namespace GraduationTracker.Models
{
    public class Diploma
    {
        public int Id { get; set; }
        public int Credits { get; set; }
        public IEnumerable<Requirement> Requirements { get; set; }
    }
}
