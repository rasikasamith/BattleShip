using BattleShip.Models;
using BattleShip.WebAPI.Entities;

namespace BattleShip.WebAPI.Extentions
{
    public static class DtoConvertions
    {
        //public static IEnumerable<ShipDto> ShipToShipDto(IEnumerable<Ship> Ships)
        //{
        //    IEnumerable<ShipDto> result = (from ship in Ships
        //                                  select new ShipDto()
        //                                  {
        //                                      SId=ship.SId,
        //                                      Name = ship.Name,
        //                                      Size = ship.Size,
        //                                      Hits = ship.Hits,
        //                                      CoveringAera=ship.CoveringAera()

        //                                  }).ToList();
        //    return result;
        //}

       
            public static IEnumerable<ShipDto> ShipToShipDto(IEnumerable<Ship> Ships)
            {
                IEnumerable<ShipDto> result = (from ship in Ships
                                               select new ShipDto()
                                               {
                                                   SId = ship.SId,
                                                   Name = ship.Name,
                                                   Size = ship.Size,
                                                   Hits = ship.Hits,
                                                   CoveringAera = ship.CoveringAera.Select(node =>
                                                       new NodeDto(node.NId,node.RowValue, node.ColValue, node.IsHit, node.IsClick))
                                                       .ToList()
                                               }).ToList();
                return result;
            }
        

    }
}
