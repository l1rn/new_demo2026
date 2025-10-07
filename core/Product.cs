using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demonewkakaxi.core
{
    public class Product
    {
        public int Id { get; set; }
        public string Article { get; set; }
        public string Title { get; set; }
        public string UnitMeasurement { get; set; }
        public double Price { get; set; }
        public string SellerCompany { get; set; }
        public string ManufactureCompany { get; set; }
        public string ProductCategory { get; set; }
        public double Discount { get; set; }
        public double QuantityInStorage { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }

    }
}
