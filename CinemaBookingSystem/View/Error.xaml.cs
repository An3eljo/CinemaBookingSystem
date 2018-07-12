using System.Windows;

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
            Init(message);
        }

        private void Init(string message)
        {
            if (message != null)
            {
                LabelError.Content = "An error occured: " + message;
            }
            else
            {
                LabelError.Content = "An unhandled error occured";
            }
        }

        private void ButtonClose_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
