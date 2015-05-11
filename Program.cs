using System;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;

namespace SpecUI
{
    public static class Program
    {
        public static void Main(string[] args) {
            const int port = 8888;
            var options = new StartOptions();
            options.Urls.Add(String.Format("http://localhost:{0}", port));
            options.Urls.Add(String.Format("http://127.0.0.1:{0}", port));
            using (WebApp.Start<Startup>(options))
            {
                Console.ReadLine();
            }
        }
    }
}
