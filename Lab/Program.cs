namespace Lab;

class TurnCount
{
    public static int TurnNumber = 0;
    public static int Count() {
        TurnNumber += 1;
        return TurnNumber;
    }
    public static int MinusCount() {
        TurnNumber -= 1;
        return TurnNumber;
    }
    public static int ReadCount() {
        return TurnNumber;
    }
    public static void ResetCount() {
        TurnNumber = 0;
    }
}

class Grid
{
        public static string cell7 = "7"; public static string cell8 = "8"; public static string cell9 = "9"; // row 1 values
        public static string cell4 = "4"; public static string cell5 = "5"; public static string cell6 = "6"; // row 2 values
        public static string cell1 = "1"; public static string cell2 = "2"; public static string cell3 = "3"; // row 3 values
        // these have to be overwritten with every input i think
        static public void GenerateGrid() {
            Console.WriteLine(" ---  ---  ---");
            Console.WriteLine("| " + cell7 + " |" + "| " + cell8 + " |" + "| " + cell9 + " |"); // row 1
            Console.WriteLine(" ---  ---  ---");
            Console.WriteLine("| " + cell4 + " |" + "| " + cell5 + " |" + "| " + cell6 + " |"); // row 2
            Console.WriteLine(" ---  ---  ---");
            Console.WriteLine("| " + cell1 + " |" + "| " + cell2 + " |" + "| " + cell3 + " |"); // row 3
            Console.WriteLine(" ---  ---  ---");
        }

        static public void ResetGrid() {
            cell7 = "7"; cell8 = "8"; cell9 = "9";
            cell4 = "4"; cell5 = "5"; cell6 = "6";
            cell1 = "1"; cell2 = "2"; cell3 = "3";
        }
}

class Program
{
    static void Main(string[] args)
    {
        Logic.RunIt(); // this runs the program on dotnet run
    }
}

