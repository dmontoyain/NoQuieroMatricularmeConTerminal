// <copyright file="UPRMPortal.cs" company="Dagoberto Montoya">
// Copyright (c) Dagoberto Montoya. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace NoQuieroMatricularmeConTerminal.Desktop.UPRPortals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Renci.SshNet;

    /// <summary>
    /// Class <see cref="UPRMPortal"/> controls and contains all the logic for communication with the UPR Mayaguez Campus Portal.
    /// </summary>
    public class UPRMPortal : UPRPortal
    {
        private static readonly int UPRMPort = 22;
        private static readonly string UPRMHostname = "rumad.uprm.edu";
        private static readonly string UPRMUsername = "estudiante";
        private static readonly string UPRMPassword = string.Empty;

        private List<string> MenuDelimiters = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UPRMPortal"/> class.
        /// </summary>
        public UPRMPortal()
            : base(UPRMUsername, UPRMPassword, UPRMHostname, UPRMPort)
        {
            Initialize();
            Open();
        }

        private void Initialize()
        {
            MenuDelimiters.Add("HO");
            MenuDelimiters.Add("H1");
            MenuDelimiters.Add("H2");
            MenuDelimiters.Add("H3");
            MenuDelimiters.Add("H4");
            MenuDelimiters.Add("H5");
            MenuDelimiters.Add("H6");
            MenuDelimiters.Add("H7");
            MenuDelimiters.Add("H8");
            MenuDelimiters.Add("H9");
            MenuDelimiters.Add("H1O");

        }

        public override void Open()
        {
            StringBuilder rawMessage = new StringBuilder();

            try
            {
                State = 1;
                //Thread.Sleep(1000);
                using (var shellStream = this.SshClient.CreateShellStream(this.Username, 0, 0, 0, 0, 4096))
                {
                    while (shellStream.DataAvailable)
                    {
                        rawMessage.Append(shellStream.Read());
                    }
                }
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("sshtest.txt", ex.Message);
            }

            System.IO.File.AppendAllText("sshtest.txt", rawMessage.ToString());

            string message = rawMessage.ToString();
            string[] splitmsg = message.Split(new char[] { '\u001b' });

            this.MenuOptions.Clear();
            bool checkformenu = false;

            foreach (string msg in splitmsg)
            {
                if (checkformenu)
                {
                    foreach (string d in this.MenuDelimiters)
                    {
                        if (msg.Contains(d))
                        {
                            this.MenuOptions.Add(int.Parse(d.Substring(1)), msg.Substring(msg.IndexOf(d) + d.Length));

                            break;
                        }
                    }
                }
                else
                {
                    checkformenu = msg.ToUpper().Contains("MENU");
                }
            }

            string raw = message.ToString();
        }

        public override void GoTo()
        {
        }

        public override void Start()
        {
        }

        public override void Terminate()
        {
        }

        public override void ValidateState()
        {
        }

    }
}
