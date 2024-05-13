using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers_For_Server
{
    public class Servers
    {
        private static readonly Servers instance = new Servers();
        private List<string> serverList;
        private static readonly object lockObject = new object();
        private Servers()
        {
            serverList = new List<string>();
        }
        public static Servers GetInstance()
        {
            return instance;
        }
        public bool AddServer(string serverAddress)
        {
            lock (lockObject)
            {
                if (serverAddress.StartsWith("http://") || serverAddress.StartsWith("https://"))
                {
                    if (!serverList.Contains(serverAddress))
                    {
                        serverList.Add(serverAddress);
                        return true;
                    }
                }
                return false;
            }
        }
        public List<string> GetHttpServers()
        {
            lock (lockObject)
            {
                return serverList.FindAll(server => server.StartsWith("http://"));
            }
        }
        public List<string> GetHttpsServers()
        {
            lock (lockObject)
            {
                return serverList.FindAll(server => server.StartsWith("https://"));
            }
        }
    }
}
