using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheoryInfoProcess.Labs.Lab1
{
    using MathNet = MathNet.Numerics.Distributions;
    public class LabLogic : LabsHelper
    {
        public static readonly System.Int32 N = 500, M = 10000;

        public System.Int32 SegmentsCount { get; private set; } = default;
        public System.Int32 ExperimentsCount { get; private set; } = default;

        public LabLogic() : this(LabLogic.N, LabLogic.M) { }
        public LabLogic(int segmentsCount, int experimentsCount) : base()
        {
            (ExperimentsCount, SegmentsCount) = (experimentsCount, segmentsCount);
        }
        public Dictionary<double, double> CalculateTask1(double a, double b)
        {
            var f_array = new double[this.SegmentsCount];
            var d = (b - a) / this.SegmentsCount;

            var range = Enumerable.Range(0, this.SegmentsCount)
                .Select((e) => a + e * d).ToArray();

            for(int m = 0; m < this.ExperimentsCount; m++)
            {
                double x = RandomValue(a, b);
                f_array[(int)((x - a) / (b - a) * this.SegmentsCount)] += 1;
            }
            var result = new Dictionary<double, double>();
            for(int n = 0; n < this.SegmentsCount; n++)
            {
                result.Add(range[n], f_array[n] / (this.ExperimentsCount * d));
            }
            return result;

            double RandomValue(double _a, double _b) 
                => _a + (_b - _a) * LabLogic.RandomGenerator.NextDouble();
        }

        public Dictionary<double, double> CalculateTask2()
        {
            double[] X = { 5, 25, 55, 7, 19, 21, 17 };

            var list = new Dictionary<double, int[]>()
            {
                [0.01] = new int[] { 5 }, [0.02] = new int[] { 25, 55 },
                [0.05] = new int[] { 7 }, [0.3] = new int[] { 19, 21, 17 },
            };
            var results = new Dictionary<double, double>();

            for (int i = 0; i < this.ExperimentsCount; i++)
            {
                var rand = RandomValue();

                if (results.ContainsKey(rand)) results[rand]++;
                else results.Add(rand, 1);
            }
            return results.OrderBy((e) => e.Key)
                .Select((e) => new KeyValuePair<double, double>(e.Key, e.Value / this.ExperimentsCount))
                .ToDictionary((e) => e.Key, (e) => e.Value);

            double RandomValue()
            {
                double random_num = default, x_exit = default;
                for (int i = 0; i < list.Count; i++)
                {
                    if(i == 0) { random_num = LabLogic.RandomGenerator.NextDouble(); }

                    var item = list.ElementAt<KeyValuePair<double, int[]>>(i);
                    if (random_num < item.Key) 
                    {
                        var rand = LabLogic.RandomGenerator.Next(item.Value.Length);
                        x_exit = item.Value[rand]; break; 
                    }
                    if (x_exit == default && i >= list.Count - 1) i = -1;
                }
                return x_exit;
            }
        }

        public Dictionary<double, double> CalculateTask3(double a, double b, double std, double mean)
        {
            var dist_random = this.CalculateTask1(a, b);

            double d = (b - a) / this.SegmentsCount;
            double[] f_array = new double[this.SegmentsCount];

            for (int m = 0; m < this.ExperimentsCount; m++)
            {
                var x = GaussRandom<object>(mean, std, (val) => { return (val <= b && val >= a); });

                int n = (int)((x - a) / (b - a) * this.SegmentsCount);
                f_array[n] = f_array[n] + 1;
            }
            for (int n = 0; n < this.SegmentsCount; n++)
            {
                f_array[n] = f_array[n] / (this.ExperimentsCount * d);
                dist_random[dist_random.ElementAt(n).Key] += f_array[n];
            }
            return dist_random;

            
        }
    }
}
