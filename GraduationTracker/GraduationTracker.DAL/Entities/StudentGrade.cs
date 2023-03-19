﻿namespace GraduationTracker.DAL.Entities
{
    public class StudentGrade
    {
        public int Id { get; set; }

        // Option 1
        //public int CourseId { get; set; }
        //public virtual Course Course { get; set; }

        // Option 2
        public int StudentId { get; set; }
        public Student Student { get; set; }

        // Option 1
        //public int StudentId { get; set; }
        //public virtual Student Student { get; set; }

        // Opotion 2
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int Mark { get; set; }

        public int Credits { get; set; }
    }
}
