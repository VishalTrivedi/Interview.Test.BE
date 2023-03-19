using GraduationTracker.DAL.Entities;

namespace GraduationTracker.DAL
{
    public interface IRequirementRepository
    {
        IEnumerable<Requirement> GetRequirements();

        Requirement GetRequirementById(int requirementId);
    }
}
