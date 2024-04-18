using BattleShip.Models;
using BattleShip.WebAPI.Models;

namespace BattleShip.WebAPI.Repositories.Contracts
{
    public interface IGameBoardRepository
    {        
        public Task<List<ShipDto>> GetComputerPlaceShip();      

        public Task<bool> Hit(int row, int col);

        public Task<IEnumerable<ShipDto>> GetAllUpdatedShips(int row, int col);

        public Task GetTempNum_1();

        public Task<int> GetTempNum_2();
    }
}
