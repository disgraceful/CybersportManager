using Microsoft.Win32;
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
    /// Interaction logic for AddTeam.xaml
    /// </summary>
    public partial class AddTeam : UserControl
    {
        public AddTeam()
        {
            InitializeComponent();
            listView.ItemsSource = Database.allPlayers;
        }

        List<Player> signedplayers = new List<Player>();
        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            Team newteam = new Team(nametb.Text, tagtb.Text, (Region)Enum.Parse(typeof(Region), regioncb.Text));
            foreach (Player p in signedplayers)
            {
                p.SetTeam(newteam);
            }
            newteam.Img = new BitmapImage(new Uri(image.Source.ToString()));
            Database.allTeams.Add(newteam);
        }

        private void SignPlayer_Click(object sender, RoutedEventArgs e)
        {
            var k = listView.SelectedItem as Player;
            Image playerimg = (Image)this.FindName(k.RoleType.ToString());
            playerimg.Source = k.Img;
            signedplayers.Add(k);
        }

        OpenFileDialog op = new OpenFileDialog();

        private void chooseimg_Click(object sender, RoutedEventArgs e)
        {
            op.Title = "Select an image";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                image.Source = new BitmapImage(new Uri(op.FileName));
            }
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
