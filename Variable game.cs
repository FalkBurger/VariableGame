using System;

namespace Variables
{
	class Program
	{
		private static string username, password;
		private static int inputNumber = 0;
		
		static void Main(string[] args)
		{
			StartScreen();
			
			MainMenu();
		}
		
		static void MainMenu()
		{
			
		}
		
		static void StartScreen()
		{
			bool loopOne = false;
			while (!loopOne)
			{
				Console.WriteLine("Input a number and press enter/return\n");
				Console.WriteLine("1. Log in");
				Console.WriteLine("2. Create Account");
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
				
		}
	}
}