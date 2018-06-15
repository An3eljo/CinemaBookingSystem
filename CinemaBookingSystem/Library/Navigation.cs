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
    class Navigation
    {
        public static List<Page> PagesStack { get; set; }

        public static Page PushPage(Page page)
        {
            PagesStack.Add(page);
            return page;
        }
    }
}
