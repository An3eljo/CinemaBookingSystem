using System.Windows;
using System.Windows.Controls;
using CinemaBookingSystem.Library;

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
            ButtonDeleteCustomer.IsEnabled = false;
            ButtonEdit.IsEnabled = false;

            ComboBoxShow.Items.Clear();
            ComboBoxCustomer.Items.Clear();

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
            ButtonDeleteCustomer.IsEnabled = false;
            ButtonEdit.IsEnabled = false;

            ComboBoxCustomer.Items.Clear();

            var choosenShow = Model.Show.ListOfShows[((ComboBox)sender).SelectedIndex];

            var customers = Model.Customer.CustomerList;
            foreach (var customer in customers)
            {
                if (customer.Show == choosenShow)
                {
                    ComboBoxCustomer.Items.Add(customer.Seat.Row + "/" + customer.Seat.Column + ": " + customer.Name +
                                               ", " + customer.Prename);
                }
            }
        }

        private void ComboBoxCustomer_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonDeleteCustomer.IsEnabled = true;
            ButtonEdit.IsEnabled = true;
        }

        private void ButtonDeleteCustomer_OnClick(object sender, RoutedEventArgs e)
        {
            var choosenCustomer = Model.Customer.CustomerList[((ComboBox)sender).SelectedIndex];

            choosenCustomer.Delete();
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            var choosenCustomer = Model.Customer.CustomerList[((ComboBox)sender).SelectedIndex];

            Navigation.PageChange.Invoke(this, new PageEventArgs(new CreateCustomer(choosenCustomer)));
        }
    }
}
