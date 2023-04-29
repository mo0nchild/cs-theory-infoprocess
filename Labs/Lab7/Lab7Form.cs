using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TheoryInfoProcess.Labs.Lab7
{
    using chrt = System.Windows.Forms.DataVisualization.Charting;
    public partial class Lab7Form : Form
    {
        public Lab7Form()
        {
            this.Text = "Лабораторная работа 7";
            this.InitializeComponent();
            this.button1_Click(this, EventArgs.Empty);
        }
        double result;

        private const int V = 3;
        public double Calculate(int v, int Intensity)
        {
            double sum = 0;

            result = 0;
            result = Math.Pow(Intensity, v) / (double)Factorial(v);
            for (int j = 0; j <= v; j++)
            {
                sum += ((Math.Pow(Intensity, j)) / (double)Factorial(j));
            }
            result /= sum;

            return result;
        }
        private double Factorial(double n)
        {
            if (n == 1 || n == 0) return 1;
            return Factorial(n - 1) * n;
        }
        private double CalculatePInfinity(double v, int i, out double p0_infinity)
        {
            p0_infinity = default(double);
            for (int k = 0; k <= v; k++)
            {
                p0_infinity += (Math.Pow(v, k) / this.Factorial(k));
            }
            p0_infinity = Math.Round(1 / (1.0 + p0_infinity), 4, MidpointRounding.AwayFromZero);
            var pi_infinity = (Math.Pow(v, i) / this.Factorial((double)i)) * p0_infinity;
            return Math.Round(pi_infinity, 4, MidpointRounding.AwayFromZero);
        }
        public sealed class FoundedModel : object
        {
            public (double P0, double PINf) Values { get; set; }
            public double I { get; set; }
            public double V { get; set; }
        }
        private FoundedModel[] CheckCroosing(int VN)
        {
            var result = new List<FoundedModel>();
            for (int i = 1; i <= VN; i++)
            {
                for (int j = 1; j <= VN; j++)
                {
                    var current = this.CalculatePInfinity(j, i, out var p0_inf);
                    var previous = this.CalculatePInfinity(j, i - 1, out var p0_inf_prev);
                    if (Math.Round(current, 3) == Math.Round(previous, 3) && Math.Round(p0_inf, 3) == Math.Round(p0_inf_prev, 3))
                    {
                        result.Add(new FoundedModel { Values = (Math.Round(current, 3), Math.Round(p0_inf, 3)), I = i, V = j });
                    }
                }
            }
            return result.ToArray();
        }
        //xd
        public sealed class QualityCharacteristics : Object
        {
            public double Pb { get; set; } = default; // Вероятность потери вызова
            public double Pt { get; set; } = default; // Вероятность потерь по времени
            public double Ph { get; set; } = default; // Вероятность потерь по нагрузке
            //xd
            public double Y { get; set; } = default; // Обслуженную нагрузку Y;
            public double R { get; set; } = default; // Избыточную нагрузку R;
            public double A { get; set; } = default; // Потенциальную нагрузку A.

            public QualityCharacteristics() : base() { }
        }
        //xd
        public QualityCharacteristics CalculateCharacter(int N)
        {
            var lq = 10 * (N + 1) / (double)(N + 4);
            var pivalue = GetPiValue(N);
            return new QualityCharacteristics()
            {
                Pb = Math.Round(pivalue, 4, MidpointRounding.AwayFromZero),
                Pt = Math.Round(pivalue, 4, MidpointRounding.AwayFromZero),
                Ph = Math.Round(lq / (double)(lq + N), 4, MidpointRounding.AwayFromZero),
                Y = Math.Round(lq * (1 - pivalue), 4, MidpointRounding.AwayFromZero),
                R = Math.Round(lq * pivalue, 4, MidpointRounding.AwayFromZero),
                A = Math.Round(lq, 4, MidpointRounding.AwayFromZero)
            };
            double GetPiValue(int i)
            {
                double value = 0;
                for (int j = 0; j <= N; j++) value += (Math.Pow(lq, j) / this.Factorial(j));
                return (Math.Pow(lq, i) / this.Factorial(i)) / value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chrt.Series seriesOne =
              new chrt.Series()
              {
                  Color = Color.Green,
                  Name = "Канал 1",
                  ChartType = SeriesChartType.Spline,
                  BorderWidth = 4,
              };
            chrt.Series seriesTwo =
             new chrt.Series()
             {
                 Color = Color.Crimson,
                 Name = "Канал 2",
                 ChartType = SeriesChartType.Spline,
                 BorderWidth = 4,
             };
            chrt.Series seriesThree =
             new chrt.Series()
             {
                 Color = Color.BlueViolet,
                 Name = "Канал 3",
                 ChartType = SeriesChartType.Spline,
                 BorderWidth = 4,
             };
            for (int i = 0; i <= 15; i++)
            {
                seriesOne.Points.Add(new DataPoint(i, Calculate(1, i)));
                seriesTwo.Points.Add(new DataPoint(i, Calculate(2, i)));
                seriesThree.Points.Add(new DataPoint(i, Calculate(3, i)));
            }
            chart1.Series.Add(seriesOne);
            chart1.Series.Add(seriesTwo);
            chart1.Series.Add(seriesThree);

            foreach (var item in this.CheckCroosing(V))
            {
                Console.WriteLine($"({item.Values.P0}, {item.Values.PINf}):\ti: {item.I}; v: {item.V}");
            }
            var c = this.CalculateCharacter(20);

            this.label1.Text = ("Вероятность потери вызова: " + c.Pb.ToString());
            this.label2.Text = ("Вероятность потерь по времени: " + c.Pt.ToString());
            this.label3.Text = ("Вероятность потерь по нагрузке: " + c.Ph.ToString());
            this.label4.Text = ("Обслуженная нагрузка Y: " + c.Y.ToString());
            this.label5.Text = ("Избыточная нагрузка R: " + c.R.ToString());
            this.label6.Text = ("Потенциальная нагрузка: " + c.A.ToString());

            Console.WriteLine("Вероятность потери вызова " + c.Pb.ToString());
            Console.WriteLine("Вероятность потерь по времени " + c.Pt.ToString());
            Console.WriteLine("Вероятность потерь по нагрузке " + c.Ph.ToString());
            Console.WriteLine("Обслуженная нагрузка Y " + c.Y.ToString());
            Console.WriteLine("Избыточная нагрузка R " + c.R.ToString());

            dataGridFull(dataGridView1, true);
            dataGridFull(dataGridView2, false);
        }
        private void dataGridFull(DataGridView dataGrid, bool flag)
        {
            dataGrid.Rows.Clear();
            dataGrid.Font = new Font(FontFamily.GenericSansSerif, 10);

            dataGrid.BackgroundColor = Color.WhiteSmoke;

            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            dataGrid.RowHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            dataGrid.EnableHeadersVisualStyles = false;
            dataGrid.DefaultCellStyle.SelectionBackColor = Color.GreenYellow;
            dataGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGrid.RowHeadersDefaultCellStyle.SelectionBackColor = Color.GreenYellow;
            dataGrid.RowHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dataGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dataGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.GreenYellow;

            if (flag)
            {
                var p0_inf = default(double);
                dataGrid.RowCount = V + 1;
                dataGrid.ColumnCount = 9;
                dataGrid.RowHeadersWidth = 70;
                dataGrid.ColumnHeadersHeight = 50;
                dataGrid.Columns[0].HeaderCell.Value = $"i";

                dataGrid.Columns[1].HeaderCell.Value = $"Pi(∞), v=0";
                dataGrid.Columns[2].HeaderCell.Value = $"P0(∞), v=0";
                dataGrid.Columns[3].HeaderCell.Value = $"Pi(∞), v=1";
                dataGrid.Columns[4].HeaderCell.Value = $"P0(∞), v=1";
                dataGrid.Columns[5].HeaderCell.Value = $"Pi(∞), v=2";
                dataGrid.Columns[6].HeaderCell.Value = $"P0(∞), v=2";
                dataGrid.Columns[7].HeaderCell.Value = $"Pi(∞), v=3";
                dataGrid.Columns[8].HeaderCell.Value = $"P0(∞), v=3";

                for (int i = 0; i < V + 1; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        dataGrid.Rows[i].Cells[0].Value = i;
                        dataGrid.Rows[i].Cells[1].Value = this.CalculatePInfinity(0, i, out p0_inf);
                        dataGrid.Rows[i].Cells[2].Value = p0_inf;
                        dataGrid.Rows[i].Cells[3].Value = this.CalculatePInfinity(1, i, out p0_inf);
                        dataGrid.Rows[i].Cells[4].Value = p0_inf;
                        dataGrid.Rows[i].Cells[5].Value = this.CalculatePInfinity(2, i, out p0_inf);
                        dataGrid.Rows[i].Cells[6].Value = p0_inf;
                        dataGrid.Rows[i].Cells[7].Value = this.CalculatePInfinity(3, i, out p0_inf);
                        dataGrid.Rows[i].Cells[8].Value = p0_inf;
                        dataGrid.Rows[i].Cells[j].Style.BackColor = SystemColors.Control;
                        dataGrid.Columns[j].Width = 80;
                        dataGrid.Rows[i].Height = 30;
                        dataGrid.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                }
                dataGrid.Columns[0].Width = 40;
                dataGrid.Columns[1].Width = 60;
                dataGrid.Columns[2].Width = 60;
            }
            else if (flag == false)
            {
                dataGrid.RowCount = V;
                dataGrid.ColumnCount = 3;
                dataGrid.RowHeadersWidth = 70;
                dataGrid.ColumnHeadersHeight = 60;
                dataGrid.Columns[0].HeaderCell.Value = $"i";

                dataGrid.Columns[1].HeaderCell.Value = $"V";
                dataGrid.Columns[2].HeaderCell.Value = $"P0";
                dataGrid.Columns[2].HeaderCell.Value = $"Точки пересечений, Pi(∞)";

                int a = 0;
                foreach (var item in this.CheckCroosing(V))
                {
                    if (a <= V)
                    {
                        dataGrid.Rows[a].Cells[0].Value = item.I;
                        dataGrid.Rows[a].Cells[1].Value = item.V;
                        dataGrid.Rows[a].Cells[2].Value = $"({item.Values.P0}; {item.Values.PINf})";
                        a++;
                    }
                }
                for (int i = 0; i < V; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        dataGrid.Rows[i].Cells[j].Style.BackColor = SystemColors.Control;
                        dataGrid.Rows[i].Height = 30;
                    }
                }
                dataGrid.Columns[0].Width = 40;
                dataGrid.Columns[1].Width = 40;
                dataGrid.Columns[2].Width = 100;
            }
        }
    }
}
