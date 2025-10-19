using DungeonsAdventure.Models;
using System;
using System.Collections.Generic;

namespace DungeonsAdventure.Services
{
    public class CommandParser
    {
        public string[] Parse(string userInput)
        {
            return userInput.Split(' ');
        }
    }
}