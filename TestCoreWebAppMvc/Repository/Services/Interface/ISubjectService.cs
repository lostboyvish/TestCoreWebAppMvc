using Microsoft.EntityFrameworkCore.Query.Internal;
using TestCoreWebAppMvc.Models;

namespace TestCoreWebAppMvc.Repository.Services.Interface
{
    public interface ISubjectService
    {
        Task AddAsync(Subject subject); 
        //Task<List<SubjectWithDetailsViewModel>> GetSubjectsWithStudentsAndTeachersAsync();

    }
}
