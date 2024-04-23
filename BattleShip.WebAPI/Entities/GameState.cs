using System.Data.Common;

namespace BattleShip.WebAPI.Models
{
    public class GameState
    {
        public GameBoard PlayerBoard { get; set; }
        public GameBoard ComputerBoard { get; set; }

        public GameState()
        {
            PlayerBoard = new GameBoard();
            ComputerBoard = new GameBoard();
        }

        // Method to handle player's move
        public bool PlayerMove(string position)
        {
            // Convert the position string to row and column indices
            int row = position[0] - 'A'; // Convert letter to row index (A is 0, B is 1, ...)
            int column = int.Parse(position.Substring(1)) - 1; // Convert number to column index (1 is 0, 2 is 1, ...)

            // Check if the position is within the bounds of the game board
            if (row < 0 || row >= 10 || column < 0 || column >= 10)
            {
                throw new ArgumentOutOfRangeException("Invalid position for player's move");
            }

            // Check if the position has already been attacked
            //if (AttackedPositions[row, column])
            //{
            //    throw new InvalidOperationException("Position has already been attacked");
            //}

            // Mark the position as attacked
            //AttackedPositions[row, column] = true;

            // Check if the attack hits a ship
            GameBoard gameBoard=new GameBoard();
            Ship ship = gameBoard.Ships[row, column];
            if (ship != null)
            {
                // Mark the ship's hit position
                ship.Hits = ship.Hits + 1;
                return true; // Hit
            }

            return false; // Miss
        }

        // Method to handle computer's move
        public bool ComputerMove(string position)
        {
            // Convert the position string to row and column indices
            int row = position[0] - 'A'; // Convert letter to row index (A is 0, B is 1, ...)
            int column = int.Parse(position.Substring(1)) - 1; // Convert number to column index (1 is 0, 2 is 1, ...)

            // Check if the attack hits a ship
            GameBoard gameBoard = new GameBoard();
            Ship ship = gameBoard.Ships[row, column];
            if (ship != null)
            {
                // Mark the ship's hit position
                ship.Hits = ship.Hits + 1;
                return true; // Hit
            }
            return false; // Miss
        }

        // Other methods and properties as needed
    }
}
