using BattleShip.Models;
using BattleShip.WebAPI.Models;

namespace BattleShip.WebAPI.Extentions
{
    public static class DtoConvertions
    {
        public static IEnumerable<ShipDto> ShipToShipDto(IEnumerable<Ship> Ships)
        {
            IEnumerable<ShipDto> result = (from ship in Ships
                                          select new ShipDto()
                                          {
                                              Name = ship.Name,
                                              Size = ship.Size,
                                              Hits = ship.Hits
                                          }).ToList();
            return result;
        }
    }
}
