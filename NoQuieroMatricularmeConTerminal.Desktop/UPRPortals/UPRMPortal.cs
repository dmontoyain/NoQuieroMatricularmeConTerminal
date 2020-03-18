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
    using System.Threading.Tasks;
    using Renci.SshNet;

    /// <summary>
    /// Class <see cref="UPRMPortal"/> controls and contains all the logic for communication with the UPR Mayaguez Campus Portal.
    /// </summary>
    public class UPRMPortal : UPRPortal
    {
        public override int Port { get => 22; }

        public override string HostName { get => "rumad.uprm.edu"; }

        public override string Username { get => "estudiante"; }

        public override string Password { get => string.Empty; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UPRMPortal"/> class.
        /// </summary>
        public UPRMPortal()
            : base()
        {
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
