using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

namespace Model
{
	public class ActorSocket : AbstractActor
    {
		// https://docs.microsoft.com/fr-fr/dotnet/framework/network-programming/asynchronous-server-socket-example
		// https://docs.microsoft.com/fr-fr/dotnet/framework/network-programming/asynchronous-client-socket-example
		protected Socket socketListen;
		protected Socket socketWrite;
		public ManualResetEvent allDone = new ManualResetEvent(false);
		private ManualResetEvent connectDone = new ManualResetEvent(false);
		private ManualResetEvent sendDone = new ManualResetEvent(false);
		private ManualResetEvent receiveDone = new ManualResetEvent(false);

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
				InitListen(11000);            
				InitWrite(11001);         
			}
			else
			{
				InitWrite(11000);
				InitListen(11001);
			}
        }

        private void InitWrite(int port)
		{
			IPAddress ipAddress = IPAddress.Parse("127.0.0.1"); 

			IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

            // Create a TCP/IP socket.  
			socketWrite = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Connect to the remote endpoint.
            socketWrite.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), socketWrite);
            connectDone.WaitOne();
		}

        private void InitListen(int port)
		{
			IPAddress ipAddress = IPAddress.Parse("127.0.0.1"); 

			IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
			IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

            // Create a TCP/IP socket.
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

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
                Console.WriteLine(e);
            }
		}

		public void Send(string s)
		{
			Send(socketWrite, s);
		}

		private void ConnectCallback(IAsyncResult ar) {  
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

		public void AcceptCallback(IAsyncResult ar) {  
            // Signal the main thread to continue.  
            allDone.Set();  
      
            // Get the socket that handles the client request.  
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

			socketListen = handler;
      
            // Create the state object.  
            StateObject state = new StateObject();  
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,  
                new AsyncCallback(ReadCallback), state);
        }

		public void ReadCallback(IAsyncResult ar)
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
                    //Console.WriteLine("Read {0} bytes from socket. \nData : {1}",
                    //    content.Length, content);

					TriggerEvent("DataReceived", content);

					state.sb.Clear();
                }

				handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                
            }
        }

		protected void Send(Socket client, String data) {  
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(data);  

            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, byteData.Length, 0,  
                new AsyncCallback(SendCallback), client);  
        }

		protected void SendCallback(IAsyncResult ar) {  
            try {  
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;  
      
                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                //Console.WriteLine("Sent {0} bytes to server.", bytesSent);  
      
                // Signal that all bytes have been sent.  
                sendDone.Set();
            } catch (Exception e) {  
                Console.WriteLine(e.ToString());  
            }  
        }

		public override void NextTick(List<AbstractActor> AllActors)
		{
			Strategy.Behavior(this, AllActors);         
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
