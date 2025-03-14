using E_Dnevnik.Models;

namespace E_Dnevnik.Repositories.StudentRepo
{
    public class StudentRepository : IStudentRepository
    {
        public List<Student> Students = [];
        public void AddStudentToRepo()
        {
            Console.Write("Enter students: ");
            string input = Console.ReadLine();
            string[] inputList = input.Split(',', ' ', StringSplitOptions.RemoveEmptyEntries);
            
            foreach(var item in inputList)
            {
                string trimmedPart = item.Trim();
                if (string.IsNullOrEmpty(trimmedPart))
                {
                    Console.WriteLine("Error");
                    return;
                }
                Students.Add(new Student(item, [])); 
            }
        }
        public List<Student> GetAllStudents()
        {
            return Students;
        }

        //what if there are two students with the same name??
        public Student? GetStudentByName(string studentName)
        {
            foreach(var student in Students)
            {
                if(student.FullName.Equals(studentName, StringComparison.CurrentCultureIgnoreCase))
                {
                    return student;
                }
            }
            return null;
        }
    }
}
