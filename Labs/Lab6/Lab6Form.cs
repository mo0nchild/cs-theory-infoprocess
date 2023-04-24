using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TheoryInfoProcess.Labs.Lab6
{
    using chrt = System.Windows.Forms.DataVisualization.Charting;
    public partial class Lab6Form : Form
    {
        public Lab6Form() => InitializeComponent();

        //N=2
        //lambda one = 10*(N+1)/(N+4);
        //lambdaTwo = 15 * 3 / 6.0;
        //T1 = N+1;
        //T2=N+4;
        Random RND = new Random();
        static int T1 = 21;
        static int T2 = 24;
        public double[] TK;
        double[] Zi;
        double[] Ri;

        double lambdaOne = 10 * 21 / 24.0;
        double lambdaTwo = 15 * 21 / 24.0;

        double model_lambda;
        public double[] Table1(int N, DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();
            dataGrid.Font = new Font("Comic Sans MS", 9);
            dataGrid.RowCount = N;
            dataGrid.ColumnCount = 3;
            dataGrid.RowHeadersWidth = 70;
            dataGrid.ColumnHeadersHeight = 50;

            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            dataGrid.RowHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            dataGrid.EnableHeadersVisualStyles = false;
            dataGrid.DefaultCellStyle.SelectionBackColor = Color.LightCoral;
            dataGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGrid.RowHeadersDefaultCellStyle.SelectionBackColor = Color.LightCoral;
            dataGrid.RowHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dataGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dataGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightCoral;

            dataGrid.Columns[0].HeaderCell.Value = $"Ri";

            dataGrid.Columns[1].HeaderCell.Value = $"Zi";
            dataGrid.Columns[2].HeaderCell.Value = $"Tk";
            Ri = new double[N];
            for (int i = 0; i < Ri.Length; i++)
            {
                Ri[i] = RND.NextDouble();
            }
            Zi = new double[N];

            for (int i = 0; i < Zi.Length; i++)
            {
                Zi[i] = (-1.0 / lambdaOne) * Math.Log(Ri[i]);
            }

            var Tk = new List<double>();
            for (; (Tk.Count == 0) ? true : Tk[Tk.Count - 1] <= T2;)
            {
                Tk.Add(T1);

                for (int i = 0; i < Tk.Count && i < Zi.Length; i++) Tk[Tk.Count - 1] += Zi[i];

            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    dataGrid.Rows[i].Cells[0].Value = Ri[i];
                    dataGrid.Rows[i].Cells[1].Value = Zi[i];

                    dataGrid.Rows[i].Cells[j].Style.BackColor = SystemColors.Control;
                    dataGrid.Columns[j].Width = 160;
                    dataGrid.Rows[i].Height = 30;
                    dataGrid.Rows[i].HeaderCell.Value = $"{i + 1}";

                }
            }
            for (int i = 0; i < Tk.Count; i++)
            {
                dataGrid.Rows[i].Cells[2].Value = Tk[i];
            }
            TK = Tk.ToArray();
            return Tk.ToArray();
        }
        public double[] Table2(int N, DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();
            dataGrid.Font = new Font("Comic Sans MS", 9);
            dataGrid.RowCount = N;
            dataGrid.ColumnCount = 3;
            dataGrid.RowHeadersWidth = 70;
            dataGrid.ColumnHeadersHeight = 50;

            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            dataGrid.RowHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            dataGrid.EnableHeadersVisualStyles = false;
            dataGrid.DefaultCellStyle.SelectionBackColor = Color.LightCoral;
            dataGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGrid.RowHeadersDefaultCellStyle.SelectionBackColor = Color.LightCoral;
            dataGrid.RowHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dataGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dataGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightCoral;

            dataGrid.Columns[0].HeaderCell.Value = $"Ri";

            dataGrid.Columns[1].HeaderCell.Value = $"Zi";
            dataGrid.Columns[2].HeaderCell.Value = $"Tk";
            Ri = new double[N];
            for (int i = 0; i < Ri.Length; i++)
            {
                Ri[i] = RND.NextDouble();
            }
            Zi = new double[N];

            for (int i = 0; i < Zi.Length; i++)
            {
                Zi[i] = (-1.0 / lambdaTwo) * Math.Log(Ri[i]);
            }

            var Tk = new List<double>();
            for (; (Tk.Count == 0) ? true : Tk[Tk.Count - 1] <= T2;)
            {
                Tk.Add(T1);

                for (int i = 0; i < Tk.Count && i < Zi.Length; i++) Tk[Tk.Count - 1] += Zi[i];

            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    dataGrid.Rows[i].Cells[0].Value = Ri[i];
                    dataGrid.Rows[i].Cells[1].Value = Zi[i];

                    dataGrid.Rows[i].Cells[j].Style.BackColor = SystemColors.Control;
                    dataGrid.Columns[j].Width = 160;
                    dataGrid.Rows[i].Height = 30;
                    dataGrid.Rows[i].HeaderCell.Value = $"{i + 1}";

                }
            }
            for (int i = 0; i < Tk.Count; i++)
            {
                dataGrid.Rows[i].Cells[2].Value = Tk[i];
            }
            TK = Tk.ToArray();
            return Tk.ToArray();

        }

        readonly double tau = (T2 - T1) / 24.0;
        List<(double, double)> result1;
        List<(double, double)> result2;
        List<(double, double)> result3;
        double res4 = default(double);
        public void Table3(double[] Tk, int N, DataGridView dataGrid, DataGridView dataGrid1)
        {
            dataGrid.Rows.Clear();
            dataGrid.Font = new Font("Comic Sans MS", 9);
            dataGrid.RowCount = 4;
            dataGrid.ColumnCount = 24;
            dataGrid.RowHeadersWidth = 150;
            dataGrid.ColumnHeadersHeight = 30;

            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            dataGrid.RowHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            dataGrid.EnableHeadersVisualStyles = false;
            dataGrid.DefaultCellStyle.SelectionBackColor = Color.LightCoral;
            dataGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGrid.RowHeadersDefaultCellStyle.SelectionBackColor = Color.LightCoral;
            dataGrid.RowHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dataGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dataGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightCoral;


            dataGrid1.Rows.Clear();
            dataGrid1.Font = new Font("Comic Sans MS", 9);
            dataGrid1.RowCount = 2;
            dataGrid1.ColumnCount = 24;
            dataGrid1.RowHeadersWidth = 150;
            dataGrid1.ColumnHeadersHeight = 30;

            dataGrid1.AllowUserToResizeColumns = false;
            dataGrid1.AllowUserToResizeRows = false;
            dataGrid1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGrid1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            dataGrid1.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            dataGrid1.RowHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            dataGrid1.EnableHeadersVisualStyles = false;
            dataGrid1.DefaultCellStyle.SelectionBackColor = Color.LightCoral;
            dataGrid1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGrid1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.LightCoral;
            dataGrid1.RowHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dataGrid1.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dataGrid1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightCoral;

            dataGrid1.Rows[0].HeaderCell.Value = $"x(t)";
            dataGrid1.Rows[1].HeaderCell.Value = $"Nk";

            dataGrid.Rows[0].HeaderCell.Value = $"N интервала";
            dataGrid.Rows[1].HeaderCell.Value = $"x1(t)";
            dataGrid.Rows[2].HeaderCell.Value = $"x2(t)";
            dataGrid.Rows[3].HeaderCell.Value = $"x1+x2";

            result1 = new List<(double, double)>();
            result2 = new List<(double, double)>();
            result3 = new List<(double, double)>();
            List<double> result5 = new List<double>();

            var t = Table1(N, dataGridView1);
            var n = 1;
            for (double i = T1; i < T2; i += tau)
            {
                var count = default(int);
                for (int o = 0; o < t.Length; o++) { if (t[o] < i) count++; }
                var item = (n, count);
                result1.Add(item);
                n++;
            }
            t = Table2(N, dataGridView2);
            n = 1;
            for (double i = T1; i < T2; i += tau)
            {
                var count = default(int);
                for (int o = 0; o < t.Length; o++) { if (t[o] < i) count++; }
                var item = (n, count);
                result2.Add(item);
                n++;
            }


            result3 = Sum(result1, result2);
            res4 = 0;
            for (int index = 0; index < 24; index++)
            {
                var count = default(int);
                foreach (var item in result3) { if (item.Item2 == index) count++; }
                result5.Add(count);

                res4 += result3[index].Item2 * result5[index];
            }


            for (int i = 0; i < 24; i++)
            {
                dataGrid.Rows[0].Cells[i].Value = i + 1;
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    dataGrid.Rows[1].Cells[j].Value = (result1.ElementAt(j)).Item2;
                    dataGrid.Rows[2].Cells[j].Value = (result2.ElementAt(j)).Item2;
                    dataGrid.Rows[3].Cells[j].Value = (result3.ElementAt(j)).Item2;

                    dataGrid.Rows[i].Cells[j].Style.BackColor = SystemColors.Control;
                    dataGrid.Columns[j].Width = 50;
                    dataGrid.Rows[0].Height = 30;
                    dataGrid.Rows[1].Height = 30;

                }
            }
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < result5.Count; j++)
                {
                    dataGrid1.Rows[0].Cells[j].Value = j + 1;
                    dataGrid1.Rows[1].Cells[j].Value = result5.ElementAt(j);

                    dataGrid1.Rows[i].Cells[j].Style.BackColor = SystemColors.Control;
                    dataGrid1.Columns[j].Width = 50;
                    dataGrid1.Rows[0].Height = 30;
                    dataGrid1.Rows[1].Height = 30;

                }
            }
            var sum = default(double);
            foreach (var item in result3)
            {
                sum += item.Item2;
            }
            var math_ojid = sum / 24.0;
            var dispersiya = default(double);

            label20.Text = math_ojid.ToString();
            foreach (var item in result3)
            {
                dispersiya += Math.Pow((item.Item2 - math_ojid), 2) / (result3.Count);
            }

            label21.Text = dispersiya.ToString();

            model_lambda = Math.Round(res4 / (T2 - T1), 5, MidpointRounding.AwayFromZero);
        }
        public List<(double, double)> Sum(List<(double, double)> list1, List<(double, double)> list2)
        {
            return list1.Zip(list2, (item1, item2) => (item1.Item1, item1.Item2 + item2.Item2)).ToList();
        }
        private void Show_Click(object sender, EventArgs e)
        {
            //Table1((int)numericUpDown1.Value, dataGridView1);
            //Table2((int)numericUpDown1.Value, dataGridView2);
            Table3(TK, 500, dataGridView3, dataGridView4);
            label2.Text = model_lambda.ToString();

            if (model_lambda > (lambdaOne + lambdaTwo))
            {
                label17.Text = $"в {model_lambda / (lambdaOne + lambdaTwo)} раз";
            }

            else if (model_lambda < (lambdaOne + lambdaTwo))
            {
                label17.Text = $"в {(lambdaOne + lambdaTwo) / model_lambda} раз";
            }
            chart1.Series.Clear();

            chrt.Series seriesOne =
              new chrt.Series()
              {
                  Color = Color.Green,
                  Name = "График x1",
                  ChartType = SeriesChartType.Spline,
                  BorderWidth = 4,
              };


            var result = result1;

            foreach (var item in result)
            {
                seriesOne.Points.Add(new DataPoint(item.Item1, item.Item2));
            }
            chart1.Series.Add(seriesOne);

            chart2.Series.Clear();

            chrt.Series seriesTwo =
              new chrt.Series()
              {
                  Color = Color.SteelBlue,
                  Name = "График x2",
                  ChartType = SeriesChartType.Spline,
                  BorderWidth = 4,
              };


            var res = result2;

            foreach (var item in res)
            {
                seriesTwo.Points.Add(new DataPoint(item.Item1, item.Item2));
            }
            chart2.Series.Add(seriesTwo);

            chart3.Series.Clear();

            chrt.Series seriesThree =
              new chrt.Series()
              {
                  Color = Color.Brown,
                  Name = "График x",
                  ChartType = SeriesChartType.Spline,
                  BorderWidth = 4,
              };


            var resul = result3;

            foreach (var item in resul)
            {
                seriesThree.Points.Add(new DataPoint(item.Item1, item.Item2));
            }
            chart3.Series.Add(seriesThree);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
