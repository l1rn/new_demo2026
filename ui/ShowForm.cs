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

namespace demonewkakaxi.ui
{
    public partial class ShowForm : Form
    {
        public ShowForm()
        {
            InitializeComponent();
            LoadForm();
        }

        private void ShowForm_Load(object sender, EventArgs e)
        {
            panel2.AutoScroll = true;
            label1.Text = $"{CurrentUser.Name}";
        }
        private void LoadForm()
        {

            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    panel2.Controls.Clear();
                    int y = 10;
                    int space = 10;
                    foreach (var product in db.Products.ToList())
                    {
                        ProductCard card = new ProductCard(product);
                        card.Size = new Size(panel2.Width - 100, card.Height);
                        card.Location = new Point(10, y);
                        card.ProductDeleted += (deletedProduct) =>
                        {
                            LoadForm();
                        };
                        panel2.Controls.Add(card);
                        y += card.Height + space;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
