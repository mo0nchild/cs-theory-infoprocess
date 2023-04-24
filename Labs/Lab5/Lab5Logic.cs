using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryInfoProcess.Labs.Lab5
{
    public partial class Lab5Logic : LabsHelper
    {
        public Lab5Logic() : base() { }

        public sealed class Task1Model : System.Object
        {
            public double[] TK { get; set; } = default;
            public double[] RI { get; set; } = default;
            public double[] ZI { get; set; } = default;

            public double Lambda { get; set; } = default;
            public (int T1, int T2) TValues { get; set; } = default;
        }

        public Lab5Logic.Task1Model CalculateTask1(int N)
        {
            double lambda = 10 * (N + 1) / (double)(N + 4), n = 100, T1 = N + 1, T2 = N + 4;

            double[] Ri = new double[(int)n];
            for (int i = 0; i < Ri.Length; i++)
            {
                Ri[i] = LabsHelper.RandomGenerator.NextDouble();
            }
            double[] Zi = new double[(int)n];
            for (int i = 0; i < Zi.Length; i++) Zi[i] = (-1.0 / lambda) * Math.Log(Ri[i]);

            var Tk = new List<double>();
            for (; (Tk.Count == 0) ? true : Tk[Tk.Count - 1] <= T2;)
            {
                Tk.Add(T1);
                for (int i = 0; i < Tk.Count && i < Zi.Length; i++) Tk[Tk.Count - 1] += Zi[i];
            }
            return new Task1Model { 
                Lambda = lambda, RI = Ri, TK = Tk.ToArray(), ZI = Zi, TValues = ((int)T1, (int)T2) 
            };
        }
        public sealed class Task2Model : System.Object
        {
            public double[] XT { get; set; } = default;
            public double[] NK { get; set; } = default;
            public double Lambda { get; set; } = default;
        }

        public Lab5Logic.Task2Model CalculateTask2(int N, double[] Tk)
        {
            double T1 = N + 1, T2 = N + 4, result3 = default;
            List<double> result1 = new List<double>(), result2 = new List<double>();

            for(double interval = T1; interval < T2; interval += (T2 - T1) / 24.0)
            {
                var count = default(int);
                foreach(var item in Tk) { if (item < interval) count++; }
                result1.Add(count);
            }
            for(int index = 0; index < 24; index++)
            {
                var count = default(int);
                foreach (var item in result1) { if (item == index) count++; }
                result2.Add(count);

                result3 += (result1[index] * result2[index]);
            }
            return new Task2Model { Lambda = result3 / (T2 - T1), NK = result2.ToArray(), XT = result1.ToArray() };
        }

        public string[] CalculateTask3(double lambda, (int T1, int T2) tvalues, double[] Zi)
        {
            var result_value = new List<string>();
            var t = tvalues.T2 - tvalues.T1;
            double P0 = Math.Round(Math.Pow(Math.E, -lambda * t), 10, MidpointRounding.AwayFromZero);
            result_value.Add(string.Format("{0:E}", P0));
            double P1 = Math.Round(Math.Pow(Math.E, -lambda * t) * lambda * t, 10, MidpointRounding.AwayFromZero);
            result_value.Add(string.Format("{0:E}", P1));


            double P4 = Math.Round(Math.Pow(Math.E, -lambda) * Math.Pow(lambda, 4) / this.Factorial(4), 10, MidpointRounding.AwayFromZero);
            result_value.Add(string.Format("{0:E}", P4));
            double P2 = Math.Round(Math.Pow(Math.E, -lambda) * Math.Pow(lambda, 2) / this.Factorial(2), 10, MidpointRounding.AwayFromZero);
            double P3 = Math.Round(Math.Pow(Math.E, -lambda) * Math.Pow(lambda, 3) / this.Factorial(3), 10, MidpointRounding.AwayFromZero);
            double sum = P0 + P1 + P2 + P3 + P4;
            double Pmore5 = 1 - sum;
            result_value.Add(string.Format("{0:E}", Pmore5));

            double sum1 = P0 + P1 + P2;
            result_value.Add(string.Format("{0:E}", sum1));
            double P5 = Math.Round(Math.Pow(Math.E, -lambda) * Math.Pow(lambda, 5) / this.Factorial(5), 10, MidpointRounding.AwayFromZero);
            double P6 = Math.Round(Math.Pow(Math.E, -lambda) * Math.Pow(lambda, 6) / this.Factorial(6), 10, MidpointRounding.AwayFromZero);
            double P7 = Math.Round(Math.Pow(Math.E, -lambda) * Math.Pow(lambda, 7) / this.Factorial(7), 10, MidpointRounding.AwayFromZero);
            sum += P5 + P6 + P7;
            result_value.Add(string.Format("{0:E}", sum));
            result_value.Add(string.Format("{0:E}", F()));

            return result_value.ToArray();
            double F() {
                var x = new List<double>();
                for (int i = 0; i < Zi.Length; i++)
                {
                    if (Zi[i] >= 0.1 && Zi[i] <= 0.5) x.Add(Zi[i]);
                }
                return (double)(x.Count) / (double)(Zi.Length);
            }
        }
    }
}