using BattleShip.Models;
using BattleShip.UI.Service;
using BattleShip.UI.Service.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System;

namespace BattleShip.UI.Pages
{
    public class ComputerGridBase: ComponentBase
    {
        [Inject]
        public IJSRuntime _jSRuntime { get; set; }

        [Inject]
        IShipService _shipService { get; set; }

        public List<ShipDto> AllShipsDemo { get; set; }


        protected override async Task OnInitializedAsync()
        {
            AllShipsDemo = (List<ShipDto>)await _shipService.GetAllShipsDemo();            
        }


        // Define a list to track clicked positions
        public List<(int, int)> ClickedPositions = new List<(int, int)>();

        // Method to handle cell clicks
        public void HandleClick(string position)
        {
            string[] valus = position.Split(',');

            //_jSRuntime.InvokeVoidAsync("alert", $"{row}, {col},{innerHtml}");


            // Add the clicked position to the list
            ClickedPositions.Add((Convert.ToInt16(valus[0]), Convert.ToInt16(valus[1])));
            _jSRuntime.InvokeVoidAsync("alert", $"{valus[0]}, {valus[1]}");

            // Trigger UI update
            StateHasChanged();
        }
    }
}
