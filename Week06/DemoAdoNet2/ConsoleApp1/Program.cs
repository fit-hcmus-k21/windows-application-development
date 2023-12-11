namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var x = new
            {
                ID = "001",
                Name = "tester1"
            };

            var y = new
            {
                ID = "001",
                Name = "tester2"
            };

            var z = new
            {
                ID = "001",
                Name = "tester2",
                Credits = 7
            };
            Console.WriteLine(x.GetType().Name);
            Console.WriteLine(y.GetType().Name);
            Console.WriteLine(z.GetType().Name);
        }
    }
}