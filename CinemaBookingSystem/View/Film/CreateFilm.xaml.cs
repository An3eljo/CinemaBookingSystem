using System;
using System.Windows;
using System.Windows.Controls;
using CinemaBookingSystem.Library;

namespace CinemaBookingSystem.View.Film
{
    /// <summary>
    /// Interaction logic for CreateFilm.xaml
    /// </summary>
    public partial class CreateFilm : Page
    {

        public CreateFilm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
                TextBoxDurationHours.Text = "0";
                TextBoxDurationMinutes.Text = "0";
                TextBoxDurationSeconds.Text = "0";
                TextBoxTitle.Text = "Title";
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            string title;
            TimeSpan duration = new TimeSpan();
            if (TextBoxTitle.Text != String.Empty)
            {
                title = TextBoxTitle.Text;
            }
            else
            {
                return;
            }

            if (TextBoxDurationHours.Text != String.Empty && TextBoxDurationMinutes.Text != String.Empty)
            {
                try
                {
                    var hours = int.Parse(TextBoxDurationHours.Text);
                    var minutes = int.Parse(TextBoxDurationMinutes.Text);
                    var seconds = 0;

                    if (int.TryParse(TextBoxDurationSeconds.Text, out seconds))
                    {
                        duration = new TimeSpan(hours, minutes, seconds);
                    }
                    else
                    {
                        duration = new TimeSpan(hours, minutes, 00);
                    }

                }
                catch (Exception)
                {
                    Errors.ErrorHandler.Invoke(this, new ErrorEventArgs(Errors.ErrorMessages[0]));
                    return;
                }
            }
            else
            {
                Errors.ErrorHandler.Invoke(this, new ErrorEventArgs(Errors.ErrorMessages[1]));
            }
                new Model.Film(title, duration);
                Navigation.PageChange.Invoke(this,
                new PageEventArgs(new ShowFilm(Model.Film.ListOfFilms[Model.Film.ListOfFilms.Count - 1])));
        }
    }
}
