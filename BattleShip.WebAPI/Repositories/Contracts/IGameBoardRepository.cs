using BattleShip.Models;
using BattleShip.WebAPI.Models;

namespace BattleShip.WebAPI.Repositories.Contracts
{
    public interface IGameBoardRepository
    {
        public Ship[,] GetPlayerPlaceShip();
        public Task<List<ShipDto>> GetComputerPlaceShip();
    }
}
