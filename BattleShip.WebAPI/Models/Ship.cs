namespace BattleShip.WebAPI.Models
{
    public class Ship
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public int Hits { get; set; }

        public Ship(string name,int size)
        {
            Name = name;
            Size = size;
            Hits = 0;
        }

        public bool IsSunk()
        {
            if(Size>=Hits)
            {
                return true;
            }
            else
            {
               return false;
            }
        }

    }
}
