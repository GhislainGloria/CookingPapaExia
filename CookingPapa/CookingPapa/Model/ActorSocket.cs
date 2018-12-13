using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading;


namespace Model
{
	public class ActorSocket : Actor
    {
		// https://docs.microsoft.com/fr-fr/dotnet/framework/network-programming/asynchronous-server-socket-example
		// https://docs.microsoft.com/fr-fr/dotnet/framework/network-programming/asynchronous-client-socket-example
		protected Socket socket;
		public static ManualResetEvent allDone = new ManualResetEvent(false);
		private static ManualResetEvent connectDone = new ManualResetEvent(false);
		private static ManualResetEvent sendDone = new ManualResetEvent(false);
		private static ManualResetEvent receiveDone = new ManualResetEvent(false); 

		public ActorSocket(string ClientOrServer)
        {
			// Establish the local endpoint for the socket.  
            // The DNS name of the computer  
            // running the listener is "host.contoso.com".  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());  
            IPAddress ipAddress = ipHostInfo.AddressList[0];
			Name = "counter";

			if(ClientOrServer == "server")
			{
				IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP socket.
                Socket listener = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Bind the socket to the local endpoint and listen for incoming connections.  
                try
                {
                    listener.Bind(localEndPoint);
                    listener.Listen(1);

                    // Set the event to nonsignaled state.  
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.
					Console.WriteLine(this + " server: Waiting for a connection...");
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Wait until a connection is made before continuing.  
                    allDone.WaitOne();
               
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
			}
			else
			{
				IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

				// Create a TCP/IP socket.  
				socket = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.  
				socket.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), socket);
                connectDone.WaitOne();

			}
        }

		public void SendToServer(string s)
		{
			Send(socket, s);
		}

		private static void ConnectCallback(IAsyncResult ar) {  
            try {  
                // Retrieve the socket from the state object.  
                Socket client = (Socket) ar.AsyncState;  
      
                // Complete the connection.  
                client.EndConnect(ar);  
      
                Console.WriteLine(
					"Socket connected to {0}",  
				     client.RemoteEndPoint
				);  
      
                // Signal that the connection has been made.  
                connectDone.Set();  
            } catch (Exception e) {  
    			Console.WriteLine(e);  
            }  
        } 

		public static void AcceptCallback(IAsyncResult ar) {  
            // Signal the main thread to continue.  
            allDone.Set();  
      
            // Get the socket that handles the client request.  
            Socket listener = (Socket)ar.AsyncState;  
            Socket handler = listener.EndAccept(ar);  
      
            // Create the state object.  
            StateObject state = new StateObject();  
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,  
                new AsyncCallback(ReadCallback), state);
        }

		public static void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket.   
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.  
                state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));

                // Check for end-of-file tag. If it is not there, read   
                // more data.  
                content = state.sb.ToString();
                if (content.IndexOf("<EOF>") > -1)
				{
                    // All the data has been read from the   
                    // client. Display it on the console.  
                    Console.WriteLine("Read {0} bytes from socket. \nData : {1}",
                        content.Length, content);

					state.sb.Clear();
                    // Echo the data back to the client.  
                    //Send(handler, content);
                }

				handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                
            }
        }

		protected static void Send(Socket client, String data) {  
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(data);  

            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, byteData.Length, 0,  
                new AsyncCallback(SendCallback), client);  
        }

		protected static void SendCallback(IAsyncResult ar) {  
            try {  
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;  
      
                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);  
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);  
      
                // Signal that all bytes have been sent.  
                sendDone.Set();
            } catch (Exception e) {  
                Console.WriteLine(e.ToString());  
            }  
        }
    }

	// State object for reading client data asynchronously  
    public class StateObject {  
        // Client  socket.  
        public Socket workSocket = null;  
        // Size of receive buffer.  
        public const int BufferSize = 1024;  
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];  
    // Received data string.  
        public StringBuilder sb = new StringBuilder();    
    }  
}
