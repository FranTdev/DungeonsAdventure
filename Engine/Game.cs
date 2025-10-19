using DungeonsAdventure.Models;
using DungeonsAdventure.Interfaces;
using DungeonsAdventure.Factories;
using DungeonsAdventure.Services;
using DungeonsAdventure.Views;
using System;
using System.Collections.Generic;

namespace DungeonsAdventure.Engine
{
    public class Game
    {
        private readonly Player _player; 
        private readonly GameView _view;
        private readonly CommandParser _parser;

        public Game()
        {
            Room startingRoom = WorldFactory.CreateWorld(); // Create the game world

            _player = new Player("Hero", startingRoom);
            _view = new GameView();
            _parser = new CommandParser();

        }

        public void Run()
        {
            while (true)
            {
                _view.DisplayCurrentRoom(_player.CurrentRoom);

                string input = _view.GetInput();

                string[] parts = _parser.Parse(input);
                string command = parts[0];

                if (command == "go" && parts.Length > 1)
                {
                    string direction = parts[1];
                    if (_player.CurrentRoom.Exits.ContainsKey(direction))
                    {
                        _player.CurrentRoom = _player.CurrentRoom.Exits[direction];
                    }
                    else
                    {
                        _view.DisplayMessage("You can't go that way.");
                    }
                }
                else if (int.TryParse(command, out int choice) && choice >= 0 && choice < _player.CurrentRoom.Interactives.Count)
                {
                    _player.CurrentRoom.Interactives[choice].Interact();
                }
                else
                {
                    _view.DisplayMessage("Invalid command.");
                }

                _view.DrawSeparator();
            }
        }
    }
}
