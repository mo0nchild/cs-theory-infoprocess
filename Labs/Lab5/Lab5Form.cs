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
        }
    }
}