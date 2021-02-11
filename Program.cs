using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroCliente.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CadastroClienteApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            VerificarConexao();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void VerificarConexao()
        {
            using (var _context = new ClienteContext())
            {
                if (_context.Database.CanConnect())
                {
                    Console.WriteLine("Database is running...");
                }
                else
                {
                    Console.WriteLine("No database has found, please config your connection in file: /Data/ClienteContext.cs\n" 
                                        + "or verify if you enter a command: dotnet ef database update.");
                
                    System.Environment.Exit(0);
                }
            }
        }
    }
}
