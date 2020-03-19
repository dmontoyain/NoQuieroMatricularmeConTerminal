// <copyright file="FormMain.cs" company="Dagoberto Montoya">
// Copyright (c) Dagoberto Montoya. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace NoQuieroMatricularmeConTerminal.Desktop
{
    using System;
    using System.Windows.Forms;
    using WinFormsControlLibrary;

    public partial class FormMain : Form
    {
        SSHSessionManager session = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormMain"/> class.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            StartSession();

            UIControls.DimBackground(this, new FormLogin());
        }

        private void StartSession()
        {
            try
            {
                this.session = new SSHSessionManager(UPRCampus.Mayaguez);

            }
            catch (Exception ex)
            {
            }
        }
    }
}
