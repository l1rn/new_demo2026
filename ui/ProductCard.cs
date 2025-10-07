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
    public partial class ProductCard : UserControl
    {
        private int _productId {  get; set; }
        private string _productArticle {  get; set; }
        private Product _product { get; set; }
        public event Action<ProductCard> ProductDeleted;

        public ProductCard(Product product)
        {
            InitializeComponent();
            LoadData(product);
        }

        private void ProductCard_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadData(Product product)
        {
            var name = product.Title;
            var category = product.ProductCategory;
            var desc = product.Description;
            var seller = product.SellerCompany;
            var manifacture = product.ManufactureCompany;
            var price = product.Price;
            var unit = product.UnitMeasurement;
            var quantity = product.QuantityInStorage;
            var photoPath = product.PhotoPath;
            var discount = product.Discount;

            _productId = product.Id;
            _productArticle = product.Article;
            _product = product;

            label1.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
            label2.Font = new Font("Times New Roman", 11f, FontStyle.Bold);

            label1.Text = name;
            label2.Text = category;

            label3.Text = $"Описание товара: {desc}";
            label3.MaximumSize = new Size(200, 30);
            label3.AutoEllipsis = true;

            label4.Text = $"Производитель: {manifacture}";
            label5.Text = $"Поставщик: {seller}";

            label6.Text = $"Цена: {price} р.";
            label7.Text = $"Количество на складе: {quantity} {product.UnitMeasurement}";

            label8.Text = $"Скидка: {discount}%";

            if (photoPath is null || photoPath == "")
            {
                return;
            }
            string imagePath = Path.Combine("assets", photoPath);
            try
            {
                pictureBox1.Image = Image.FromFile(imagePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
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
                    if (product == null) {
                        MessageBox.Show($"Продукт не найден: {_productId}; {_productArticle};");    
                        return; 
                    }

                    db.Products.Remove(product);
                    db.SaveChanges();
                    ProductDeleted?.Invoke(this);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
