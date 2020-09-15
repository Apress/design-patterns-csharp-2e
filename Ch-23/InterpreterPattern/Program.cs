using System;
using System.Collections.Generic;

namespace InterpreterPattern
{
    public class Context
    {
        private string input;
        public string Input {
            get
            {
                return input;
            }
        }
        public string Output { get; set; }
        
        // The constructor
        public Context(string input)
        {
            this.input = input;
        }       
       
    }
    // The abstract class. It will hold the common code
    abstract class InputExpression
    {
        public abstract void Interpret(Context context);
        public string GetWord(string str)
        {
           
            switch (str)
            {
                case "1":
                    return "One";                  
                case "2":
                    return "Two";                   
                case "3":
                    return "Three";                   
                case "4":
                    return "Four";                 
                case "5":
                    return "Five";                   
                case "6":
                    return "Six";                 
                case "7":
                    return "Seven";                   
                case "8":
                    return "Eight";                   
                case "9":
                    return "Nine";                
                case "0":
                    return "Zero";                
                default:
                    return "*";                    
            }
        }
    }
    /// <summary>
    /// HundredExpression class
    /// </summary>
    class HundredExpression : InputExpression
    {
        public override void Interpret(Context context)
        {
            string hundreds = context.Input.Substring(0,1);
            context.Output += GetWord(hundreds) + " hundred(s) ";
        }
    }
    /// <summary>
    /// TensExpression class
    /// </summary>
    class TensExpression : InputExpression
    {
        public override void Interpret(Context context)
        {
            string tens = context.Input.Substring(1,1);
            context.Output += GetWord(tens) + " ten(s) ";
        }
    }
    /// <summary>
    /// UnitExpression class
    /// </summary>
    class UnitExpression : InputExpression
    {
        public override void Interpret(Context context)
        {
            string units = context.Input.Substring(2, 1);
            context.Output += "and "+GetWord(units);           
        }
    }

    /// <summary>
    /// Client Class
    /// </summary>
    class Client
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("***Interpreter Pattern Demonstation-1.***\n");
            Console.WriteLine(" It will validate first three digit of a valid number.");
            string inputString="789";
            EvaluateInputWithContext(inputString);
            inputString = "456";
            EvaluateInputWithContext(inputString);
            inputString = "123";
            EvaluateInputWithContext(inputString);
            inputString = "075";
            EvaluateInputWithContext(inputString);
            inputString = "Ku79";//invalid input
            EvaluateInputWithContext(inputString);

            Console.ReadLine();
        }
        public static void EvaluateInputWithContext(string inputString)
        {
            Context context = new Context(inputString);
            //Building the parse tree
            List<InputExpression> expTree = new List<InputExpression>();
            expTree.Add(new HundredExpression());
            expTree.Add(new TensExpression());
            expTree.Add(new UnitExpression());
            // Interpret the input
            foreach (InputExpression inputExp in expTree)
            {
                inputExp.Interpret(context);
            }
            /*
             The presense of * in Output tells that
             its not a digit i.e.it is not in 0-9
            */
            if (!context.Output.Contains("*"))
                Console.WriteLine($"{context.Input} is interpreted as {context.Output}");
            else
            {
                Console.WriteLine($"{context.Input} is not a valid input.");
            }
        }
    }
}
