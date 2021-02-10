using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMM_Lab1
{
    public partial class Form1 : Form
    {

        private int day = 0;

        Dictionary<CheckBox, Cell> field = new Dictionary<CheckBox, Cell>();
        Game farm = new Game(10);
        public Form1()
        {
            InitializeComponent();
            label_bal.Text = "Баланс: " + farm.get_balance();
            foreach (CheckBox cb in tableLayoutPanel1.Controls)
            {
                field.Add(cb, new Cell()); UpdateBox(cb);
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (sender as CheckBox);
            if (cb.Checked) Plant(cb);
            else Harvest(cb);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (CheckBox cb in tableLayoutPanel1.Controls)
                NextStep(cb);
            day++;
            label_date.Text = "День: " + day;
        }

        private void Plant(CheckBox cb)
        {
            if (farm.Plant())
            {
                field[cb].Plant();
                UpdateBox(cb);
                label_err.Text = "";
            }
            else
            {
                cb.Checked = false;
                label_err.Text = "Не хватает денег";
            }
            label_bal.Text = "Баланс: " + farm.get_balance();
        }

        private void Harvest(CheckBox cb)
        {
            if (farm.Harvest(field[cb]))
            {
                field[cb].Harvest();
                UpdateBox(cb);
                label_err.Text = "";
            }
            else
            {
                cb.Checked = false;
                label_err.Text = "Не хватает денег";
            }
            label_bal.Text = "Баланс: " + farm.get_balance();
        }

        private void NextStep(CheckBox cb)
        {
            field[cb].NextStep();
            UpdateBox(cb);
        }

        private void UpdateBox(CheckBox cb)
        {
            Color c = Color.White;
            switch (field[cb].state)
            {
                case CellState.Planted:
                    c = Color.Black;
                    break;
                case CellState.Green:
                    c = Color.Green;
                    break;
                case CellState.Immature:
                    c = Color.Yellow;
                    break;
                case CellState.Mature:
                    c = Color.Red;
                    break;
                case CellState.Overgrown:
                    c = Color.Brown;
                    break;
            }
            cb.BackColor = c;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000 / 8;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000 * 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000 / 2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000 / 4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled) timer1.Enabled = false;
            else timer1.Enabled = true;
        }
    }
}
