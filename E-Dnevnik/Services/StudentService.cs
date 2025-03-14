using E_Dnevnik.Models;
using E_Dnevnik.Repositories.StudentRepo;
using E_Dnevnik.Repositories.SubjectRepo;
using E_Dnevnik.Utilites;

namespace E_Dnevnik.Services
{
    public class StudentService(IStudentRepository studentRepository, ISubjectRepository subjectRepository)
    {
        private readonly IStudentRepository _studentRepository = studentRepository;
        private readonly ISubjectRepository _subjectRepository = subjectRepository;

        public void AssignSubjectsToStudents()
        {
            foreach (var student in _studentRepository.GetAllStudents())
            {
                foreach (var subject in _subjectRepository.GetAllSubjects())
                {
                    if (!student.SubjectGrade.ContainsKey(subject.SubjectId))
                    {
                        student.SubjectGrade[subject.SubjectId] = [];
                    }
                }
            }
        }
        public void AssignGradesToStudents()
        {
            Input inputValidator = new Input();
            string studentName = inputValidator.InputStudentName();
            Student student = _studentRepository.GetStudentByName(studentName);
            student.StudentExists();
            int subjectId = inputValidator.InputSubjectName(_subjectRepository);
            int grade = inputValidator.InputGrade();
            student.SubjectGrade[subjectId].Add(grade);
        }

        private string DescribeGrades(double averageGrade)
        {
            if (averageGrade >= 1 && averageGrade < 1.49) //refactor
            {
                return "Nedovoljan";
            }
            else if (averageGrade >= 1.5 && averageGrade < 2.49)
            {
                return "Dovoljan";
            }
            else if (averageGrade >= 2.5 && averageGrade < 3.49)
            {
                return "Dobar";
            }
            else if (averageGrade >= 3.5 && averageGrade < 4.49)
            {
                return "Vrlo dobar";
            }
            return "Odlican";
        }

        //move to printer class
        public void PrintGrades()
        {
            Console.Write("Student Name:");
            string name = Console.ReadLine() ?? string.Empty;
            Student student = _studentRepository.GetStudentByName(name);
            Console.WriteLine("Subject Grades:");
            PrintSubjectGrade(student);
        }

        private void PrintSubjectGrade(Student student)
        {
            foreach (var entry in student.SubjectGrade)
            {
                int subjectId = entry.Key;
                List<int> grades = entry.Value;

                Console.Write($"{_subjectRepository.GetSubjectNameById(subjectId)}: ");
                
                if (grades.Count > 0)
                {
                    double average = grades.Average();
                    Console.Write(string.Join(", ", grades));
                    Console.WriteLine(" | Average: " + average + " " + DescribeGrades(average));
                    //Console.WriteLine($"[{string.Join(", ", grades)}]");
                }
                else
                {
                    Console.WriteLine("No grades available.");
                }
            }
        }
    }
}
