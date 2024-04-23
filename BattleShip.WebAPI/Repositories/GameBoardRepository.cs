using BattleShip.Models;
using BattleShip.WebAPI.Entities;
using BattleShip.WebAPI.Repositories.Contracts;
using System.Collections.Generic;
using System.Drawing;

namespace BattleShip.WebAPI.Repositories
{
    public class GameBoardRepository : IGameBoardRepository
    {
        //public Ship[,] Ships { get; set; }        
        public List<ShipDto> AllShips { get; set; }
        public List<(int, int)> SuccesfullTargerts = new List<(int, int)>();
        public int tempNum = 12;
        int BoardSize = 10;
        

        public GameBoardRepository() {
            AllShips=new List<ShipDto>();
            AllShips.Add(new ShipDto()
            {
                Name = "BattleShip",
                Size = 5,
                Hits = 0,
                CoveringAera = new List<NodeDto>()
                {
                    new NodeDto(1,4,false,false),
                    new NodeDto(1,5,false,false),
                    new NodeDto(1,6,false,false),
                    new NodeDto(1,7,false,false),
                    new NodeDto(1,8,false,false)
                }
            });

            AllShips.Add(new ShipDto()
            {
                Name = "Distroyer_1",
                Size = 2,
                Hits = 0,
                CoveringAera = new List<NodeDto>()
                {
                    new NodeDto(1,3,false,false),
                    new NodeDto(2,3,false,false)
                }
            });

            AllShips.Add(new ShipDto()
            {
                Name = "Distroyer_2",
                Size = 2,
                Hits = 0,
                CoveringAera = new List<NodeDto>()
                {
                    new NodeDto(7,7,false, false),
                    new NodeDto(7,8,false, false)
                }
            });

            tempNum = 18;

        }

        public async Task<List<ShipDto>> GetComputerPlaceShip()
        {
            var res = SuccesfullTargerts;
            return AllShips;
        }      

        public async Task<bool> Hit(int row, int col)
        {
            //var result = from sh in AllShips
            //             where sh.CoveringAera.Any(x => (x.RowValue == row) && (x.ColValue == col))
            //             select new
            //             {
            //                 Name = sh.Name,
            //                 Size = sh.Size,
            //                 Hits = sh.Hits
            //             };
           
            //AllShips[0].CoveringAera[1].IsHit = true;
            //return true;
            
                foreach (var item in AllShips)
                {
                    foreach (var node in item.CoveringAera)
                    {
                        if ((node.RowValue == row) && (node.ColValue == col))
                        {
                            node.IsHit = true;
                            //node.IsClick = true;
                        }
                        else
                        {
                            node.IsClick = true;
                        }

                            
                    }
                }
                return true;        



            //// Find the ship that covers the specified position
            //var ship = AllShips.FirstOrDefault(s => s.CoveringAera.Any(n => n.RowValue == row && n.ColValue == col));

            //if (ship != null)
            //{
            //    // Find the node in the covering area of the ship
            //    var node = ship.CoveringAera.FirstOrDefault(n => n.RowValue == row && n.ColValue == col);

            //    if (node != null)
            //    {
            //        // Mark the node as hit
            //        node.IsHit = true;

            //        // Update Hits count of the ship if necessary
            //        //if (!node.IsHit)
            //        //{
            //        //    ship.Hits++;
            //        //}

            //        // You may want to perform any additional logic here, such as checking if the ship is sunk
            //    }
            //}
        }

        public async Task<IEnumerable<ShipDto>> GetAllUpdatedShips( int row, int col)
        {
            foreach (var item in AllShips)
            {
                foreach (var node in item.CoveringAera)
                {
                    if ((node.RowValue == row) && (node.ColValue == col))
                    {
                        node.IsHit = true;
                        item.Hits++;
                    }
                }
            }

            //AllShips[0].Name = "B1U";
            //AllShips[0].CoveringAera[2].IsHit = true;

            IEnumerable<ShipDto> AllShipsUpdated = AllShips;

            //Add fired node
            SuccesfullTargerts.Add((row, col));

            return AllShipsUpdated;
        }

        //public async Task GetTempNum_1()
        //{
        //    tempNum = 24;            
        //}
        //public async Task<int> GetTempNum_2()
        //{               
        //    return tempNum;  
        //}

    }
}
