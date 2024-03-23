using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace UKD_OOP_TimeTracker
{
    public partial class Form1 : Form
    {
        static string workType;
        Timer mainTimer = new Timer()
        {
            Interval = 1000
        };
        static int mainTimeElapsed = 0;
        static int workTimeElapsed = 0;
        static int restTimeElapsed = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainTimer.Tick += new System.EventHandler(OnTick);
        }

        private void OnTick(object source, EventArgs e)
        {
            mainTimeElapsed++;
            label3.Text = $"{ (mainTimeElapsed / 3600):00}:{ (mainTimeElapsed % 3600 / 60):00}:{ (mainTimeElapsed % 60):00}";
            if (workType == "Робота")
            {
                workTimeElapsed++;
                label1.Text = $"Робота : { (workTimeElapsed / 3600):00}:{ (workTimeElapsed % 3600 / 60):00}:{ (workTimeElapsed % 60):00}"; ;
            }
            else if (workType == "Відпочинок")
            {
                restTimeElapsed++;
                label2.Text = $"Відпочинок : { (restTimeElapsed / 3600):00}:{ (restTimeElapsed % 3600 / 60):00}:{ (restTimeElapsed % 60):00}"; ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (workType == null)
            {
                MessageBox.Show("Тип не обраний", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                mainTimer.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainTimer.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainTimer.Enabled = false;
            if (mainTimeElapsed != 0)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = workType;
                row.Cells[1].Value = $"{(mainTimeElapsed / 3600):00}:{(mainTimeElapsed % 3600 / 60):00}:{(mainTimeElapsed % 60):00}";
                dataGridView1.Rows.Insert(0, row);
                
                mainTimeElapsed = 0;
                label3.Text = $"{(mainTimeElapsed/3600):00}:{(mainTimeElapsed%3600/60):00}:{(mainTimeElapsed%60):00}";
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.PerformClick();
            workType = comboBox1.GetItemText(comboBox1.SelectedItem);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
