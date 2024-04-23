namespace BattleShip.WebAPI.Entities
{
    public class Node
    {
        public Node(int rowValue, int colValue, bool isHit, bool isClick)
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
