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
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace demonewkakaxi.ui
{
    public partial class EditFormOrder : Form
    {
        private string _article;
        public bool DataUpdate { get; set; } = false;
        public EditFormOrder(string article)
        {
            InitializeComponent();
            _article = article;
            LoadForm();
        }

        private void EditFormOrder_Load(object sender, EventArgs e)
        {
            label1.Text = CurrentUser.Name;
            label2.Text = "Артикул";
            label3.Text = "Количество";
            label4.Text = "Дата заказа";
            label5.Text = "Дата поставки";
            label6.Text = "Адрес ПВЗ";
            label7.Text = "Пользователь";
            label8.Text = "Код для подтверждения заказа";
            label9.Text = "Статус";
            comboBox5.Items.Add("Новый");
            comboBox5.Items.Add("Завершен");
        }

        private void LoadForm()
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    comboBox1.Items.Clear();
                    comboBox3.Items.Clear();
                    comboBox4.Items.Clear();

                    comboBox1.Items.AddRange(db.Products.Select(p => p.Article).ToArray());
                    comboBox3.Items.AddRange(db.PickUpPoints.Select(p => p.Name).ToArray());
                    comboBox4.Items.AddRange(db.Users.Select(u => u.Name).ToArray());

                    var order = db.Orders.Where(o => o.Article == _article).FirstOrDefault();

                    comboBox1.Text = order.Article;
                    textBox1.Text = order.Quantity.ToString();
                    textBox2.Text = order.CodeToConfirmOrder;
                    comboBox3.Text = db.PickUpPoints.Find(order.PickUpPointId).Name;
                    comboBox4.Text = db.Users.Find(order.UserId).Name;
                    comboBox5.Text = order.Status;

                    dateTimePicker1.Value = DateTime.Parse(order.DateOrder);
                    dateTimePicker2.Value = DateTime.Parse(order.ArriveDate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    if (!int.TryParse(textBox1.Text, out int q))
                    {
                        MessageBox.Show("Поле количество int!");
                        return;
                    }

                    var order = db.Orders.FirstOrDefault(o => o.Article == _article);

                    order.Article = comboBox1.Text;
                    order.Quantity = q;
                    order.DateOrder = dateTimePicker1.Value.ToString();
                    order.ArriveDate = dateTimePicker2.Value.ToString();
                    order.PickUpPointId = db.PickUpPoints.Where(p => p.Name == comboBox3.Text).FirstOrDefault().Id;
                    order.UserId = db.Users.Where(u => u.Name == comboBox4.Text).FirstOrDefault().Id;
                    order.CodeToConfirmOrder = textBox2.Text;
                    order.Status = comboBox5.Text;
                    order.Product = db.Products.Where(p => p.Article == comboBox1.Text).FirstOrDefault();

                    db.SaveChanges();
                    MessageBox.Show("Товар успешно изменен!");
                    this.DialogResult = DialogResult.OK;
                    DataUpdate = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
