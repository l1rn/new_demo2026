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
        public float Price { get; set; }
        public string SellerCompany { get; set; }
        public string ManufactureCompany { get; set; }
        public string ProductCategory { get; set; }
        public float Discount { get; set; }
        public float QuantityInStorage { get; set; }
        public string Description { get; set; }
        public string? PhotoPath { get; set; }
    }
}
