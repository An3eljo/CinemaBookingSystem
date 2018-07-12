using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using CinemaBookingSystem.Model;

namespace CinemaBookingSystem.View
{
    /// <summary>
    /// Interaction logic for ChooseSeat.xaml
    /// </summary>
    public partial class ChooseSeat : Window
    {
        private Model.Show ChoosenShow;
        public Seat ChoosenSeat;
        public ChooseSeat(Model.Show show)
        {
            this.ChoosenShow = show;
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
                    button.Content = (i +1) + "/" + (j + 1);
                    button.Click += OnSeatClick;


                    Grid.SetColumn(grid, j);
                    Grid.SetRow(grid, i);

                    grid.Children.Add(button);
                    GridMain.Children.Add(grid);
                }
            }
        }

        private void OnSeatClick(object sender, EventArgs e)
        {
            var sendr = (ToggleButton) sender;

            if (sendr.IsChecked == true)
            {
                ButtonCreate.IsEnabled = true;
                foreach (var item in GridMain.Children.OfType<Grid>())
                {
                    foreach (var toggleButton in item.Children.OfType<ToggleButton>())
                    {
                        if (!Equals(toggleButton, sendr))
                        {
                            toggleButton.IsChecked = false;
                        }
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

            ChoosenSeat = ChoosenShow.ShowRoom.ListOfSeats.First(seat => seat.Column == column && seat.Row == row);

            //todo: in create and edit
            //if (Customer != null)
            //{
            //    Model.Customer.CustomerList.First(customer => customer == Customer)
            //}
            //else
            //{
            //    new Model.Customer(choosenSeat, ChoosenShow, ChoosenName, Prename);
            //}
        }
    }
}
