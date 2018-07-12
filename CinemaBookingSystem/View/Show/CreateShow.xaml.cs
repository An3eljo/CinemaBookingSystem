using System;
using System.Linq;
using System.Windows.Controls;
using CinemaBookingSystem.Library;
using CinemaBookingSystem.Model;

namespace CinemaBookingSystem.View.Show
{
    /// <summary>
    /// Interaction logic for CreateShow.xaml
    /// </summary>
    public partial class CreateShow : Page
    {
        private Model.Show CurrentShow;
        public CreateShow()
        {
            InitializeComponent();
            Init();
        }

        public CreateShow(Model.Show show)
        {
            InitializeComponent();
            Init(show);
            CurrentShow = show;
        }

        private void Init(Model.Show show = null)
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
                var second = 0;

                if (int.TryParse(TextBoxDateSecond.Text, out second))
                {
                    date.AddHours(hour).AddMinutes(minute).AddSeconds(second);
                }

                date.AddHours(hour).AddMinutes(minute);
            }
            catch (Exception)
            {
                Errors.ErrorHandler.Invoke(this, new ErrorEventArgs(Errors.ErrorMessages[0]));
                return;
            }

            try
            {
                price = double.Parse(TextBoxPrice.Text);
            }
            catch (Exception)
            {
                Errors.ErrorHandler.Invoke(this, new ErrorEventArgs(Errors.ErrorMessages[2]));
                return;
            }

            if (CurrentShow != null)
            {
                var index = Model.Show.ListOfShows.IndexOf(CurrentShow);
                Model.Show.ListOfShows[index].Film = film;
                Model.Show.ListOfShows[index].Date = date;
                Model.Show.ListOfShows[index].Price = price;
                Model.Show.ListOfShows[index].ShowRoom = showRoom;
                Navigation.PageChange.Invoke(this, new PageEventArgs(new ShowShow(Model.Show.ListOfShows[index])));
            }
            else
            {
                new Model.Show(film, date, showRoom, price);

                Navigation.PageChange.Invoke(this,
                    new PageEventArgs(new ShowShow(Model.Show.ListOfShows[Model.Show.ListOfShows.Count - 1])));
            }
        }
    }
}
