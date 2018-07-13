using System;
using System.Windows.Controls;
using CinemaBookingSystem.Library;
using CinemaBookingSystem.View.Customer;

namespace CinemaBookingSystem.View.Show
{
    /// <summary>
    /// Interaction logic for ShowShow.xaml
    /// </summary>
    public partial class ShowShow : Page
    {
        private Model.Show CurrentShow;

        public ShowShow()
        {
            InitializeComponent();
            Init();
        }

        public ShowShow(Model.Show show)
        {
            InitializeComponent();
            CurrentShow = show;
            Init(show);
        }

        private void Init(Model.Show currentShow = null)
        {
            var shows = Model.Show.ListOfShows;
            foreach (var show in shows)
            {
                ComboBoxShows.Items.Add(show.Date.ToString() + ": " + show.Film.Title);
            }

            if (currentShow != null)
            {
                var index = shows.IndexOf(currentShow);
                FillShowUi(index);
            }
        }

        private void FillShowUi(int indexInList)
        {
            var show = Model.Show.ListOfShows[indexInList];

            ButtonEdit.IsEnabled = true;
            TextBlockDate.Text = show.Date.ToString();
            TextBlockFilm.Text = show.Film.Title;
            TextBlockShowRoom.Text = show.ShowRoom.RoomNumber.ToString();
            TextBlockPrice.Text = show.Price.ToString();
        }

        private void OnEditClick(object sender, EventArgs e)
        {
            if (CurrentShow != null)
            {
                Navigation.PageChange.Invoke(this, new PageEventArgs(new EditShow(CurrentShow)));
            }
            else
            {
                try
                {
                    Navigation.PageChange.Invoke(this, new PageEventArgs(new EditShow(Model.Show.ListOfShows[ComboBoxShows.SelectedIndex])));
                }
                catch (Exception)
                {
                    Errors.ErrorHandler.Invoke(this, new ErrorEventArgs(Errors.ErrorMessages[4]));
                    return;
                }
            }
        }

        private void ComboBoxShows_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = ((ComboBox)sender).SelectedIndex;
            FillShowUi(index);
        }
    }
}
