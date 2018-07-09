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
using CinemaBookingSystem.Model;

namespace CinemaBookingSystem.View.Show
{
    /// <summary>
    /// Interaction logic for CreateShow.xaml
    /// </summary>
    public partial class CreateShow : Page
    {
        public CreateShow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            DatePickerSelectDate.DisplayDate = DateTime.Now;
            TextBoxDurationHour.Text = "0";
            TextBoxDurationMinute.Text = "0";
            TextBoxDurationSecond.Text = "0";
            TextBoxPrice.Text = "10.00";

            var films = Model.Film.ListOfFilms;
            foreach (var film in films)
            {
                ComboBoxFilm.Items.Add(film.Title);
            }
            ComboBoxFilm.SelectedIndex = 0;

            var showRooms = ShowRoom.ShowRooms;
            foreach (var showRoom in showRooms)
            {
                ComboBoxShowRoom.Items.Add(showRoom.RoomNumber);
            }
            ComboBoxShowRoom.SelectedIndex = 0;
        }

        private void OnCreateClick(object sender, EventArgs e)
        {
            var dateTimeDatePicker = new DateTime();




            var choosenFilm = Model.Film.ListOfFilms[0]; //choosen film from dropdown
            var parsedDateTime = new DateTime(); //parsed DateTime from DatePicker and Hours/Minutes/Seconds from inputfield
            var choosenShowroom = ShowRoom.ShowRooms[0]; //choosen Showroom from dropdown
            new Model.Show(choosenFilm, parsedDateTime, choosenShowroom);
        }
    }
}
