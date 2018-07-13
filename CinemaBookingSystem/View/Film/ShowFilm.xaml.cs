using System.Windows;
using System.Windows.Controls;
using CinemaBookingSystem.Library;

namespace CinemaBookingSystem.View.Film
{
    /// <summary>
    /// Interaction logic for ShowFilm.xaml
    /// </summary>
    public partial class ShowFilm : Page
    {
        private Model.Film CurrentFilm;

        public ShowFilm()
        {
            InitializeComponent();
            Init(null);
        }

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

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            if (CurrentFilm != null)
            {
                Navigation.PageChange.Invoke(this, new PageEventArgs(new CreateFilm()));
            }
        }
    }
}
