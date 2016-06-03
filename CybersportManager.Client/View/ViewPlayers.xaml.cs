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


namespace CybersportManager.Client
{
    /// <summary>
    /// Interaction logic for ViewPlayers.xaml
    /// </summary>
    public partial class ViewPlayers : UserControl
    {
        public ActivePage currentPage;
        public ViewPlayers()
        {
            
            InitializeComponent();
            var list = Database.allPlayers;
            CollectionViewSource itemCollectionViewSource;
            itemCollectionViewSource = (CollectionViewSource)(FindResource("ItemCollectionViewSource"));
            itemCollectionViewSource.Source = list;
                     
        }

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
