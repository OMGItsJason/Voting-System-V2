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
    public partial class VotingForm : Window
    {
        public VotingForm()
        {
            InitializeComponent();

            Presdients = new List<RadioButton> { BMRB, LRRB, MPRB, IMRB, PLRB };
            VPresidents = new List<RadioButton> { SDRB, KPRB, VTSRB, WORB, LARB };
            Senators = new List<RadioButton> { RPRB, LLRB, RTRB, WGRB, CERB };

        }

        private List<RadioButton> Presdients;
        private List<RadioButton> VPresidents;
        private List<RadioButton> Senators;

        private void VoteBtn_Click(object sender, RoutedEventArgs e)
        {
    
                string selectedPresident = GetSelectedCandidate(Presdients);
                string selectedVPresident = GetSelectedCandidate(VPresidents);
                string selectedSenator = GetSelectedCandidate(Senators);
           
            if (selectedPresident == string.Empty || selectedVPresident == string.Empty || selectedSenator == string.Empty) 
            {
                MessageBox.Show("Select Candidates For Each Positions");
            }
            else
            {
                LogOut lg = new LogOut(selectedPresident, selectedVPresident, selectedSenator);
                lg.Show();
                this.Close();
            }
        }

        private string GetSelectedCandidate(List<RadioButton> radioButtonList)
        {
            foreach (RadioButton radioButton in radioButtonList)
            {
                if (radioButton.IsChecked == true)
                {
                    return radioButton.Content.ToString();
                }
            }
            return string.Empty;
        }
    }
}
