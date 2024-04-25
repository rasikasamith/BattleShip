using BattleShip.Models;
using System.ComponentModel.DataAnnotations;

namespace BattleShip.WebAPI.Entities
{
    public class Ship
    {
        [Key]
        public int SId { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int Hits { get; set; }

        
        public List<Node> CoveringAera { get; set; }
    }
}
