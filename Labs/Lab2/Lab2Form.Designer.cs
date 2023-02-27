namespace TheoryInfoProcess.Labs.Lab2
{
    public partial class Lab2Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.exp1_color_button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.segments1_numeric = new System.Windows.Forms.NumericUpDown();
            this.exp1_textbox = new System.Windows.Forms.TextBox();
            this.calctask1_button = new System.Windows.Forms.Button();
            this.graph_chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.exp2_textbox = new System.Windows.Forms.TextBox();
            this.exp2_color_button = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.segments2_numeric = new System.Windows.Forms.NumericUpDown();
            this.calctask2_button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.graph_chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.segments1_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph_chart1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.segments2_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph_chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(640, 437);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.exp1_color_button);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.segments1_numeric);
            this.tabPage1.Controls.Add(this.exp1_textbox);
            this.tabPage1.Controls.Add(this.calctask1_button);
            this.tabPage1.Controls.Add(this.graph_chart1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(632, 411);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Задание 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // exp1_color_button
            // 
            this.exp1_color_button.BackColor = System.Drawing.Color.SteelBlue;
            this.exp1_color_button.Location = new System.Drawing.Point(352, 316);
            this.exp1_color_button.Name = "exp1_color_button";
            this.exp1_color_button.Size = new System.Drawing.Size(31, 26);
            this.exp1_color_button.TabIndex = 16;
            this.exp1_color_button.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(15, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Датчик случайной величины:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(15, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Число отчетов:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(195, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Имя графика:";
            // 
            // segments1_numeric
            // 
            this.segments1_numeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.segments1_numeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.segments1_numeric.Location = new System.Drawing.Point(18, 316);
            this.segments1_numeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.segments1_numeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.segments1_numeric.Name = "segments1_numeric";
            this.segments1_numeric.Size = new System.Drawing.Size(120, 26);
            this.segments1_numeric.TabIndex = 7;
            this.segments1_numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.segments1_numeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // exp1_textbox
            // 
            this.exp1_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.exp1_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exp1_textbox.Location = new System.Drawing.Point(198, 316);
            this.exp1_textbox.Name = "exp1_textbox";
            this.exp1_textbox.Size = new System.Drawing.Size(126, 26);
            this.exp1_textbox.TabIndex = 5;
            // 
            // calctask1_button
            // 
            this.calctask1_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calctask1_button.Location = new System.Drawing.Point(498, 359);
            this.calctask1_button.Name = "calctask1_button";
            this.calctask1_button.Size = new System.Drawing.Size(120, 36);
            this.calctask1_button.TabIndex = 2;
            this.calctask1_button.Text = "Вычислить";
            this.calctask1_button.UseVisualStyleBackColor = true;
            // 
            // graph_chart1
            // 
            this.graph_chart1.BorderlineColor = System.Drawing.Color.Linen;
            chartArea1.Name = "ChartArea1";
            this.graph_chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.graph_chart1.Legends.Add(legend1);
            this.graph_chart1.Location = new System.Drawing.Point(18, 30);
            this.graph_chart1.Name = "graph_chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.graph_chart1.Series.Add(series1);
            this.graph_chart1.Size = new System.Drawing.Size(600, 265);
            this.graph_chart1.TabIndex = 1;
            this.graph_chart1.Text = "Датчик случайной величины";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.exp2_textbox);
            this.tabPage2.Controls.Add(this.exp2_color_button);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.segments2_numeric);
            this.tabPage2.Controls.Add(this.calctask2_button);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.graph_chart2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(632, 411);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Задание 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(193, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Имя графика:";
            // 
            // exp2_textbox
            // 
            this.exp2_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.exp2_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exp2_textbox.Location = new System.Drawing.Point(198, 316);
            this.exp2_textbox.Name = "exp2_textbox";
            this.exp2_textbox.Size = new System.Drawing.Size(126, 26);
            this.exp2_textbox.TabIndex = 19;
            // 
            // exp2_color_button
            // 
            this.exp2_color_button.BackColor = System.Drawing.Color.Tomato;
            this.exp2_color_button.Location = new System.Drawing.Point(352, 316);
            this.exp2_color_button.Name = "exp2_color_button";
            this.exp2_color_button.Size = new System.Drawing.Size(31, 26);
            this.exp2_color_button.TabIndex = 18;
            this.exp2_color_button.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(15, 298);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Число эксперементов:";
            // 
            // segments2_numeric
            // 
            this.segments2_numeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.segments2_numeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.segments2_numeric.Location = new System.Drawing.Point(18, 316);
            this.segments2_numeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.segments2_numeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.segments2_numeric.Name = "segments2_numeric";
            this.segments2_numeric.Size = new System.Drawing.Size(122, 26);
            this.segments2_numeric.TabIndex = 16;
            this.segments2_numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.segments2_numeric.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // calctask2_button
            // 
            this.calctask2_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calctask2_button.Location = new System.Drawing.Point(498, 359);
            this.calctask2_button.Name = "calctask2_button";
            this.calctask2_button.Size = new System.Drawing.Size(120, 36);
            this.calctask2_button.TabIndex = 15;
            this.calctask2_button.Text = "Вычислить";
            this.calctask2_button.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(15, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Датчик случайной величины:";
            // 
            // graph_chart2
            // 
            this.graph_chart2.BorderlineColor = System.Drawing.Color.Linen;
            chartArea2.Name = "ChartArea1";
            this.graph_chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.graph_chart2.Legends.Add(legend2);
            this.graph_chart2.Location = new System.Drawing.Point(18, 30);
            this.graph_chart2.Name = "graph_chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.graph_chart2.Series.Add(series2);
            this.graph_chart2.Size = new System.Drawing.Size(600, 265);
            this.graph_chart2.TabIndex = 2;
            this.graph_chart2.Text = "Датчик случайной величины";
            // 
            // Lab2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 461);
            this.Controls.Add(this.tabControl1);
            this.MaximumSize = new System.Drawing.Size(680, 500);
            this.MinimumSize = new System.Drawing.Size(680, 500);
            this.Name = "Lab2Form";
            this.Text = "Лабораторная работа 1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.segments1_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph_chart1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.segments2_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph_chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart graph_chart1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox exp1_textbox;
        private System.Windows.Forms.Button calctask1_button;
        private System.Windows.Forms.Button exp1_color_button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart graph_chart2;
        private System.Windows.Forms.Button calctask2_button;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown segments2_numeric;
        private System.Windows.Forms.Button exp2_color_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown segments1_numeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox exp2_textbox;
    }
}