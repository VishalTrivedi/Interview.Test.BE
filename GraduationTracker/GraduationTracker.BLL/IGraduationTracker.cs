using GraduationTracker.DAL;
using GraduationTracker.Entities;

namespace GraduationTracker.BLL
{
    public interface IGraduationTracker
    {
        //GraduationResult GetGraduationResult(int studentId);

        GraduationResult GetGraduationResult(Student student, List<StudentGrade> studentGrade, Diploma diploma);
    }
}
