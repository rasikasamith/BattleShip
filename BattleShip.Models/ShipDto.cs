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
        public Node(int row,int col)
        {
            rowValue = row;
            colValue = col;
        }
        public  int rowValue { get; set; }
        public  int colValue { get; set; }
    }
}
