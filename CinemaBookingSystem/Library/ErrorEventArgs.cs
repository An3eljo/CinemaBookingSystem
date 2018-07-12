using System;

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
