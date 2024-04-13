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
        [Route(nameof(GetComputerPlaceShipsDemo))]
        public async Task<ActionResult<IEnumerable<ShipDto>>> GetComputerPlaceShipsDemo()
        {

            try
            {
                var ships = await _gameBoardRepository.GetComputerPlaceShip();

                if (ships == null)
                {
                    return NotFound();
                }
                else
                {                    
                    return Ok(ships);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the databse");
            }
        }



        [HttpGet]
        [Route(nameof(GetShips))]
        public async Task<ActionResult<IEnumerable<BattleShipDto>>> GetShips()
        {
            try
            {
                var ships = await _gameBoardRepository.GetShips();

                if (ships == null)
                {
                    return NotFound();
                }
                else
                {
                    //var productDtos = products.ConvertToDto();
                    return Ok(ships);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the databse");

            }
        }



        


    }
}
