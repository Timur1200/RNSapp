using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RNSapp.Service
{
    internal class FrameStore
    {
        public static Frame MainFrame { get; set; }
        public static void Back()
        {
            if (MainFrame.CanGoBack) MainFrame.NavigationService.GoBack(); 
        }
    }
}
