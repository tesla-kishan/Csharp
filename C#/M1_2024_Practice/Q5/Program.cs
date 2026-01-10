public delegate bool IsEligibleforScholarship(Student std);
public class student
    {
        public int RollNo {get;set;}
        public string Name {get;set;}
        public int Marks {get;set;}
        public char SportsGrade {get;set;}
    }
public class Program
{
    public static string GetEligibleStudent(
        List<Student> students,
        IsEligibleForScholarship check)
    {
        string str = "";
        foreach(var s in students)
        {
            if (check(s))
            {
                str += s.Name + " ";
            }
        }
        return str.TrimEnd(',' ,' ');
    }
}