namespace MyLibrary
{
    public interface I1
    {
        void M1();
        void M2();
    }

    public class ClassA : I1
    {
        public void M1()
        {
            System.Console.WriteLine("M1 executed");
        }

        public void M2()
        {
            System.Console.WriteLine("M2 executed");
        }
    }
}