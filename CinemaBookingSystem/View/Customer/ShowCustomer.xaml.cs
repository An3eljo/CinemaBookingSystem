using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CinemaBookingSystem.Library;

namespace CinemaBookingSystem.View.Customer
{
    /// <summary>
    /// Interaction logic for CancelCustomer.xaml
    /// </summary>
    public partial class ShowCustomer : Page
    {
        public ShowCustomer(Model.Customer customer = null)
        {
            InitializeComponent();
            Init(customer);
        }

        private void Init(Model.Customer customer)
        {
            var films = Model.Film.ListOfFilms;
            foreach (var film in films)
            {
                ComboBoxFilm.Items.Add(film.Title);
            }

            if (customer != null)
            {
                InsertShows(Model.Show.ListOfShows.IndexOf(customer.Show));
                InsertCustomers(Model.Customer.CustomerList.IndexOf(customer));
            }
        }

        private void ComboBoxFilm_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InsertShows(((ComboBox)sender).SelectedIndex);
        }

        private void InsertShows(int index)
        {
            ButtonDeleteCustomer.IsEnabled = false;
            ButtonEdit.IsEnabled = false;

            ComboBoxShow.Items.Clear();
            ComboBoxCustomer.Items.Clear();

            var choosenFilm = Model.Film.ListOfFilms[index];

            var shows = Model.Show.ListOfShows;
            foreach (var show in shows)
            {
                if (show.Film == choosenFilm)
                {
                    ComboBoxShow.Items.Add(show.Date.ToString());
                }
            }
        }

        private void InsertCustomers(int index)
        {
            ButtonDeleteCustomer.IsEnabled = false;
            ButtonEdit.IsEnabled = false;

            ComboBoxCustomer.Items.Clear();

            var choosenShow = Model.Show.ListOfShows[index];

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

        private void ComboBoxShow_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InsertCustomers(((ComboBox)sender).SelectedIndex);
        }

        private void ComboBoxCustomer_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var customer = Model.Customer.CustomerList[((ComboBox) sender).SelectedIndex];

            LabelName.Content = customer.Name;
            LabelPrename.Content = customer.Prename;
            LabelShow.Content = customer.Show.Date + ": " + customer.Show.Film.Title;
            LabelPrice.Content = customer.Show.Price;

            ButtonDeleteCustomer.IsEnabled = true;
            ButtonEdit.IsEnabled = true;
        }

        private void ButtonDeleteCustomer_OnClick(object sender, RoutedEventArgs e)
        {
            Model.Customer.CustomerList[((ComboBox)sender).SelectedIndex].Delete();
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            var choosenCustomer = Model.Customer.CustomerList[((ComboBox)sender).SelectedIndex];

            Navigation.PageChange.Invoke(this, new PageEventArgs(new EditCustomer(choosenCustomer)));
        }
    }
}
