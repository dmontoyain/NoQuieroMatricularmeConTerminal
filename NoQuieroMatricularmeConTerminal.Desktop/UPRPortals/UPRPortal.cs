using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;

namespace NoQuieroMatricularmeConTerminal.Desktop.UPRPortals
{
    public abstract class UPRPortal
    {
        public int State { get; private set; } = 0;

        public abstract int Port { get; }

        public abstract string HostName { get; }

        public abstract string Username { get; }

        public abstract string Password { get; }

        public SshClient SshClient { get; private set; } = null;

        public ConnectionInfo ConnectionInfo { get; private set; } = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="UPRPortal"/> class.
        /// </summary>
        public UPRPortal()
        {
            Initialize();
        }

        private void Initialize()
        {
            this.ConnectionInfo = new ConnectionInfo(this.HostName, this.Port, this.Username,
                new AuthenticationMethod[]
                {
                    new PasswordAuthenticationMethod(this.Username, this.Password),
                });

            this.SshClient = new SshClient(this.ConnectionInfo);
            this.SshClient.Connect();
        }

        public abstract void Start();

        public abstract void GoTo();

        public abstract void Terminate();

        public abstract void ValidateState();

    }
}
