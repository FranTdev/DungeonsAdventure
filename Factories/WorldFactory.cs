using DungeonsAdventure.Models;

namespace DungeonsAdventure.Factories 
{
    public static class WorldFactory
    {
        public static Room CreateWorld() 
        {
            // Initialize rooms
            var entrance = new Room("Entrance Hall", "A large, dusty hall with a single torch.");
            var armory = new Room("Armory", "A small room filled with rusty weapons. ");

            // Connect rooms
            entrance.Exits.Add("north", armory);
            armory.Exits.Add("south", entrance);

            // Create the items in the rooms
            entrance.Interactives.Add(new Door());
            armory.Interactives.Add(new Chest());
            armory.Interactives.Add(new Enemy());

            return entrance; // Return the starting room
        }
    }
}