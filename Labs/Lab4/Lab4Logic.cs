using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TheoryInfoProcess.Labs.Lab4
{
    public sealed class Lab4Logic : LabsHelper
    {
        public Lab4Logic(): base() { }

        public List<(double, double, double)> CalculateTask1(int N, double a, double b)
        {
            double[] y = new double[N];
            double[] m_rek = new double[N];
            double[] m_ist = new double[N];
            int i;
            var result = new List<(double, double, double)>();

            for (i = 0; i < N; i++)
            {
                for (i = 1; i < N; i++) m_ist[i] = Math.Exp(0 * 0 / 2.0) / Math.Sqrt(2 * Math.PI);

                for (i = 1; i < N; i++)
                {
                    y[i] = GaussRandom(a, b, (_) => true);
                    if (y[i] <= 0) y[i] = 0;
                    else y[i] = Math.Pow(y[i], 2);
                }

                m_rek[1] = y[1];

                for (i = 2; i < N; i++) m_rek[i] = (i - 1.0) / i * m_rek[i - 1] + 1.0 / i * y[i];

            }

            for (int k = 0; k < N; k++)
            {
                var item = (y[k], m_rek[k], m_ist[k]);
                result.Add(item);
                // Console.WriteLine($"y[{k}]= {y[k]}\tm_rek[{k}]= {m_rek[k]}\tm_ist[{k}]= {m_ist[k]}\n");
            }

            return result;
        }

        public List<(double, double, double)> CalculateTask2(int N, double a, double b)
        {
            double[] y = new double[N];
            double[] m_rek = new double[N];
            double[] m_ist = new double[N];
            int i;
            var result = new List<(double, double, double)>();

            for (i = 0; i < N; i++)
            {
                for (i = 1; i < N; i++) m_ist[i] = Math.Exp(0 * 0 / 2.0) / Math.Sqrt(2 * Math.PI);

                for (i = 1; i < N; i++)
                {
                    y[i] = GaussRandom(a, b, (_) => true);
                    Console.WriteLine("feee" + y[i]);
                    y[i] = Math.Pow(y[i], 2);
                }

                m_rek[1] = y[1];

                for (i = 2; i < N; i++) m_rek[i] = (i - 1.0) / i * m_rek[i - 1] + 1.0 / i * y[i];
            }

            for (int k = 0; k < N; k++)
            {
                var item = (y[k], m_rek[k], m_ist[k]);
                result.Add(item);
                // Console.WriteLine($"y[{k}]= {y[k]}\tm_rek[{k}]= {m_rek[k]}\tm_ist[{k}]= {m_ist[k]}\n");
            }

            return result;
        }

        public List<(double, double, double)> CalculateTask3_1(int N, double a, double b)
        {
            double[] y = new double[N];
            double[] m_rek = new double[N];
            double[] m_ist = new double[N];
            int i;
            var result = new List<(double, double, double)>();

            for (i = 0; i < N; i++)
            {
                for (i = 1; i < N; i++) m_ist[i] = Math.Exp(-0.5 * 0.5 / 2.0) / Math.Sqrt(2 * Math.PI);

                for (i = 1; i < N; i++)
                {
                    y[i] = GaussRandom(a, b, (_) => true);
                    if (y[i] <= 0.5) y[i] = y[i];
                    else y[i] = -y[i];
                }

                m_rek[1] = y[1];

                for (i = 2; i < N; i++) m_rek[i] = (i - 1.0) / i * m_rek[i - 1] + 1.0 / i * y[i];

            }

            for (int k = 0; k < N; k++)
            {
                var item = (y[k], m_rek[k], m_ist[k]);
                result.Add(item);

            }

            return result;
        }

        public List<(double, double, double)> CalculateTask3_2(int N, double a, double b)
        {
            double[] y = new double[N];
            double[] m_rek = new double[N];
            double[] m_ist = new double[N];
            int i;
            var result = new List<(double, double, double)>();

            for (i = 0; i < N; i++)
            {
                for (i = 1; i < N; i++) m_ist[i] = Math.Exp(0 * 0 / 2.0) / Math.Sqrt(2 * Math.PI);

                for (i = 1; i < N; i++)
                {
                    y[i] = GaussRandom(a, b, (_) => true);
                    if (y[i] <= 0) y[i] = 0;
                    else y[i] = y[i];
                }

                m_rek[1] = y[1];

                for (i = 2; i < N; i++) m_rek[i] = (i - 1.0) / i * m_rek[i - 1] + 1.0 / i * y[i];

            }

            for (int k = 0; k < N; k++)
            {
                var item = (y[k], m_rek[k], m_ist[k]);
                result.Add(item);

            }

            return result;
        }
        public List<(double, double, double)> Difference1(List<(double, double, double)> list1, List<(double, double, double)> list2)
        {
            return list1.Zip(list2, (item1, item2) => (item1.Item1, item1.Item2 - item2.Item2, item1.Item3)).ToList();
        }
        public List<(double, double, double)> Difference2(List<(double, double, double)> list1, List<(double, double, double)> list2)
        {
            return list1.Zip(list2, (item1, item2) => (item1.Item1, item1.Item2, item1.Item3 - item2.Item3)).ToList();
        }

        public sealed class T8ModelResult : System.Object
        {
            public Dictionary<double, double> graphic { get; set; } = new Dictionary<double, double>();
            public (double A, double B) interval { get; set; } = default;
        }
        public T8ModelResult CalculateTask4(int MM, int N, int a, int b)
        {
            var result = new T8ModelResult();
            const double porog = 15, t = 1.960, d_prav = 0.95;

            double[] s = new double[N], k = new double[N], x = new double[N]; ;
            for (int i = 0; i < N; i++) s[i] = Math.Sin(-2.0 * Math.PI * i / N);
            for (int i = 0; i < N; i++) k[i] = s[N - 1 - i];

            for (int n = 0; n < MM; n++)
            {
                double A = 0.2 + 0.05 * n;
                for (int j = 0; j < N; j++)
                {
                    for (int i = 0; i < N; i++) x[i] = GaussRandom(a, b, (_) => true) + A * s[i];
                    var z = Solg();

                    if (z >= porog)
                    {
                        result.graphic.Add(A, z);
                        break;
                    }
                }
            }
            double m_ = result.graphic.Select((item) => item.Value).Sum() / N,
                D = result.graphic.Select((item) => Math.Pow(item.Value - m_, 2)).Sum() / N;

            double o = Math.Pow(D / N, 0.5), e = o * o * t;
            result.interval = (m_ - e, m_ + e);

            return result;
            double Solg()
            {
                var sym = default(double);
                for (int i = 0; i < N; i++) sym = sym + x[i] * k[N - 1 - i];
                return sym;
            }
        }
    }
}
