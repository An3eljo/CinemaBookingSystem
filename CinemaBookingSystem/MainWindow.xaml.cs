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

            InitializeComponent();
        }

        private void CreateFilm()
        {
            
        }

        private void ManageFilms()
        {
            
        }
    }
}
