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

    public class BracketFactor : InfluenceFactor
    {
        public List<Tuple<string, string>> Brackets { get; set; }
        public BracketType TypeOfBracket { get; set; }

        public BracketFactor(BracketType type, List<Tuple<string, string>> brackets)
        {
            TypeOfFactor = FactorTypes.Bracket;
            TypeOfBracket = type;
            Brackets = brackets;
        }
        public override float ConsiderFactor(float age, float modifier, string answer)
        {
            return age - age/(((float)TypeOfBracket * (Convert.ToInt64(answer)+1)) * modifier);
        }

        public override void DisplayOptions()
        {
            Console.WriteLine($"\n\nHow much do you {(BracketType) TypeOfBracket}?:\n");
            for(int i=0; i<Brackets.Count; i++)
            {
                Console.WriteLine($"\n({i}) {Brackets[i].LowerLimit} - {Brackets[i].UpperLimit}\n");
            }
            Console.WriteLine();
        }

        public override bool CheckAnswer(string answer)
        {
            if (Convert.ToInt32(answer) >= 0 && Convert.ToInt32(answer) < Brackets.Count)
                return true;
            return false;
        }

        public override void GetSpecificType()
        {
            Console.Write($"\n\n-------{(BracketType)TypeOfBracket} Question--------\n");
        }
    }
}
