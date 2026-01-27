// interface IGear
// {
//     void Gear1();
//     void Gear2();
//     void Gear3();

//     void Gear4();
//     void Gear5();
//     void Gear6();

// }
// class MyCar : IGear
// {
//     public void Gear1()
//     {
//         Console.WriteLine("Gear1");
//     }
//     public void Gear2()
//     {
//         Console.WriteLine("Gear2");
//     }
//     public void Gear3()
//     {
//         Console.WriteLine("Gear3");
//     }
//     public void Gear4()
//     {
//         Console.WriteLine("Gear4");
//     }
//     public void Gear5()
//     {
//         Console.WriteLine("Gear5");
//     }
//     public void Gear6()
//     {
//         Console.WriteLine("Gear6");
//     }
// }
// abstract class MyCar1
// {
//     public abstract void SoundBox();
//     public abstract void SunRoof();
//     public abstract void AirBag();
// }

// class car : MyCar1
// {
//     public override void SoundBox()
//     {
//         Console.WriteLine("SoundBox");
//     }
//     public override void SunRoof()
//     {
//         Console.WriteLine("SunRoof");
//     }
//     public override void AirBag()
//     {
//         Console.WriteLine("AirBag");
//     }
// }


// class Program2
// {
//     static void Main()
//     {
//         IGear g1 = new MyCar();
//         g1.Gear1();
//         g1.Gear2();
//         g1.Gear3();
//         g1.Gear4();
//         g1.Gear5();
//         g1.Gear6();


//         MyCar1 obj = new car();
//         obj.SoundBox();
//         obj.SunRoof();
//         obj.AirBag();
//     }
// }


