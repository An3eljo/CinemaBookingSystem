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
using System.Windows.Shapes;

namespace CinemaBookingSystem.View
{
    /// <summary>
    /// Interaction logic for Error.xaml
    /// </summary>
    public partial class Error : Window
    {
        //todo: UI
        public Error(string message)
        {
            InitializeComponent();

        }

        private void Init(string message)
        {
            if (message != null)
            {
                //todo: set text of labelerror
            }
            else
            {
                //todo: set errormessage "no errormessage"
            }
        }
    }
}
