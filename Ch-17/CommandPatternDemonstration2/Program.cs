using System;
using System.Collections.Generic;

namespace CommandPatternDemonstration2
{
    //Receiver Class
    public class Game
    {
        string gameName;
        public int level;
        public Game(string name)
        {
            this.gameName = name;
            level = -1;
            Console.WriteLine($"Game started.");
        }     
        public void DisplayLevel()
        {
            //Console.WriteLine("The score is changing time to time.");
            Console.WriteLine($"Current level is set to {level}.");
        }
        public void UpLevel()
        {
            ++level;
            Console.WriteLine("Level upgraded.");
        }
        public void DownLevel()
        {
            --level;
            Console.WriteLine("Level downgraded.");
        }
        public void Finish()
        {
            Console.WriteLine($"---The game of {gameName} is over.---");
        }

    }
    public interface ICommand
    {
        void Execute();
        void Undo();

    }
    /// <summary>
    /// GameStartCommand
    /// </summary>
    public class GameStartCommand : ICommand
    {
        private Game game;
        public GameStartCommand(Game game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.UpLevel();
            game.DisplayLevel();
        }

        public void Undo()
        {
            if (game.level > 0)
            {
                game.DownLevel();
                game.DisplayLevel();
            }
            else
            {
                game.Finish();
            }
        }
    }
    

    /// <summary>
    /// Invoker class
    /// </summary>
    public class RemoteControl
    {
        ICommand commandToBePerformed, lastCommandPerformed;
        List<ICommand> savedCommands = new List<ICommand>();
        public void SetCommand(ICommand command)
        {
            this.commandToBePerformed = command;
        }
        public void ExecuteCommand()
        {
            commandToBePerformed.Execute();
            lastCommandPerformed = commandToBePerformed;
            savedCommands.Add(commandToBePerformed);
        }

        public void UndoCommand()
        {
            //Undo the last command executed
            lastCommandPerformed.Undo();
        }
        public void UndoAll()
        {
            for (int i = savedCommands.Count; i > 0; i--)
            {
                //Get a restore point and call Undo()                
                savedCommands[i - 1].Undo();
            }
           
        }
    }
    /// <summary>
    /// Client code
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Command Pattern Demonstration2***\n");

            // Client holds both the Invoker and Command Objects
            RemoteControl invoker = new RemoteControl();

            Game gameName = new Game("Golf");
            //Command to start the game
            GameStartCommand gameStartCommand = new GameStartCommand(gameName);          

            Console.WriteLine("**Starting the game and upgrading the level 3 times.**");
            invoker.SetCommand(gameStartCommand);
            invoker.ExecuteCommand();
            invoker.ExecuteCommand();
            invoker.ExecuteCommand();

            //Performing undo operation(s) one at a time
            //invoker.UndoCommand();
            //invoker.UndoCommand();
            //invoker.UndoCommand();
            
            Console.WriteLine("\nUndoing all the previous commands at one shot.");
            invoker.UndoAll();
            Console.ReadKey();
        }
    }
}
