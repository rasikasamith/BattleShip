using BattleShip.Models;
using BattleShip.WebAPI.Extentions;
using BattleShip.WebAPI.Entities;
using BattleShip.WebAPI.Repositories;
using BattleShip.WebAPI.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BattleShip.WebAPI.Controllers
{
    [Route("api/[controller]")]
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
                    var shipsDto= DtoConvertions.ShipToShipDto(ships);
                    return Ok(shipsDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the databse");
            }
        }
                
        [HttpGet("FireShot/{row:int}/{col:int}")]
        public async Task<bool> UserFireAShot(int row, int col)
        {
            try
            {
                var ships = await _gameBoardRepository.GetComputerPlaceShip();

                var result = from sh in ships
                             where sh.CoveringAera.Any(x => (x.RowValue == row) && (x.ColValue == col))
                             select new
                             {
                                 Name = sh.Name,
                                 Size = sh.Size,
                                 Hits = sh.Hits
                             };                

                var hit = result.Any();
                return hit;
            }
            catch (Exception)
            {
                throw;
            }
        }
     
        [HttpGet("GetUpdatedShips/{row:int}/{col:int}")]
        public async Task<ActionResult<IEnumerable<ShipDto>>> GetAllUpdatedShips(int row, int col)
        {
            try
            {
                var result = await _gameBoardRepository.GetAllUpdatedShips(row, col);
               
                if (result != null)
                {
                    var shipDto = DtoConvertions.ShipToShipDto(result);
                    return Ok(shipDto);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }        

    }
}
