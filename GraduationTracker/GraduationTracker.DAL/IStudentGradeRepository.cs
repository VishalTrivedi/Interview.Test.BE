using GraduationTracker.DAL.Entities;

namespace GraduationTracker.DAL
{
    public interface IStudentGradeRepository
    {        
        IEnumerable<StudentGrade> GetCoursesByStudent(int studentId);
    }
}
