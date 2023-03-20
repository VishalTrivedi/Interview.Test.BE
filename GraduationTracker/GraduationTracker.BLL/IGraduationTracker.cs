using GraduationTracker.Entities;

namespace GraduationTracker.BLL
{
    public interface IGraduationTracker
    {
        GraduationResult GetGraduationResult(IEnumerable<StudentGrade> studentGrade, Diploma diploma);
    }
}
