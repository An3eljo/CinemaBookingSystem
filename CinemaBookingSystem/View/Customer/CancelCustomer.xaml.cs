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

namespace CinemaBookingSystem.View.Customer
{
    /// <summary>
    /// Interaction logic for CancelCustomer.xaml
    /// </summary>
    public partial class CancelCustomer : Page
    {
        public CancelCustomer()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            var films = Model.Film.ListOfFilms;
            foreach (var film in films)
            {
                ComboBoxFilm.Items.Add(film.Title);
            }
        }

        private void ComboBoxFilm_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var choosenFilm = Model.Film.ListOfFilms[((ComboBox) sender).SelectedIndex];

            var shows = Model.Show.ListOfShows;
            foreach (var show in shows)
            {
                if (show.Film == choosenFilm)
                {
                    ComboBoxShow.Items.Add(show.Date.ToString());
                }
            }
        }

        private void ComboBoxShow_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var choosenShow = Model.Show.ListOfShows[((ComboBox)sender).SelectedIndex];

            var shows = Model.Show.ListOfShows;
            foreach (var show in shows)
            {
                if (show.Film == choosenShow)
                {
                    ComboBoxShow.Items.Add(show.Date.ToString());
                }
            }
        }

        private void ComboBoxCustomer_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
