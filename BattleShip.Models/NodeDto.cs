using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Models
{
    public class NodeDto
    {
        public NodeDto(int rowValue, int colValue, bool isHit,bool isClick)
        {
            RowValue = rowValue;
            ColValue = colValue;
            IsHit = isHit;
            IsClick = isClick;
        }

        public int RowValue { get; set; }
        public int ColValue { get; set; }
        public bool IsHit { get; set; }
        public bool IsClick { get; set; }
    }
}
