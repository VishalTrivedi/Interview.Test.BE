namespace GraduationTracker.Entities
{
    public class StudentGrade
    {
        public int Id { get; set; }

        // Option 1
        //public virtual Course Course { get; set; }

        // Option 2
        public int CourseId { get; set; }
        public Course Course { get; set; }

        // Option 1
        //public virtual Student Student { get; set; }

        // Option 2
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int Mark { get; set; }

        public int Credits { get; set; }
    }
}
