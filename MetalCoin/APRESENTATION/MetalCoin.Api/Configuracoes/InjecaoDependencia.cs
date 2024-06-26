using Metalcoin.Core.Interfaces.Repositories;
using Metalcoin.Core.Interfaces.Services;
using MetalCoin.Application.Services;
using MetalCoin.Infra.Data.Repositories;

namespace MetalCoin.Api.Configuracoes
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection ResolveDependencias
            (this IServiceCollection services)
        {
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

            return services;
        }
    }
}
