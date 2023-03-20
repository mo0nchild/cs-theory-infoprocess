using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TheoryInfoProcess.Labs.Lab3
{
    using MH = MathNet.Numerics.Distributions;
    public sealed class Lab3Logic : LabsHelper
    {
        public const System.Int32 N = 50, M = 20, MM = 15;

        public Lab3Logic() : base() { }

        private double Primitive(double x)
        {
            double tau = 6.2831853071;
            return -139.0 / (20 * Math.Pow(Math.E, 4 * tau)) + x / 5 + 139.0 / 20.0;
        }

        public Dictionary<double, double> CalculateTask1(int a, int b)
        {
            double[] Y_n = new double[b + 1];

            var result = new Dictionary<double, double>();
            for (int x = 0; x <= b; x++)
            {
                var t = this.GaussRandom(a, b, (_) => true);

                Y_n[x] = Newton(t);
                result.Add(t, Y_n[x]);
            }
            return result;
            double Newton(double t) => Primitive(t) - Primitive(0);
        }

        public Dictionary<double, double> CalculateTask2(double a, double b, int L, int N)
        {
            double[] s = new double[L], k = new double[L], x = new double[N], y = new double[N];
            var result = new Dictionary<double, double>();

            for (int i = 0; i < L; i++) { s[i] = 1.0 * i / L; x[i] = s[i]; }

            for (int i = 0; i < L; i++) k[i] = s[L - i - 1];
            for (int i = 2 * L; i < 3 * L; i++) x[i] = x[i] + s[i - 2 * L];

            for (int i = 0; i < N; i++) x[i] = x[i] + this.GaussRandom(a, b, (_) => true);
            for (int i = 0; i < N; i++)
            {
                y[i] = 0.0;
                for (int p = 0; p < L; p++)
                {
                    if ((i - p) >= 0) y[i] = y[i] + x[i - p] * k[p];
                }
                result.Add(x[i], y[i]);
            }
            return result;
        }

        public List<double> CalculateTask3()
        {
            double[] s = new double[N], k = new double[N], x = new double[N];

            for(int i = 0; i < N; i++) s[i] =  Math.Sin(-2 * Math.PI * i / N);
            for (int i = 0; i < N; i++) k[i] = s[N - 1 - i];

            var disp = default(double);
            for(int i = 0; i < 200; i++)
            {
                for (int j = 0; j < N; j++) x[j] = this.GaussRandom(0, 1, (_) => true);
                var z = Solg();
                disp += z * z;
            }
            disp /= 200.0;

            double[] mass_porog = new double[M], veroa = new double[M];
            for (int i = 0; i < M; i++) mass_porog[i] = Math.Sqrt(disp) * (1.0 + 0.1 * i);

            for(int n = 0; n < 30000L; n++)
            {
                for(int j = 0; j < N; j++) x[j] = this.GaussRandom(0, 1, (_) => true);
                var z = Solg();
                for(int j = 0; j < M; j++)
                {
                    if (z >= mass_porog[j]) veroa[j]++;
                }
            }
            for (int j = 0; j < M; j++) veroa[j] /= 30000.0;

            for(int n = 0; n < MM; n++)
            {

            }


            double Solg()
            {
                var sym = default(double);
                for (int i = 0; i < N; i++) sym = sym + x[i] * k[N - 1 - i];
                return sym;
            }

            return default;
        }
    }
}
