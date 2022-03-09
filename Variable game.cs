using System;
using System.IO;

namespace Variables
{
	class Program
	{
		private static string username, password;
		private static int strength = 10, dexterity = 10, will = 10, inteligence = 10;
		private static int inputNumber = 0;
		
		static void Main(string[] args)
		{
			StartScreen();
			
			MainMenu();
		}
		
		static void MainMenu()
		{
			bool doLoop = true;
			while (doLoop)
			{
				Console.Clear();			
				Console.WriteLine("Variable Game Menu\n");	
				Console.WriteLine("1) View Statistics");		
				Console.WriteLine("2) Save Profile");
				Console.WriteLine("3) Exit game");		
				Console.Write(">> ");
				
				try
				{
					inputNumber = Convert.ToInt32(Console.ReadLine());
					if ((inputNumber > 0) || (inputNumber < 3))
						doLoop = true;
					else
						Console.Clear();
				}
				catch
				{
					Console.Clear();
				}

				switch (inputNumber)
				{
					case 1:
						ViewStats();
						break;

					case 2:
						SaveGame();
						break;
					
					case 3:
						doLoop = false;
						break;
				}
			}	
		}

		static void ViewStats()
		{
			Console.Clear();
			Console.WriteLine("Your character's stats. Refer to readme for how they work\n");

			Console.WriteLine($"Str: {strength}");
			Console.WriteLine($"Dex: {dexterity}");
			Console.WriteLine($"Will: {will}");
			Console.WriteLine($"Int: {inteligence}");
			Console.ReadLine();
		}

		static void SaveGame()
		{
			string outputText = $"{password}\n{strength}\n{dexterity}\n{will}\n{inteligence}";

			File.WriteAllText($"{username}.txt",outputText);
		}
		
		static void StartScreen()
		{
			Console.Clear();
			bool loopOne = false;
			while (!loopOne)
			{
				Console.WriteLine("Input a number and press enter/return\n");
				Console.WriteLine("1) Log in");
				Console.WriteLine("2) Create Account");
				Console.Write(">> ");
				
				try
				{
					inputNumber = Convert.ToInt32(Console.ReadLine());
					if ((inputNumber == 1) || (inputNumber == 2))
						loopOne = true;
					else
						Console.Clear();
				}
				catch
				{
					Console.Clear();
				}
			}

			switch (inputNumber)
			{
				case 1:
					LogIn();
					break;
					
				case 2:
					CreateAccount();
					break;
			}
		}
		
		static void CreateAccount()
		{
			Console.WriteLine("What do you want your username to be?");
				Console.Write(">> ");
			username = Console.ReadLine();
			
			Console.WriteLine("What do you want your password to be?");
				Console.Write(">> ");
			password = Console.ReadLine();			
		}
			
		static void LogIn()
		{
			string readUsername, readPassword;
			string[] fileReader = new string[64];
			int counter = 0;
			
			Console.Write("Enter username: ");
			readUsername = Console.ReadLine();
			
			if (!File.Exists($"{readUsername}.txt"))
			{
				Console.WriteLine("Invalid username");
				Console.ReadLine();
				StartScreen();
			}
			
			Console.Write("Enter password: ");
			readPassword = Console.ReadLine();
			
			foreach (string line in File.ReadLines($"{readUsername}.txt"))
			{
				fileReader[counter] = line;

				switch (counter)
				{
					case 0:			
						password = fileReader[counter];
						break;

					case 1:
						strength = Convert.ToInt32(fileReader[counter]);
						break;

					case 2:
						dexterity = Convert.ToInt32(fileReader[counter]);
						break;

					case 3:
						will = Convert.ToInt32(fileReader[counter]);
						break;

					case 4:
						inteligence = Convert.ToInt32(fileReader[counter]);
						break;
				}

				counter++;
			}
			
			if (readPassword != password)
			{
				Console.WriteLine("Invalid password");
				Console.ReadLine();
				StartScreen();
			}
		}
	}
}