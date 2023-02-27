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

        public virtual List<double> CalculateTask1(double mean, double std, double a) 
        {
            var func_result = new List<double>();
            double k2 = Math.Exp(a), k1 = Math.Sqrt(std * (1.0 - k2 * k2));

            func_result.Add(this.GaussRandom(mean, std, (_) => true));
            for(int n = 1; n < this.SegmentsCount; n++)
            {
                func_result.Add(k1 * this.GaussRandom(mean, 1, (_) => true) + k2 * func_result[n-1]);
            }
            return func_result;
        }

        public virtual List<double> CalculateTask2(double b)
        {
            var Xn = this.CalculateTask1(0, 1, Math.Log(0.02));
            var Yn = new List<double>();

            for(int n = 1; n < this.SegmentsCount; n++)Yn.Add(2 * Xn[n] + b * Xn[n - 1]);
            return Yn;
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
