using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooRunner.GUI
{
    public partial class Informations : UserControl
    {
        public Informations()
        {
            InitializeComponent();
        }

        public void DisplayInfos(string informations)
        {
            _zoomTextBox.Text = informations;
        }

        public void DisplayWatchs(string watchs)
        {
            this.Invoke((MethodInvoker)delegate { _watchsTextBox.Text = watchs; });
        }
    }
}
