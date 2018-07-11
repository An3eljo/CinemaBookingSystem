using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Library
{
    public class ErrorEventArgs : EventArgs
    {
        private string _message;

        public string Message
        {
            get { return _message; }
        }

        public ErrorEventArgs(string message)
        {
            _message = message;
        }
    }
}
