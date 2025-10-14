using DungeonsAdventure.Interfaces;
using System;

namespace DungeonsAdventure.Models
{
    public class Door : IInteractive
    {
        public void Interact()
        {
            Console.WriteLine("You try to open the door. It's locked.");
        }
    }
}
