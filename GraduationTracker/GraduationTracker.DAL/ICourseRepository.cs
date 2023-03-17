using GraduationTracker.Models;

namespace GraduationTracker.DAL
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourses();

        Course GetCourseById(int courseId);

        Course GetCourseByName(string courseName);
    }
}
