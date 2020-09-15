using System;

namespace CommandPattern
{
    /// <summary>
    ///  Receiver Class
    /// </summary>  
    public class Game
    {
        string gameName;
        public Game(string name)
        {
            this.gameName = name;
        }
        public void Start()
        {
            Console.WriteLine($"{gameName} is on.");
        }
        public void DisplayScore()
        {
            Console.WriteLine("The score is changing time to time.");
        }
        public void Finish()
        {
            Console.WriteLine($"---The game of {gameName} is over.---");
        }

    }
    /// <summary>
    /// The command interface
    /// </summary>
    public interface ICommand
    {
        //To execute a command
        void Execute();
        //To undo last command execution
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
            game.Start();
            game.DisplayScore();
        }

        public void Undo()
        {
            Console.WriteLine("Undoing start command.");
            game.Finish();
        }
    }
    /// <summary>
    /// GameStopCommand
    /// </summary>

    public class GameStopCommand : ICommand
    {
        private Game game;
        public GameStopCommand(Game game)
        {
            this.game = game;
        }
        public void Execute()
        {
            Console.WriteLine("Finishing the game.");
            game.Finish();
        }

        public void Undo()
        {
            Console.WriteLine("Undoing stop command.");
            game.Start();
            game.DisplayScore();
        }
    }

    /// <summary>
    /// Invoker class
    /// </summary>
    public class RemoteControl
    {
        ICommand commandToBePerformed, lastCommandPerformed;
        public void SetCommand(ICommand command)
        {
            this.commandToBePerformed = command;
        }
        public void ExecuteCommand()
        {
            commandToBePerformed.Execute();
            lastCommandPerformed = commandToBePerformed;
        }
       
        public void UndoCommand()
        {
            //Undo the last command executed
            lastCommandPerformed.Undo();            
        }
    }
    /// <summary>
    /// Client code
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Command Pattern Demonstration***\n");

            /*Client holds both the Invoker and Command Objects*/
            RemoteControl invoker = new RemoteControl();

            Game gameName = new Game("Golf");
            //Command to start the game
            GameStartCommand gameStartCommand = new GameStartCommand(gameName);
            //Command to stop the game
            GameStopCommand gameStopCommand = new GameStopCommand(gameName);

            Console.WriteLine("**Starting the game and performing undo immediately.**");
            invoker.SetCommand(gameStartCommand);
            invoker.ExecuteCommand();
            //Performing undo operation
            Console.WriteLine("\nUndoing the previous command now.");
            invoker.UndoCommand();           

            Console.WriteLine("\n**Starting the game again.Then stopping it and undoing the stop operation.**");
            invoker.SetCommand(gameStartCommand);
            invoker.ExecuteCommand();
            //Stop command to finish the game
            invoker.SetCommand(gameStopCommand);
            invoker.ExecuteCommand();
            //Performing undo operation
            Console.WriteLine("\nUndoing the previous command now.");
            invoker.UndoCommand();


            //#region OPTIONAL FOR YOU
            ////Doing the same series of steps for another game
            //Console.WriteLine("\nPlaying another game now.(Optional for you)");

            //gameName = new Game("Soccer");
            ////Command to start the game
            //gameStartCommand = new GameStartCommand(gameName);
            ////Command to stop the game
            //gameStopCommand = new GameStopCommand(gameName);

            ////Starting the game
            //invoker.SetCommand(gameStartCommand);
            //invoker.ExecuteCommand();

            ////Stopping the game
            //invoker.SetCommand(gameStopCommand);
            //invoker.ExecuteCommand();

            ////Performing undo operation
            //Console.WriteLine("Undoing the previous command now.");
            //invoker.UndoCommand();
            //#endregion

            Console.ReadKey();
        }
    }
}
