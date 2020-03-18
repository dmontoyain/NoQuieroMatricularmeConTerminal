// <copyright file="FormLogin.cs" company="Dagoberto Montoya">
// Copyright (c) Dagoberto Montoya. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace NoQuieroMatricularmeConTerminal.Desktop
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

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

        private void ButtonOK_Click(object sender, EventArgs e)
        {
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
