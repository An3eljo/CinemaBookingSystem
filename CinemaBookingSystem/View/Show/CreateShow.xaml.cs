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
            OnCreateClick(this, EventArgs.Empty);
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
            var date = DatePickerSelectDate.DisplayDate;
            double price = 0;

            var film = Model.Film.ListOfFilms.First(flm => flm.Title == ComboBoxFilm.SelectionBoxItem.ToString());
            var showRoom =
                ShowRoom.ShowRooms.First(showroom => showroom.RoomNumber == (int) ComboBoxShowRoom.SelectionBoxItem);

            try
            {
                var hour = int.Parse(TextBoxDurationHour.Text);
                var minute = int.Parse(TextBoxDurationMinute.Text);
                var second = int.Parse(TextBoxDurationSecond.Text);
                date.AddHours(hour).AddMinutes(minute).AddSeconds(second);
            }
            catch (Exception)
            {
                //todo: errorhandling
                return;
            }

            try
            {
                price = double.Parse(TextBoxPrice.Text);
            }
            catch (Exception)
            {
                //todo: errorhandling
                return;
            }

            new Model.Show(film, date, showRoom, price);
        }
    }
}
