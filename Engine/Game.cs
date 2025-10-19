using DungeonsAdventure.Models;
using DungeonsAdventure.Interfaces;
using DungeonsAdventure.Factories;
using System;
using System.Collections.Generic;

namespace DungeonsAdventure.Engine
{
    public class Game
    {
        private readonly Player _player; // Player instance

        public Game()
        {
            Room startingRoom = WorldFactory.CreateWorld(); // Create the game world

            _player = new Player("Hero", startingRoom); // Initialize player in the entrance hall

        }

        public void Run()
        {
            while (true)
            {
                // 1. Display current room information
                Console.WriteLine("\n" + _player.CurrentRoom.Name);
                Console.WriteLine(_player.CurrentRoom.Description);

                // 2. List available interactives
                Console.WriteLine("\nWhat do you want to do?");

                // List interactives with indices
                for (int i = 0; i < _player.CurrentRoom.Interactives.Count; i++)
                {
                    var interactive = _player.CurrentRoom.Interactives[i];
                    Console.WriteLine($"{i}: Interract with the {interactive.GetType().Name}");
                }

                // List available exits
                Console.WriteLine("Exist:");
                foreach (var exit in _player.CurrentRoom.Exits)
                {
                    Console.WriteLine($"- Go {exit.Key} to {exit.Value.Name}");
                }

                // 3. Get player input
                Console.WriteLine("> ");
                string input = Console.ReadLine()!.ToLower();
                string[] parts = input.Split(' '); // Split input into parts
                string command = parts[0]; // First part is the command

                if (command == "go" && parts.Length > 1)
                {
                    string direction = parts[1];
                    if (_player.CurrentRoom.Exits.ContainsKey(direction))
                    {
                        _player.CurrentRoom = _player.CurrentRoom.Exits[direction];
                        Console.WriteLine($"You move {direction} to the {_player.CurrentRoom.Name}.");
                    }
                    else
                    {
                        Console.WriteLine("You can't go that way.");
                    }
                }

                if (int.TryParse(input, out int choice) && choice >= 0 && choice <_player.CurrentRoom.Interactives.Count)
                {
                    _player.CurrentRoom.Interactives[choice].Interact();
                }
                else
                {
                    Console.WriteLine("Invalid choice. ");
                }

                Console.WriteLine("__________________________________________");
            }
        }
    }
}
