// See https://aka.ms/new-console-template for more information
/*
 * start game
 * create board
 * x turn update
 * check who one
 * y turn update
 * check who won
 * once someone wins ask :restart, quit
 * restart - start again
 * quit - close program 
 */

using System.Globalization;

string[] board = new string[9];
bool xspace = true;
bool ospace = true;
bool gamecontinue = true;
int count = 0;
tictactoe();

void tictactoe()
{
    clearboard();
    drawboard();
    game();

}

void clearboard()
{
    Console.WriteLine("welcome to the TicTacToe game");
    for (int i = 0; i < board.Length; i++)
    {
        board[i] = " ";
    }
}

void game()
{
    count = 0;
    while (gamecontinue) 
    {
        xspace = true;
        ospace = true;
        turnX();
        count++;
        gamescore();
        turnO();
        count++;
        gamescore();
    }
}

void turnX()
{
    Console.WriteLine("X'x turn");
    while (xspace)
    {
        string positionx = Console.ReadLine();
        if (checkuserinput(positionx))
        {
            int position = int.Parse(positionx);
            if (board[position - 1] != " ")
            {
                Console.WriteLine("sorry this is taken try again");
            }
            else
            {
                board[position - 1] = "X";
                drawboard();
                xspace = false;
            }
        }
    }
}

void turnO()
{
    Console.WriteLine("O's turn");
    while (ospace)
    {
        string positiono = Console.ReadLine();
        if (checkuserinput(positiono))
        {
            int position = int.Parse(positiono);
            if (board[position - 1] != " ")
            {
                Console.WriteLine("sorry this is taken try again");
            }
            else
            {
                board[position - 1] = "O";
                drawboard();
                ospace = false;
            }
        }
    }
}

void drawboard()
{
    Console.WriteLine
        ($" {board[0]} | {board[1]} | {board[2]}\n"+
        $"---+---+---\n"+
        $" {board[3]} | {board[4]} | {board[5]}\n"+
        $"---+---+---\n"+
        $" {board[6]} | {board[7]} | {board[8]}\n");
}

void gamescore()
{
    if (board[0] == "X" && board[1] == "X" && board[2] == "X") { Console.WriteLine("THE WINNER IS X!");gamecontinue = false; gameend(); }
    else if (board[0] == "X" && board[4] == "X" && board[8] == "X") { Console.WriteLine("THE WINNER IS X!"); gamecontinue = false; gameend(); }
    else if (board[0] == "X" && board[3] == "X" && board[6] == "X") { Console.WriteLine("THE WINNER IS X!"); gamecontinue = false; gameend(); }
    else if (board[1] == "X" && board[4] == "X" && board[7] == "X") { Console.WriteLine("THE WINNER IS X!"); gamecontinue = false; gameend(); }
    else if (board[2] == "X" && board[5] == "X" && board[8] == "X") { Console.WriteLine("THE WINNER IS X!"); gamecontinue = false; gameend(); }
    else if (board[2] == "X" && board[4] == "X" && board[6] == "X") { Console.WriteLine("THE WINNER IS X!"); gamecontinue = false; gameend(); }
    else if (board[3] == "X" && board[4] == "X" && board[5] == "X") { Console.WriteLine("THE WINNER IS X!"); gamecontinue = false; gameend(); }
    else if (board[6] == "X" && board[7] == "X" && board[8] == "X") { Console.WriteLine("THE WINNER IS X!"); gamecontinue = false; gameend(); }
    else if (board[0] == "O" && board[1] == "O" && board[2] == "O") { Console.WriteLine("THE WINNER IS O!"); gamecontinue = false; gameend(); }
    else if (board[0] == "O" && board[4] == "O" && board[8] == "O") { Console.WriteLine("THE WINNER IS O!"); gamecontinue = false; gameend(); }
    else if (board[0] == "O" && board[3] == "O" && board[6] == "O") { Console.WriteLine("THE WINNER IS O!"); gamecontinue = false; gameend(); }
    else if (board[1] == "O" && board[4] == "O" && board[7] == "O") { Console.WriteLine("THE WINNER IS O!"); gamecontinue = false; gameend(); }
    else if (board[2] == "O" && board[5] == "O" && board[8] == "O") { Console.WriteLine("THE WINNER IS O!"); gamecontinue = false; gameend(); }
    else if (board[2] == "O" && board[4] == "O" && board[6] == "O") { Console.WriteLine("THE WINNER IS O!"); gamecontinue = false; gameend(); }
    else if (board[3] == "O" && board[4] == "O" && board[5] == "O") { Console.WriteLine("THE WINNER IS O!"); gamecontinue = false; gameend(); }
    else if (board[6] == "O" && board[7] == "O" && board[8] == "O") { Console.WriteLine("THE WINNER IS O!"); gamecontinue = false; gameend(); }
    else if (count >= 9 ){ Console.WriteLine("ITS A DRAW!"); gamecontinue = false; gameend(); }
    else { gamecontinue = true;}
}

void gameend()
{
    bool question = true;
    while (question)
    {
        Console.WriteLine("Would you like to play again?\n1. Yes\n2. Exit");
        String text = Console.ReadLine();
        if (checkuserinput(text))
        {
            int parsed = int.Parse(text);
            if (parsed == 1) { question = false; tictactoe(); }
            else if (parsed == 2) { question = false; }
            else { Console.WriteLine("input is out of range"); }
        }
    }
}

bool checkuserinput(string input)
{
    if (input == "")
    {
        Console.WriteLine("User input is empty");
        return false;
    }
    else
    {
        bool tryparse = int.TryParse(input, out int a);
        if (tryparse) { return true; }
        else
        {
            Console.WriteLine("Input is not a number");
            return false;
        }
    }
}