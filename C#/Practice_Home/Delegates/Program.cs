// delegate void PaymentDelegate(decimal amnount);
// delegate void PaymentDelegate0();
// class PaymentService
// {
//     public static  void ProcessPayment(decimal amount)
//     {
//         Console.WriteLine("Payment of " + amount + " Processed successfully");
//     }
//     public static  void ProcessPayment1()
//     {
//         Console.WriteLine("Payment of Processed successfully");
//     }
//     public static  void ProcessPayment2()
//     {
//         Console.WriteLine("Payment of Processed successfully");
//     }

// }

// class Program
// {
//     static void Main()
//     {
//         // PaymentService service = new PaymentService();
//         // PaymentDelegate payment = service.ProcessPayment;
//         // PaymentDelegate payment = PaymentService.ProcessPayment;
//         // payment(500);

//         // PaymentDelegate0 obj = new PaymentDelegate0(PaymentService.ProcessPayment1);
//         PaymentDelegate0 obj =PaymentService.ProcessPayment1;
//         obj += PaymentService.ProcessPayment2;
//         obj.Invoke();
//         // obj();
//     }
// }




// // single casting  delegates
// delegate void Home ();
// class A
// {
//     public void Room()
//     {
//         Console.WriteLine("M");
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         A obj = new A();
//         Home dname = obj.Room;
//         dname();
//     } 
// }



// Multi Casting Delegates

delegate void kk (string s);
class Ns
{
    public void fn1(string s)
    {
        Console.WriteLine("String is " + s);
    }
    public void fn2(string s)
    {
        Console.WriteLine("String is " + s);
    }

}
class Program
{
    static void Main()
    {
        Ns obj = new Ns();
        kk addd = obj.fn1;
        addd+= obj.fn2;
        addd("kk");
    }
}


