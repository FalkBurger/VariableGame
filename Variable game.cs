using System;
using System.IO;

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
			Console.Clear();
			
			Console.WriteLine("Variable Game Menu\n");
			
			Console.WriteLine("1) Save Profile");
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
				counter++;
			}
			
			password = fileReader[0];
			
			if (readPassword != password)
			{
				Console.WriteLine("Invalid password");
				Console.ReadLine();
				StartScreen();
			}
		}
	}
}