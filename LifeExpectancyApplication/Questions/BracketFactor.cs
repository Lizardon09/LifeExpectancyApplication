using System;
using System.Collections.Generic;
using System.Text;

namespace LifeExpectancyApplication.Questions
{
    public enum BracketType
    {
        Exercise = 5,
        Diet = 2
    }

    public class BracketFactor : IInfluenceFactor
    {
        Dictionary<string, string> _brackets { get; set; }
        public BracketType TypeOfBracket { get; set; }
        public FactorTypes TypeOfFactor { get; set; }

        public BracketFactor(BracketType type, Dictionary<string, string> brackets)
        {
            TypeOfFactor = FactorTypes.Bracket;
            TypeOfBracket = type;
            _brackets = brackets;
        }

        public float ConsiderFactor(float age, float modifier, string answer)
        {
            return age - (((float)TypeOfBracket * (Convert.ToInt64(answer)+1)) + (((float)TypeOfBracket * (Convert.ToInt64(answer) + 1)) * modifier));
        }

        public void DisplayOptions()
        {
            foreach (KeyValuePair<string, string> kvp in _brackets)
            {
                Console.WriteLine($"\n({kvp.Key}) {kvp.Value}\n");
            }
            Console.WriteLine();
        }

        public bool CheckAnswer(string answer)
        {
            try
            {
                if (Convert.ToInt32(answer) >= 0 && _brackets.ContainsKey(answer))
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
            Console.Write($"\n\n-------{(BracketType)TypeOfBracket} Question--------\n");
        }

        public bool Compare(IInfluenceFactor factor)
        {
            if (((BracketFactor)factor).TypeOfBracket == this.TypeOfBracket)
                return true;
            return false;
        }
    }
}
