using TestCoreWebAppMvc.Models;

namespace TestCoreWebAppMvc.Repository.Interface
{
    public interface ITeacherRepository
    {

        Task AddAsync(Teacher teacher);
        Task UpdateAsync(Teacher teacher);
        Task AddTeacherSubjectAsync(TeacherSubject teacherSubject);

    }
}
