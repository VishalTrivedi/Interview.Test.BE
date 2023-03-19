using GraduationTracker.DAL.Entities;

namespace GraduationTracker.DAL
{
    public interface IDiplomaRepository
    {
        IEnumerable<Diploma> GetDiplomas();
        
        Diploma GetDiplomaById(int diplomaId);
    }
}
