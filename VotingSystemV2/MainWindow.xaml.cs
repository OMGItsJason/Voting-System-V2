using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace VotingSystemV2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PCB.IsEnabled = false;
        }

        private void RCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PCB.Items.Clear();

            if (RCB.SelectedItem != null)
            {
                string selectedRegion = ((ComboBoxItem)RCB.SelectedItem).Content.ToString();
                switch (selectedRegion)
                {
                    case "Region I – Ilocos Region":
                        PCB.Items.Add("Ilocos Norte");
                        PCB.Items.Add("Ilocos Sur");
                        PCB.Items.Add("La Union");
                        PCB.Items.Add("Pangasinan");
                        break;
                    case "Region II – Cagayan Valley":
                        PCB.Items.Add("Batanes");
                        PCB.Items.Add("Cagayan");
                        PCB.Items.Add("Nueva Vizcaya");
                        PCB.Items.Add("Isabela");
                        PCB.Items.Add("Quirino");
                        break;
                    case "Region III – Central Luzon":
                        PCB.Items.Add("Bataan");
                        PCB.Items.Add("Bulacan");
                        PCB.Items.Add("Aurora");
                        PCB.Items.Add("Tarlac");
                        PCB.Items.Add("Pampanga");
                        PCB.Items.Add("Zambales");
                        PCB.Items.Add("Nueva Ecija");
                        break;
                    case "NCR - National Capital Region":
                        PCB.Items.Add("Manila");
                        PCB.Items.Add("Quezon City");
                        PCB.Items.Add("Makati");
                        PCB.Items.Add("Las Piñas");
                        PCB.Items.Add("Malabon");
                        PCB.Items.Add("Muntinlupa");
                        PCB.Items.Add("Mandaluyong");
                        PCB.Items.Add("Marikina");
                        PCB.Items.Add("Navotas");
                        PCB.Items.Add("Pasay");
                        PCB.Items.Add("Pasig");
                        PCB.Items.Add("Paranaque");
                        PCB.Items.Add("San Juan");
                        PCB.Items.Add("Valenzuela");
                        PCB.Items.Add("Taguig");
                        break;
                    case "Region IV A- CALBARZON":
                        PCB.Items.Add("Cavite");
                        PCB.Items.Add("Laguna");
                        PCB.Items.Add("Batangas");
                        PCB.Items.Add("Quezon");
                        PCB.Items.Add("Rizal");
                        break;
                    case "Region IV B – MIMAROPA Region":
                        PCB.Items.Add("Occidental Mindoro");
                        PCB.Items.Add("Oriental Mindoro");
                        PCB.Items.Add("Marinduque");
                        PCB.Items.Add("Palawan");
                        PCB.Items.Add("Romblon");
                        break;
                    case "Region V – Bicol Region":
                        PCB.Items.Add("Albay");
                        PCB.Items.Add("Camarines Norte");
                        PCB.Items.Add("Camarines Sur");
                        PCB.Items.Add("Catanduanes");
                        PCB.Items.Add("Sorsogon");
                        PCB.Items.Add("Masbate");
                        break;
                    case "Region VI – Western Visayas":
                        PCB.Items.Add("Aklan");
                        PCB.Items.Add("Antique");
                        PCB.Items.Add("Capiz");
                        PCB.Items.Add("Guimaras");
                        PCB.Items.Add("Iloilo");
                        PCB.Items.Add("Negros Occidental");
                        break;
                    case "Region VII – Central Visayas":
                        PCB.Items.Add("Bohol");
                        PCB.Items.Add("Cebu");
                        PCB.Items.Add("Negros Oriental");
                        PCB.Items.Add("Siquijor");
                        break;
                    case "Region VIII – Eastern Visayas":
                        PCB.Items.Add("Biliran");
                        PCB.Items.Add("Leyte");
                        PCB.Items.Add("Eastern Samar");
                        PCB.Items.Add("Northern Samar");
                        PCB.Items.Add("Samar");
                        PCB.Items.Add("Southern Leyte");
                        break;
                    case "Region IX – Zamboanga Peninsula":
                        PCB.Items.Add("Zamboanga del Norte");
                        PCB.Items.Add("Zamboanga del Sur");
                        PCB.Items.Add("Zamboanga Sibugay");
                        break;
                    case "Region X – Northern Mindanao":
                        PCB.Items.Add("Bukidnon");
                        PCB.Items.Add("Camiguin");
                        PCB.Items.Add("Lanao del Norte");
                        PCB.Items.Add("Misamis Occidental");
                        PCB.Items.Add("Misamis Oriental");
                        break;
                    case "Region XI – Davao Region":
                        PCB.Items.Add("");
                        PCB.Items.Add("Davao de Oro");
                        PCB.Items.Add("Davao del Norte");
                        PCB.Items.Add("Davao Occidental");
                        PCB.Items.Add("Davao Oriental");
                        PCB.Items.Add("Davao del Sur");
                        break;
                    case "Region XII – SOCCSKSARGEN":
                        PCB.Items.Add("Cotabato");
                        PCB.Items.Add("South Cotabato");
                        PCB.Items.Add("Sultan Kudarat");
                        PCB.Items.Add("Sarangani");
                        break;
                    case "Region XIII – Caraga":
                        PCB.Items.Add("Agusan del Norte");
                        PCB.Items.Add("Agusan del Sur");
                        PCB.Items.Add("Dinagat Isands");
                        PCB.Items.Add("Surigao del Sur");
                        PCB.Items.Add("Surigao del Norte");
                        break;
                    case "CAR – Cordillera Administrative Region":
                        PCB.Items.Add("Abra");
                        PCB.Items.Add("Apayao");
                        PCB.Items.Add("Ifugao");
                        PCB.Items.Add("Benguet");
                        PCB.Items.Add("Mountain Province");
                        PCB.Items.Add("Kalinga");
                        break;
                    case "BARMM – Bangsamoro Autonomous Region In Muslim Mindanao":
                        PCB.Items.Add("Basilan");
                        PCB.Items.Add("Lanao del Sur");
                        PCB.Items.Add("Maguindanao");
                        PCB.Items.Add("Sulu");
                        PCB.Items.Add("Tawi-tawi");
                        break;
                }
                PCB.IsEnabled = true;
            }
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FNTB.Text) || string.IsNullOrEmpty(LNTB.Text) || string.IsNullOrEmpty(MNTB.Text) || string.IsNullOrEmpty(RCB.Text) || string.IsNullOrEmpty(PCB.Text))
            {
                MessageBox.Show("Fill Up The Information","Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jason User\Documents\VotingSystemV2\VotingSystemV2\LogInDB.mdf;Integrated Security=True";
            string checkDuplicateSql = "SELECT COUNT(*) FROM TableInf WHERE FirstName = @FirstName AND LastName = @LastName AND MiddleName = @MiddleName AND Region = @Region AND ProvinceCity = @ProvinceCity";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand commandCheckDuplicate = new SqlCommand(checkDuplicateSql, sqlConnection))
                {
                    commandCheckDuplicate.Parameters.AddWithValue("@FirstName", FNTB.Text);
                    commandCheckDuplicate.Parameters.AddWithValue("@LastName", LNTB.Text);
                    commandCheckDuplicate.Parameters.AddWithValue("@MiddleName", MNTB.Text);
                    commandCheckDuplicate.Parameters.AddWithValue("@Region", RCB.Text);
                    commandCheckDuplicate.Parameters.AddWithValue("@ProvinceCity", PCB.Text);

                    int duplicateCount = (int)commandCheckDuplicate.ExecuteScalar();

                    if (duplicateCount > 0)
                    {
                        MessageBox.Show("You May Only Vote Once.","Once",MessageBoxButton.OK,MessageBoxImage.Warning);
                        FNTB.Clear();
                        LNTB.Clear();
                        MNTB.Clear();
                        RCB.SelectedIndex = -1;
                        PCB.SelectedIndex = -1;
                        PCB.IsEnabled = false;
                        return;
                    }
                }

                string sql = "INSERT INTO TableInf (FirstName, LastName, MiddleName, Region, ProvinceCity) VALUES (@FirstName, @LastName, @MiddleName, @Region, @ProvinceCity)";

                using (SqlCommand command = new SqlCommand(sql, sqlConnection))
                {
                    command.Parameters.AddWithValue("@FirstName", FNTB.Text);
                    command.Parameters.AddWithValue("@LastName", LNTB.Text);
                    command.Parameters.AddWithValue("@MiddleName", MNTB.Text);
                    command.Parameters.AddWithValue("@Region", RCB.Text);
                    command.Parameters.AddWithValue("@ProvinceCity", PCB.Text);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        VotingForm vf = new VotingForm();
                        vf.ShowDialog();
                        this.Close();
                    }
                }
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            FNTB.Clear();
            LNTB.Clear();
            MNTB.Clear();
            RCB.SelectedIndex = -1;
            PCB.SelectedIndex = -1;
            PCB.IsEnabled = false;
        }

        private void xBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminLogIn adminLogIn = new AdminLogIn();
            var result = adminLogIn.ShowDialog();

            if (result == true)
            {
                Admin ad = new Admin();
                ad.Show();

                this.Close();
                adminLogIn.Close();
            }
        }
    }
}
