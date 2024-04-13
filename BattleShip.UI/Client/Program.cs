using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BattleShip.UI;
using BattleShip.UI.Service.Contracts;
using BattleShip.UI.Service;
using Microsoft.JSInterop;

namespace BattleShip.UI;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7237/") });

        builder.Services.AddScoped<IShipService, ShipService>();
        

        await builder.Build().RunAsync();
    }
}
