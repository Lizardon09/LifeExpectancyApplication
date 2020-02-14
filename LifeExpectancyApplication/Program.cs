using System;
using LifeExpectancyApplication.Questions;

namespace LifeExpectancyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            LifeExpectancyCalculator LEapp = new LifeExpectancyCalculator();

            //IInfluenceFactor question = new QuantitativeFactor(QuantitativeType.Height, "Test");
            //IInfluenceFactor questionB = new OptionalFactor(OptionalType.Drink, "Testing", "Now");
            //LEapp.AddQuestion(questionB);

            LEapp.StartCalculator();
            Console.ReadKey();
        }
    }
}
