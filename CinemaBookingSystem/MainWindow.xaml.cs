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
using CinemaBookingSystem.Model;
using CinemaBookingSystem.View.Booking;

namespace CinemaBookingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Init.Initialize();
            InitializeComponent();
        }

        public void CreateFilm(string title, DateTime duration)
        {
            
        }

        public void ManageFilms(Film film)
        {
            
        }

        public void CreateShow(Film film, DateTime date, ShowRoom showRoom, double price = 10)
        {
            new Show(film, date, showRoom, price);
        }

        private void ButtonBooking_OnClick(object sender, RoutedEventArgs e)
        {
            GridBooking.Visibility = GridBooking.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        private void LabelNewBooking_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GridBooking.Visibility = Visibility.Hidden;
            GridShows.Visibility = Visibility.Hidden;
            GridFilms.Visibility = Visibility.Hidden;
        }

        private void LabelCancelBooking_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void ButtonFilms_OnClick(object sender, RoutedEventArgs e)
        {
            GridFilms.Visibility = GridFilms.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        private void LabelAddFilm_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void LabelManageFilms_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void ButtonShows_OnClick(object sender, RoutedEventArgs e)
        {
            GridShows.Visibility = GridShows.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        private void LabelAddShow_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void LabelManageShows_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
