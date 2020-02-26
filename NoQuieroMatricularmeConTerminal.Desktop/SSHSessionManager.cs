// <copyright file="SSHSessionManager.cs" company="Dagoberto Montoya">
// Copyright (c) Dagoberto Montoya. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace NoQuieroMatricularmeConTerminal.Desktop
{
    using System;
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

        private string username = string.Empty;
        private string password = string.Empty;

        public UPRCampus UPRCampus { get; private set; } = UPRCampus.None;

        /// <summary>
        /// Initializes a new instance of the <see cref="SSHSessionManager"/> class. This call provides a set of commands and functions the user uses to interact with their created session.
        /// </summary>
        /// <param name="uprcampus">Must receive one of the valid UPR campus supported in the application.</param>
        public SSHSessionManager(UPRCampus uprcampus)
        {
            this.UPRCampus = uprcampus;

            this.Initialize();
        }

        /// <summary>
        /// Attempts to open a SSH connection to the campus server. This connection is to be reused throughout the user navigation.
        /// </summary>
        /// <returns>Message returned by the UPR Campus session start.</returns>
        public string Start()
        {
            string message = string.Empty;

            try
            {
                using (var sshclient = new SshClient(this.connectionInfo))
                {
                    sshclient.Connect();

                    using (var shellStream = sshclient.CreateShellStream("student", 0, 0, 0, 0, 4096))
                    {
                        shellStream.WriteLine("5");
                        message = shellStream.Read();
                    }

                    sshclient.Disconnect();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return message;
        }

        private void Initialize()
        {
            switch (this.UPRCampus)
            {
                case UPRCampus.Mayaguez:
                    this.hostname = Resources.UPRCampusHosts.Mayaguez;
                    this.port = 22;
                    this.username = "estudiante";
                    break;
                default:
                    throw new ApplicationException("Ssh session for campus 'None' can't be initialized. Send a valid campus.");
            }

            this.CreateConnection();
        }

        private void CreateConnection()
        {
            try
            {
                this.connectionInfo = null;

                this.connectionInfo = new ConnectionInfo(this.hostname, this.port, this.username,
                new AuthenticationMethod[]
                {
                    // Pasword based Authentication
                    new PasswordAuthenticationMethod(this.username, this.password),
                });
            }
            catch (Exception)
            {
            }
        }
    }
}
