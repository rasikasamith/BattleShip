using BattleShip.Models;
using BattleShip.WebAPI.Entities;
using BattleShip.WebAPI.Extentions;
using BattleShip.WebAPI.Repositories.Contracts;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace BattleShip.WebAPI.Repositories
{
    public class GameBoardRepository : IGameBoardRepository
    {             
        //public List<ShipDto> AllShips { get; set; }
        public List<Ship> AllShips { get; set; }
        public List<(int, int)> SuccesfullTargerts = new List<(int, int)>();        
        int BoardSize = 10;        

        public GameBoardRepository() {
            //AllShips=new List<ShipDto>();
            //AllShips.Add(new ShipDto()
            //{
            //    Name = "BattleShip",
            //    Size = 5,
            //    Hits = 0,
            //    CoveringAera = new List<NodeDto>()
            //    {
            //        new NodeDto(1,4,false,false),
            //        new NodeDto(1,5,false,false),
            //        new NodeDto(1,6,false,false),
            //        new NodeDto(1,7,false,false),
            //        new NodeDto(1,8,false,false)
            //    }
            //});

            //AllShips.Add(new ShipDto()
            //{
            //    Name = "Distroyer_1",
            //    Size = 2,
            //    Hits = 0,
            //    CoveringAera = new List<NodeDto>()
            //    {
            //        new NodeDto(1,3,false,false),
            //        new NodeDto(2,3,false,false)
            //    }
            //});

            //AllShips.Add(new ShipDto()
            //{
            //    Name = "Distroyer_2",
            //    Size = 2,
            //    Hits = 0,
            //    CoveringAera = new List<NodeDto>()
            //    {
            //        new NodeDto(7,7,false, false),
            //        new NodeDto(7,8,false, false)
            //    }
            //});

            AllShips = new List<Ship>();
            AllShips.Add(new Ship()
            {
                SId = 1,
                Name = "BattleShip",
                Size = 5,
                Hits = 0,
                CoveringAera = new List<Node>()
                {
                    new Node(){NId=1,RowValue=1,ColValue=4,IsHit=false,IsClick=false },
                    new Node(){NId=2,RowValue=1,ColValue=5,IsHit=false,IsClick=false },
                    new Node(){NId=3,RowValue=1,ColValue=6,IsHit=false,IsClick=false },
                    new Node(){NId=4,RowValue=1,ColValue=7,IsHit=false,IsClick=false },
                    new Node(){NId=5,RowValue=1,ColValue=8,IsHit=false,IsClick=false }
                }
            });
            AllShips.Add(new Ship()
            {
                SId = 2,
                Name = "Distroyer_1",
                Size = 2,
                Hits = 0,
                CoveringAera = new List<Node>()
                {
                    new Node(){NId=6,RowValue=1,ColValue=3,IsHit=false,IsClick=false },
                    new Node(){NId=7,RowValue=2,ColValue=3,IsHit=false,IsClick=false }                
                }
            });
            AllShips.Add(new Ship()
            {
                SId = 3,
                Name = "Distroyer_2",
                Size = 2,
                Hits = 0,
                CoveringAera = new List<Node>()
                {
                    new Node(){NId=8,RowValue=7,ColValue=7,IsHit=false,IsClick=false },
                    new Node(){NId=9,RowValue=7,ColValue=8,IsHit=false,IsClick=false }
                }
            });     
        }

        //public async Task<List<ShipDto>> GetComputerPlaceShip()
        //{
        //    var res = SuccesfullTargerts;
        //    return AllShips;
        //}
        public async Task<List<Ship>> GetComputerPlaceShip()
        {            
            return AllShips;
        }

        //public async Task<IEnumerable<ShipDto>> GetAllUpdatedShips( int row, int col)
        //{
        //    foreach (var item in AllShips)
        //    {
        //        foreach (var node in item.CoveringAera)
        //        {
        //            if ((node.RowValue == row) && (node.ColValue == col))
        //            {
        //                node.IsHit = true;
        //                item.Hits++;
        //            }
        //        }
        //    }

        //    //AllShips[0].Name = "B1U";
        //    //AllShips[0].CoveringAera[2].IsHit = true;

        //    IEnumerable<ShipDto> AllShipsUpdated = AllShips;

        //    //Add fired node
        //    SuccesfullTargerts.Add((row, col));

        //    return AllShipsUpdated;
        //}

        public async Task<IEnumerable<Ship>> GetAllUpdatedShips(int row, int col)
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

            IEnumerable<Ship> AllShipsUpdated = AllShips;

            //Add fired node
            SuccesfullTargerts.Add((row, col));

            return AllShipsUpdated;
        }

    }
}
