using System.Net.Sockets;


namespace Model
{
	public class ActorSocket : Actor
    {
		// https://docs.microsoft.com/fr-fr/dotnet/framework/network-programming/asynchronous-server-socket-example
		// https://docs.microsoft.com/fr-fr/dotnet/framework/network-programming/asynchronous-client-socket-example
		protected Socket socket;

        public ActorSocket(string ClientOrServer)
        {
			
        }
    }
}
