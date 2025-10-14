using DungeonsAdventure.Interfaces;
using System;

namespace DungeonsAdventure.Models
{
    public class Enemy : IInteractive
    {
        public void Interact()
        {
            Console.WriteLine("You encounter a fearsome enemy! Prepare for battle!");
        }
    }
}