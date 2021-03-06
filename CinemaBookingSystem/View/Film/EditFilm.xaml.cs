﻿using System;
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
using CinemaBookingSystem.Library;

namespace CinemaBookingSystem.View.Film
{
    /// <summary>
    /// Interaction logic for EditFilm.xaml
    /// </summary>
    public partial class EditFilm : Page
    {
        private Model.Film CurrentFilm;

        public EditFilm(Model.Film film)
        {
            InitializeComponent();
            CurrentFilm = film;
            Init(film);
        }

        private void Init(Model.Film film)
        {
            var films = Model.Film.ListOfFilms;
            foreach (var film1 in films)
            {
                ComboBoxFilms.Items.Add(film1.Title);
            }

            if (film != null)
            {
                var index = films.IndexOf(film);
                ComboBoxFilms.SelectedIndex = index;
            }
            else
            {
                Errors.ErrorHandler.Invoke(this, new ErrorEventArgs(Errors.ErrorMessages[4]));
                return;
            }
        }

        private void FillFilmUi(Model.Film film)
        {
            TextBoxDurationHours.Text = film.Duration.Hours.ToString();
            TextBoxDurationMinutes.Text = film.Duration.Minutes.ToString();
            TextBoxDurationSeconds.Text = film.Duration.Seconds.ToString();
            TextBoxTitle.Text = film.Title;
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
                //todo: errorhandling
                try
                {
                    var hours = int.Parse(TextBoxDurationHours.Text);
                    var minutes = int.Parse(TextBoxDurationMinutes.Text);
                    var seconds = 0;

                    if (TextBoxDurationSeconds.Text != String.Empty)
                    {
                        seconds = int.Parse(TextBoxDurationSeconds.Text);
                    }

                    duration = new TimeSpan(hours, minutes, seconds);
                }
                catch (Exception)
                {
                    return;
                }
            }
            else
            {
                //Errors.ErrorHandler.Invoke(this, new ErrorEventArgs());
            }

            if (CurrentFilm != null)
            {
                var index = Model.Film.ListOfFilms.IndexOf(CurrentFilm);
                Model.Film.ListOfFilms[index].Title = title;
                Model.Film.ListOfFilms[index].Duration = duration;
                Navigation.PageChange.Invoke(this, new PageEventArgs(new ShowFilm(Model.Film.ListOfFilms[index])));
            }
            else
            {
                new Model.Film(title, duration);
                Navigation.PageChange.Invoke(this,
                    new PageEventArgs(new ShowFilm(Model.Film.ListOfFilms[Model.Film.ListOfFilms.Count - 1])));
            }
        }

        private void ComboBoxFilms_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var film = Model.Film.ListOfFilms[((ComboBox)sender).SelectedIndex];
            FillFilmUi(film);
        }
    }

}
