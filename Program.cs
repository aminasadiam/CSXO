namespace CSXO;

public class Program
{
    public static void Main(string[] args)
    {
        Program p = new Program();
        p.PlayGame();    
    }

    public void PlayGame()
    {
        Events events = new Events();
        Board board = new Board(3);

        bool gameEnded = false;

        events.GreenMessage("Welcome to Tic Tac Toe!\n\n");
        events.BlueMessage("Please enter your Symbol (X or O) : ");
        string userSymbol = Console.ReadLine()!.ToLower();

        if (userSymbol == "x")
        {
            board.UserSymbol = "x";
            board.ComputerSymbol = "o";

            board.FillComputerRoom();
            board.PrintBoard();

            while (!gameEnded)
            {
                events.BlueMessage("Please enter your move (row,col) : ");
                string userMove = Console.ReadLine()!;
                string[] userMoveArray = userMove.Split(',');
                int row = int.Parse(userMoveArray[0]);
                int col = int.Parse(userMoveArray[1]);

                board.FillBoard(row, col, board.UserSymbol);

                board.FillComputerRoom();
                board.PrintBoard();

                if (board.CheckEnd() || board.CheckFull())
                {
                    gameEnded = true;
                }
            }

            // Get the winner
            string winner = board.GetWinner();
            if (winner == " ")
            {
                events.GreenMessage("\nDraw!");
            }
            else
            {
                events.GreenMessage("\n" + winner + " wins!");
            }
        }
        else if (userSymbol == "o")
        {
            board.UserSymbol = "o";
            board.ComputerSymbol = "x";

            board.FillComputerRoom();
            board.PrintBoard();

            while (!gameEnded)
            {
                events.BlueMessage("Please enter your move (row,col) : ");
                string userMove = Console.ReadLine()!;
                string[] userMoveArray = userMove.Split(',');
                int row = int.Parse(userMoveArray[0]);
                int col = int.Parse(userMoveArray[1]);

                board.FillBoard(row, col, board.UserSymbol);

                board.FillComputerRoom();
                board.PrintBoard();

                if (board.CheckEnd() || board.CheckFull())
                {
                    gameEnded = true;
                }
            }

            // Get the winner
            string winner = board.GetWinner();
            if (winner == " ")
            {
                events.GreenMessage("\nDraw!");
            }
            else
            {
                events.GreenMessage("\n" + winner + " wins!");
            }
        }
        else
        {
            events.RedMessage("Invalid Symbol.\n");
            events.BlueMessage("Please enter your Symbol (X or O) : ");
            userSymbol = Console.ReadLine()!.ToLower();
        }
    }
}