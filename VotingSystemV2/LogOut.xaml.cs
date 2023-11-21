using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

    public partial class LogOut : Window
    {
        public LogOut(string selectedPresident,string selectedVPresident,string selectedSenator)
        {
            InitializeComponent();
            setCandName(selectedPresident, selectedVPresident, selectedSenator);
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateVoteCount();
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void setCandName(string presName, string vpresName, string senaName)
        {
            presla.Content = presName;
            vpresla.Content = vpresName;
            senla.Content = senaName;
        }

        private void UpdateVoteCount()
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jason User\Documents\VotingSystemV2\VotingSystemV2\LogInDB.mdf;Integrated Security=True";
            string sqlUpdatePresident = "UPDATE Presidents SET VoteCount = VoteCount + 1 WHERE Candidates = @SelectedPresident";
            string sqlUpdateVicePresident = "UPDATE VicePresidents SET VoteCount = VoteCount + 1 WHERE Candidates = @SelectedVicePresident";
            string sqlUpdateSenator = "UPDATE Senators SET VoteCount = VoteCount + 1 WHERE Candidates = @SelectedSenator";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlUpdatePresident, connection))
                {
                    command.Parameters.AddWithValue("@SelectedPresident", presla.Content);
                    int rowsAffectedPresident = command.ExecuteNonQuery();
                }

                using (SqlCommand command = new SqlCommand(sqlUpdateVicePresident, connection))
                {
                    command.Parameters.AddWithValue("@SelectedVicePresident", vpresla.Content);
                    int rowsAffectedVicePresident = command.ExecuteNonQuery();
                }

                using (SqlCommand command = new SqlCommand(sqlUpdateSenator, connection))
                {
                    command.Parameters.AddWithValue("@SelectedSenator", senla.Content);
                    int rowsAffectedSenator = command.ExecuteNonQuery();
                }
            }
        }
    }
}
