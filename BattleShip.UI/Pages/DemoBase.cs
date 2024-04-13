using BattleShip.Models;
using BattleShip.UI.Service.Contracts;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;

namespace BattleShip.UI.Pages
{
    public class DemoBase: ComponentBase
    {
        [Inject]
        IShipService _shipService { get; set; }

        public List<ShipDto> AllShips { get; set; }

        private readonly HttpClient _httpClient;

        protected override async Task OnInitializedAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7237/api/GameBoard/GetComputerPlaceShips");
           
            if (response != null)
            {
                AllShips = await response.Content.ReadFromJsonAsync<List<ShipDto>>();                
            }
            
            
        }
    }
}
