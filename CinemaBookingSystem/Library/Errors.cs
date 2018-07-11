using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaBookingSystem.View;

namespace CinemaBookingSystem.Library
{
    public static class Errors
    {
        public static EventHandler<ErrorEventArgs> ErrorHandler;

        public static void OnErrorThrow(object sender, ErrorEventArgs e)
        {
            var errorWindow = new Error(e.Message);
            errorWindow.Show();
        }
    }
}
