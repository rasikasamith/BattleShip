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

        //public async Task<IEnumerable<ShipDto>> UpdateShipStatus(int row, int col)
        //{
        //    try
        //    {
        //        var response = await _httpClient.PatchAsync($"api/GameBoard/GetUpdatedShips/{row}/{col}",null);
        //        //HttpResponseMessage response = await _httpClient.PatchAsync(requestUri, null);


        //        //return response.Content.ReadFromJsonAsync<IEnumerable<ShipDto>>();
        //        if (response.IsSuccessStatusCode)
        //        {
        //            return await response.Content.ReadFromJsonAsync<IEnumerable<ShipDto>>();
        //        }
        //        else
        //        {
        //            return Enumerable.Empty<ShipDto>();
        //        }

        //        //return (IEnumerable<ShipDto>)response;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


    }

}
