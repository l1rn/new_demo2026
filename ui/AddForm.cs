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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            label2.Text = "Артикул";
            label3.Text = "Наименование товара";
            label4.Text = "Единица измерения";
            label5.Text = "Цена";
            label6.Text = "Поставщик";
            label7.Text = "Производитель";
            label8.Text = "Категория товара";
            label9.Text = "Действующая скидка";
            label10.Text = "Кол-во на складе";
            label11.Text = "Описание товара";

            comboBox1.Items.Add("Мужская обувь");
            comboBox1.Items.Add("Женская обувь");

            label1.Text = CurrentUser.Name;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext()) {
                    if(!float.TryParse(textBox4.Text, out float price))
                    {
                        MessageBox.Show("Поле цена float!");
                        return;
                    }

                    if(!float.TryParse(textBox8.Text, out float discount))
                    {
                        MessageBox.Show("Поле цена float!");
                        return;
                    }

                    if (!float.TryParse(textBox9.Text, out float quantityInStorage))
                    {
                        MessageBox.Show("Поле цена float!");
                        return;
                    }

                    Product product = new Product
                    {
                        Article = textBox1.Text,
                        Title = textBox2.Text,
                        UnitMeasurement = textBox3.Text,
                        Price = price,
                        SellerCompany = textBox5.Text,
                        ManufactureCompany = textBox6.Text,
                        ProductCategory = comboBox1.Text,
                        Discount = discount,
                        QuantityInStorage = quantityInStorage,  
                        Description = textBox7.Text,
                    };

                    db.Products.Add(product);
                    db.SaveChanges();
                    MessageBox.Show("Продукт успешно добавлен");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }  
        }
    }
}
