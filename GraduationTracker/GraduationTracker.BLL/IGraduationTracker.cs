using GraduationTracker.Models;

namespace GraduationTracker.BLL
{
    public interface IGraduationTracker
    {
        Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student);

        GraduationResult[] GetGraduationResults();
    }
}
