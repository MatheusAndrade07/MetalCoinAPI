using MetalCoin.Web.Spa;
using MetalCoin.Web.Spa.Core.Endpoint;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//injeção de dependêcia  - projeto converte as categorias
builder.Services.AddScoped<ICategoriaEndpoint, CategoriaEndpoint>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
