using E_Dnevnik.Models;

namespace E_Dnevnik.Repositories.SubjectRepo
{
    public interface ISubjectRepository
    {
        public List<Subject> GetAllSubjects();
        public void DisplayAllSubjects();
        public Subject GetSubjectByName(string subjectName);
        public int GetSubjectIdByName(string subjectName);
        public string GetSubjectNameById(int subjectId);
    }
}
