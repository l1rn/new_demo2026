using demonewkakaxi.core;
using Microsoft.VisualBasic.ApplicationServices;

namespace demonewkakaxi
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Email == textBox1.Text);
                    if (user == null)
                    {
                        MessageBox.Show("Такого пользователя не существует");
                        return;
                    }

                    if (user.Password != textBox2.Text)
                    {
                        MessageBox.Show("Пароли не совпадают");
                        return;
                    }

                    MessageBox.Show($"Поздравляю, вы зашли за {user.RoleString}");

                    CurrentUser.Id = user.Id;
                    CurrentUser.Email = user.Email;
                    CurrentUser.Role = user.RoleString;
                    CurrentUser.Name = user.Name;
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CurrentUser.Id = -1;
            CurrentUser.Email = "guest";
            CurrentUser.Name = "Режим гостя";
            CurrentUser.Role = Role.GUEST;
            MainForm main = new MainForm();
            main.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
