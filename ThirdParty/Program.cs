namespace ThirdParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numb = 35;
            int result = Square(numb);
            Console.WriteLine($"{numb} ^ 2 = {result}");
        }
        static int Square(int number) => number * number;
    }
}