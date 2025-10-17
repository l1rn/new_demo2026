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
    public partial class ShowFormOrder : Form
    {
        public ShowFormOrder()
        {
            InitializeComponent();
            LoadForm();
        }

        private void ShowFormOrder_Load(object sender, EventArgs e)
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

                    foreach (var order in db.Orders.ToList())
                    {
                        OrderLoadData data = new OrderLoadData
                        {
                            Article = order.Article,
                            Status = order.Status,
                            Address = db.PickUpPoints.Find(order.PickUpPointId).Name,
                            DateOrder = order.DateOrder,
                            ArriveDate = order.ArriveDate,
                            Order = order
                        };
                        OrderCard card = new OrderCard(data);
                        card.Size = new Size(panel2.Width - 100, card.Height);
                        card.Location = new Point(10, y);
                        card.OrderDeleted += (deletedProduct) =>
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
    }
}
