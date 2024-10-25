using TestCoreWebAppMvc.Models;
using TestCoreWebAppMvc.Repository.Implementations;
using TestCoreWebAppMvc.Repository.Interface;
using TestCoreWebAppMvc.Repository.Services.Interface;

namespace TestCoreWebAppMvc.Repository.Services.Implementation
{
    public class TeacherService:ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISubjectRepository _subjectRepository;
        public TeacherService(ITeacherRepository teacherRepository, ISubjectRepository subjectRepository)
        {
            _teacherRepository = teacherRepository;
            _subjectRepository = subjectRepository;
        }

        
        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _subjectRepository.GetAllSubjectsAsync();
        }

       

        public async Task AddAsync(TeacherViewModel viewModel)
        {
            var teacher = new Teacher
            {
                Name = viewModel.Name,
                Age = viewModel.Age,
                Sex = viewModel.Sex,
                Image= viewModel.Image
            };

            await _teacherRepository.AddAsync(teacher);

            if (viewModel.SelectedSubjectIds != null)
            {
                foreach (var subjectId in viewModel.SelectedSubjectIds)
                {
                    var studentSubject = new TeacherSubject
                    {
                        TeacherId = teacher.Id,
                        SubjectId = subjectId
                    };

                    await _teacherRepository.AddTeacherSubjectAsync(studentSubject);
                }
            }
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            await _teacherRepository.UpdateAsync(teacher);
        }

        
    }
}
