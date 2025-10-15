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
                Console.WriteLine("\n" + _player.CurrentRoom.Name);
                Console.WriteLine(_player.CurrentRoom.Description);

                Console.WriteLine("\nWhat do you want to do?");

                for (int i = 0; i < _player.CurrentRoom.Interactives.Count; i++)
                {
                    var interactive = _player.CurrentRoom.Interactives[i];
                    Console.WriteLine($"{i}: Interract with the {interactive.GetType().Name}");
                }

                Console.WriteLine("> ");
                string input = Console.ReadLine()!;

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
