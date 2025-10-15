using DungeonsAdventure.Interfaces;
using System.Collections.Generic;

namespace DungeonsAdventure.Models
{
    public class Room
    {   
        public string Name { get; set; }
        public string Description { get; set; }

        // List to hold interactive objects in the room
        public List<IInteractive> Interactives { get; set; }

        // Dictionary to hold exits to other rooms (e.g., "north" -> another Room)
        public Dictionary<string, Room> Exits { get; set; }

        // Constructor to initialize the room with interactive objects
        public Room(string name, string description)
        {
            Name = name;
            Description = description;

            // Initialize the list and dictionary
            Interactives = new List<IInteractive>();
            Exits = new Dictionary<string, Room>();
        }
    }
}