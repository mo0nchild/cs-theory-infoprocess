using MathNet.Numerics.LinearAlgebra.Factorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryInfoProcess.Labs
{
    using MathNet = MathNet.Numerics.Distributions;

    public class LabsHelper : System.Object
    {
        protected static readonly System.Random RandomGenerator = new Random();
        public LabsHelper() : base() { }

        public virtual double GaussRandom(double mean, double std, Predicate<double> state) 
            => this.GaussRandom<object>(mean, std, state);

        public virtual double GaussRandom<T>(double mean, double std, Predicate<double> state, 
            T param = default(T)) where T : class
        {
            double return_value = default;
            while (true)
            {
                return_value = MathNet::Normal.Sample(LabsHelper.RandomGenerator, mean, std);
                if (state.Invoke(return_value)) { break; }
            }
            return return_value;
        }
    }
}
