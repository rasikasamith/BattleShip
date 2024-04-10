using BattleShip.Models;
using BattleShip.UI.Service.Contracts;
using System.Net.Http;
using System;
using System.Net.Http.Json;

namespace BattleShip.UI.Service
{
    public class ShipService: IShipService
    {
        private readonly HttpClient _httpClient;

        public ShipService(HttpClient httpClient)
        {
            this._httpClient= httpClient;
        }        

        public async Task<List<ShipDto>> GetAllShips_Temp()
        {
            List<ShipDto> AllShips = new List<ShipDto>();
            //AllShips.Add(new ShipDto()
            //{
            //    Name = "B1",
            //    Size = 5,
            //    Hits = 0,
            //    CoveringAera = new List<Node>()
            //     {
            //         new Node(1,4),
            //         new Node(1,5),
            //         new Node(1,6),
            //         new Node(1,7),
            //         new Node(1,8)
            //     }
            //});

            //AllShips.Add(new ShipDto()
            //{
            //    Name = "D1",
            //    Size = 2,
            //    Hits = 0,
            //    CoveringAera = new List<Node>()
            //     {
            //         new Node(1,4),
            //         new Node(2,4)
            //     }
            //});

            //AllShips.Add(new ShipDto()
            //{
            //    Name = "D2",
            //    Size = 2,
            //    Hits = 0,
            //    CoveringAera = new List<Node>()
            //     {
            //         new Node(7,7),
            //         new Node(7,8)
            //     }
            //});

            //try
            //{
            //    //https://localhost:7237/api/GameBoard/GetComputerPlaceShips
            //    var response = await _httpClient.GetAsync("api/GameBoard/GetComputerPlaceShips");
            //    response.EnsureSuccessStatusCode(); // Throws on error

            //   // return await response.Content.ReadFromJsonAsync<List<ShipDto>>() ?? List.Empty<ShipDto>();
            //    return await response.Content.ReadFromJsonAsync<List<ShipDto>>() ?? new List<ShipDto>();
            //}
            //catch (HttpRequestException ex)
            //{
            //    // Log the exception or handle it as needed
            //    throw new Exception("An error occurred while fetching ships from the server.", ex);
            //}

            //var response = await this._httpClient.GetAsync("api/GameBoard/GetComputerPlaceShips");


            //if (response.IsSuccessStatusCode)
            //{
            //    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            //    {
            //        return new List<ShipDto>();
            //    }
            //    return await response.Content.ReadFromJsonAsync<List<ShipDto>>();

            //}
            //else
            //{
            //    var message = await response.Content.ReadAsStringAsync();
            //    throw new Exception(message);
            //}


            return AllShips;
        }
        

  
        private List<ShipDto> computerShips;

        public async Task<List<ShipDto>> GetAllShips()
        {

            computerShips = await _httpClient.GetFromJsonAsync<List<ShipDto>>("https://localhost:7237/api/GameBoard/GetComputerPlaceShips");          
            //var response = await _httpClient.GetAsync("api/GameBoard/GetComputerPlaceShips"); GetComputerPlaceShips
            return computerShips;


        }

        public List<ShipDto> GetAllShipsDemo()
        {
            //await _httpClient.GetFromJsonAsync<List<ShipDto>>("https://localhost:7237/api/GameBoard/GetShipDemo");       

            
        }
    }
}
