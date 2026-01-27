// using System;
// interface ILibrary
// {
//     void IssueBook();
//     void ReturnBook();
// }
// class StudentLibrary : ILibrary
// {
//     public void IssueBook()
//     {
//         Console.WriteLine("Book Issued");
//     }
//     public void ReturnBook()
//     {
//         Console.WriteLine("Book Returned");
//     }
// }
// class TeacherLibrary : ILibrary
// {
//     public void IssueBook()
//     {
//         Console.WriteLine("Book issued to teacher");
//     }

//     public void ReturnBook()
//     {
//         Console.WriteLine("Book returned by teacher");
//     }
// }

// class Library
// {
//     static void Main()
//     {
//         Console.WriteLine("Start");
//         ILibrary obj1 = new StudentLibrary();
//         ILibrary obj2 = new TeacherLibrary();
//         obj1.IssueBook();
//         obj2.IssueBook();

//     }
// }