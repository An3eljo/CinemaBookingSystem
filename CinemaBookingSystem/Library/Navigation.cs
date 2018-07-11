using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Navigation;

namespace CinemaBookingSystem.Library
{
    public static class Navigation
    {
        public static EventHandler<PageEventArgs> PageChange;
        private static Frame _frame;

        public static void Initialize(ref Frame frame)
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
