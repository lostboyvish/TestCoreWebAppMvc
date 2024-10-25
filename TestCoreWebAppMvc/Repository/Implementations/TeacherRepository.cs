using Microsoft.EntityFrameworkCore;
using TestCoreWebAppMvc.Data;
using TestCoreWebAppMvc.Models;
using TestCoreWebAppMvc.Repository.Interface;

namespace TestCoreWebAppMvc.Repository.Implementations
{


    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task AddAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var teacher = await GetByIdAsync(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
            }
        }
        public async Task AddTeacherSubjectAsync(TeacherSubject teacherSubject)
        {
            _context.TeacherSubjects.Add(teacherSubject);
            await _context.SaveChangesAsync();
        }
    }
}
