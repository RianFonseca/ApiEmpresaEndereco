using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Identity.Client;

namespace Teste
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();


            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<AppDbContext>();
                InitializeData(dbContext);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void InitializeData(AppDbContext Dbcontext)
        {
            EmpresaController empresaController = new EmpresaController(Dbcontext);
            var empresa = new Empresa(1, "Empresa Teste");
            var endereco = new Endereco(empresa.Id);
            empresa.CNPJ = 1234;
            empresa.NomeFantasia = "Teste";
            Dbcontext.Empresas.Add(empresa);

            EndereçoController endereçoController = new EndereçoController(Dbcontext);
            var endereço = new Endereco (1);
            endereco.Id = 1;
            endereco.Cep = 91030080;
            endereco.EnderecoCompleto = "Av.Tapiaçu";
            endereco.Numero = 340;
            endereco.Bairro = "Passo d'Areia";
            endereco.Cidade = "Porto Alegre";
            Dbcontext.Enderecos.Add(endereco);
          
            Dbcontext.SaveChanges();
        }  

    }

}