using BattleShip.Models;
using BattleShip.UI.Service.Contracts;
using Microsoft.AspNetCore.Components;

namespace BattleShip.UI.Pages
{
    public class ShipsBase:ComponentBase
    {
        [Inject]
        public IShipService ShipService { get; set; }

        public IEnumerable<BattleShipDto> Ships { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Ships=await ShipService.GetShips();
        }
    }
}
 