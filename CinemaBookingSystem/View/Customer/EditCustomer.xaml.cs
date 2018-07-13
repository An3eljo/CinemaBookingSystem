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
using CinemaBookingSystem.Library;
using CinemaBookingSystem.Model;

namespace CinemaBookingSystem.View.Customer
{
    /// <summary>
    /// Interaktionslogik für EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Page
    {
        private Model.Customer CurrentCustomer;
        private Seat CurrentSeat;
        public EditCustomer(Model.Customer customer)
        {
            InitializeComponent();
            CurrentCustomer = customer;
            CurrentSeat = customer.Seat;
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
                ComboBoxFilm.SelectedIndex = Model.Film.ListOfFilms.IndexOf(customer.Show.Film);
                ComboBoxShow.SelectedIndex = Model.Show.ListOfShows.IndexOf(customer.Show);
                ComboBoxCustomer.SelectedIndex = Model.Customer.CustomerList.IndexOf(customer);
                TextBoxName.Text = customer.Name;
                TextBoxPrename.Text = customer.Prename;
            }
        }

        private void ComboBoxFilm_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxShow.Items.Clear();
            ComboBoxCustomer.Items.Clear();

            var choosenFilm = Model.Film.ListOfFilms[((ComboBox)sender).SelectedIndex];

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
            
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {

            try
            {
                Model.Customer.CustomerList[((ComboBox) sender).SelectedIndex].Show = CurrentCustomer.Show;
                Model.Customer.CustomerList[((ComboBox) sender).SelectedIndex].Name = TextBoxName.Text;
                Model.Customer.CustomerList[((ComboBox) sender).SelectedIndex].Prename = TextBoxPrename.Text;
                Model.Customer.CustomerList[((ComboBox) sender).SelectedIndex].Seat = CurrentSeat;
                Navigation.PageChange.Invoke(this, new PageEventArgs(new ShowCustomer(Model.Customer.CustomerList[((ComboBox)sender).SelectedIndex])));
            }
            catch (Exception )
            {
                Errors.ErrorHandler.Invoke(this, new ErrorEventArgs(Errors.ErrorMessages[4]));
            }
        }

        private void ButtonSelectSeat_Click(object sender, RoutedEventArgs e)
        {
            var show = Model.Show.ListOfShows[ComboBoxShow.SelectedIndex];

            var chooseSeat = new ChooseSeat(show);
            chooseSeat.ShowDialog();
            var choosenSeat = chooseSeat.ChoosenSeat;

            CurrentCustomer.Show.ShowRoom.ListOfSeats.First(seat => seat == CurrentSeat).IsBooked[
                    CurrentCustomer.Seat.IsBooked.IndexOf(new Tuple<Model.Show, bool>(CurrentCustomer.Show, true))] =
                new Tuple<Model.Show, bool>(CurrentCustomer.Show, false);

            CurrentSeat = choosenSeat;

        }
    }
}
