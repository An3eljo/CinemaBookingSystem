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

namespace CinemaBookingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            #region Setup

            var list = new List<Tuple<int, int, int>>();
            list.AddRange(new[]
            {
                new Tuple<int, int, int>(1, 10, 40),
                new Tuple<int, int, int>(2, 3, 5),
                new Tuple<int, int, int>(3, 6, 15),
                new Tuple<int, int, int>(5, 10, 18),
                new Tuple<int, int, int>(7, 20, 30),
            });
            ShowRooms.Create(list);


            new Show(new Film("Solo: A Star Wars Story", new DateTime().AddHours(1).AddMinutes(40).AddSeconds(20)),
                new DateTime(2018, 05, 25, 19, 50, 0), ShowRooms.ShowRoomList[0], 7);

            new Show(new Film("I Feel Pretty", new DateTime().AddHours(1).AddMinutes(50).AddSeconds(33)), 
                new DateTime(2018, 05, 25, 20, 45, 0), ShowRooms.ShowRoomList[1]);

            new Show(new Film("Avengers: Infinity War", new DateTime().AddHours(2).AddMinutes(40)),
                new DateTime(2018, 05, 25, 18, 45, 0), ShowRooms.ShowRoomList[3]);

            new Show(new Film("Deadpool 2", new DateTime().AddHours(2).AddMinutes(13)), new DateTime(2018, 05, 25, 19, 20, 0),
                ShowRooms.ShowRoomList[2]);

            new Show(new Film("Jim Knopf und Lukas der Lokomotivführer", new DateTime().AddHours(2).AddMinutes(27)), 
                new DateTime(2018, 05, 25, 18, 45, 0), ShowRooms.ShowRoomList[2]);


            #endregion

            InitializeComponent();
        }

        private void CreateFilm()
        {
            
        }

        private void ManageFilms()
        {
            
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
        }

        private void LabelCancelBooking_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
