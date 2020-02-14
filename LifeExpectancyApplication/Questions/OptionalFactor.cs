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

    public class OptionalFactor : IInfluenceFactor
    {
        public string Positive { get; set; }
        public string Negative { get; set; }
        public OptionalType TypeOfOptional { get; set; }
        public FactorTypes TypeOfFactor { get; set; }

        public OptionalFactor(OptionalType type, string postiveanswer, string negativeanswer)
        {
            TypeOfFactor = FactorTypes.Optional;
            TypeOfOptional = type;
            Positive = postiveanswer;
            Negative = negativeanswer;
        }

        public float ConsiderFactor(float age, float modifier, string answer)
        {
            if (answer == "1")
                return age - ((float)TypeOfOptional + ((float)TypeOfOptional * modifier));
            else
                return age - (1 + 1 * modifier);
        }

        public void DisplayOptions()
        {
            Console.WriteLine($"\nDo you:\n\n(0) {Positive}\n(1) {Negative}");
        }

        public bool CheckAnswer(string answer)
        {
            try
            {
                if (Convert.ToInt32(answer)==0 || Convert.ToInt32(answer) == 1)
                    return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message + "\n");
                return false;
            }
            Console.WriteLine("\nInput is not one of the options provided, please try again.\n");
            return false;
        }

        public void GetSpecificType()
        {
            Console.WriteLine($"\n\n-------{(OptionalType)TypeOfOptional} Question--------\n");
        }
    }
}
