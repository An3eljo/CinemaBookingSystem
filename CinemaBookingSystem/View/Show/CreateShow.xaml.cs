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
            //todo: set price to 10
        }

        private void OnCreateClick(object sender, EventArgs e)
        {
            var everyFieldInUiIsFilled = true; //var to simulate state of all fields on Ui
            if (!everyFieldInUiIsFilled)
            {
                //dislpay warning "not all fields are filled"
                return;
            }

            var choosenFilm = Model.Film.ListOfFilms[0]; //choosen film from dropdown
            var parsedDateTime = new DateTime(); //parsed DateTime from DatePicker and Hours/Minutes/Seconds from inputfield
            var choosenShowroom = ShowRoom.ShowRooms[0]; //choosen Showroom from dropdown
            new Model.Show(choosenFilm, parsedDateTime, choosenShowroom);
        }
    }
}
