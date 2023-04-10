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

namespace TheoryInfoProcess.Labs.Lab4
{
    using Charting = System.Windows.Forms.DataVisualization.Charting;
    public partial class Lab4Form : Form
    {
        private readonly Lab4Logic labLogic = new Lab4Logic();
        public Lab4Form() : base()
        {
            this.InitializeComponent();
            this.calculate1_button.Click += new EventHandler(this.Calculate1_button_Click);
            this.calculate2_button.Click += new EventHandler(this.Calculate2_button_Click);
            this.calculate3_button.Click += new EventHandler(this.Calculate3_button_Click);
            this.calculate4_button.Click += new EventHandler(this.Calculate4_button_Click);

            this.Calculate1_button_Click(this, EventArgs.Empty);
            this.Calculate2_button_Click(this, EventArgs.Empty);
            this.Calculate3_button_Click(this, EventArgs.Empty);
            this.Calculate4_button_Click(this, EventArgs.Empty);
        }

        private void Calculate4_button_Click(object sender, EventArgs args)
        {
            this.graph_chart4.Series.Clear();
            var series = new Charting::Series()
            {
                  Color = Color.Crimson, Name = "График",
                  ChartType = SeriesChartType.Spline, BorderWidth = 4,
            };
            int L = (int)this.chart4_L_numeric.Value, N = (int)this.chart4_N_numeric.Value;
            var result = this.labLogic.CalculateTask4(N, L, 0, 1);

            foreach (var item in result.graphic)
            {
                series.Points.Add(new DataPoint(item.Key, item.Value));
            }
            this.graph_chart4.Series.Add(series);
            this.chart1_textbox.Text = $"({string.Format("{0:F2}", result.interval.A)}; " +
                $"{string.Format("{0:F2}", result.interval.B)})";
        }

        private void Calculate3_button_Click(object sender, EventArgs args)
        {
            this.graph_chart3.Series.Clear();

            var series_one = new Charting::Series()
            {
                Color = Color.Crimson, Name = "Система 1",
                ChartType = SeriesChartType.Spline, BorderWidth = 4,
            };

            var series_two = new Charting::Series()
            {
                Color = Color.LightBlue, Name = "Система 2",
                ChartType = SeriesChartType.Spline, BorderWidth = 4,
            };

            var series_three = new Charting::Series()
            {
                Color = Color.Purple, Name = "Разность",
                ChartType = SeriesChartType.Spline, BorderWidth = 4,
            };

            var series_four = new Charting::Series()
            {
                Color = Color.Turquoise, Name = "Теоретическая\n истинная\n разность",
                ChartType = SeriesChartType.Spline, BorderWidth = 4,
            };
            int N1 = (int)chart3_n1_numeric.Value, N2 = (int)chart3_n2_numeric.Value;
            var result = this.labLogic.CalculateTask3_1(N1 - 1, 0, 1);
            var result2 = this.labLogic.CalculateTask3_2(N2 - 1, 0, 1);

            var result3 = this.labLogic.Difference1(result2, result);
            var result4 = this.labLogic.Difference2(result2, result);

            foreach (var item in result) series_one.Points.Add(new DataPoint(item.Item1, item.Item2));
            foreach (var item in result2) series_two.Points.Add(new DataPoint(item.Item1, item.Item2));
            foreach (var item in result3) series_three.Points.Add(new DataPoint(item.Item1, item.Item2));
            foreach (var item in result4) series_four.Points.Add(new DataPoint(item.Item1, item.Item3));

            this.graph_chart3.Series.Add(series_one);
            this.graph_chart3.Series.Add(series_two);
            this.graph_chart3.Series.Add(series_three);
            this.graph_chart3.Series.Add(series_four);
        }

        private void Calculate2_button_Click(object sender, EventArgs args)
        {
            this.graph_chart2.Series.Clear();

            var series_one = new Charting::Series()
            {
                Color = Color.Crimson, Name = "График 1",
                ChartType = SeriesChartType.Spline, BorderWidth = 4,
            };

            var series_two = new Charting::Series()
            {
                Color = Color.DarkOrchid, Name = "График 2",
                ChartType = SeriesChartType.Spline, BorderWidth = 4,
            };
            var N = (int)this.chart2_n_numeric.Value;
            var result = this.labLogic.CalculateTask2(N - 1, 0, 1);
            var result2 = this.labLogic.CalculateTask2(N - 1, 0, 1);

            foreach (var item in result)
            {
                series_one.Points.Add(new DataPoint(item.Item1, item.Item2));
            }
            foreach (var item in result2)
            {
                series_two.Points.Add(new DataPoint(item.Item1, item.Item3));
            }

            this.graph_chart2.Series.Add(series_one);
            this.graph_chart2.Series.Add(series_two);
        }

        private void Calculate1_button_Click(object sender, EventArgs args)
        {
            this.graph_chart1.Series.Clear();

            var series_one = new Charting::Series()
            {
                Color = Color.DarkTurquoise, Name = "График 1",
                ChartType = SeriesChartType.Spline, BorderWidth = 4,
            };

            var series_two = new Charting::Series()
            {
                Color = Color.DimGray, Name = "График 2",
                ChartType = SeriesChartType.Spline, BorderWidth = 4,
            };
            var N = (int)this.chart1_n_numeric.Value;
            var result = this.labLogic.CalculateTask1(N - 1, 0, 1);
            var result2 = this.labLogic.CalculateTask1(N - 1, 0, 1);

            foreach (var item in result)
            {
                series_one.Points.Add(new DataPoint(item.Item1, item.Item2));
            }
            foreach (var item in result2)
            {
                series_two.Points.Add(new DataPoint(item.Item1, item.Item3));
            }
            this.graph_chart1.Series.Add(series_one);
            this.graph_chart1.Series.Add(series_two);
        }
    }
}
