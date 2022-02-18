using System.Collections.Generic;
using System.Linq;

namespace Vakor.ABCAlgorithm.Lib.ProbabilityTapes
{
    public class ProbabilityTape
    {
        private double[] _maxValLimits;

        public void InitTape(List<int> values)
        {
            int totalValue = values.Sum();
            double[] probabilityTape = new double[values.Count];
            for (int i = 0; i < values.Count; i++)
            {
                double probability = (double) values[i] / totalValue;
                if (i != 0)
                {
                    probability += probabilityTape[i - 1];
                }

                probabilityTape[i] = probability;
            }

            _maxValLimits = probabilityTape;
        }

        public int FindValue(double value)
        {
            for (int j = 1; j < _maxValLimits.Length; j++)
            {
                if (_maxValLimits[j] >= value)
                {
                    return j - 1;
                }
            }

            return _maxValLimits.Length-1;
        }
    }
}