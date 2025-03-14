namespace E_Dnevnik.Models
{
    public class Student(string fullName, Dictionary<int, List<int>> subjectGrade)
    {
        public string FullName { get; set; } = fullName;
        public Dictionary<int, List<int>>? SubjectGrade { get; set; } = subjectGrade;
    }
}
