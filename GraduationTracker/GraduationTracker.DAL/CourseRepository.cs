using GraduationTracker.Entities;

namespace GraduationTracker.DAL
{
    public class CourseRepository : ICourseRepository
    {
        private readonly GraduationContext _context;

        public CourseRepository(GraduationContext context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Course> GetCourses()
        {
            return _context.Courses;
        }

        public Course GetCourseById(int courseId)
        {
            return _context.Courses
                .Single(c => c.Id == courseId);
        }

        public Course GetCourseByName(string courseName)
        {
            return _context.Courses
                .Single(c => c.Name == courseName);
        }
    }
}
