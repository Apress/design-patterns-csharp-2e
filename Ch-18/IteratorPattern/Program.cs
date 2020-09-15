using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorPattern
{
    #region Iterator
    public interface IIterator
    {
        //Reset to first element
        void First();
        //Get next element
        string Next();
        //End of collection check
        bool IsCollectionEnds();
        //Retrieve Current Item
        string CurrentItem();
    }

    /// <summary>
    ///  ScienceIterator
    /// </summary>
    public class ScienceIterator : IIterator
    {
        private LinkedList<string> Subjects;
        private int position;

        public ScienceIterator(LinkedList<string> subjects)
        {
            this.Subjects = subjects;
            position = 0;
        }

        public void First()
        {
            position = 0;
        }

        public string Next()
        {
            return Subjects.ElementAt(position++);
        }

        public bool IsCollectionEnds()
        {
            if (position < Subjects.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string CurrentItem()
        {
            return Subjects.ElementAt(position);
        }
    }
    /// <summary>
    ///  ArtsIterator
    /// </summary>
    public class ArtsIterator : IIterator
    {
        private string[] Subjects;
        private int position;
        public ArtsIterator(string[] subjects)
        {
            this.Subjects = subjects;
            position = 0;
        }
        public void First()
        {
            position = 0;
        }

        public string Next()
        {
            //Console.WriteLine("Currently pointing to the subject: "+ this.CurrentItem());
            return Subjects[position++];
        }

        public bool IsCollectionEnds()
        {
            if (position >= Subjects.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string CurrentItem()
        {
            return Subjects[position];
        }
    }
    #endregion

    #region Aggregate

    public interface ISubjects
    {
        IIterator CreateIterator();
    }
    public class Science : ISubjects
    {
        private LinkedList<string> Subjects;

        public Science()
        {
            Subjects = new LinkedList<string>();
            Subjects.AddFirst("Mathematics");
            Subjects.AddFirst("Computer Science");
            Subjects.AddFirst("Physics");
            Subjects.AddFirst("Electronics");
        }

        public IIterator CreateIterator()
        {
            return new ScienceIterator(Subjects);
        }
    }
    public class Arts : ISubjects
    {
        private string[] Subjects;

        public Arts()
        {
            Subjects = new[] { "English", "History", "Geography", "Psychology" };
        }

        public IIterator CreateIterator()
        {
            return new ArtsIterator(Subjects);
        }
    }
    #endregion

    /// <summary>
    /// Client code
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {

            Console.WriteLine("***Iterator Pattern Demonstration.***");
            //For Science
            ISubjects subjects= new Science();
            IIterator iterator = subjects.CreateIterator();
            Console.WriteLine("\nScience subjects :");
            Print(iterator);

            //For Arts
            subjects = new Arts();            
            iterator = subjects.CreateIterator();
            Console.WriteLine("\nArts subjects :");
            Print(iterator);

            Console.ReadLine();
        }
        public static void Print(IIterator iterator)
        {
            while (!iterator.IsCollectionEnds())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }

}
