using CandidateMGMT.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CandidateMGMT.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<ICandidateService, CandidateService>();
            builder.Services.AddScoped<ILevelService, LevelService>();
            builder.Services.AddScoped<IPositionService, PositionService>();
            builder.Services.AddScoped<IUploadService, UploadService>();

            await builder.Build().RunAsync();
        }
    }
}
