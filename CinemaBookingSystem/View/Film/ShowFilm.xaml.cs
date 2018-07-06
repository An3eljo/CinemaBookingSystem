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

namespace CinemaBookingSystem.View.Film
{
    /// <summary>
    /// Interaction logic for ShowFilm.xaml
    /// </summary>
    public partial class ShowFilm : Page
    {
        public ShowFilm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            var filmList = Model.Film.ListOfFilms;

            foreach (var film in filmList)
            {
                ComboBoxFilms.Items.Add(film.Title);
            }
        }

        private void ComboBoxFilms_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
