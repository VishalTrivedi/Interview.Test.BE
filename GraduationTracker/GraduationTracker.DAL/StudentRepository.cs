using GraduationTracker.Entities;

namespace GraduationTracker.DAL
{
    public class StudentRepository : IStudentRepository
    {
        private readonly GraduationContext _context;

        public StudentRepository(GraduationContext context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students;
        }

        public Student GetStudentByID(int studentId)
        {
            return _context.Students
                .Single(s => s.Id == studentId);
        }
    }
}
