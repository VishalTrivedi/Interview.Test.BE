using GraduationTracker.DAL.Entities;

namespace GraduationTracker.DAL
{
    public class RequirementRepository : IRequirementRepository
    {
        private readonly GraduationContext _context;

        public RequirementRepository(GraduationContext context)
        {
            _context = context;
        }

        public IEnumerable<Requirement> GetRequirements()
        {
            return _context.Requirements;
        }

        public Requirement GetRequirementById(int requirementId)
        {
            return _context.Requirements
                .Single(s => s.Id == requirementId);
        }
    }
}
