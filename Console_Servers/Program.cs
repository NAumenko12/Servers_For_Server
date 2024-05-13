using Servers_For_Server;

namespace Console_Servers
{
    class Program
    {
        static void Main()
        {
            Servers servers = Servers.GetInstance();

            Console.WriteLine("Добавление серверов:");
            Console.WriteLine("Добавляем 'http://example.com': " + servers.AddServer("http://example.com"));
            Console.WriteLine("Добавляем 'https://example.org': " + servers.AddServer("https://example.org"));
            Console.WriteLine("Добавляем 'ftp://notallowed.com': " + servers.AddServer("ftp://notallowed.com")); // Не добавится из-за префикса
            Console.WriteLine("Добавляем 'http://example.com': " + servers.AddServer("http://example.com")); // Дубликат - не добавится

            Console.WriteLine("\nHTTP сервера:");
            var httpServers = servers.GetHttpServers();
            foreach (var server in httpServers)
            {
                Console.WriteLine(server);
            }

            Console.WriteLine("\nHTTPS сервера:");
            var httpsServers = servers.GetHttpsServers();
            foreach (var server in httpsServers)
            {
                Console.WriteLine(server);
            }
        }
    }
}
