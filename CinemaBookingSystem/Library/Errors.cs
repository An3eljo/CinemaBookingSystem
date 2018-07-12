using System;
using System.Collections.Generic;
using CinemaBookingSystem.View;

namespace CinemaBookingSystem.Library
{
    public static class Errors
    {
        public static EventHandler<ErrorEventArgs> ErrorHandler;
        public static Dictionary<int, string> ErrorMessages;

        private static void OnErrorThrow(object sender, ErrorEventArgs e)
        {
            var errorWindow = new Error(e.Message);
            errorWindow.Show();
        }

        public static void Init()
        {
            ErrorHandler += OnErrorThrow;

            InitErrorMessages();
        }

        private static void InitErrorMessages()
        {
            ErrorMessages = new Dictionary<int, string>()
            {
                {0, "Hours and minutes have to be in a valid Format" },
                {1, "Hours and minutes are required" },
                {2, "Price have to be in a valid Format" }
            };
        }
    }
}
