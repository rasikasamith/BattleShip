using BattleShip.Models;
using BattleShip.WebAPI.Controllers;
using BattleShip.WebAPI.Repositories;
using BattleShip.WebAPI.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BattleShip.WebAPI.Test
{
    public class GameBoardControllerTest
    {
        private GameBoardController _controller;
        private IGameBoardRepository _gameBoardRepository;

        public GameBoardControllerTest()
        {
            _gameBoardRepository =new  GameBoardRepository();
            _controller = new GameBoardController(_gameBoardRepository);
        }

        [Fact]
        public void GetComputerPlaceShipsTest()
        {
            //Arrange
            //Act
            var result = _controller.GetComputerPlaceShips();
            //Assert
            Assert.IsType<ActionResult<IEnumerable<ShipDto>>>(result.Result);
             
            var list = result.Result.Result as OkObjectResult;
            Assert.IsType<List<ShipDto>>(list.Value);

            var listShips = list.Value as List<ShipDto>;
            Assert.Equal(3, listShips.Count);
        }

        [Theory]
        [InlineData(7,3,false)]
        [InlineData(1,5,true)]
        [InlineData(160, 112,false)]
        public void UserFireAShotTest(int row,int col,bool expectedResult)
        {
            //Arrange

            //Act
            var actualResult= _controller.UserFireAShot(row,col);

            //Assest
            Assert.Equal(expectedResult.ToString(), actualResult.Result.ToString());
        }

        [Theory]       
        [InlineData(1, 5)]        
        public void GetAllUpdatedShips(int row, int col)
        {
            //Arrage 
            //Act
            var result= _controller.GetAllUpdatedShips(row,col);

            //Assert
            //Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<ActionResult<IEnumerable<ShipDto>>>(result.Result);

            var list = result.Result.Result as OkObjectResult;
            Assert.IsType<List<ShipDto>>(list.Value);

            var updatedShips = list.Value as List<ShipDto>;
            Assert.Equal(3, updatedShips.Count);
        }
    }
}
