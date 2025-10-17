using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using demonewkakaxi.core;
using demonewkakaxi.ui;

namespace demonewkakaxi
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            label1.Text = $"{CurrentUser.Name}";
            button1.Visible = false;
            panel4.Visible = false;
            button3.Visible = false;

            if (CurrentUser.Role == Role.ADMIN)
            {
                button1.Visible = true;
                button3.Visible = true;
            }

            if(CurrentUser.Role == Role.MANAGER || CurrentUser.Role == Role.ADMIN)
            {
                panel4.Visible = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowForm showForm = new ShowForm();
            showForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddFormOrder addFormOrder = new AddFormOrder();
            addFormOrder.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowFormOrder showFormOrder = new ShowFormOrder();
            showFormOrder.Show();
        }
    }
}
