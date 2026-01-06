using System;
using SmartHomeSecurity;
namespace SmartHomeSecurity;
using CallbackDemo;


class Program
{
    static void Main()
    {
        // PaymentService  service = new PaymentService();
        // PaymentDelegate payment = service.ProcessPayment;
        // payment(5000);

        // PaymentService service = new PaymentService();
        // PaymentDelegate payment =  service.ProcessPayment;
        // decimal amount = 5000;
        // if (amount.isValidPayment())
        // {
        //     payment(amount);
        // }
        // else
        // {
        //     Console.WriteLine("Invalid payment amount.");
        // }

        // NotificationService service = new NotificationService();
        // OrderDelegate notify = null;
        // notify += service.SendEmail;
        // notify += service.SendSMS;

        // notify("ORD1001");


        // Action<string> logActivity = message => Console.WriteLine("Log Entry: " + message);
        // logActivity("User logged in at 10:30 AM");

        // Func<decimal,decimal,decimal> calculateDiscount = (price,discount) => price - (price*discount /100);
        // Console.WriteLine(calculateDiscount(1000,10));

        // Predicate<int> isEligible = age => age >= 18;
        // Console.WriteLine(isEligible(20));

        // ErrorDelegate  errorHandler = delegate (string message)
        // {
        //     Console.WriteLine("Error : " + message);
        // };
        // errorHandler("File not found");

        // Button btn = new Button();

        // // Subscribing a  method to the event
        // btn.Clicked += () =>Console.WriteLine("Buttton was clicked");

        // //Trigger the event 
        // btn.Click();



        // // Objects Initialization
        //     MotionSensor livingRoomSensor = new MotionSensor();
        //     AlarmSystem siren = new AlarmSystem();
        //     PoliceNotifier police = new PoliceNotifier();

        //     // 2. INSTANTIATION & MULTICASTING
        //     // We "Subscribe" different methods to the sensor's delegate
        //     SecurityAction panicSequence = siren.SoundSiren; // Assignment of methods
        //     panicSequence += police.CallDispatch;

        //     // Linking the sequence to the sensor
        //     livingRoomSensor.OnEmergency = panicSequence;
	    //     // class_object.delegate_instance = delegate_instance_multicast

        //     // Simulation
        //     livingRoomSensor.DetectIntruder("Main Lobby");




        //   // STEP 4: The actual Callback Method
        // static void DisplayNotification(string file)
        // {
        //     Console.WriteLine($"NOTIFICATION: You can now open {file}.");
        // }

        //     FileDownloader downloader = new FileDownloader();

        //     // Pass the method 'DisplayNotification' as a callback
        //     downloader.DownloadFile("Presentation.pdf", DisplayNotification);



        Comparison<int> sortDescending = (a, b) => b.CompareTo(a);

        Console.WriteLine(sortDescending(5, 10));
        Console.WriteLine(sortDescending(10, 5));
        Console.WriteLine(sortDescending(5, 5));


    }
}

