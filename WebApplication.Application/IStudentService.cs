using WebApplication.Models;

namespace WebApplication.Application
{
    public interface IStudentService
    {
        Student Get();
        Student Get(int id);
        void Edit(Student student);
    }
}
