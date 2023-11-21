using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VotingSystemV2
{
    public partial class AdminLogIn : Window
    {

        private const string ValidAdmin = "Admin";
        private const string ValidPass = "2822";

        public AdminLogIn()
        {
            InitializeComponent();
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            string admin = ATB.Text;
            string adminPass = AdminPass.Password;

            if (ValidateLogIn(admin, adminPass))
            {
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Invalid Username And Password. Please Try Again", "Invalid Log In", MessageBoxButton.OK, MessageBoxImage.Error);
                ATB.Clear();
                AdminPass.Clear();
            }
        }

        private bool ValidateLogIn(string uAdmin, string uAdminPass)
        {
            return (uAdmin == ValidAdmin && uAdminPass == ValidPass);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
