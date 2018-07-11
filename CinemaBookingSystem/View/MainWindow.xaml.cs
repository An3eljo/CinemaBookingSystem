using System;
using System.Windows;
using System.Windows.Input;
using CinemaBookingSystem.Library;
using CinemaBookingSystem.Model;
using CinemaBookingSystem.View.Customer;
using CinemaBookingSystem.View.Film;
using CinemaBookingSystem.View.Show;

namespace CinemaBookingSystem.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static EventHandler<PageEventArgs> PageChange;
        public MainWindow()
        {
            Init.Initialize();
            InitializeComponent();
            PageChange += OnPageChanged;
        }

        private void OnPageChanged(object sender, PageEventArgs e)
        {
            var newPage = e.Page;
            FrameDisplayContent.Navigate(newPage);
        }

        private void ButtonBooking_OnClick(object sender, RoutedEventArgs e)
        {
            GridBooking.Visibility = GridBooking.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        private void LabelNewBooking_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PageChange.Invoke(this, new PageEventArgs(new CreateCustomer()));
        }

        private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GridBooking.Visibility = Visibility.Hidden;
            GridShows.Visibility = Visibility.Hidden;
            GridFilms.Visibility = Visibility.Hidden;
        }

        private void LabelCancelBooking_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PageChange.Invoke(this, new PageEventArgs(new CancelCustomer()));
        }

        private void ButtonFilms_OnClick(object sender, RoutedEventArgs e)
        {
            GridFilms.Visibility = GridFilms.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        private void LabelAddFilm_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PageChange.Invoke(this, new PageEventArgs(new CreateFilm()));
        }

        private void LabelManageFilms_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PageChange.Invoke(this, new PageEventArgs(new ShowFilm()));
        }

        private void ButtonShows_OnClick(object sender, RoutedEventArgs e)
        {
            GridShows.Visibility = GridShows.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        private void LabelAddShow_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PageChange.Invoke(this, new PageEventArgs(new ShowFilm()));
        }

        private void LabelManageShows_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PageChange.Invoke(this, new PageEventArgs(new ShowShow()));
        }
    }
}
