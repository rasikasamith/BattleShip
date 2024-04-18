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
        //public List<ShipDto> AllShipsDemoTemp { get; set; }

        // Define a list to track clicked positions
        //public List<(int, int)> ClickedPositions = new List<(int, int)>();

        public List<(int, int)> SuccesfullTargerts = new List<(int, int)>();
        public List<(int, int)> MissedTargets = new List<(int, int)>();

        private List<(int, int)> clickedCells = new List<(int, int)>();

        public bool IsClicked(int row, int col) => clickedCells.Contains((row, col));


        //public int TempNum { get; set; }
        public int Marks { get; set; } = 0;

        public List<ShipDto> LatestUpdateShips = new List<ShipDto>();

        protected override async Task OnInitializedAsync()
        {        
                AllShipsDemo = (List<ShipDto>)await _shipService.GetAllShipsDemo();           
        }

        // Method to handle cell clicks
        public async Task HandleClick(string position)
        {
            string[] valus = position.Split(',');

            //Fire a shot and change the hit count
            var feedback = await _shipService.UserFireAShot(Convert.ToInt16(valus[0]), Convert.ToInt16(valus[1]));


            if (feedback)
            {
                //await _jSRuntime.InvokeVoidAsync("alert", "You hit the target");
                AllShipsDemo = (List<ShipDto>)await _shipService.GetAllUpdatedShips(Convert.ToInt16(valus[0]), Convert.ToInt16(valus[1]));
                //test
                foreach (ShipDto ship in AllShipsDemo)
                {
                    foreach (var area  in ship.CoveringAera)
                    {
                        foreach (var location in SuccesfullTargerts)
                        {
                            if((area.RowValue== location.Item1)&&(area.ColValue==location.Item2))
                            {
                                area.IsHit = true;
                            }

                        }
                    }
                }

                Marks = Marks + 1000;
                SuccesfullTargerts.Add((Convert.ToInt16(valus[0]), Convert.ToInt16(valus[1])));
                
            }
            else
            {
                //await _jSRuntime.InvokeVoidAsync("alert", "You missed the target");
                MissedTargets.Add((Convert.ToInt16(valus[0]), Convert.ToInt16(valus[1])));
                //test
                foreach (ShipDto ship in AllShipsDemo)
                {
                    foreach (var area in ship.CoveringAera)
                    {
                        foreach (var location in MissedTargets)
                        {
                            if ((area.RowValue == location.Item1) && (area.ColValue == location.Item2))
                            {
                                area.IsClick = true;
                            }
                        }
                    }
                }

            }


            // Add the clicked position to the list
            //ClickedPositions.Add((Convert.ToInt16(valus[0]), Convert.ToInt16(valus[1])));
                                

            StateHasChanged();
        }

        private void HandleClick(int row, int col)
        {
            if (!IsClicked(row, col))
            {
                clickedCells.Add((row, col));
                StateHasChanged(); // Notify Blazor to re-render the component
            }
        }

    }
}
