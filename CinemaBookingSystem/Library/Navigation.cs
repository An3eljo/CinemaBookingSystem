using System;
using System.Windows.Controls;

namespace CinemaBookingSystem.Library
{
    public static class Navigation
    {
        public static EventHandler<PageEventArgs> PageChange;
        private static Frame _frame;

        public static void Init(ref Frame frame)
        {
            _frame = frame;
        }

        public static void OnPageChanged(object sender, PageEventArgs e)
        {
            var newPage = e.Page;
            _frame.Navigate(newPage);
        }
    }
}
