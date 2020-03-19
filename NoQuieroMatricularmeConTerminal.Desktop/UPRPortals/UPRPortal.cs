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
        protected int State { get; set; } = 0;

        protected int Port { get; private set; }

        protected string HostName { get; private set; }

        protected string Username { get; private set; }

        protected string Password { get; private set; }

        public SshClient SshClient { get; private set; } = null;

        public ConnectionInfo ConnectionInfo { get; private set; } = null;

        public Dictionary<int, string> MenuOptions { get; private set; } = new Dictionary<int, string>();

        public string Header { get; private set; } = string.Empty;

        public string Message { get; private set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="UPRPortal"/> class.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        public UPRPortal(string username, string password, string hostname, int port)
        {
            this.Username = username;
            this.Password = password;
            this.HostName = hostname;
            this.Port = port;

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

        public abstract void Open();

        public abstract void Start();

        public abstract void GoTo();

        public abstract void Terminate();

        public abstract void ValidateState();

    }
}
