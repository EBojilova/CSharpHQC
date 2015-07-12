namespace Application2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Minesweeper
    {
        private const int MaxTurns = 35;

        private const int MaxRows = 5;

        private const int MaxCols = 10;

        private static string command = string.Empty;

        private static char[,] playgroundField;

        private static char[,] bombs;

        private static Player currentPlayer = new Player();

        private static List<Player> players = new List<Player>(6);

        private static int rowPlayer;

        private static int colPlayer;

        private static bool gameStarted;

        private static void Main()
        {
            do
            {
                if (!gameStarted)
                {
                    gameStarted = true;
                    playgroundField = CreatePlaygroundField();
                    bombs = PutTheBombs();
                    var sb = new StringBuilder();
                    sb.AppendLine("Lets play a game “Mini4KI”.");
                    sb.AppendLine("Try to step on a field without mines.");
                    sb.AppendLine("Commands:");
                    sb.AppendLine("'top' shows the rating,");
                    sb.AppendLine("'restart' starts a new game");
                    sb.AppendLine("'exit' exits the game and Good Bye!");
                    Console.Write(sb.ToString());
                    PrintPlayGroundField(playgroundField);
                    Console.Write("Please enter your nickname: ");
                    var playerName = Console.ReadLine();
                    currentPlayer = new Player(playerName, 0);
                    if (players.Count < 5)
                    {
                        players.Add(currentPlayer);
                    }
                    else
                    {
                        for (var i = 0; i < players.Count; i++)
                        {
                            if (players[i].Score <= currentPlayer.Score)
                            {
                                players.Insert(i, currentPlayer);
                                players.RemoveAt(players.Count - 1);
                                break;
                            }
                        }
                    }
                }

                Console.Write("Enter row[0...4] and column[0...9], separated by space: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out rowPlayer)
                        && int.TryParse(command[2].ToString(), out colPlayer)
                        && rowPlayer < playgroundField.GetLength(0) && colPlayer < playgroundField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintRating();
                        break;
                    case "restart":
                        playgroundField = CreatePlaygroundField();
                        bombs = PutTheBombs();
                        PrintPlayGroundField(playgroundField);
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye, bye!");
                        break;
                    case "turn":
                        if (bombs[rowPlayer, colPlayer] != '*')
                        {
                            if (bombs[rowPlayer, colPlayer] == '-')
                            {
                                SetPlayerOnEnteredPositon();
                                currentPlayer.Score++;
                            }

                            if (MaxTurns == currentPlayer.Score)
                            {
                                Console.WriteLine(
                                    "\nCONGRATULATIONS, {0}! You made {1} steps without exploding a bomb.", 
                                    currentPlayer.Name, 
                                    currentPlayer.Score);
                                PrintPlayGroundField(bombs);
                                PrintRating();
                                gameStarted = false;
                            }
                            else
                            {
                                PrintPlayGroundField(playgroundField);
                            }
                        }
                        else
                        {
                            PrintPlayGroundField(bombs);
                            Console.WriteLine("\nHrrrrrr! Sorry {0}, you stepped on mine and died.", currentPlayer.Name);
                            Console.WriteLine("You made {0} steps without exploding a bomb.", currentPlayer.Score);
                            PrintRating();
                            gameStarted = false;
                        }

                        break;
                    default:
                        Console.WriteLine("\nInvalid command! Please enter again!\n");
                        break;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("Have a nice day!");
        }

        private static void PrintRating()
        {
            SortPlayers();
            Console.WriteLine("\nRating:");
            if (players.Count > 0)
            {
                for (var i = 0; i < players.Count; i++)
                {
                    Console.WriteLine(
                        "{0}. {1} --> {2} sucess steps, before bomb exploded", 
                        i + 1, 
                        players[i].Name, 
                        players[i].Score);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No players paticipate the game!\n");
            }
        }

        private static void SortPlayers()
        {
            players = players.OrderByDescending(p => p.Score).ThenBy(p => p.Name).ToList();
        }

        private static void SetPlayerOnEnteredPositon()
        {
            bombs[rowPlayer, colPlayer] = BombsArround();
            playgroundField[rowPlayer, colPlayer] = BombsArround();
        }

        private static void PrintPlayGroundField(char[,] board)
        {
            var rows = board.GetLength(0);
            var cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (var i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (var j = 0; j < cols; j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlaygroundField()
        {
            var board = new char[MaxRows, MaxCols];
            for (var row = 0; row < board.GetLength(0); row++)
            {
                for (var col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = '?';
                }
            }

            return board;
        }

        private static char[,] PutTheBombs()
        {
            bombs = new char[MaxRows, MaxCols];

            for (var row = 0; row < bombs.GetLength(0); row++)
            {
                for (var col = 0; col < bombs.GetLength(1); col++)
                {
                    bombs[row, col] = '-';
                }
            }

            var bombsCollection = new List<int>();
            while (bombsCollection.Count < 15)
            {
                var random = new Random();
                var bombPostion = random.Next(50);
                if (!bombsCollection.Contains(bombPostion))
                {
                    bombsCollection.Add(bombPostion);
                }
            }

            foreach (var bombPostion in bombsCollection)
            {
                var rowBombs = bombPostion / bombs.GetLength(1);
                var colBoms = bombPostion % bombs.GetLength(1);
                if (colBoms == 0 && bombPostion != 0)
                {
                    rowBombs--;
                    colBoms = bombs.GetLength(1) - 1;
                }

                bombs[rowBombs, colBoms] = '*';
            }

            return bombs;
        }

        private static char BombsArround()
        {
            var brojkata = 0;
            brojkata += BombInPosition(-1, 0);
            brojkata += BombInPosition(-1, -1);
            brojkata += BombInPosition(-1, 1);
            brojkata += BombInPosition(1, 0);
            brojkata += BombInPosition(1, -1);
            brojkata += BombInPosition(1, 1);
            brojkata += BombInPosition(0, -1);
            brojkata += BombInPosition(0, 1);

            return char.Parse(brojkata.ToString());
        }

        private static int BombInPosition(int rowChange, int colChange)
        {
            var row = rowPlayer + rowChange;
            var col = colPlayer + colChange;
            if (row >= 0 && row < bombs.GetLength(0) && col >= 0 && col < bombs.GetLength(1))
            {
                if (bombs[row, col] == '*')
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}