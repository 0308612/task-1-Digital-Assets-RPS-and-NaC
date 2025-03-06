using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assesment_1_IT_Sebastian_S 
{
	internal class Program
	{
		static string[,] arr = {{"1", "2", "3" }, { "4", "5", "6"}, { "7", "8", "9"}};
		static int player = 1;
		static int flag = 0;
		static int rounds = 1;
		static int pScore;
		static int cScore;
		static string input;
		static string win;

		public static void Main(string[] args)
		{
			{
				string Value = "type RPS to play Rock, Paper, Scissors OR type NAC to play Naughts and Crosses";

				Console.WriteLine("Hello");
				Console.WriteLine(Value);
				string RPSORNaC = Console.ReadLine();
				string RPSORNaCtrimed = RPSORNaC.Trim();
				string RPSORNaCtrimedupper = RPSORNaCtrimed.ToUpper();
				if (RPSORNaCtrimedupper == "RPS")
				{
					while (rounds <= 3)
					{
						if (((rounds == 1 || rounds == 2) && input != "rock" || input != "paper" || input != "scissors" || rounds == 3 && pScore == 1 && cScore == 1 && input != "rock" || input != "paper" || input != "scissors") && win != "yes" && win != "no" && win != "tie")
						{
							RPS();
							rounds++;
						}
						if ((pScore == 2 && cScore == 1) || (pScore == 3 && cScore == 2) || (pScore == 2 && cScore == 0))
						{
							win = "yes";
							Console.WriteLine("\n");
							Console.WriteLine("your score was " + pScore + " and the conputers score was " + cScore);
							Console.WriteLine("You have won the most rounds CONGRATULATIONS!");
							Console.ReadLine();
							Environment.Exit(0);
						}
						if ((pScore == 1 && cScore == 2) || (pScore == 2 && cScore == 3) || (pScore == 0 && cScore == 2))
						{
							win = "no";
							Console.WriteLine("\n");
							Console.WriteLine("your score was " + pScore + " and the conputers score was " + cScore);
							Console.WriteLine("The conputer has won the most rounds, Better luck next time");
							Console.ReadLine();
							Environment.Exit(0);
						}
						if ((pScore == 2 && cScore == 2 && rounds == 3) || pScore == 3 && cScore == 3)
						{
							win = "tie";
							Console.WriteLine("\n");
							Console.WriteLine("your score was " + pScore + " and the conputers score was " + cScore);
							Console.WriteLine("You and the conpuer tied, Better luck next time");
							Console.ReadLine();
							Environment.Exit(0);
						}
					}
				}
				else if (RPSORNaCtrimedupper == "NAC")
				{
					NaC();
				}
				else
                {
					Console.WriteLine("you did not put in a acceptable input");
				}
				// load all 
			//	Console.ReadLine();
			}
			Console.ReadLine();
		}
		public static void NaC()
        {
			//naught and Crosses
			string welcome = "Welcome to Naughts and Crosses";
			Program p = new Program();
			Console.WriteLine();
			Console.WriteLine(welcome);
			do
			{
				Console.WriteLine("Player1:X and Player2:O");
				Console.WriteLine("\n");
				if (player % 2 == 0)
				{
					Console.WriteLine("Player 2 Turn");
				}
				else
				{
					Console.WriteLine("Player 1 Trun");
				}
				Console.WriteLine("\n");
				Board();
				Console.WriteLine("\ntype a number corresponding to where you want to go");
				Console.WriteLine();
				string input = Console.ReadLine();
				int choice;
				Int32.TryParse(input.Substring(0, 1), out choice);
				int choice1 = choice - 1;
				int row = choice1 / 3;
				int column = choice1 % 3;
				if (arr[row, column] != "X" && arr[row, column] != "O")
				{
					if (player % 2 == 0)
					{
						arr[row, column] = "O";
						player++;
					}
					else
					{
						arr[row, column] = "X";
						player++;
					}
				}
				else
				{
					Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, arr[row, column]);
					Console.WriteLine("Please wait 2 seconds board is loading again.....");
					Thread.Sleep(2000);
					Console.WriteLine("\n\n");
				}
                flag = CheckWin();
			}
			while (flag != 1 && flag != -1);
			{
				Board();
			}
			if (flag == 1)
			{
				Console.WriteLine("\nPlayer {0} has won!", (player % 2) + 1);
			}
			else
			{
				Console.WriteLine("\nIt was a TIE!");
			}
			Console.ReadLine();
		}
		public static void Board()
		{
			for (int i = 0; i < 3; i++)
			{

				for (int j = 0; j < 3; j++)
				{
					if (j != 0)
					{
						Console.Write(" | ");
					}
					Console.Write(/*" " +*/ arr[i, j] /*+ " "*/);
				}
				if (i < 2)
				{
					Console.WriteLine();
					Console.WriteLine("----------");
				}
			}
		}
		public static int CheckWin()
		{
			if (arr[0,0] == arr[0,1] && arr[0,1] == arr[0,2] || arr[1,0] == arr[1,1] && arr[1,1] == arr[1,2] || arr[2,0] == arr[2,1] && arr[2,1] == arr[2,2])
			{
				return 1;
			}
			else if (arr[0, 0] == arr[1,0] && arr[1,0] == arr[2,0] || arr[0,1] == arr[0,0] && arr[0,0] == arr[2,1] || arr[0,2] == arr[1,2] && arr[1,2] == arr[2,2])
			{
				return 1;
			}
			else if (arr[0, 0] == arr[0,0] && arr[0,0] == arr[2,2] || arr[0,2] == arr[0,0] && arr[0,0] == arr[2,0])
			{
				return 1;
			}
			else if (arr[0, 0] != "1" && arr[0,1] != "2" && arr[0,2] != "3" && arr[1,0] != "4" && arr[1,1] != "5" && arr[1,2] != "6" && arr[2,0] != "7" && arr[2,1] != "8" && arr[2,2] != "9")
			{
				return -1;
			}
			else
			{
				return 0;
			}
		}
		public static void RPS()
        {
				string computerInput;
				Random rand = new Random();
				int randomValue;
				string welcome1 = "Welcome to Rock, Paper, Scissors , Please type your move";
				string welcome2 = "Welcome to round " + rounds + " of RPS, Please type your move";

				if (rounds == 1)
				{
					Console.WriteLine(welcome1);
				}
				else
				{
					Console.WriteLine();
					Console.WriteLine("round " + rounds);
					Console.WriteLine("the score is " + pScore + " : " + cScore);
					Console.WriteLine(welcome2);
				}
				input = Console.ReadLine().ToLower();
				if (input == "rock" || input == "paper" || input == "scissors")
				{
					Console.WriteLine("your move was " + input.ToUpper());
					randomValue = rand.Next(1, 4);
					if (randomValue == 1)
					{
						computerInput = "rock";
					}
					else if (randomValue == 2)
					{
						computerInput = "paper";
					}
					else
					{
						computerInput = "scissors";
					}
					//win lose or tie
					if (input == "rock" && computerInput == "rock" || input == "paper" && computerInput == "paper" || input == "scissors" && computerInput == "scissors")
					{
						Console.WriteLine("The computer went " + computerInput + ", It was a TIE!");
						cScore++;
						pScore++;
					}
					if (input == "paper" && computerInput == "rock" || input == "scissors" && computerInput == "paper" || input == "rock" && computerInput == "scissors")
					{
						Console.WriteLine("The computer went " + computerInput + ", You WIN!");
						pScore++;
					}
					if (input == "scissors" && computerInput == "rock" || input == "rock" && computerInput == "paper" || input == "paper" && computerInput == "scissors")
					{
						Console.WriteLine("The computer went " + computerInput + ", You LOSE!");
						cScore++;
					}
				}
				else
				{
					Console.WriteLine("you did not put in a acceptable input");
				}
        }
    }
}