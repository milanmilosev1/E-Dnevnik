using E_Dnevnik.Models;

namespace E_Dnevnik.Repositories.SubjectRepo
{
    public class SubjectRepository : ISubjectRepository
    {
        public List<Subject> Subjects = [];

        public void DisplayAllSubjects()
        {
            Console.Write("Available subjects: ");
            foreach(var subject in Subjects)
            {
                Console.Write(subject.SubjectName + " ");
            }
            Console.WriteLine("\n");
        }

        public List<Subject> GetAllSubjects()
        {
            return Subjects;
        }

        public Subject GetSubjectByName(string subjectName)
        {
            foreach(var subject in Subjects)
            {
                if(subject.SubjectName.Equals(subjectName, StringComparison.CurrentCultureIgnoreCase))
                {
                    return subject;
                }
            }
            return null;
        }

        public int GetSubjectIdByName(string subjectName)
        {
            Subject subject = GetSubjectByName(subjectName);
            if(subject == null)
            {
                return -1;
            }
            return subject.SubjectId;
        }
    }
}
