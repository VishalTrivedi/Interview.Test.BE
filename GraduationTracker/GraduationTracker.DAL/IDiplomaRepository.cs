using GraduationTracker.Models;

namespace GraduationTracker.DAL
{
    public interface IDiplomaRepository
    {
        IEnumerable<Diploma> GetDiplomas();
        
        Diploma GetDiplomaById(int diplomaId);
    }
}
