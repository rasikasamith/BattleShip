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
                    var response = await this._httpClient.GetFromJsonAsync<IEnumerable<ShipDto>>("api/GameBoard/GetComputerPlaceShipsDemo");
                    return response;
               
            }
            catch (Exception)
            {                
                throw;
            }

        }

        public async Task<bool> UserFireAShot(int row, int col)
        {
            try
            {
                var response = await this._httpClient.GetAsync($"api/GameBoard/FireShot/{row}/{col}"); ;

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a boolean value
                    return await response.Content.ReadFromJsonAsync<bool>();
                }
                else
                {
                    // If the response is not successful, throw an exception with the status code
                    throw new HttpRequestException($"Failed to call API. Status code: {response.StatusCode}");
                }
            }
            catch
            {
                throw;
            }

        }

        public async Task<IEnumerable<ShipDto>> GetAllUpdatedShips(int row, int col)
        {
            try
            {
                var response = await this._httpClient.GetFromJsonAsync<List<ShipDto>>($"api/GameBoard/GetUpdatedShips/{row}/{col}");
                return response;
            }
            catch
            {
                throw;
            }
        }

        //public async Task<IEnumerable<BattleShipDto>> GetShips()
        //{
        //    try
        //    {
        //        var ships = await this._httpClient.GetFromJsonAsync<IEnumerable<BattleShipDto>>("api/GameBoard/GetShips");
        //        return ships;
        //    }
        //    catch (Exception)
        //    {               
        //        throw;
        //    }
        //}

        //public async Task<int> GetTempNum()
        //{
        //    var response = await this._httpClient.GetAsync("api/GameBoard/GetTempNum");
        //    return await response.Content.ReadFromJsonAsync<int>();            
        //}

    }

}
