﻿using System;
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

namespace CinemaBookingSystem.View.Customer
{
    /// <summary>
    /// Interaktionslogik für EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Page
    {
        public EditCustomer(Model.Customer customer)
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

        private void ButtonDeleteCustomer_OnClick(object sender, RoutedEventArgs e)
        {
            var choosenCustomer = Model.Customer.CustomerList[((ComboBox)sender).SelectedIndex];

            choosenCustomer.Delete();
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            var choosenCustomer = Model.Customer.CustomerList[((ComboBox)sender).SelectedIndex];

            Navigation.PageChange.Invoke(this, new PageEventArgs(new EditCustomer(choosenCustomer)));
        }

        private void ButtonSelectSeat_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
