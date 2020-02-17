using Chilkat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoQuieroMatricularmeConTerminal.Desktop
{
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

        public UPRCampus UPRCampus { get; private set; } = UPRCampus.None;

        string hostname = string.Empty;
        int port = 0;

        public SSHSessionManager(UPRCampus uprcampus)
        {
            this.UPRCampus = uprcampus;

            Initialize();
        }

        private void Initialize()
        {
            switch (this.UPRCampus)
            {
                case UPRCampus.Mayaguez:
                    this.hostname = Resources.UPRCampusHosts.Mayaguez;
                    this.port = 22;
                    break;
                default:
                    throw new ApplicationException("Ssh session for campus 'None' can't be initialized. Send a valid campus.");
            }
        }

        private void UnlockChilkat()
        {
            string message = string.Empty;
            // property after unlocking.  For example:
            Chilkat.Global glob = new Chilkat.Global();
            bool success = glob.UnlockBundle("Anything for 30-day trial");
            if (success != true)
            {
                return;
            }

            int status = glob.UnlockStatus;
            if (status == 2)
            {
            }
            else
            {
            }


        }

        public string Start()
        {
            UnlockChilkat();
            string message = string.Empty;


            Ssh ssh = new Chilkat.Ssh();

            bool success = ssh.Connect(this.hostname, this.port);

            if (!success)
            {
                message = ssh.LastErrorText;
            }

            int channelNum;
            channelNum = ssh.OpenSessionChannel();
            if (channelNum < 0)
            {
                message = ssh.LastErrorText;
            }

            return message;
        }
    }
}
