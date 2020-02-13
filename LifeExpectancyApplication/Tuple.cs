using System;
using System.Collections.Generic;
using System.Text;

namespace LifeExpectancyApplication
{
    public class Tuple<T, U>
    {
        public T LowerLimit { get; set; }
        public U UpperLimit { get; set; }

        public Tuple(T lowerlimit, U upperlimit)
        {
            LowerLimit = lowerlimit;
            UpperLimit = upperlimit;
        }
    }
}
