using System.Windows;
using System.Windows.Controls;

namespace CinemaBookingSystem.View.Customer
{
    /// <summary>
    /// Interaction logic for CreateCustomer.xaml
    /// </summary>
    public partial class CreateCustomer : Page
    {
        //private Model.Customer CurrentCustomer;
        public CreateCustomer(Model.Customer customer = null)
        {
            InitializeComponent();
            //CurrentCustomer = customer;
            Init(customer);
        }

        private void Init(Model.Customer customer = null)
        {
            var shows = Model.Show.ListOfShows;
            foreach (var show in shows)
            {
                ComboBoxShow.Items.Add(show.Date.ToString() + ": " + show.Film.Title);
            }

            if (customer != null)
            {
                var index = shows.IndexOf(customer.Show);
                FillUi(customer, shows[index]);
                ComboBoxShow.SelectedIndex = index;
            }
            else
            {

            }
        }

        private void FillUi(Model.Customer customer, Model.Show show)
        {
            if (customer != null)
            {
                TextBoxPrename.Text = customer.Prename;
                TextBoxName.Text = customer.Name;
            }

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
            FillUi(null, show);
        }

        private void ButtonCreate_OnClick(object sender, RoutedEventArgs e)
        {
            var prename = TextBoxPrename.Text;
            var name = TextBoxName.Text;
            var show = Model.Show.ListOfShows[ComboBoxShow.SelectedIndex];

            
        }

        private void ButtonSelectSeat_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}