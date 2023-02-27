using MathNet.Numerics;
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

namespace TheoryInfoProcess.Labs.Lab2
{
    using Charting = System.Windows.Forms.DataVisualization.Charting;
    public partial class Lab2Form : Form
    {
        private static readonly System.Int32 GraphWidth = 2, N = 500;
        private Lab2Logic Logic { get; set; } = new Lab2Logic(Lab2Form.N);

        public Lab2Form() : base()
        {
            this.InitializeComponent();
            this.exp1_textbox.Text = "График 1"; this.exp2_textbox.Text = "График 2";

            this.exp1_color_button.Click += new EventHandler(ChangeColorHandler);

            this.calctask1_button.Click += new EventHandler(CalculateTask1Handler);
            this.calctask2_button.Click += new EventHandler(CalculateTask2Handler);

            this.CalculateTask1Handler(this, EventArgs.Empty);
            this.CalculateTask2Handler(this, EventArgs.Empty);
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
            var result = (this.Logic = new Lab2Logic((int)this.segments1_numeric.Value))
                .CalculateTask1(2, 5, Math.Log(0.95));

            foreach(var item in result)
            {
                series1.Points.Add(item);
            }
          
            this.graph_chart1.Series.Add(series1);
        }

        private void CalculateTask2Handler(object sender, EventArgs args)
        {
            this.graph_chart2.Series.Clear();
            var series2 = new Charting::Series("График")
            {
                ChartType = Charting::SeriesChartType.FastLine, BorderWidth = Lab2Form.GraphWidth,
                Color = this.exp2_color_button.BackColor,
            };

            var result = (this.Logic = new Lab2Logic((int)this.segments2_numeric.Value))
               .CalculateTask2(1);

            foreach (var item in result) series2.Points.Add(item);

            this.graph_chart2.Series.Add(series2);
        }
    }
}
