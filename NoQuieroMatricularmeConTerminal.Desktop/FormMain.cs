using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsControlLibrary;

namespace NoQuieroMatricularmeConTerminal.Desktop
{
    public partial class FormMain : Form
    {

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartSession();
            UIControls.DimBackground(this, new FormLogin());
        }

        private void StartSession()
        {
            try
            {
                SSHSessionManager session = new SSHSessionManager(UPRCampus.Mayaguez);

                MessageBox.Show(session.Start());
            }
            catch (Exception)
            {
            }
        }
    }
}
