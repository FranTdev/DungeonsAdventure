using DungeonsAdventure.Interfaces;
using DungeonsAdventure.Models;
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a list to hold interactive game objects
        List<IInteractive> gameObjects = new List<IInteractive>();

        // Add different interactive objects to the list
        gameObjects.Add(new Door());
        gameObjects.Add(new Chest());
        gameObjects.Add(new Enemy());

        // Game loop
        while (true)
        {

            Console.WriteLine("\nYou are in a dark room. You see several objects. What do you want to interact with?");

            // Display options to the player
            for (int i = 0; i < gameObjects.Count; i++)
            {
                // Display the type of the object (Door, Chest, Enemy)
                Console.WriteLine($"{i}: A {gameObjects[i].GetType().Name}");
            }

            Console.WriteLine("> ");
            string input = Console.ReadLine()!;

            // Validate input
            if (int.TryParse(input, out int choice) && choice >= 0 && choice < gameObjects.Count)
            {
                // Interact with the chosen object
                gameObjects[choice].Interact();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

            Console.WriteLine("--------------------------------------");
        }
    }
}
