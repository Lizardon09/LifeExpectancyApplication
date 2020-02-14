using LifeExpectancyApplication.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifeExpectancyApplication
{
    public class LifeExpectancyCalculator
    {
        public List<IInfluenceFactor> Questions { get; set; }

        private int CurrentAge { get; set; }

        private int ExpectedLife { get; set; }

        private float Modifier { get; set; }

        public LifeExpectancyCalculator()
        {
            Dictionary<string, string> Brackets = new Dictionary<string, string>();

            Brackets.Add("0","Every 2 days - 1 week");
            Brackets.Add("1", "Every 2 weeks - 1 month");
            Brackets.Add("2", "Every 2 months - 5 months");
            Brackets.Add("3", "More than a year - Almost Never");

            Questions = new List<IInfluenceFactor>()
            {
                new QuantitativeFactor(QuantitativeType.Height, "ft"),
                new QuantitativeFactor(QuantitativeType.Weight, "kg"),
                new OptionalFactor(OptionalType.Drink, "Not Drink", "Drink"),
                new OptionalFactor(OptionalType.Posture,"Have a good posture", "Have a bad posture"),
                new OptionalFactor(OptionalType.Smoke, "Not Smoke", "Smoke"),
                new BracketFactor(BracketType.Diet, Brackets),
                new BracketFactor(BracketType.Exercise, Brackets)
            };

            CurrentAge = 0;
            Modifier = 0;
            ExpectedLife = 120;
        }

        public LifeExpectancyCalculator(List<IInfluenceFactor> questions)
        {
            Questions = questions;

            CurrentAge = 0;
            Modifier = 0;
            ExpectedLife = 120;
        }

        public void StartCalculator()
        {
            string input = "";

            do
            {
                Console.WriteLine("\n\n------Please enter your age to begin-----\n");
                input = Console.ReadLine();

                

                if(input.All(Char.IsDigit) && Convert.ToInt32(input)>5){
                    CurrentAge = Convert.ToInt32(input);
                    break;
                }
                else
                {
                    Console.WriteLine("\nIncorrect input, please try again.");
                }

            } while (true);

            Console.WriteLine("\n\n--------Please answer the questions bellow----------\n");

            foreach(var question in Questions)
            {
                if(question.TypeOfFactor == FactorTypes.Quantitative)
                {
                    Modifier += ProcessQuestion(question, CurrentAge, Modifier, input);
                }
            }

            foreach(var question in Questions)
            {
                if(question.TypeOfFactor != FactorTypes.Quantitative)
                {
                    ExpectedLife = (int) ProcessQuestion(question, ExpectedLife, Modifier, input);
                }
            }

            if(ExpectedLife<CurrentAge)
                Console.WriteLine($"\n\n-----Your going to die very soon-----");
            else
                Console.WriteLine($"\n\n-----Your Life Expectancy is: {ExpectedLife} years-----");

        }

        public float ProcessQuestion(IInfluenceFactor question, int age, float modifier, string input)
        {
            question.GetSpecificType();
            do
            {
                question.DisplayOptions();
                Console.WriteLine();
                input = Console.ReadLine();
                if (question.CheckAnswer(input))
                {
                    break;
                }

            } while (true);

            return question.ConsiderFactor(age, modifier, input);

        }

    }
}
