using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsControlLibrary
{
    public partial class UIControls
    {
        public static void DimBackground(Form backgroundForm, Form showForm)
        {
            try
            {
                using (Form shadow = new Form())
                {
                    shadow.MinimizeBox = false;
                    shadow.MaximizeBox = false;
                    shadow.ControlBox = false;

                    shadow.Text = "";
                    shadow.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    shadow.Size = backgroundForm.Size;
                    shadow.BackColor = Color.Black;
                    shadow.Opacity = 0.5;
                    shadow.Location = backgroundForm.Location;
                    showForm.TopLevel = true;
                    shadow.Show(backgroundForm);
                    showForm.ShowDialog(shadow);

                }
            }
            catch (Exception) { }
        }
    }
}
