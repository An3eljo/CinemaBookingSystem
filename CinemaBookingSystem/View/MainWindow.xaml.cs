using System;
using System.Windows;
using System.Windows.Input;
using CinemaBookingSystem.Library;
using CinemaBookingSystem.Model;

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

        public void CreateFilm(string title, DateTime duration)
        {
            
        }

        public void ManageFilms(Model.Film film)
        {
            
        }

        public void CreateShow(Model.Film film, DateTime date, ShowRoom showRoom, double price = 10)
        {
            new Model.Show(film, date, showRoom, price);
        }

        private void ButtonBooking_OnClick(object sender, RoutedEventArgs e)
        {
            GridBooking.Visibility = GridBooking.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        private void LabelNewBooking_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameDisplayContent.Source = new Uri ("Customer/CreateCustomer.xaml", UriKind.Relative);
        }

        private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GridBooking.Visibility = Visibility.Hidden;
            GridShows.Visibility = Visibility.Hidden;
            GridFilms.Visibility = Visibility.Hidden;
        }

        private void LabelCancelBooking_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameDisplayContent.Source = new Uri("Customer/CancelCustomer.xaml", UriKind.Relative);
        }

        private void ButtonFilms_OnClick(object sender, RoutedEventArgs e)
        {
            GridFilms.Visibility = GridFilms.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        private void LabelAddFilm_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameDisplayContent.Source = new Uri("Film/CreateFilm.xaml", UriKind.Relative);
        }

        private void LabelManageFilms_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameDisplayContent.Source = new Uri("Film/ShowFilm.xaml", UriKind.Relative);
        }

        private void ButtonShows_OnClick(object sender, RoutedEventArgs e)
        {
            GridShows.Visibility = GridShows.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        private void LabelAddShow_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameDisplayContent.Source = new Uri("Show/CreateShow.xaml", UriKind.Relative);
        }

        private void LabelManageShows_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameDisplayContent.Source = new Uri("Show/ShowShow.xaml", UriKind.Relative);
        }
    }
}
