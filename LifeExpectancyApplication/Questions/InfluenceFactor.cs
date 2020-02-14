using System;
using System.Collections.Generic;
using System.Text;

namespace LifeExpectancyApplication
{
    public enum FactorTypes
    {
        Quantitative,
        Bracket,
        Optional
    }

    public interface IInfluenceFactor
    {
        FactorTypes TypeOfFactor { get; set; }

        float ConsiderFactor(float age, float modifier, string answer);

        bool CheckAnswer(string answer);

        void DisplayOptions();

        void GetSpecificType();

    }
}
