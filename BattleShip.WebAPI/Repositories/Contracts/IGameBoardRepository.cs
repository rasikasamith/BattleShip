using BattleShip.Models;
using BattleShip.WebAPI.Models;

namespace BattleShip.WebAPI.Repositories.Contracts
{
    public interface IGameBoardRepository
    {        
        public Task<List<ShipDto>> GetComputerPlaceShip();

        public Task<List<BattleShipDto>> GetShips();
    }
}
