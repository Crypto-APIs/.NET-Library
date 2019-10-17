namespace CryptoApisLibrary.Misc
{
    public class ProxyCredentials
    {
        public ProxyCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public ProxyCredentials(string host, int port, string username, string password, string domain = null)
        {
            Host = host;
            Port = port;
            Username = username;
            Password = password;
            Domain = domain;
        }

        public string Host { get; }
        public int Port { get; }
        public string Username { get; }
        public string Password { get; }
        public string Domain { get; }
    }
}