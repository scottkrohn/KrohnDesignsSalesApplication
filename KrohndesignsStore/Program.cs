using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// TODO: Write program to generate item numbers.

namespace KrohndesignsStore
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginDialog gui = new LoginDialog();
            gui.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            gui.ShowDialog();
        }
    }
}