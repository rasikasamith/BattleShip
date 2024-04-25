using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Models
{
    public class NodeDto
    {
        public NodeDto(int nId,int rowValue, int colValue, bool isHit,bool isClick)
        { 
            NId=nId;
            RowValue = rowValue;
            ColValue = colValue;
            IsHit = isHit;
            IsClick = isClick;
        }

        public int NId { get; set; }
        public int RowValue { get; set; }
        public int ColValue { get; set; }
        public bool IsHit   { get; set; }
        public bool IsClick { get; set; }
    }
}
