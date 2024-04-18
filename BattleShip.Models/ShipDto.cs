using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Models
{
    public  class ShipDto
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public int Hits { get; set; }
        public List<NodeDto> CoveringAera { get; set; }
    }
}
