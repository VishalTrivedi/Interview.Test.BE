using GraduationTracker.DAL.Entities;

namespace GraduationTracker.DAL
{
    public class GraduationResult
    {
        public Student Student { get; set; }

        public bool HasGraduated { get; set; }

        public STANDING Standing { get; set; }

        public GraduationResult(Student student, bool hasGraduated, STANDING standing)
        {
            Student = student;
            HasGraduated = hasGraduated;
            Standing = standing;
        }
    }
}
