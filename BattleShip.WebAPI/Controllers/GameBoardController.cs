using BattleShip.Models;
using BattleShip.WebAPI.Extentions;
using BattleShip.WebAPI.Models;
using BattleShip.WebAPI.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BattleShip.WebAPI.Controllers
{
    [Route("api/[controller]")]
    //[Route("[controller]")]
    [ApiController]
    public class GameBoardController : ControllerBase
    {
        IGameBoardRepository _gameBoardRepository;
        public GameBoardController(IGameBoardRepository gameBoardRepository)
        {
            this._gameBoardRepository = gameBoardRepository;
        }

        [HttpGet]
        [Route(nameof(GetComputerPlaceShips))]
        public async Task<List<ShipDto>> GetComputerPlaceShips()
        {
            List<ShipDto> result = await _gameBoardRepository.GetComputerPlaceShip();
            return result;
        }

        [HttpGet]
        public  ActionResult<IEnumerable<ShipDto>> GetShipDemo()
        {
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
            return AllShips;
        }

            //[HttpGet]
            //[Route(nameof(GetPlayerPlaceShips))]
            //public ActionResult<IEnumerable<ShipDto>> GetPlayerPlaceShips()
            //{
            //    var ships = _gameBoardRepository.GetPlayerPlaceShip().Cast<Ship>();
            //    if(ships !=null)
            //    {
            //       return Ok(DtoConvertions.ShipToShipDto(ships));
            //    }
            //    else
            //    {
            //       return NotFound();
            //    }

            //}


        }
}
