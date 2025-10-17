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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace demonewkakaxi.ui
{
    public partial class OrderCard : UserControl
    {
        private int _orderId { get; set; }
        public event Action<OrderCard> OrderDeleted;
        private string _article;
        public OrderCard(OrderLoadData data)
        {
            InitializeComponent();
            LoadCard(data);
        }

        private void LoadCard(OrderLoadData data)
        {
            label1.Text = data.Article;
            label2.Text = data.Status;
            label3.Text = data.Address;
            label4.Text = data.DateOrder;
            label5.Text = data.ArriveDate;
            
            _article = data.Article;
            _orderId = data.OrderId;
        }

        private void OrderCard_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#7FFF00");
            panel1.BackColor = ColorTranslator.FromHtml("#7FFF00");
            panel2.BackColor = ColorTranslator.FromHtml("#7FFF00");
            if(CurrentUser.Role != Role.ADMIN)
            {
                button1.Visible = false;
                button2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var order = db.Orders.Find(_orderId);

                    db.Orders.Remove(order);
                    db.SaveChanges();
                    OrderDeleted.Invoke(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(var editForm = new EditFormOrder(_article))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    if (editForm.DataUpdate == true)
                    {
                        try
                        {
                           using(ApplicationContext db = new ApplicationContext())
                            {
                                var firstOrder = db.Orders.Find(_orderId);
                                if (firstOrder != null)
                                {
                                    var ordersInGroup = db.Orders
                                        .Where(o => o.OrderGroupId == firstOrder.OrderGroupId)
                                        .ToList();
                                    label1.Text = string.Join(", ", ordersInGroup.Select(o => $"{o.Article} x{o.Quantity}"));
                                    label2.Text = ordersInGroup.First().Status;
                                    label3.Text = db.PickUpPoints.Find(ordersInGroup.First().PickUpPointId)?.Name ?? "Не указан";
                                    label4.Text = ordersInGroup.First().DateOrder;
                                    label5.Text = ordersInGroup.First().ArriveDate;
                                }
                            }
                        }
                        catch (Exception ex) { 
                        
                        }
                    }
                }
            }
        }
    }
}
