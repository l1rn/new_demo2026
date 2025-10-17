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
    public partial class AddFormOrder : Form
    {
        public AddFormOrder()
        {
            InitializeComponent();
            LoadForm();
        }

        private void AddFormOrder_Load(object sender, EventArgs e)
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
                }
            }
            catch(Exception ex)
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
                    if(!int.TryParse(textBox1.Text, out int q))
                    {
                        MessageBox.Show("Поле количество int!");
                        return;
                    }

                    Order order = new Order { 
                        Article = comboBox1.Text,
                        Quantity = q,
                        DateOrder = dateTimePicker1.Value.ToString(),
                        ArriveDate = dateTimePicker2.Value.ToString(),
                        PickUpPointId = db.PickUpPoints.Where(p => p.Name == comboBox3.Text).FirstOrDefault().Id,
                        UserId = db.Users.Where(u => u.Name == comboBox4.Text).FirstOrDefault().Id,
                        CodeToConfirmOrder = textBox2.Text,
                        Status = comboBox5.Text,
                        Product = db.Products.Where(p => p.Article == comboBox1.Text).FirstOrDefault(),
                    };

                    db.Orders.Add(order);
                    db.SaveChanges();
                    MessageBox.Show("Товар успешно добавлен!");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
