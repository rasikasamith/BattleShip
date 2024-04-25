using BattleShip.Models;
using BattleShip.WebAPI.Entities;

namespace BattleShip.WebAPI.Repositories.Contracts
{
    public interface IGameBoardRepository
    {        
        //public Task<List<ShipDto>> GetComputerPlaceShip();    

        //public Task<IEnumerable<ShipDto>> GetAllUpdatedShips(int row, int col);

        public Task<List<Ship>> GetComputerPlaceShip();

        public Task<IEnumerable<Ship>> GetAllUpdatedShips(int row, int col);
    }
}
