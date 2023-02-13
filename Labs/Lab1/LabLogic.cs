using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheoryInfoProcess.Labs.Lab1
{
    using MathNet = MathNet.Numerics.Distributions;
    public class LabLogic : System.Object
    {

        public static readonly System.Int32 N = 500, M = 10000;
        private static readonly Random RandomGenerator = new Random();

        public System.Int32 SegmentsCount { get; private set; } = default;
        public System.Int32 ExperimentsCount { get; private set; } = default;
        public System.Int32 CalculatingTimeout { get; private set; } = 1;

        public LabLogic() : this(LabLogic.N, LabLogic.M) { }
        public LabLogic(int segmentsCount, int experimentsCount) : base()
        {
            (ExperimentsCount, SegmentsCount) = (experimentsCount, segmentsCount);
        }
        public List<double> CalculateTask1(double a, double b)
        {
            double d = (b - a) / this.SegmentsCount;
            double[] f_array = new double[this.SegmentsCount];

            for(int m = 0; m < this.ExperimentsCount; m++)
            {
                double x = RandomValue(a, b);
                int n = (int)((x - a) / (b - a) * this.SegmentsCount);
                f_array[n] = f_array[n] + 1;
            }
            for(int n = 0; n < this.SegmentsCount; n++)
            {
                f_array[n] = f_array[n] / (this.ExperimentsCount * d); 
            }
            return f_array.ToList<double>();

            double RandomValue(double _a, double _b) 
                => _a + (_b - _a) * LabLogic.RandomGenerator.NextDouble();
        }

        public List<double> CalculateTask2()
        {
            double[] X = { 5, 25, 55, 7, 19, 21, 17 };
            double[] P = { 0.01, 0.02, 0.02, 0.05, 0.3, 0.3, 0.3 };

            var results = new List<double>();

            for (int i = 0; i < this.SegmentsCount; i++) results.Add(RandomValue());
            return results;

            double RandomValue()
            {
                double e = LabLogic.RandomGenerator.NextDouble(), x_exit = X[X.Length - 1];
                for (int i = 0; i < P.Length; i++)
                {
                    if (e < P[i]) { x_exit = X[i]; break; }
                }
                return x_exit;
            }
        }

        public List<double> CalculateTask3(double a, double b, double std, double mean)
        {
            var dist_random = this.CalculateTask1(a, b);

            double d = (b - a) / this.SegmentsCount;
            double[] f_array = new double[this.SegmentsCount];

            for (int m = 0; m < this.ExperimentsCount; m++)
            {
                var x = GaussRandom();

                int n = (int)((x - a) / (b - a) * this.SegmentsCount);
                f_array[n] = f_array[n] + 1;
            }
            for (int n = 0; n < this.SegmentsCount; n++)
            {
                f_array[n] = f_array[n] / (this.ExperimentsCount * d);
                f_array[n] += dist_random[n];
            }
            return f_array.ToList<double>();

            double GaussRandom()
            {
                double retval = default;
                while (true)
                {
                    retval = MathNet::Normal.Sample(LabLogic.RandomGenerator, mean, std);
                    if (retval <= b && retval >= a) { break; }
                }
                return retval;
            }
        }
    }
}
