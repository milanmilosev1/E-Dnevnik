using E_Dnevnik.Repositories.SubjectRepo;

namespace E_Dnevnik.Utilites
{
    public class Input
    {
        public int InputGrade()
        {
            Console.Write("\nEnter grade: ");
            int grade = Convert.ToInt32(Console.ReadLine());
            if (!grade.ValidateGrade())
            {
                return InputGrade();
            }
            return grade;
        }

        public int InputSubjectName(ISubjectRepository subjectRepo)
        {
            Console.Write("Subject name: ");
            string subject = Console.ReadLine();
            if (!subject.All(char.IsLetter))
            {
                Console.WriteLine("invalid input");
                return InputSubjectName(subjectRepo);
            }
            int subjectId = subjectRepo.GetSubjectIdByName(subject);
            if (subjectId == -1)
            {
                Console.WriteLine("Subject not found");
                return InputSubjectName(subjectRepo);
            }
            return subjectId;
        }

        public string InputStudentName()
        {
            Console.Write("Student name: ");
            string studentName = Console.ReadLine();
            if (studentName.All(char.IsLetter)) // whitespace - regex
            {
                return studentName;
            }
            Console.WriteLine("invalid input");
            return InputStudentName();
        }
    }
}
