using System;
using Nancy.Hosting.Self;
using Mono.Unix;

namespace Nancy.Linux
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri =
                new Uri("http://localhost:8099");
            Console.WriteLine($"Your application is running on {uri}");
            Console.WriteLine("Press any [Enter] to close the host.");

            using (var host = new NancyHost(uri))
            {
                host.Start();
                if(Type.GetType("Mono.Runtime") != null)
                {
                    UnixSignal.WaitAny(new[] {
                        new UnixSignal(Mono.Unix.Native.Signum.SIGINT),
                        new UnixSignal(Mono.Unix.Native.Signum.SIGTERM),
                        new UnixSignal(Mono.Unix.Native.Signum.SIGQUIT),
                        new UnixSignal(Mono.Unix.Native.Signum.SIGHUP)
                    });
                }
               else
                Console.ReadLine();
                host.Stop();
            }
        }
    }
}
