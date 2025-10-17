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
            InitializeFilters();
        }

        private void ShowForm_Load(object sender, EventArgs e)
        {
            panel2.AutoScroll = true;
            label1.Text = $"{CurrentUser.Name}";
            panel3.Visible = false;
            if (CurrentUser.Role == Role.MANAGER || CurrentUser.Role == Role.ADMIN)
            {
                panel3.Visible = true;
            }
        }
        private void LoadForm()
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var allProducts = db.Products.ToList();
                    UpdateForm(allProducts);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitializeFilters()
        {
            comboBox1.Items.Add("Все поставщики");
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var allSellers = db.Products.ToDictionary(p => p.Id, p => p.SellerCompany);
                    var distinctSellers = allSellers.Values.Distinct().OrderBy(s => s).ToList();
                    foreach (var seller in distinctSellers)
                    {
                        comboBox1.Items.Add(seller);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateForm(List<Product> products)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    panel2.Controls.Clear();
                    int y = 10;
                    int space = 10;
                    foreach (var product in products)
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
                    string searchText = textBox1.Text.Trim().ToLower();

                    if (string.IsNullOrEmpty(searchText))
                    {
                        LoadForm();
                        return;
                    }

                    var filteredProducts = db.Products
                .Where(p => p.Title.ToLower().Contains(searchText) ||
                           p.Article.ToLower().Contains(searchText) ||
                           p.SellerCompany.ToLower().Contains(searchText) ||
                           p.ManufactureCompany.ToLower().Contains(searchText) ||
                           p.ProductCategory.ToLower().Contains(searchText) ||
                           p.Description.ToLower().Contains(searchText))
                .ToList();
                    UpdateForm(filteredProducts);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    string fitlerText = comboBox1.Text;

                    if (string.IsNullOrEmpty(fitlerText))
                    {
                        LoadForm();
                        return;
                    }

                    if(fitlerText == "Все поставщики")
                    {
                        LoadForm();
                        return;
                    }
                    
                    var filteredProducts = db.Products.Where(p => p.SellerCompany == fitlerText).ToList();
                    UpdateForm(filteredProducts);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
