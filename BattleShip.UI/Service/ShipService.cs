using BattleShip.Models;
using BattleShip.UI.Service.Contracts;
using System.Net.Http;
using System;
using System.Net.Http.Json;
using BattleShip.UI.Pages;

namespace BattleShip.UI.Service
{
    public class ShipService: IShipService
    {
        private readonly HttpClient _httpClient;

        public ShipService(HttpClient httpClient)
        {
            this._httpClient= httpClient;
        } 

        

        public async Task<IEnumerable<ShipDto>> GetAllShipsDemo()
        {
            try
            {
                //var response = await _httpClient.GetAsync("https://localhost:7237/api/GameBoard/GetComputerPlaceShipsDemo");
                try
                {
                    var response = await this._httpClient.GetFromJsonAsync<IEnumerable<ShipDto>>("api/GameBoard/GetComputerPlaceShipsDemo");
                    return response;
                }
                catch
                {
                    throw;
                }
               

            }
            catch (Exception)
            {
                //Log exception
                throw;
            }

        }            

        public async Task<IEnumerable<BattleShipDto>> GetShips()
        {
            try
            {
                var ships = await this._httpClient.GetFromJsonAsync<IEnumerable<BattleShipDto>>("api/GameBoard/GetShips");
                return ships;
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

    }
}
