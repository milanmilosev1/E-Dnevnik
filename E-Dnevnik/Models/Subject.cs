namespace E_Dnevnik.Models
{
    public class Subject(int subjectId, string? subjectName)
    {
        public int SubjectId { get; set; } = subjectId;
        public string? SubjectName { get; set; } = subjectName;
    }
}
