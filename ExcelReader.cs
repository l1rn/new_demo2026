using demonewkakaxi.core;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demonewkakaxi
{
    internal class ExcelReader
    {
        public void ReadUsers(ApplicationContext db, string excelFile)
        {
            ExcelPackage.License.SetNonCommercialPersonal("adasdsaregrgsertgsertse");
            using var package = new ExcelPackage(new FileInfo(excelFile));
            var worksheet = package.Workbook.Worksheets[0];

            for (int row = 2; row <= worksheet.Dimension.End.Row; row++) {
                var role = worksheet.Cells[row, 1].Text;
                var name = worksheet.Cells[row, 2].Text;
                var login = worksheet.Cells[row, 3].Text;
                var password = worksheet.Cells[row, 4].Text;
                Role roleEnum = Role.USER;
                if (role == "Администратор") roleEnum = Role.ADMIN;
                if (role == "Менеджер") roleEnum = Role.MANAGER;
                if (role == "Авторизированный клиент") roleEnum = Role.USER;
                if(name == "")
                {
                    return;
                }
                User user = new User { 
                    RoleString = roleEnum,
                    Name = name,
                    Email = login,
                    Password = password
                };
                db.Users.Add(user); 
                db.SaveChanges();
            }
        }
        public void ReadLocation(ApplicationContext db, string excelFile) 
        {
            ExcelPackage.License.SetNonCommercialPersonal("adasdsaregrgsertgsertse");
            using var package = new ExcelPackage(new FileInfo(excelFile));
            var worksheet = package.Workbook.Worksheets[0];
            for (int row = 1; row <= worksheet.Dimension.End.Row; row++)
            {
                var location = worksheet.Cells[row, 1].Text;

                PickUpPoint pick = new PickUpPoint { 
                    Name = location,
                };
                db.PickUpPoints.Add(pick);
                db.SaveChanges();
            }
        }
        public void ReadProduct(ApplicationContext db, string excelFile)
        {
            ExcelPackage.License.SetNonCommercialPersonal("adasdsaregrgsertgsertse");
            using var package = new ExcelPackage(new FileInfo(excelFile));
            var worksheet = package.Workbook.Worksheets[0];
            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var article = worksheet.Cells[row, 1].Text;
                var name = worksheet.Cells[row, 2].Text;
                var unit = worksheet.Cells[row, 3].Text;
                var price  = worksheet.Cells[row, 4].Text;
                var seller = worksheet.Cells[row, 5].Text;
                var manifacture = worksheet.Cells[row, 6].Text;
                var category = worksheet.Cells[row, 7].Text;
                var discount = worksheet.Cells[row, 8].Text;
                var quantity = worksheet.Cells[row, 9].Text;
                var desc = worksheet.Cells[row, 10].Text;
                var photoPath = worksheet.Cells[row, 11].Text;

                Product product = new Product
                {
                    Article = article,
                    Title = name,
                    UnitMeasurement = unit,
                    Price = float.Parse(price),
                    SellerCompany = seller,
                    ManufactureCompany = manifacture,
                    ProductCategory = category,
                    Discount = float.Parse(discount),
                    QuantityInStorage = float.Parse(quantity),
                    Description = desc,
                    PhotoPath = photoPath,
                };

                db.Products.Add(product);
                db.SaveChanges();
            }
        }
        public void ReadOrder(ApplicationContext db, string excelFile)
        {
            ExcelPackage.License.SetNonCommercialPersonal("adasdsaregrgsertgsertse");
            using var package = new ExcelPackage(new FileInfo(excelFile));
            var worksheet = package.Workbook.Worksheets[0];
            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var article = worksheet.Cells[row, 2].Text;
                var date = worksheet.Cells[row, 3].Text;
                var arriveDate = worksheet.Cells[row, 4].Text;
                var idPickUpPoint = worksheet.Cells[row, 5].Text;
                var nameUser = worksheet.Cells[row, 6].Text;
                var code = worksheet.Cells[row, 7].Text;
                var status = worksheet.Cells[row, 8].Text;

                string[] parts = article.Split(',');

                for(int i = 0; i < parts.Length; i++)
                {
                    parts[i] = parts[i].Trim();
                }
    
                Guid guid = Guid.NewGuid();
                int orderNumber = 1;
                for(int i = 0; i < parts.Length; i += 2)
                {
                    if(i + 1  < parts.Length)
                    {
                        string articleValue = parts[i];
                        string quantityArticle = parts[i + 1];
                        
                        Order order = new Order
                        {
                            Article = articleValue,
                            Quantity = int.Parse(quantityArticle),
                            DateOrder = date,
                            ArriveDate = arriveDate,
                            PickUpPointId = int.Parse(idPickUpPoint),
                            UserId = db.Users.FirstOrDefault(u => u.Name == nameUser).Id,
                            CodeToConfirmOrder = code,
                            Status = status,
                            User = db.Users.FirstOrDefault(u => u.Name == nameUser),
                            PickUpPoint = db.PickUpPoints.Find(int.Parse(idPickUpPoint)),
                            Product = db.Products.FirstOrDefault(p => p.Article == articleValue),
                            OrderGroupId = guid,
                            OrderNumber = orderNumber
                        };

                        orderNumber++;
                        db.Orders.Add(order);
                    }
                }
            }
            db.SaveChanges();

        }
    }
}
