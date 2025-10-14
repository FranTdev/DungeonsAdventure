using DungeosAdventure.Interfaces;
using System;

namespace DungeosAdventure.Models
{
    public class Chest : IInteractive
    {
        public void Interact()
        {
            Console.WriteLine("You open the chest. It's filled with gold and jewels!");
        }
    }
}