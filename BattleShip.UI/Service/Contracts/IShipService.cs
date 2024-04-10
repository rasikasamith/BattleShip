using BattleShip.Models;

namespace BattleShip.UI.Service.Contracts
{
    public interface IShipService
    {
        Task<List<ShipDto>> GetAllShips();
    }
}
