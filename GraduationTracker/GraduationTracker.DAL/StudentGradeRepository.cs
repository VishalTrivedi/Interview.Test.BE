using GraduationTracker.Entities;

namespace GraduationTracker.DAL
{
    public class StudentGradeRepository : IStudentGradeRepository
    {
        private readonly GraduationContext _context;

        public StudentGradeRepository(GraduationContext context)
        {
            _context = context;
        }

        public IEnumerable<StudentGrade> GetCoursesByStudent(int studentId)
        {
            return _context.StudentGrades
                .Where(sg => sg.StudentId == studentId);
        }
    }
}