class Logic
{
static public void RunIt() {

        if (PlayerO() == true) {
            Console.WriteLine("Play Again?");
            Restart();
            return;
        };
        if (TurnCount.ReadCount() > 8) {
            Console.Clear();
            Console.WriteLine("- TIED GAME -");
            Grid.GenerateGrid();
            Console.WriteLine("Yeah this game sucks huh lmao, run it back?");
            Restart();
            return;
        }

        if (PlayerX() == true) {
            Console.WriteLine("Play Again?");
            Restart();
            return;
        };
        if (TurnCount.ReadCount() > 8) {
            Console.Clear();
            Console.WriteLine("- TIED GAME -");
            Grid.GenerateGrid();
            Console.WriteLine("Yeah this game sucks huh lmao, run it back?");
            Restart();
            return;
        }
        RunIt(); // after 2 turns, run it again
        }
static public bool CheckVictoryO() {

    bool victoryState = false; // default victoryState
    string validWinO = "OOO"; // OOO as a string    

    if (Grid.cell1 + Grid.cell2 + Grid.cell3 == validWinO) {victoryState = true;} // check bottom row
    if (Grid.cell4 + Grid.cell5 + Grid.cell6 == validWinO) {victoryState = true;} // check middle row
    if (Grid.cell7 + Grid.cell8 + Grid.cell9 == validWinO) {victoryState = true;} // check top row
    if (Grid.cell1 + Grid.cell4 + Grid.cell7 == validWinO) {victoryState = true;} // check left column
    if (Grid.cell2 + Grid.cell5 + Grid.cell8 == validWinO) {victoryState = true;} // check middle column
    if (Grid.cell3 + Grid.cell6 + Grid.cell9 == validWinO) {victoryState = true;} // check right column
    if (Grid.cell1 + Grid.cell5 + Grid.cell9 == validWinO) {victoryState = true;} // check up-right slant
    if (Grid.cell7 + Grid.cell5 + Grid.cell3 == validWinO) {victoryState = true;} // check bottom-right slant

    return victoryState;
}
static public bool CheckVictoryX() {

    bool victoryState = false; // default victoryState
    string validWinX = "XXX"; // XXX as a string    

    if (Grid.cell1 + Grid.cell2 + Grid.cell3 == validWinX) {victoryState = true;} // check bottom row
    if (Grid.cell4 + Grid.cell5 + Grid.cell6 == validWinX) {victoryState = true;} // check middle row
    if (Grid.cell7 + Grid.cell8 + Grid.cell9 == validWinX) {victoryState = true;} // check top row
    if (Grid.cell1 + Grid.cell4 + Grid.cell7 == validWinX) {victoryState = true;} // check left column
    if (Grid.cell2 + Grid.cell5 + Grid.cell8 == validWinX) {victoryState = true;} // check middle column
    if (Grid.cell3 + Grid.cell6 + Grid.cell9 == validWinX) {victoryState = true;} // check right column
    if (Grid.cell1 + Grid.cell5 + Grid.cell9 == validWinX) {victoryState = true;} // check up-right slant
    if (Grid.cell7 + Grid.cell5 + Grid.cell3 == validWinX) {victoryState = true;} // check bottom-right slant

    return victoryState;
}
static public bool PlayerO() {

    bool victoryO = false;
    Console.WriteLine("- Turn: " + TurnCount.Count());
    Console.WriteLine("- Player O, where would you like to place?");
    Grid.GenerateGrid();
    int playerOinput = Convert.ToInt32(Console.ReadLine());
        if (playerOinput < 1 || playerOinput > 9) {
        Console.WriteLine("Not a valid position. Pick again");
        playerOinput = Convert.ToInt32(Console.ReadLine());
    }

    switch (playerOinput) // input = cell, if cell full retry, if cell empty, go ahead
    {
        case 1:
        if (Grid.cell1 == "X" || Grid.cell1 == "O") {
            TurnCount.MinusCount();
            Console.Clear();
            Console.WriteLine("Cell already taken, choose again.");
            PlayerO();
        } else {Grid.cell1 = "O";}
        break;
        case 2:
        if (Grid.cell2 == "X" || Grid.cell2 == "O")
        {
            TurnCount.MinusCount();
            Console.Clear();
            Console.WriteLine("Cell already taken, choose again.");
            PlayerO();
        } else {Grid.cell2 = "O";}
        break;
        case 3:
        if (Grid.cell3 == "X" || Grid.cell3 == "O")
        {
            TurnCount.MinusCount();
            Console.Clear();
            Console.WriteLine("Cell already taken, choose again.");
            PlayerO();
        } else {Grid.cell3 = "O";}
        break;
        case 4:
        if (Grid.cell4 == "X" || Grid.cell4 == "O")
        {
            TurnCount.MinusCount();
            Console.Clear();
            Console.WriteLine("Cell already taken, choose again.");
            PlayerO();
        } else {Grid.cell4 = "O";}
        break;
        case 5:
        if (Grid.cell5 == "X" || Grid.cell5 == "O")
        {
            TurnCount.MinusCount();
            Console.Clear();
            Console.WriteLine("Cell already taken, choose again.");
            PlayerO();
        } else {Grid.cell5 = "O";}
        break;
        case 6:
        if (Grid.cell6 == "X" || Grid.cell6 == "O")
        {
            TurnCount.MinusCount();
            Console.Clear();
            Console.WriteLine("Cell already taken, choose again.");
            PlayerO();
        } else {Grid.cell6 = "O";}
        break;
        case 7:
        if (Grid.cell7 == "X" || Grid.cell7 == "O")
        {
            TurnCount.MinusCount();
            Console.Clear();
            Console.WriteLine("Cell already taken, choose again.");
            PlayerO();
        } else {Grid.cell7 = "O";}
        break;
        case 8:
        if (Grid.cell8 == "X" || Grid.cell8 == "O")
        {
            TurnCount.MinusCount();
            Console.Clear();
            Console.WriteLine("Cell already taken, choose again.");
            PlayerO();
        } else {Grid.cell8 = "O";}
        break;
        case 9:
        if (Grid.cell9 == "X" || Grid.cell9 == "O")
        {
            TurnCount.MinusCount();
            Console.Clear();
            Console.WriteLine("Cell already taken, choose again.");
            PlayerO();
        } else {Grid.cell9 = "O";}
        break;
    };
    Console.Clear();
    if (CheckVictoryO() == true) {
        victoryO = true;
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("- Player O has won a Turn " + TurnCount.ReadCount() + " Victory, Congratulations. -");
        Grid.GenerateGrid();
    };

    return victoryO;
}
static public bool PlayerX() {

    
    bool victoryX = false;
    Console.WriteLine("- Turn: " + TurnCount.Count());
    Console.WriteLine("- Player X, where would you like to place?");
    Grid.GenerateGrid();
    int playerXinput = Convert.ToInt32(Console.ReadLine());
    if (playerXinput < 1 || playerXinput > 9) {
        Console.WriteLine("Not a valid position. Pick again");
        playerXinput = Convert.ToInt32(Console.ReadLine());
    }

    switch (playerXinput) // input = cell, if cell full retry, if cell empty, go ahead
    {
        case 1:
        if (Grid.cell1 == "X" || Grid.cell1 == "O") {
            TurnCount.MinusCount();
            Console.Clear();
            Console.WriteLine("Cell already taken, choose again.");
            PlayerX();
        } else {Grid.cell1 = "X";};        
        break;
        case 2:
        if (Grid.cell2 == "X" || Grid.cell2 == "O")
        {
            TurnCount.MinusCount();
            Console.Clear();
            Console.WriteLine("Cell already taken, choose again.");
            PlayerX();
        } else {Grid.cell2 = "X";}; 
        break;
        case 3:
        if (Grid.cell3 == "X" || Grid.cell3 == "O")
        {
            TurnCount.MinusCount();
            Console.Clear();
            Console.WriteLine("Cell already taken, choose again.");
            PlayerX();
        } else {Grid.cell3 = "X";}; 
        break;
        case 4:
        if (Grid.cell4 == "X" || Grid.cell4 == "O")
        {
            TurnCount.MinusCount();
            Console.Clear();
            Console.WriteLine("Cell already taken, choose again.");
            PlayerX();
        } else {Grid.cell4 = "X";}; 
        break;
        case 5:
        if (Grid.cell5 == "X" || Grid.cell5 == "O")
        {
            TurnCount.MinusCount();
            Console.Clear();
            Console.WriteLine("Cell already taken, choose again.");
            PlayerX();
        } else {Grid.cell5 = "X";}; 
        break;
        case 6:
        if (Grid.cell6 == "X" || Grid.cell6 == "O")
        {
            TurnCount.MinusCount();
            Console.Clear();
            Console.WriteLine("Cell already taken, choose again.");
            PlayerX();
        } else {Grid.cell6 = "X";}; 
        break;
        case 7:
        if (Grid.cell7 == "X" || Grid.cell7 == "O")
        {
            TurnCount.MinusCount();
            Console.Clear();
            Console.WriteLine("Cell already taken, choose again.");
            PlayerX();
        } else {Grid.cell7 = "X";}; 
        break;
        case 8:
        if (Grid.cell8 == "X" || Grid.cell8 == "O")
        {
            TurnCount.MinusCount();
            Console.Clear();
            Console.WriteLine("Cell already taken, choose again.");
            PlayerX();
        } else {Grid.cell8 = "X";}; 
        break;
        case 9:
        if (Grid.cell9 == "X" || Grid.cell9 == "O")
        {
            TurnCount.MinusCount();
            Console.Clear();
            Console.WriteLine("Cell already taken, choose again.");
            PlayerX();
        } else {Grid.cell9 = "X";}; 
        break;
    };
    Console.Clear();
    if (CheckVictoryX() == true) {
        victoryX = true;
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("- Player X has won a Turn " + TurnCount.ReadCount() + " Victory, Congratulations. -");
        Grid.GenerateGrid();
    };

    return victoryX;
}
static public void Restart() {
            Console.WriteLine("Y / N");
            string restartAnswer = Console.ReadLine();

            if (restartAnswer == "Y" || restartAnswer == "y") {
                TurnCount.ResetCount();
                Grid.ResetGrid();
                Console.Clear();
                RunIt();
            } else if (restartAnswer != "Y" || restartAnswer != "y") { 
                return;
            }
        }
}