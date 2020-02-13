using System;
using System.Collections.Generic;
using System.Text;

namespace LifeExpectancyApplication.Questions
{

    public enum OptionalType
    {
        Smoke = 10,
        Drink = 5,
        Stress = 3,
        Posture = 7

    }

    public class OptionalFactor : InfluenceFactor
    {
        public string Positive { get; set; }
        public string Negeative { get; set; }
        public OptionalType TypeOfOptional { get; set; }
        public OptionalFactor(OptionalType type, string postiveanswer, string negativeanswer)
        {
            TypeOfFactor = FactorTypes.Optional;
            TypeOfOptional = type;
            Positive = postiveanswer;
            Negeative = negativeanswer;
        }

        public override float ConsiderFactor(float age, float modifier, string answer)
        {
            if (answer == "1")
                return age - ((float)TypeOfOptional * modifier);
            else
                return age;
        }

        public override void DisplayOptions()
        {
            Console.WriteLine($"\nDo you:\n\n(0) {Positive}\n(1) {Negeative}");
        }

        public override bool CheckAnswer(string answer)
        {
            if (answer == "0" || answer == "1")
                return true;
            return false;
        }
        public override void GetSpecificType()
        {
            Console.WriteLine($"\n\n-------{(OptionalType)TypeOfOptional} Question--------\n");
        }
    }
}
