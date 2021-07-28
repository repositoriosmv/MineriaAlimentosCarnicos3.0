﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MineriaAlimentosCarnicos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                // COMENTAR PARA MODO DESARROLLO Y EJECUCIONES LOCALES HASTA LA MARCA
                //.UseIISIntegration()
                //.UseKestrel()
                //.UseContentRoot(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location))
                //.ConfigureAppConfiguration((hostingContext, config) =>
                //{
                //    IHostingEnvironment env = hostingContext.HostingEnvironment;
                //    config.SetBasePath(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location));
                //    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                //          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                //})
                // COMENTA HASTA AQUI
                .UseStartup<Startup>();
    }
}
