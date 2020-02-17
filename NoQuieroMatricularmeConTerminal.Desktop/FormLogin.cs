using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoQuieroMatricularmeConTerminal.Desktop
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color c = Color.FromArgb(69, 69, 69);
            Pen p = new Pen(c, 0.3f);
            e.Graphics.DrawRectangle(p, 0, 0, this.Width, this.Height);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

        }
    }
}
