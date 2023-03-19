using GraduationTracker.DAL.Entities;

namespace GraduationTracker.DAL
{
    public class DiplomaRepository : IDiplomaRepository
    {
        private readonly GraduationContext _context;

        public DiplomaRepository(GraduationContext context)
        {
            _context = context;
        }
        public IEnumerable<Diploma> GetDiplomas()
        {
            return _context.Diplomas;
        }

        public Diploma GetDiplomaById(int diplomaId)
        {
            return _context.Diplomas
                .Single(d => d.Id == diplomaId);
        }
    }
}
