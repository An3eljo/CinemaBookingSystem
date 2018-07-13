using System;
using System.Windows.Controls;

namespace CinemaBookingSystem.Library
{
    public class PageEventArgs : EventArgs
    {
        private Page _page;

        public Page Page
        {
            get { return _page; }
        }

        public PageEventArgs(Page page)
        {
            _page = page;
        }
    }
}
