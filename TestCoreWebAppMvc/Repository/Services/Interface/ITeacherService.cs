using TestCoreWebAppMvc.Models;

namespace TestCoreWebAppMvc.Repository.Services.Interface
{
    public interface ITeacherService
    {
        Task AddAsync(TeacherViewModel teacher);
        Task UpdateAsync(Teacher teacher);
        Task<IEnumerable<Subject>> GetAllSubjectsAsync();

    }
}
