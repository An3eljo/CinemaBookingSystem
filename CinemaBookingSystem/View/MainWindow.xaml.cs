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
        //todo: einheitliches design
        //todo: UI allgemein
        //todo: Create/edit code behind
        public MainWindow()
        {
            InitializeComponent();
            Init.Initialize();
            Navigation.Init(ref FrameDisplayContent);
        }

        private void ButtonBooking_OnClick(object sender, RoutedEventArgs e)
        {
            GridBooking.Visibility = GridBooking.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        private void LabelNewBooking_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var t = new ChooseSeat("", "", Model.Show.ListOfShows[0]);
            t.ShowDialog();

            int f = 0;
            //Navigation.PageChange.Invoke(this, new PageEventArgs(new CreateCustomer()));
        }

        private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GridBooking.Visibility = Visibility.Hidden;
            GridShows.Visibility = Visibility.Hidden;
            GridFilms.Visibility = Visibility.Hidden;
        }

        private void LabelCancelBooking_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Navigation.PageChange.Invoke(this, new PageEventArgs(new CancelCustomer()));
        }

        private void ButtonFilms_OnClick(object sender, RoutedEventArgs e)
        {
            GridFilms.Visibility = GridFilms.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        private void LabelAddFilm_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Navigation.PageChange.Invoke(this, new PageEventArgs(new CreateFilm()));
        }

        private void LabelManageFilms_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Navigation.PageChange.Invoke(this, new PageEventArgs(new ShowFilm()));
        }

        private void ButtonShows_OnClick(object sender, RoutedEventArgs e)
        {
            GridShows.Visibility = GridShows.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        private void LabelAddShow_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Navigation.PageChange.Invoke(this, new PageEventArgs(new ShowFilm()));
        }

        private void LabelManageShows_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Navigation.PageChange.Invoke(this, new PageEventArgs(new ShowShow()));
        }
    }
}
