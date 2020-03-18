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
        private string hostname = string.Empty;
        private int port = 0;
        private ConnectionInfo connectionInfo = null;
        private SshClient sshClient = null;

        private string username = string.Empty;
        private string password = string.Empty;

        private ILogger logger = null;

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
        public string Start()
        {
            StringBuilder rawMessage = new StringBuilder();

            try
            {
                using (var shellStream = this.sshClient.CreateShellStream("student", 0, 0, 0, 0, 4096))
                {
                    while (shellStream.DataAvailable)
                    {
                        rawMessage.Append(shellStream.Read());
                    }
                }
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
                System.IO.File.AppendAllText("sshtest.txt", this.ErrorMessage);
            }


            System.IO.File.AppendAllText("sshtest.txt", rawMessage.ToString());

            string message = rawMessage.ToString();
            string[] splitmsg = message.Split(new char[] { '\u001b' });
            return message.ToString();
        }

        private void Initialize()
        {
            switch (this.UPRCampus)
            {
                case UPRCampus.Mayaguez:
                    UPRPortal uprportal = new UPRMPortal();
                    break;
                default:
                    throw new ApplicationException("Ssh session for campus 'None' can't be initialized. Send a valid campus.");
            }

            this.CreateConnection();
        }

        private void ClearLocalParams()
        {
            this.ErrorMessage = string.Empty;
        }

        private void CreateConnection()
        {
            try
            {
                this.connectionInfo = null;

                this.connectionInfo = new ConnectionInfo(this.hostname, this.port, this.username,
                new AuthenticationMethod[]
                {
                    new PasswordAuthenticationMethod(this.username, this.password),
                });

                this.sshClient = new SshClient(this.connectionInfo);
                this.sshClient.Connect();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
