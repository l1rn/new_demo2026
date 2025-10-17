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
    public partial class EditForm : Form
    {
        public float oldPrice { get; set; }
        public bool DataUpdate { get; set; } = false;
        private int _productId { get; set; }
        public EditForm(int productId)
        {
            InitializeComponent();
            _productId = productId;
            LoadForm();
        }

        private void EditForm_Load(object sender, EventArgs e)
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

        private void LoadForm()
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var product = db.Products.Find(_productId);
                    if (product == null)
                    {
                        return;
                    }

                    textBox1.Text = product.Article;
                    textBox2.Text = product.Title;
                    textBox3.Text = product.UnitMeasurement;
                    textBox4.Text = product.Price.ToString();
                    textBox5.Text = product.SellerCompany;
                    textBox6.Text = product.ManufactureCompany;
                    comboBox1.Text = product.ProductCategory;
                    textBox7.Text = product.Description;
                    textBox8.Text = product.Discount.ToString();
                    textBox9.Text = product.QuantityInStorage.ToString();

                    oldPrice = product.Price;
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
                    var product = db.Products.Find(_productId);
                    if (product == null)
                    {
                        return;
                    }

                    if (!float.TryParse(textBox4.Text, out float price))
                    {
                        MessageBox.Show("Поле цена float!");
                        return;
                    }

                    if (!float.TryParse(textBox8.Text, out float discount))
                    {
                        MessageBox.Show("Поле цена float!");
                        return;
                    }

                    if (!float.TryParse(textBox9.Text, out float quantityInStorage))
                    {
                        MessageBox.Show("Поле цена float!");
                        return;
                    }

                    product.Article = textBox1.Text;
                    product.Title = textBox2.Text;
                    product.UnitMeasurement = textBox3.Text;
                    product.Price = price;
                    product.SellerCompany = textBox5.Text;
                    product.ManufactureCompany = textBox6.Text;
                    product.ProductCategory = comboBox1.Text;
                    product.Description = textBox7.Text;
                    product.Discount = discount;
                    product.QuantityInStorage = quantityInStorage;

                    db.SaveChanges();
                    this.DialogResult = DialogResult.OK;
                    DataUpdate = true;
                    MessageBox.Show("Изменения успешно применены!");
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
