using BattleShip.Models;
using BattleShip.WebAPI.Models;
using BattleShip.WebAPI.Repositories.Contracts;
using System.Drawing;

namespace BattleShip.WebAPI.Repositories
{
    public class GameBoardRepository : IGameBoardRepository
    {
        public Ship[,] Ships { get; set; }
        int BoardSize = 10;

        public async Task<List<ShipDto>> GetComputerPlaceShip()
        {  
            List<ShipDto> AllShips = new List<ShipDto>();
            
            AllShips.Add(new ShipDto()
            {
                Name = "B1",
                Size = 5,
                Hits = 0,
                CoveringAera = new List<Node>()
                {
                    new Node(1,4,false),
                    new Node(1,5,false),
                    new Node(1,6,false),
                    new Node(1,7,false),
                    new Node(1,8,false)
                }
            });

            AllShips.Add(new ShipDto()
            {
                Name = "D1",
                Size = 2,
                Hits = 0,
                    CoveringAera = new List<Node>()
                {
                    new Node(1,3,false),
                    new Node(2,3,false)
                }
            });

            AllShips.Add(new ShipDto()
            {
                Name = "D2",
                Size = 2,
                Hits = 0,
                    CoveringAera = new List<Node>()
                {
                    new Node(7,7,false),
                    new Node(7,8,false)
                }
            });

            return AllShips;
        }

        public async Task<List<BattleShipDto>> GetShips()
        {
           List<BattleShipDto> AllBattleShips = new List<BattleShipDto>();
            AllBattleShips.Add(new BattleShipDto() 
            {   
                Name="B1",
                Size = 5,
                Hits = 0}
            );
            AllBattleShips.Add(new BattleShipDto()
            {
                Name = "D1",
                Size = 2,
                Hits = 1
            });
            AllBattleShips.Add(new BattleShipDto()
            {
                Name = "D2",
                Size = 2,
                Hits = 2
            });
            return AllBattleShips;
        }
    }
}
