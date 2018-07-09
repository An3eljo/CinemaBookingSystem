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
using CinemaBookingSystem.Library;
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
            Init(null);
            OnCreateClick(this, EventArgs.Empty);
        }

        public CreateShow(Model.Show show = null)
        {
            InitializeComponent();
            Init(show);
            OnCreateClick(this, EventArgs.Empty);
        }

        private void Init(Model.Show show)
        {
            var films = Model.Film.ListOfFilms;
            foreach (var film in films)
            {
                ComboBoxFilm.Items.Add(film.Title);
            }

            var showRooms = ShowRoom.ShowRooms;
            foreach (var showRoom in showRooms)
            {
                ComboBoxShowRoom.Items.Add(showRoom.RoomNumber);
            }

            if (show != null)
            {
                InitEdit(show);
            }
            else
            {
                InitNew();
            }
        }

        private void InitNew()
        {
            DatePickerSelectDate.DisplayDate = DateTime.Now;
            TextBoxDateHour.Text = "0";
            TextBoxDateMinute.Text = "0";
            TextBoxDateSecond.Text = "0";
            TextBoxPrice.Text = "10.00";

            ComboBoxFilm.SelectedIndex = 0;
            ComboBoxShowRoom.SelectedIndex = 0;
        }

        private void InitEdit(Model.Show show)
        {
            DatePickerSelectDate.DisplayDate = show.Date;
            TextBoxDateHour.Text = show.Date.Hour.ToString();
            TextBoxDateMinute.Text = show.Date.Minute.ToString();
            TextBoxDateSecond.Text = show.Date.Minute.ToString();

            ComboBoxFilm.SelectedIndex = Model.Film.ListOfFilms.IndexOf(show.Film);
            ComboBoxShowRoom.SelectedIndex = ShowRoom.ShowRooms.IndexOf(show.ShowRoom);
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
                var hour = int.Parse(TextBoxDateHour.Text);
                var minute = int.Parse(TextBoxDateMinute.Text);
                var second = int.Parse(TextBoxDateSecond.Text);
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

            MainWindow.PageChange.Invoke(this,
                new PageEventArgs(new ShowShow(Model.Show.ListOfShows[Model.Show.ListOfShows.Count - 1])));
        }
    }
}
