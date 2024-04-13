using BattleShip.Models;

namespace BattleShip.UI.Service.Contracts
{
    public interface IShipService
    {
     

        Task<IEnumerable<ShipDto>> GetAllShipsDemo();

        Task<IEnumerable<BattleShipDto>> GetShips();



    }
}
