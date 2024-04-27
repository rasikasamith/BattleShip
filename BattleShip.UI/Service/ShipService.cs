using BattleShip.Models;
using BattleShip.UI.Service.Contracts;
using System.Net.Http;
using System;
using System.Net.Http.Json;
using BattleShip.UI.Pages;
using System.Collections.Generic;

namespace BattleShip.UI.Service
{
    public class ShipService: IShipService
    {
        private readonly HttpClient _httpClient;

        public ShipService(HttpClient httpClient)
        {
            this._httpClient= httpClient;
        }         

        public async Task<IEnumerable<ShipDto>> GetAllShips()
        {
            try
            {
                    var response = await this._httpClient.GetFromJsonAsync<IEnumerable<ShipDto>>("api/GameBoard/GetComputerPlaceShips");
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
    }

}
