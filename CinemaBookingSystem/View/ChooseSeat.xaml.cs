using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CinemaBookingSystem.Model;

namespace CinemaBookingSystem.View
{
    /// <summary>
    /// Interaction logic for ChooseSeat.xaml
    /// </summary>
    public partial class ChooseSeat : Window
    {
        private string Prename;
        private string ChoosenName;
        private Model.Show ChoosenShow;
        private Model.Customer Customer;
        public ChooseSeat(string prename, string name, Model.Show show, Model.Customer customer = null)
        {
            this.Prename = prename;
            this.ChoosenName = name;
            this.ChoosenShow = show;
            this.Customer = customer;
            InitializeComponent();
            Init(show);
        }

        private void Init(Model.Show show)
        {
            MakeGrid(show);
        }

        private void MakeGrid(Model.Show show)
        {
            for (int i = 0; i < show.ShowRoom.ColumnsCount; i++)
            {
                GridMain.ColumnDefinitions.Add(new ColumnDefinition(){Width = new GridLength(1, GridUnitType.Star)});
            }

            for (int i = 0; i < show.ShowRoom.RowsCount; i++)
            {
                GridMain.RowDefinitions.Add(new RowDefinition(){Height = new GridLength(1, GridUnitType.Star)});
            }

            for (int i = 0; i < show.ShowRoom.RowsCount; i++)
            {
                for (int j = 0; j < show.ShowRoom.ColumnsCount; j++)
                {
                    var grid = new Grid();
                    grid.Margin = new Thickness(5);

                    var button = new ToggleButton();
                    button.Content = i + "/" + j;
                    button.Click += OnSeatClick;
                }
            }
        }

        private void OnSeatClick(object sender, EventArgs e)
        {
            var sendr = (ToggleButton) sender;

            if (sendr.IsChecked == true)
            {
                ButtonCreate.IsEnabled = true;
                foreach (var toggleButton in GridMain.Children.Cast<ToggleButton>())
                {
                    if (!Equals(toggleButton, sendr))
                    {
                        toggleButton.IsChecked = false;
                    }
                }
            }
            else
            {
                ButtonCreate.IsEnabled = false;
            }
        }

        private void ButtonCreate_OnClick(object sender, RoutedEventArgs e)
        {
            var choosenToggleButton = GridMain.Children.Cast<ToggleButton>().First(chsn => chsn.IsEnabled);

            var row = Grid.GetRow((Grid) choosenToggleButton.Parent);
            var column = Grid.GetColumn((Grid)choosenToggleButton.Parent);

            var choosenSeat = ChoosenShow.ShowRoom.ListOfSeats.First(seat => seat.Column == column && seat.Row == row);

            new Model.Customer(choosenSeat, ChoosenShow, ChoosenName, Prename);
        }
    }
}
