using GraduationTracker.Models;

namespace GraduationTracker.DAL
{
    public class DiplomaRepository : IDiplomaRepository
    {
        private readonly RequirementRepository _requirementRepository;

        public DiplomaRepository(RequirementRepository requirementRepository)
        {
            _requirementRepository = requirementRepository;
        }

        public IEnumerable<Diploma> GetDiplomas()
        {
            return new[]
            {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = _requirementRepository.GetRequirements()
                }
            };
        }

        public Diploma GetDiplomaById(int diplomaId)
        {
            var diplomas = GetDiplomas();

            return diplomas.Single(d => d.Id == diplomaId);
        }
    }
}
