// <copyright file="SSHSessionManager.cs" company="Dagoberto Montoya">
// Copyright (c) Dagoberto Montoya. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace NoQuieroMatricularmeConTerminal.Desktop
{
    using System;
    using System.Text;
    using Microsoft.Extensions.Logging;
    using NoQuieroMatricularmeConTerminal.Desktop.UPRPortals;
    using Renci.SshNet;

    public enum UPRCampus
    {
        None,
        Mayaguez,
        Carolina,
        RioPiedras,
        Aguadilla,
        Cayey
    }

    public class SSHSessionManager
    {
        private ILogger logger = null;
        private UPRPortal UPRPortal = null;

        public UPRCampus UPRCampus { get; private set; } = UPRCampus.None;

        public string ErrorMessage { get; private set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="SSHSessionManager"/> class. This call provides a set of commands and functions the user uses to interact with their created session.
        /// </summary>
        /// <param name="uprcampus">Must receive one of the valid UPR campus supported in the application.</param>
        public SSHSessionManager(UPRCampus uprcampus)
        {
            this.UPRCampus = uprcampus;

            this.Initialize();
        }

        public SSHSessionManager(UPRCampus uprcampus, ILogger logger)
        {
            this.UPRCampus = uprcampus;

            this.Initialize();

            this.logger = logger;
        }

        /// <summary>
        /// Attempts to open a SSH connection to the campus server. This connection is to be reused throughout the user navigation.
        /// </summary>
        /// <returns>Message returned by the UPR Campus session start.</returns>
        public void Start()
        {
            this.UPRPortal.Open();
        }

        private void Initialize()
        {
            switch (this.UPRCampus)
            {
                case UPRCampus.Mayaguez:
                    this.UPRPortal = new UPRMPortal();
                    break;
                default:
                    throw new ApplicationException("Ssh session for campus 'None' can't be initialized. Send a valid campus.");
            }

        }

        private void ClearLocalParams()
        {
            this.ErrorMessage = string.Empty;
        }

    }
}
