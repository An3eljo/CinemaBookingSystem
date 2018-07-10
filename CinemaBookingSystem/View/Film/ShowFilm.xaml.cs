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
        private Model.Film CurrentFilm;
        public ShowFilm(Model.Film film = null)
        {
            InitializeComponent();
            CurrentFilm = film;
            Init(film);
        }

        private void Init(Model.Film currentFilm)
        {
            var filmList = Model.Film.ListOfFilms;
            foreach (var film in filmList)
            {
                ComboBoxFilms.Items.Add(film.Title);
            }

            if (currentFilm != null)
            {
                var index = filmList.IndexOf(currentFilm);
                FillFilmProperties(index);
            }
        }

        private void ComboBoxFilms_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filmIndex = ((ComboBox) sender).SelectedIndex;
            FillFilmProperties(filmIndex);
        }

        private void FillFilmProperties(int filmIndex)
        {
            var film = Model.Film.ListOfFilms[filmIndex];
            TextBlockTitleProperty.Text = film.Title;
            TextBlockDurationProperty.Text = film.Duration.ToString();
        }
    }
}
