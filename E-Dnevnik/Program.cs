using E_Dnevnik.Repositories.StudentRepo;
using E_Dnevnik.Repositories.SubjectRepo;
using E_Dnevnik.Services;

StudentRepository studentRepo = new();
SubjectRepository subjectRepo = new();

subjectRepo.Subjects.Add(new(1, "Algebra"));
subjectRepo.Subjects.Add(new(2, "Math"));
subjectRepo.Subjects.Add(new(3, "Physics"));

StudentService studentService = new(studentRepo, subjectRepo);


while (true)
{
    studentService.AssignSubjectsToStudents();
    Console.WriteLine("=== Student Management System ===");
    Console.WriteLine("1. Display all subjects");
    Console.WriteLine("2. Add a new student");
    Console.WriteLine("3. Assign grade to a student");
    Console.WriteLine("4. View all grades of a student");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Clear();
            subjectRepo.DisplayAllSubjects();
            break;
        case "2":
            Console.Clear();
            studentRepo.AddStudentToRepo();
            break;
        case "3":
            Console.Clear();
            studentService.AssignGradesToStudents();
            break;
        case "4":
            Console.Clear();
            studentService.PrintGrades();
            break;
        case "5":
            Console.Clear();
            Console.WriteLine("Are you sure you want to exit (yes/no)?");
            string prompt = Console.ReadLine();
            if (prompt == "yes")
            {
                Console.WriteLine("Exiting program...");
                return;
            }
            break;
        default:
            Console.Clear();
            Console.WriteLine("Invalid choice, please try again.");
            break;
    }
}