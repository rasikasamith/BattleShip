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
        IShipService _shipService { get; set; }

        public List<ShipDto> AllShips { get; set; } 
        public List<(int, int)> SuccesfullTargerts = new List<(int, int)>();
        public List<(int, int)> MissedTargets = new List<(int, int)>(); 
        public Dictionary<String, int> AllHits { get; set; } = new Dictionary<string, int>(); 
        public int Marks { get; set; } = 0;

        public string BattleShipStatus = "No Damage";
        public string Distroyer_1Status = "No Damage";
        public string Distroyer_2Status = "No Damage";

        public ComputerGridBase()
        {
            AllHits = new Dictionary<string, int>()
            {
                { "BattleShip", 0 },
                { "Distroyer_1", 0 },
                { "Distroyer_2", 0 }
            };
        }

        protected override async Task OnInitializedAsync()
        {        
            AllShips = (List<ShipDto>)await _shipService.GetAllShips();          
        }


        // Method to handle cell clicks
        public async Task HandleClick(string position)
        {
            string[] valus = position.Split(',');

            var result=SuccesfullTargerts.Any(x => (x.Item1 == Convert.ToInt16(valus[0])) && (x.Item2 == Convert.ToInt16(valus[1])));

            //Fire a shot and change the hit count

            var feedback = await _shipService.UserFireAShot(Convert.ToInt16(valus[0]), Convert.ToInt16(valus[1]));


            if (feedback)
            {
                if (result == false)
                {                   
                    AllShips = (List<ShipDto>)await _shipService.GetAllUpdatedShips(Convert.ToInt16(valus[0]), Convert.ToInt16(valus[1]));
                                        
                    foreach (ShipDto ship in AllShips)
                    {
                        foreach (var area in ship.CoveringAera)
                        {
                            foreach (var location in SuccesfullTargerts)
                            {
                                if ((area.RowValue == location.Item1) && (area.ColValue == location.Item2))
                                {
                                    area.IsHit = true;

                                }
                            }
                        }
                    }

                    var results = AllShips.Select(x => new { x.Name, x.Hits }).Where(x => x.Hits > 0).FirstOrDefault();

                    if (results.Name == "BattleShip")
                    {
                        AllHits["BattleShip"] += 1;
                    }
                    if (results.Name == "Distroyer_1")
                    {
                        AllHits["Distroyer_1"] += 1;
                    }
                    if (results.Name == "Distroyer_2")
                    {
                        AllHits["Distroyer_2"] += 1;
                    }

                    //BattleShip
                    if (AllHits["BattleShip"] == 0)
                    {
                        BattleShipStatus = "No Damage";
                    }
                    else if (AllHits["BattleShip"] > 0 && AllHits["BattleShip"] < 5)
                    {
                        BattleShipStatus = "Partially Damaged";
                    }
                    else
                    {
                        BattleShipStatus = "Sank";
                    }

                    //Distroyer_1
                    if (AllHits["Distroyer_1"] == 0)
                    {
                        Distroyer_1Status = "No Damage";
                    }
                    else if (AllHits["Distroyer_1"] > 0 && AllHits["Distroyer_1"] < 2)
                    {
                        Distroyer_1Status = "Partially Damaged";
                    }
                    else
                    {
                        Distroyer_1Status = "Sank";
                    }

                    //Distroyer_2
                    if (AllHits["Distroyer_2"] == 0)
                    {
                        Distroyer_2Status = "No Damage";
                    }
                    else if (AllHits["Distroyer_2"] > 0 && AllHits["Distroyer_2"] < 2)
                    {
                        Distroyer_2Status = "Partially Damaged";
                    }
                    else
                    {
                        Distroyer_2Status = "Sank";
                    }


                    Marks = Marks + 1000;
                    SuccesfullTargerts.Add((Convert.ToInt16(valus[0]), Convert.ToInt16(valus[1])));
                }
            }
            else
            {            
                MissedTargets.Add((Convert.ToInt16(valus[0]), Convert.ToInt16(valus[1])));
                
                foreach (ShipDto ship in AllShips)
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

            StateHasChanged();
        }       

    }
}
