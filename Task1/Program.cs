using System;
using System.Collections.Generic;
using Task1;

class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter your name: ");
        string playerName = Console.ReadLine();

        Console.WriteLine("\nPlayer generated");
        Random random = new Random();
        int playerMaxHP = random.Next(100, 200);
        int playerInventorySize = random.Next(10, 15);

        GameSession gameSession = new GameSession(playerName, playerMaxHP, playerInventorySize);
        gameSession.PlayGame();
    }
}