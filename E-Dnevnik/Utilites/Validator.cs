using E_Dnevnik.Models;

namespace E_Dnevnik.Utilites
{
    public static class Validator
    {
        public static bool StudentExists(this Student student)
        {
            if(student == null)
            {
                Console.WriteLine("Student not found");
                return false;
            }
            return true;
        }
        public static bool SubjectExists(this int subjectId)
        {
            if(subjectId == -1)
            {
                Console.WriteLine("Subject not found");
                return false;
            }
            return true;
        }

        public static bool ValidateGrade(this int grade)
        {
            if (grade < 1 || grade > 5)
            {
                Console.WriteLine("input rejected");
                return false;
            }
            return true;
        }
    }
}
