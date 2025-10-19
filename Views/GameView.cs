using DungeonsAdventure.Models;
using System;

namespace DungeonsAdventure.Views
{
    public class GameView
    {
        public void DisplayCurrentRoom(Room room)
        {
            Console.WriteLine("\n" + room.Name);
            Console.WriteLine(room.Description);
            Console.WriteLine("\nWhat do you want to do?");

            // List interactives with indices
            for (int i = 0; i < room.Interactives.Count; i++)
            {
                var interactive = room.Interactives[i];
                Console.WriteLine($"{i}: Interact with the {interactive.GetType().Name}");
            }

            // List available exits
            Console.WriteLine("Exits:");
            foreach (var exit in room.Exits)
            {
                Console.WriteLine($"- Go {exit.Key} to {exit.Value.Name}");
            }
        }

        public string GetInput()
        {
            Console.Write("> ");
            return Console.ReadLine()!.ToLower();
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DrawSeparator()
        {
            Console.WriteLine("_________________________________________________");
        }
    }
}