using System;

namespace LifeExpectancyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            LifeExpectancyCalculator LEapp = new LifeExpectancyCalculator();
            LEapp.StartCalculator();
            Console.ReadKey();
        }
    }
}
