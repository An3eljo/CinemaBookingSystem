using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CinemaBookingSystem.Model;

namespace CinemaBookingSystem.View.Customer
{
    /// <summary>
    /// Interaction logic for CreateCustomer.xaml
    /// </summary>
    public partial class CreateCustomer : Page
    {
        public CreateCustomer()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            var shows = Model.Show.ListOfShows;
            foreach (var show in shows)
            {
                ComboBoxShow.Items.Add(show.Date.ToString() + ": " + show.Film.Title);
            }
        }

        private void FillUi(Model.Show show)
        {
            if (show != null)
            {
                TextBlockShowFilmTitle.Text = show.Film.Title;
                TextBlockShowDate.Text = show.Date.ToString();
                TextBlockShowDuration.Text = show.Film.Duration.ToString();
            }
        }

        private void ComboBoxShow_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var show = Model.Show.ListOfShows[((ComboBox)sender).SelectedIndex];
            FillUi(show);
        }

        private void ButtonSelectSeat_Click(object sender, RoutedEventArgs e)
        {
            var prename = TextBoxPrename.Text;
            var name = TextBoxName.Text;
            var show = Model.Show.ListOfShows[ComboBoxShow.SelectedIndex];

            var chooseSeat = new ChooseSeat(show);
            chooseSeat.ShowDialog();

            var seat = chooseSeat.ChoosenSeat;

            new Model.Customer(seat, show, name, prename);
        }
    }
}