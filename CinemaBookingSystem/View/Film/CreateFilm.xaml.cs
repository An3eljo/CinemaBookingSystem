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
        }


        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            string title;
            TimeSpan duration;
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
                return;
            }

            new Model.Film(title, duration);

            var t = Model.Film.ListOfFilms;
        }
    }
}