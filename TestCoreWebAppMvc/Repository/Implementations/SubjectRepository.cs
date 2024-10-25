using Microsoft.EntityFrameworkCore;
using TestCoreWebAppMvc.Data;
using TestCoreWebAppMvc.Models;
using TestCoreWebAppMvc.Repository.Interface;

namespace TestCoreWebAppMvc.Repository.Implementations
{
    public class SubjectRepository:ISubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddStudentSubjectAsync(StudentSubject studentSubject)
        {
            _context.StudentSubjects.Add(studentSubject);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _context.Subjects.ToListAsync();
        }



        //public async Task<IEnumerable<SubjectWithDetailsViewModel>> GetSubjectsWithStudentsAndTeachersAsync()
        //{
        //    return await _context.Subjects
        //        .Select(s => new SubjectWithDetailsViewModel
        //        {
        //            SubjectId = s.Id,
        //            Name = s.Name,
        //            Class = s.Class,
        //            Teachers = s.TeacherSubjects.Select(ts => new TeacherViewModel
        //            {
        //                TeacherId = ts.Teacher.Id,
        //                Name = ts.Teacher.Name
        //            }).ToList(),
        //            Students = s.StudentSubjects.Select(ss => new StudentViewModel
        //            {
        //                StudentId = ss.Student.Id,
        //                Name = ss.Student.Name
        //            }).ToList()
        //        })
        //        .ToListAsync();
        //}
        public async Task AddAsync(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
        }

        
       
        
    }
}
