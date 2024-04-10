using BattleShip.Models;
using BattleShip.WebAPI.Models;
using BattleShip.WebAPI.Repositories.Contracts;

namespace BattleShip.WebAPI.Repositories
{
    public class GameBoardRepository : IGameBoardRepository
    {
        public Ship[,] Ships { get; set; }
        int BoardSize = 10;

        public async Task<List<ShipDto>> GetComputerPlaceShip()
        {
            //Ship[,] ComputerPlaceShips = new Ship[BoardSize, BoardSize];
            //ComputerPlaceShips[1, 2] = new Ship("B1", 5);
            //ComputerPlaceShips[2, 2] = new Ship("B1", 5);
            //ComputerPlaceShips[3, 2] = new Ship("B1", 5);
            //ComputerPlaceShips[4, 2] = new Ship("B1", 5);
            //ComputerPlaceShips[5, 2] = new Ship("B1", 5);

            //ComputerPlaceShips[1, 6] = new Ship("D1", 2);
            //ComputerPlaceShips[1, 6] = new Ship("D1", 2);

            //ComputerPlaceShips[7, 7] = new Ship("D2", 2);
            //ComputerPlaceShips[7, 8] = new Ship("D2", 2);

            List<ShipDto> AllShips = new List<ShipDto>();
            AllShips.Add(new ShipDto()
            {
                Name = "B1",
                Size = 5,
                Hits = 0,
                CoveringAera = new List<Node>()
            {
                new Node(1,4),
                new Node(1,5),
                new Node(1,6),
                new Node(1,7),
                new Node(1,8)
            }
            });

            AllShips.Add(new ShipDto()
            {
                Name = "D1",
                Size = 2,
                Hits = 0,
                CoveringAera = new List<Node>()
            {
                new Node(1,4),
                new Node(2,4)
            }
            });

            AllShips.Add(new ShipDto()
            {
                Name = "D2",
                Size = 2,
                Hits = 0,
                CoveringAera = new List<Node>()
            {
                new Node(7,7),
                new Node(7,8)
            }
            });

            return AllShips;
        }

        public Ship[,] GetPlayerPlaceShip()
        {
            Ship[,] PlayerPlaceShips = new Ship[BoardSize, BoardSize];
            PlayerPlaceShips[4, 2] = new Ship("B1", 5);
            PlayerPlaceShips[5, 2] = new Ship("B1", 5);
            PlayerPlaceShips[6, 2] = new Ship("B1", 5);
            PlayerPlaceShips[7, 2] = new Ship("B1", 5);
            PlayerPlaceShips[8, 2] = new Ship("B1", 5);

            PlayerPlaceShips[1, 4] = new Ship("D1", 2);
            PlayerPlaceShips[2, 4] = new Ship("D1", 2);

            PlayerPlaceShips[7, 7] = new Ship("D2", 2);
            PlayerPlaceShips[7, 8] = new Ship("D2", 2);

            return PlayerPlaceShips;
        }
    }
}
