using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheoryInfoProcess.Labs.Lab2;

namespace TheoryInfoProcess.Labs.Lab3
{
    using Charting = System.Windows.Forms.DataVisualization.Charting;
    public partial class Lab3Form : Form
    {
        protected Lab3Logic LabLogic { get; private set; } = new Lab3Logic();

        public Lab3Form() : base()
        {
            this.InitializeComponent();
            this.chart1_textbox.Text = "График 1"; this.chart2_textbox.Text = "График 2";
            this.chart3_textbox.Text = "График 3";

            this.chartcolor1_button.Click += new EventHandler(ChangeColorHandler);
            this.chartcolor2_button.Click += new EventHandler(ChangeColorHandler);
            this.chartcolor3_button.Click += new EventHandler(ChangeColorHandler);

            this.calculate1_button.Click += new EventHandler(Calculate1ButtonClick);
            this.calculate2_button.Click += new EventHandler(Calculate2ButtonClick);

            this.Calculate1ButtonClick(this, EventArgs.Empty);
            this.Calculate2ButtonClick(this, EventArgs.Empty);
            this.Calculate3ButtonClick(this, EventArgs.Empty);
        }

        private void ChangeColorHandler(object sender, EventArgs args)
        {
            using (var color_dialog = new ColorDialog())
            {
                if (color_dialog.ShowDialog() != DialogResult.OK) return;
                (sender as Button).BackColor = color_dialog.Color;
            }
        }

        private void Calculate1ButtonClick(object sender, EventArgs args)
        {
            this.graph_chart1.Series.Clear();
            var series = new Charting::Series(this.chart1_textbox.Text)
            {
                ChartType = Charting::SeriesChartType.FastLine,
                Color = this.chartcolor1_button.BackColor, BorderWidth = 2
            };
            foreach (var item in this.LabLogic.CalculateTask1(0, 5))
            {
                series.Points.Add(new Charting.DataPoint(item.Key, item.Value));
            }
            this.graph_chart1.Series.Add(series);
        }

        private void Calculate2ButtonClick(object sender, EventArgs args)
        {
            this.graph_chart2.Series.Clear();
            var series = new Charting::Series(this.chart2_textbox.Text)
            {
                ChartType = Charting::SeriesChartType.Spline,
                Color = this.chartcolor2_button.BackColor,
                BorderWidth = 2
            };
            try {
                foreach (var item in this.LabLogic.CalculateTask2(0, 0.5, (int)this.numericUpDown2.Value,
                    (int)this.numericUpDown1.Value))
                {
                    series.Points.Add(new Charting.DataPoint(item.Key, item.Value));
                }
                this.graph_chart2.Series.Add(series);
            }
            catch(System.Exception error) { MessageBox.Show(error.Message); }
        }

        private void Calculate3ButtonClick(object sender, EventArgs args)
        {
            this.graph_chart3.Series.Clear();
            var series = new Charting::Series(this.chart3_textbox.Text)
            {
                ChartType = Charting::SeriesChartType.Spline,
                Color = this.chartcolor3_button.BackColor,
                BorderWidth = 2
            };
            foreach (var item in this.LabLogic.CalculateTask3())
            {
                series.Points.Add();
            }
            this.graph_chart3.Series.Add(series);
        }
    }
}
