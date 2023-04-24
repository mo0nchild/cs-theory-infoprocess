using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheoryInfoProcess.Labs.Lab5
{
    public partial class Lab5Form : Form
    {
        public readonly Lab5Logic labLogic = new Lab5Logic();
        public Lab5Form()
        {
            this.InitializeComponent();
            this.calculate1_button.Click += new EventHandler(this.Calculate1_button_Click);
            this.Calculate1_button_Click(this, EventArgs.Empty);
        }

        private void Calculate1_button_Click(object sender, EventArgs args)
        {
            this.listView1.Items.Clear();
            var task_result1 = this.labLogic.CalculateTask1(22);

            for(int index = 0; index < task_result1.TK.Length; index++)
            {
                var row_value = new string[] {
                    task_result1.RI[index].ToString(),
                    task_result1.ZI[index].ToString(),
                    task_result1.TK[index].ToString() 
                };
                this.listView1.Items.Add(new ListViewItem(row_value));
            }
            //xd
            var interval = default(int);
            this.listView2.Items.Clear();

            var task_result2 = this.labLogic.CalculateTask2(22, task_result1.TK);
            foreach (var item in task_result2.XT)
            {
                var row_value = new string[] { (++interval).ToString(), item.ToString() };
                this.listView2.Items.Add(new ListViewItem(row_value));
            }
            interval = default(int);
            this.listView3.Items.Clear();

            foreach (var item in task_result2.NK)
            {
                var row_value = new string[] { (interval++).ToString(), item.ToString() };
                this.listView3.Items.Add(new ListViewItem(row_value));
            }
            this.chart1_textbox.Text = string.Format("{0:F6}", task_result2.Lambda);

            var task_result3 = this.labLogic.CalculateTask3(task_result1.Lambda, 
                task_result1.TValues, task_result1.ZI);

            var task_result4 = this.labLogic.CalculateTask3(task_result2.Lambda,
                task_result1.TValues, task_result1.ZI);

            Console.WriteLine(task_result2.Lambda);

            label4.Text = $"Вероятность отсутствия P0: {task_result3[0]}";
            label5.Text = $"Вероятность P1: {task_result3[1]}";
            label6.Text = $"Вероятность P4: {task_result3[2]}";
            label7.Text = $"Вероятность P>=5: {task_result3[3]}";
            label8.Text = $"Вероятность P<3: {task_result3[4]}";
            label9.Text = $"Вероятность P<=7: {task_result3[5]}";
            label10.Text = $"Вероятность Pzk: {task_result3[6]}";

            label17.Text = $"Вероятность отсутствия P0: {task_result4[0]}";
            label12.Text = $"Вероятность P1: {task_result4[1]}";
            label13.Text = $"Вероятность P4: {task_result4[2]}";
            label14.Text = $"Вероятность P>=5: {task_result4[3]}";
            label15.Text = $"Вероятность P<3: {task_result4[4]}";
            label16.Text = $"Вероятность P<=7: {task_result4[5]}";
            label11.Text = $"Вероятность Pzk: {task_result4[6]}";
        }
    }
}