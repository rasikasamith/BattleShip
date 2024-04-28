using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BattleShip.WebAPI.Entities
{
    public class Node
    {
        [Key]
        public int  NId {  get; set; }
        public int  RowValue { get; set; }
        public int  ColValue { get; set; }
        public bool IsHit    { get; set; }
        public bool IsClick  { get; set; }

        public int SId { get; set; }

        [ForeignKey("SId")]
        public Ship Ship {  get; set; }
    }
}
