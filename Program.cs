namespace demonewkakaxi
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            try
            {
                using (ApplicationContext db = new ApplicationContext()) {
                    ExcelReader reader = new ExcelReader();

                    if (db.Users.Count() == 0)
                    {
                        reader.ReadUsers(db, "D:\\students\\new_gen_ip402\\Таксатов\\demonewkakaxi\\data\\user_import.xlsx");
                    }
                    if (db.PickUpPoints.Count() == 0)
                    {
                        reader.ReadLocation(db, "D:\\students\\new_gen_ip402\\Таксатов\\demonewkakaxi\\data\\Пункты выдачи_import.xlsx");
                    }
                    if (db.Products.Count() == 0)
                    {
                        reader.ReadProduct(db, "D:\\students\\new_gen_ip402\\Таксатов\\demonewkakaxi\\data\\Tovar.xlsx");
                    }
                    if (db.Orders.Count() == 0)
                    {

                    }
                    reader.ReadOrder(db, "D:\\students\\new_gen_ip402\\Таксатов\\demonewkakaxi\\data\\Заказ_import.xlsx");

                    MessageBox.Show("дб подключено");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            Application.Run(new LoginForm());
        }
    }
}