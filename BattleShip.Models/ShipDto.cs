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
        public List<Node> CoveringAera { get; set; }
    }
   

    public class Node
    {
        public Node(int rowValue, int colValue, bool isHit)
        {
            RowValue = rowValue;
            ColValue = colValue;
            IsHit = isHit;
        }

        public int RowValue { get; set; }
        public int ColValue { get; set; }
        public bool IsHit { get; set; }
    }


}
