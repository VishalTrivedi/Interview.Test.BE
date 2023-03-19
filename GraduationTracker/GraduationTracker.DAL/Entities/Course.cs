namespace GraduationTracker.DAL.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MiminumMark { get; set; }
        public int RequiredCredits { get; set; }

        public virtual ICollection<StudentGrade>? StudentGrades { get; set; }
    }
}
