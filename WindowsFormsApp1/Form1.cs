using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void UpdateText()
        {
            this.BeginInvoke(
                method: new Action(
                    UpdateTitle));
        }
        
        private void UpdateTitle()
        {
            this.Text = DateTime
                .Now
                .ToString("h:mm:ss tt zz");
        }
    }
}