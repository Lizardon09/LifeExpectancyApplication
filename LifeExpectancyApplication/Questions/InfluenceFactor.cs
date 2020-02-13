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

    public abstract class InfluenceFactor
    {
        public FactorTypes TypeOfFactor { get; set; }

        public abstract float ConsiderFactor(float age, float modifier, string answer);

        public abstract bool CheckAnswer(string answer);

        public abstract void DisplayOptions();

        public abstract void GetSpecificType();

    }
}
