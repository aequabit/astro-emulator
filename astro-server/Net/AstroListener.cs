using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using NetworkTypes;

namespace Astro.Server.Net
{
    class AstroListener
    {
        private TcpListener _tcpListener;
        private Thread _serverThread;
        private BinaryFormatter _formatter = new BinaryFormatter();
        private Dictionary<string, IAstroRoute> _routes = new Dictionary<string, IAstroRoute>();

        public AstroListener(ushort port)
        {
            _tcpListener = new TcpListener(IPAddress.Any, port);
        }

        public void Start()
        {
            InitializeRoutes();

            _serverThread = new Thread(new ThreadStart(ListenForClients));
            _serverThread.Start();
        }

        private void InitializeRoutes()
        {
            foreach (var route in ImplementationDiscovery.First<AstroRouteAttribute, IAstroRoute>(AppDomain.CurrentDomain))
            {
                var attribute = route.Key;
                var Route = route.Value;
                _routes[attribute.Route] = (IAstroRoute)Activator.CreateInstance(Route);
            }
        }

        private void ListenForClients()
        {
            _tcpListener.Start();

            _tcpListener.Server.SendBufferSize = 10000000;
            _tcpListener.Server.ReceiveBufferSize = 10000000;
            _tcpListener.Server.NoDelay = true;

            while (true)
            {
                var client = _tcpListener.AcceptTcpClient();

                var clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
                clientThread.Start(client);
            }
        }

        private void HandleClient(object clientObject)
        {
            var client = (TcpClient)clientObject;

            while (client.Connected)
            {
                var stream = client.GetStream();

                // Deserialize request
                Request request = null;
                try
                {
                    request = (Request)_formatter.Deserialize(stream);
                }
                catch (Exception ex)
                {
                    continue;
                }

                // No route handler registered
                if (!_routes.ContainsKey(request.Command))
                {
                    Console.WriteLine($"Unhandled request: {request.Command}");
                    continue;
                }

                // Get response from route handler
                var handler = _routes[request.Command];
                var response = handler.Handle(request);

                // Serialize and send response
                _formatter.Serialize(stream, response);
            }
        }
    }
}
