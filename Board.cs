public class Board
{
    public string[,] BoardArray { get; set; }
    public int BoardSize { get; set; }
    public string UserSymbol { get; set; }
    public string ComputerSymbol { get; set; }

    public Board(int boardSize)
    {
        BoardSize = boardSize;
        BoardArray = new string[boardSize, boardSize];
    }

    public void FillBoard()
    {
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                BoardArray[i, j] = "o";
            }
        }
    }

    public void PrintBoard()
    {
        // Print the TicTacToe board
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                if (string.IsNullOrEmpty(BoardArray[i, j]))
                {
                    Console.Write("  ");
                }
                else
                {
                    Console.Write(BoardArray[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
    }

    public void FillBoard(int row, int col, string player)
    {
        if (string.IsNullOrEmpty(BoardArray[row, col]))
        {
            BoardArray[row, col] = player;
        }
        else
        {
            Console.WriteLine("This room is already taken!");
        }
    }

    // Get the location of free spaces and return as a array of strings
    public string[] GetFreeRooms()
    {
        List<string> freeRooms = new List<string>();
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                if (BoardArray[i, j] == null)
                {
                    freeRooms.Add(i + "," + j);
                }
            }
        }
        return freeRooms.ToArray();
    }

    // Fill a random room in the board with the computer symbol
    public void FillComputerRoom()
    {
        string[] freeRooms = GetFreeRooms();
        Random random = new Random();
        int randomIndex = random.Next(0, freeRooms.Length);
        string[] randomRoom = freeRooms[randomIndex].Split(',');
        int row = int.Parse(randomRoom[0]);
        int col = int.Parse(randomRoom[1]);
        FillBoard(row, col, ComputerSymbol);
    }

    // check whos the winner
    public string CheckWinner()
    {
        // check rows
        for (int i = 0; i < BoardSize; i++)
        {
            string row = "";
            for (int j = 0; j < BoardSize; j++)
            {
                row += BoardArray[i, j];
            }
            if (row == "xxx")
            {
                return "x";
            }
            else if (row == "ooo")
            {
                return "o";
            }
        }

        // check columns
        for (int i = 0; i < BoardSize; i++)
        {
            string col = "";
            for (int j = 0; j < BoardSize; j++)
            {
                col += BoardArray[j, i];
            }
            if (col == "xxx")
            {
                return "x";
            }
            else if (col == "ooo")
            {
                return "o";
            }
        }

        // check diagonals
        string diag1 = "";
        string diag2 = "";
        for (int i = 0; i < BoardSize; i++)
        {
            diag1 += BoardArray[i, i];
            diag2 += BoardArray[i, BoardSize - i - 1];
        }

        if (diag1 == "xxx")
        {
            return "x";
        }
        else if (diag1 == "ooo")
        {
            return "o";
        }
        else if (diag2 == "xxx")
        {
            return "x";
        }
        else if (diag2 == "ooo")
        {
            return "o";
        }

        return "";
    }

    // check game is ended
    public bool CheckEnd()
    {
        string winner = CheckWinner();
        if (winner == "x" || winner == "o")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // check board is full
    public bool CheckFull()
    {
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                if (BoardArray[i, j] == null)
                {
                    return false;
                }
            }
        }
        return true;
    }

    // Get User Move
    public int[] GetUserMove(string userMove)
    {
        int[] userMoveArray = new int[2];
        string[] userMoveSplit = userMove.Split(',');
        userMoveArray[0] = int.Parse(userMoveSplit[0]);
        userMoveArray[1] = int.Parse(userMoveSplit[1]);
        return userMoveArray;
    }

    // Get Winner
    public string GetWinner()
    {
        string winner = CheckWinner();
        if (winner == "x")
        {
            return "x";
        }
        else if (winner == "o")
        {
            return "o";
        }
        else if (winner == "tie")
        {
            return "tie";
        }
        else
        {
            return "";
        }
    }
}