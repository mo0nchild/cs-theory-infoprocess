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

namespace TheoryInfoProcess.Labs.Lab1
{
    using Charting = System.Windows.Forms.DataVisualization.Charting;
    public partial class Lab2Form : Form
    {
        private static readonly System.Int32 GraphWidth = 2;

        public Lab2Form() : base()
        {
            this.InitializeComponent();
            this.exp1_textbox.Text = "График 1"; this.exp2_textbox.Text = "График 2";

            this.exp1_color_button.Click += new EventHandler(ChangeColorHandler);
            this.exp2_color_button.Click += new EventHandler(ChangeColorHandler);

            this.exp3_color_button.Click += new EventHandler(ChangeColorHandler);
            this.exp4_color_button.Click += new EventHandler(ChangeColorHandler);

            this.calctask1_button.Click += new EventHandler(CalculateTask1Handler);
            this.calctask2_button.Click += new EventHandler(CalculateTask2Handler);
            this.calctask3_button.Click += new EventHandler(CalculateTask3Handler);

            this.CalculateTask1Handler(this, EventArgs.Empty);
            this.CalculateTask2Handler(this, EventArgs.Empty);
            this.CalculateTask3Handler(this, EventArgs.Empty);
        }

        private void ChangeColorHandler(object sender, EventArgs args)
        {
            using (var color_dialog = new ColorDialog())
            {
                if (color_dialog.ShowDialog() != DialogResult.OK) return;
                (sender as Button).BackColor = color_dialog.Color;
            }
        }

        private void CalculateTask1Handler(object sender, EventArgs args)
        {
            this.graph_chart1.Series.Clear();
            var series1 = new Charting::Series(this.exp1_textbox.Text)
            {
                ChartType = Charting::SeriesChartType.FastLine, BorderWidth = Lab2Form.GraphWidth,
                Color = this.exp1_color_button.BackColor, 
            };
            var series2 = new Charting::Series(this.exp2_textbox.Text)
            {
                ChartType = Charting::SeriesChartType.FastLine, BorderWidth = Lab2Form.GraphWidth,
                Color = this.exp2_color_button.BackColor,
            };

            int M1 = (int)this.exp1_numeric.Value, M2 = (int)this.exp2_numeric.Value,
                N = (int)this.segments1_numeric.Value;

            foreach (var item in new LabLogic(N, M1).CalculateTask1(-2, 7))
            {
                series1.Points.Add(new Charting::DataPoint(item.Key, item.Value));
            }
            foreach (var item in new LabLogic(N, M2).CalculateTask1(-2, 7))
            {
                series2.Points.Add(new Charting::DataPoint(item.Key, item.Value));
            }
            this.graph_chart1.Series.Add(series1);
            this.graph_chart1.Series.Add(series2);
        }

        private void CalculateTask2Handler(object sender, EventArgs args)
        {
            this.graph_chart2.Series.Clear();
            var series = new Charting::Series("График")
            {
                ChartType = Charting::SeriesChartType.Column, BorderWidth = Lab2Form.GraphWidth,
                Color = this.exp3_color_button.BackColor,
            };
            foreach (var item in new LabLogic(10, (int)this.experement2_numeric.Value).CalculateTask2())
            {
                series.Points.Add(new DataPoint(item.Key, item.Value));
            }
            this.graph_chart2.Series.Add(series);
        }

        private void CalculateTask3Handler(object semder, EventArgs args)
        {
            this.graph_chart3.Series.Clear();
            var series = new Charting::Series("График")
            {
                ChartType = Charting::SeriesChartType.FastLine,
                BorderWidth = Lab2Form.GraphWidth,
                Color = this.exp4_color_button.BackColor,
            };

            int N = (int)this.segments3_numeric.Value, M = (int)this.exp3_numeric.Value;
            foreach (var item in new LabLogic(N, M).CalculateTask3(5, 7, 1, 2))
            {
                series.Points.Add(new DataPoint(item.Key, item.Value));
            }
            this.graph_chart3.Series.Add(series);
        }
    }
}
