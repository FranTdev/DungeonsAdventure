using DungeonsAdventure.Models;
using DungeonsAdventure.Interfaces;
using System;
using System.Collections.Generic;

namespace DungeonsAdventure.Engine
{
    public class Game
    {
        private readonly Player _player; // Player instance

        public Game()
        {
            // Initialize rooms
            var entrance = new Room("Entrance Hall", "A large, dusty hall with a single torch.");
            var armory = new Room("Armory", "A small room filled with rusty weapons. ");

            // The north exit from Entrance Hall leads to Armory
            entrance.Exits.Add("north", armory);
            // The south exit from Armory leads back to Entrance Hall
            armory.Exits.Add("south", entrance);

            // Create the items in the rooms
            entrance.Interactives.Add(new Door());
            armory.Interactives.Add(new Chest());
            armory.Interactives.Add(new Enemy());

            _player = new Player("Hero", entrance); // Initialize player in the entrance hall

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
