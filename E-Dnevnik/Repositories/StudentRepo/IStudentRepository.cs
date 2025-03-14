using E_Dnevnik.Models;

namespace E_Dnevnik.Repositories.StudentRepo
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();
        public void AddStudentToRepo();
        public Student GetStudentByName(string studentName);
    }
}
