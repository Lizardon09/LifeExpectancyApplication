using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifeExpectancyApplication.Questions
{
    public enum QuantitativeType
    {
        Height = 85,
        Weight = 20
    }

    public class QuantitativeFactor : InfluenceFactor
    {
        public string Measurement { get; set; }
        public float Quantity { get; set; }
        public QuantitativeType TypeOfQuantitative { get; set; }

        public QuantitativeFactor(QuantitativeType type, string measurement)
        {
            TypeOfFactor = FactorTypes.Quantitative;
            TypeOfQuantitative = type;
            Measurement = measurement;
        }

        public override float ConsiderFactor(float age, float modifier, string answer)
        {
            Quantity = Convert.ToInt64(answer);

            modifier += (age - (Quantity / (float)TypeOfQuantitative))/100;

            return modifier;

        }

        public override void DisplayOptions()
        {
            Console.WriteLine($"\n\nPlease enter your {(QuantitativeType)TypeOfQuantitative}({Measurement}):\n");
        }

        public override bool CheckAnswer(string answer)
        {
            if (answer.All(Char.IsDigit) && Convert.ToInt64(answer) > 0)
                return true;
            return false;
        }
        public override void GetSpecificType()
        {
            Console.WriteLine($"\n\n-------{(QuantitativeType)TypeOfQuantitative} Question--------\n");
        }
    }
}
