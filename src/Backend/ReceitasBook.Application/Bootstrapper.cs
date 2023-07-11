using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReceitasBook.Application.Service.Criptografia;
using ReceitasBook.Application.Service.JWT;
using ReceitasBook.Application.UseCase.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasBook.Application
{
    public static class Bootstrapper
    {
        public static void AddAplication(this IServiceCollection services, IConfiguration configuration)
        {

            AdicionarchaveSenha(services, configuration);
            AdicionarJWT(services, configuration);
            services.AddScoped<IRegistrarUsuarioUseCase, RegistrarUsuarioUseCase>();
         
        }

        private static void AdicionarchaveSenha(this IServiceCollection services, IConfiguration configuration)
        {
            var hashepassword = configuration.GetSection("Configuration:passwordencripty").Value;

            services.AddScoped(options => new EncriptadorPassword(hashepassword));
        }

        private static void AdicionarJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var TempoVidaToken = configuration.GetSection("Configuration:TempoVidaToken").Value;
            var ChaveToken = configuration.GetSection("Configuration:ChaveToken").Value;
            services.AddScoped(options => new TokenController(int.Parse(TempoVidaToken), ChaveToken));
        }
    }
}
