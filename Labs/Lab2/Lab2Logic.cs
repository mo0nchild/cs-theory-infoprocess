using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TheoryInfoProcess.Labs.Lab2
{
    internal class Lab2Logic : LabsHelper
    {
        private static readonly System.Random random = new Random();
        public const System.Int32 N = 500;

        public System.Int32 SegmentsCount { get; private set; } = default;

        public Lab2Logic() : this(Lab2Logic.N) { }
        public Lab2Logic(int n) : base() => this.SegmentsCount = n;

        public virtual List<double> CalculateTask1(double mean, double std, double p) 
        {
            var func_result = new List<double>();
            double k2 = p, k1 = Math.Sqrt(std * (1.0 - k2 * k2));

            func_result.Add(this.GaussRandom(mean, std, (_) => true));
            for(int n = 1; n < this.SegmentsCount; n++)
            {
                func_result.Add(k1 * this.GaussRandom(mean, 1, (_) => true) + k2 * func_result[n-1]);
            }


            // ---------------------------------------
            const int _N = 3000;
            double[] e = new double[_N], x = new double[_N], 
                c = new double[this.SegmentsCount];

            for(int n = 0; n < _N; n++) e[n] = this.GaussRandom(0, 1, (_) => true);
            var P = (int)(2.0 / a);

            for(int k = 0; k <= P; k++)
            {
                if (k != 0) c[k] = Math.Sqrt(std) / Math.Sqrt(Math.PI * a) * Math.Sin(a * k) / k;
                else c[k] = Math.Sqrt(std) / Math.Sqrt(Math.PI * a) * a;
            }

            for(int n = 0; n < _N; n++)
            {
                x[n] = 0;
                for(int k = -P; k <= P; k++)
                {
                    var aa = default(double);
                    if (k < 0) aa = c[-k];
                    else aa = c[k];

                    if(((n - k) >= 0) && ((n - k) < _N)) x[n] = aa * e[n - k] + x[n];

                }
            }
            for (int n = 0; n < (_N - 2 * P); n++) x[n] = x[n + P];
            var N_realiz = _N - 2 * P;
            
            for(int m = 0; m < this.SegmentsCount; m++)
            {

            }

            return func_result;
        }

        public readonly struct Task1Model : System.ICloneable
        {
            public readonly List<System.Double> RandomProcess, ProcessRating;
            public Task1Model(List<double> func_process, List<double> rating)
            {
                this.RandomProcess = func_process; this.ProcessRating = rating;
            }
            System.Object ICloneable.Clone() => this.MemberwiseClone();
        }
    }
}
