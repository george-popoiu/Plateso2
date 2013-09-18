using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Plateso2.Modules
{
    public static class Message
    {
        public static void Show(string caption, string text)
        {
            MessageWindow message = new MessageWindow();
            message.Show(caption, text);
            message.Close();
            message = null;
        }
    }
}

