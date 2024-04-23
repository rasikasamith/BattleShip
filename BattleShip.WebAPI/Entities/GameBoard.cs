namespace BattleShip.WebAPI.Models
{
    public class GameBoard
    {
        public const int BoardSize = 10;
        public Ship[,] Ships { get; set; }

        public GameBoard() {
            Ships=new Ship[BoardSize,BoardSize];
        }

        //Method to place ship on the board
        public void PlaceShip(Ship ship,int row,int column,bool isHorizontal)
        {
            Ships[row, column] = ship;

            if(isHorizontal==true ) 
            {
                for (int i = 1; i < ship.Size; i++)
                {
                    Ships[row, column + i] = ship;
                }
            }
            else
            {
                for (int i = 1; i < ship.Size; i++)
                {
                    Ships[row+1, column] = ship;
                }
            }            
        }

        public bool Attack(int row,int column)
        {
            // Check if the specified position is within the bounds of the game board
            if (row < 0 || row >= BoardSize || column < 0 || column >= BoardSize)
            {                
                return false;
            }

            // Check if there's a ship at the specified position
            Ship ship = Ships[row, column];
            if (ship != null)
            {
                // There's a ship at the position, mark it as hit
                //ship.IsHit = true;
                ship.Hits= ship.Hits + 1;
                return true; // Attack successful (hit)
            }

            // No ship at the position, return false (attack unsuccessful)
            return false;
        }
    }
}
