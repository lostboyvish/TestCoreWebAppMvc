using TestCoreWebAppMvc.Models;

namespace TestCoreWebAppMvc.Repository.Interface
{
    public interface ISubjectRepository
    {
        
        Task AddAsync(Subject subject);
        Task<IEnumerable<Subject>> GetAllSubjectsAsync();
    }
}
