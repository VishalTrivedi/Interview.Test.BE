using GraduationTracker.DAL.Entities;

namespace GraduationTracker.BLL
{
    public interface IGraduationTracker
    {
        GraduationResult GetGraduationResult(int studentId);

        GraduationResult GetGraduationResult(Student student);
    }
}
