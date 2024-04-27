using BattleShip.Models;

namespace BattleShip.UI.Service.Contracts
{
    public interface IShipService
    {    
        Task<IEnumerable<ShipDto>> GetAllShips();

        Task<bool> UserFireAShot(int row, int col);

        Task<IEnumerable<ShipDto>> GetAllUpdatedShips(int row, int col);      
        
    }
}
