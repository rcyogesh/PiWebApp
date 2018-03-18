using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MVCApp
{
    public class Program
    {
        internal static evolution.Program evolution;
        
        public static void Main(string[] args)
        {
            evolution = new evolution.Program();
            Task.Run((Action)evolution.Start);
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls(File.ReadAllLines("urls.txt"))
                .Build();
    }
}
