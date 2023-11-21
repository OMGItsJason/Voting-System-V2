using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VotingSystemV2
{

    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            UpdateVoteCountLabels();
            UpdateRowCountLabel();
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void UpdateVoteCountLabels()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jason User\Documents\VotingSystemV2\VotingSystemV2\LogInDB.mdf;Integrated Security=True";
            string sqlSelectPresidentsVoteCounts = "SELECT Candidates, VoteCount FROM Presidents";
            string sqlSelectVicePresidentsVoteCounts = "SELECT Candidates, VoteCount FROM VicePresidents";
            string sqlSelectSenatorsVoteCounts = "SELECT Candidates, VoteCount FROM Senators";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                UpdateVoteCountsForCategory(connection, sqlSelectPresidentsVoteCounts);
                UpdateVoteCountsForCategory(connection, sqlSelectVicePresidentsVoteCounts);
                UpdateVoteCountsForCategory(connection, sqlSelectSenatorsVoteCounts);
            }
        }

        private void UpdateVoteCountsForCategory(SqlConnection connection, string sqlQuery)
        {
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string candidateName = reader["Candidates"].ToString();
                        int voteCount = Convert.ToInt32(reader["VoteCount"]);

                        UpdateVoteCountLabel(candidateName, voteCount);
                    }
                }
            }
        }

        private void UpdateVoteCountLabel(string candidateName, int voteCount)
        {
            if (candidateName == "Bongbong Marcos")
            {
                BMC.Content = voteCount.ToString();
            }
            else if (candidateName == "Leni Robredo")
            {
                LRC.Content = voteCount.ToString();
            }
            else if (candidateName == "Manny Pacquiao")
            {
                MPC.Content = voteCount.ToString();
            }
            else if (candidateName == "Isko Moreno")
            {
                IMC.Content = voteCount.ToString();
            }
            else if (candidateName == "Ping Lacson")
            {
                PLC.Content = voteCount.ToString();
            }
            if (candidateName == "Sarah Duterte")
            {
                SDC.Content = voteCount.ToString();
            }
            else if (candidateName == "Kiko Pangilinan")
            {
                KPC.Content = voteCount.ToString();
            }
            else if (candidateName == "Vicente Tito Sotto")
            {
                VTSC.Content = voteCount.ToString();
            }
            else if (candidateName == "Willi Ong")
            {
                WOC.Content = voteCount.ToString();
            }
            else if (candidateName == "Lito Atienza")
            {
                LAC.Content = voteCount.ToString();
            }
            if (candidateName == "Robin Padilla")
            {
                RPC.Content = voteCount.ToString();
            }
            else if (candidateName == "Loren Legarda")
            {
                LLC.Content = voteCount.ToString();
            }
            else if (candidateName == "Raffy Tulfo")
            {
                RTC.Content = voteCount.ToString();
            }
            else if (candidateName == "Win Gatchalian")
            {
                WGC.Content = voteCount.ToString();
            }
            else if (candidateName == "Chiz Escudero")
            {
                CEC.Content = voteCount.ToString();
            }
        }

        private void UpdateRowCountLabel()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jason User\Documents\VotingSystemV2\VotingSystemV2\LogInDB.mdf;Integrated Security=True";
            string sqlRowCountQuery = "SELECT COUNT(*) FROM TableInf"; // Query to count rows

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlRowCountQuery, connection))
                {
                    int rowCount = (int)command.ExecuteScalar();
                    VC.Content = rowCount.ToString(); // Update the VC label content
                }
            }
        }
    }
}
