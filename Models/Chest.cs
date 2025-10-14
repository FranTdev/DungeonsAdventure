using DungeonsAdventure.Interfaces;
using System;

namespace DungeonsAdventure.Models
{
    public class Chest : IInteractive
    {
        public void Interact()
        {
            Console.WriteLine("You open the chest. It's filled with gold and jewels!");
        }
    }
}