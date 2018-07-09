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

namespace CinemaBookingSystem.View.Show
{
    /// <summary>
    /// Interaction logic for ShowShow.xaml
    /// </summary>
    public partial class ShowShow : Page
    {
        private Model.Show CurrentShow;
        public ShowShow(Model.Show show = null)
        {
            CurrentShow = show;

            InitializeComponent();
            Init(show);
        }

        private void Init(Model.Show show)
        {
            if (show != null)
            {
                ButtonEdit.IsEnabled = true;
                TextBlockDate.Text = show.Date.ToString();
                TextBlockFilm.Text = show.Film.Title;
                TextBlockShowRoom.Text = show.ShowRoom.RoomNumber.ToString();
                TextBlockPrice.Text = show.Price.ToString();
            }
        }

        private void OnEditClick(object sender, EventArgs e)
        {
            if (CurrentShow != null)
            {
                MainWindow.PageChange.Invoke(this, new PageEventArgs(new CreateShow(CurrentShow)));
            }
            else
            {
                //todo: errorhandling
                return;
            }
        }
    }
}
