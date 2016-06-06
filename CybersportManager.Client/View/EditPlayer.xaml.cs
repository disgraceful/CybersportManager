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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CybersportManager.Client.View
{
    /// <summary>
    /// Interaction logic for EditPlayer.xaml
    /// </summary>
    public partial class EditPlayer : UserControl
    {
        public EditPlayer()
        {
            InitializeComponent();
        }
        public Player EditingPlayer;
    
        private void selectimage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void confirmchanges_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FillControls()
        {
            //CHECK IF WORKS AND ADD VALUECHANGED EVENTS
            //FILL TEAMCOMBOBOX
            //GODDAMIT
            nametb.Text = EditingPlayer.Name;
            snametb.Text = EditingPlayer.SecondName;
            nnametb.Text = EditingPlayer.NickName;
            agetb.Text = EditingPlayer.Age.ToString();
            rolecb.Text = EditingPlayer.Name;
            teamcb.Text = EditingPlayer.Team.Name;
            countrycb.Text = EditingPlayer.Homeland;
            image.Source = EditingPlayer.Img;
        }

        private ActivePage currentPage;

        private void PlayerPageBtn_Click(object sender, RoutedEventArgs e)
        {
            PlayersPage pp = new PlayersPage();
            currentPage = ActivePage.Players;
            pp.currentPage = this.currentPage;
            this.Content = pp;
        }

        private void TeamPageBtn_Click(object sender, RoutedEventArgs e)
        {
            TeamsPage tp = new TeamsPage();
            currentPage = ActivePage.Teams;
            tp.currentPage = this.currentPage;
            this.Content = tp;

        }

        private void TournamentPageBtn_Click(object sender, RoutedEventArgs e)
        {
            TournamentsPage tp = new TournamentsPage();
            currentPage = ActivePage.Tournaments;
            tp.currentPage = this.currentPage;
            this.Content = tp;

        }

        private void HeroesPageBtn_Click(object sender, RoutedEventArgs e)
        {
            HeroesPage hp = new HeroesPage();
            currentPage = ActivePage.Heroes;
            hp.currentPage = this.currentPage;
            this.Content = hp;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            switch (currentPage)
            {
                case (ActivePage.Players):
                    this.Content = new AddPlayer();
                    break;
                case (ActivePage.Teams):
                    this.Content = new AddTeam();
                    break;
            }
        }

        private void ViewBtn_Click(object sender, RoutedEventArgs e)
        {
            switch (currentPage)
            {
                case (ActivePage.Players):
                    this.Content = new ViewPlayers();
                    break;
                case (ActivePage.Teams):
                    this.Content = new ViewTeams();
                    break;
            }
        }

      
    }
}
