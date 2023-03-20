namespace GraduationTracker.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        public virtual IEnumerable<StudentGrade>? StudentGrades { get; set; }
    }
}
