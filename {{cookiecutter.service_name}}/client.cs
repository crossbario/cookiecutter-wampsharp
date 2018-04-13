using System;
using System.Threading.Tasks;
using WampSharp.V2;
using WampSharp.V2.Client;
using WampSharp.V2.Fluent;

namespace MyService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "ws://127.0.0.1:8080/ws/";
            string realm = "realm1";

            WampChannelFactory channelFactory = new WampChannelFactory();

            IWampChannel channel =
                channelFactory.ConnectToRealm(realm)
                    .WebSocketTransport(new Uri(url))
                    .JsonSerialization()
                    .Build();

            // Fire this code when the connection establishes
            channel.RealmProxy.Monitor.ConnectionEstablished += (sender, e) =>
            {
                Console.WriteLine("Session open! :" + e.SessionId);
            };

            // Fire this code when the connection has broken
            channel.RealmProxy.Monitor.ConnectionBroken += (sender, e) =>
            {
                Console.WriteLine("Session closed! :" + e.Reason);
            };

            await channel.Open().ConfigureAwait(false);

            // Your code goes here: use WAMP via the channel variable to
            // call, register, subscribe and publish ..

            await Task.Delay(1000);
        }
    }
}
