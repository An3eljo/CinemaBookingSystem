using System.Windows;
using System.Windows.Controls;
using CinemaBookingSystem.Library;
using CinemaBookingSystem.View.Customer;

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
            ButtonEdit.IsEnabled = true;
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
                Navigation.PageChange.Invoke(this, new PageEventArgs(new EditFilm(CurrentFilm)));
            }
            else
            {
                Errors.ErrorHandler.Invoke(this, new ErrorEventArgs(Errors.ErrorMessages[4]));
            }
        }

        private void ButtonDelet_OnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
