// using System;
// class Animal
// {
//     public virtual  void walk()
//     {
//         Console.WriteLine("walk");
//     }
// }
// class Cat : Animal
// {
//     public override void walk()
//     {
//         Console.WriteLine("speak");
//     }
// }
// class Dog : Animal
// {
//     public new void walk()
//     {
//         Console.WriteLine("Sound");
//     }
// }
// class Program
// {
//     static void Main()
//     {
//         Animal obj = new Cat();
//         Animal obj1 = new Dog();
//         obj1.walk();
//     }
// }



//Constructor Inheritance

// using System;
// class Parent
// {
//     public Parent()
//     {
//         Console.WriteLine("Parent");
//     }
// }

// class Child : Parent
// {
//     public Child() //: base()
//     {
//         Console.WriteLine("Child");
//     }
// }

// class Inheritance
// {
//     static void Main()
//     {
//         Child c = new Child();
//     }
// }



//Multilevel inheritance

// class Person
// {
//     public void showPerson() => Console.WriteLine("I am a Person");
// }

// class Employee : Person
// {
//     public void showEmployee() => Console.WriteLine("I am an Employee");
// }
// class Manager : Employee
// {
//     public void showManager() => Console.WriteLine("I am a Manager");
// }
// class Inheritance
// {
//     static void Main()
//     {
//         Manager m = new Manager();
//         m.showPerson();
//         m.showEmployee();
//         m.showManager();
//     }
// }