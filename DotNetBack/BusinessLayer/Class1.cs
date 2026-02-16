// namespace BusinessLayer
// {
//     public class Calculator
//     {
//         public int Add(int a, int b)
//         {
//             return a + b;
//         } 
//     }
// }


using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessLayer
{
    public class StudentService
    {
        public List<string> GetReversedStudents()
        {
            StudentRepository repo = new StudentRepository();
            var students = repo.GetStudents();

            List<string> reversed = new List<string>();

            foreach (var name in students)
            {
                char[] arr = name.ToCharArray();
                Array.Reverse(arr);
                reversed.Add(new string(arr));
            }

            return reversed;
        }
    }
}
