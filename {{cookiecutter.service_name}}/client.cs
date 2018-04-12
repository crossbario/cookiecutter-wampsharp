using System;
using WampSharp.V2;
using WampSharp.V2.Client;

namespace MyNamespace
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DefaultWampChannelFactory factory =
                new DefaultWampChannelFactory();

            const string serverAddress = "ws://127.0.0.1:8080/ws";

            IWampChannel channel =
                factory.CreateJsonChannel(serverAddress, "realm1");

            channel.Open().Wait(5000);

            IWampRealmProxy realmProxy = channel.RealmProxy;

            int received = 0;
            IDisposable subscription = null;

            subscription =
                realmProxy.Services.GetSubject<int>("com.myapp.topic1")
                     .Subscribe(x =>
                         {
                             Console.WriteLine("Got Event: " + x);

                             received++;

                             if (received > 5)
                             {
                                 Console.WriteLine("Closing ..");
                                 subscription.Dispose();
                             }
                         });

            Console.ReadLine();
        }
    }
}
